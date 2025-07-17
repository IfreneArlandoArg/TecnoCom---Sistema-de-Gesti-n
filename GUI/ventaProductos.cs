using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using BE;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;




namespace GUI
{
    public partial class ventaProductos : Form, IIdiomaObserver
    {
        public ventaProductos()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLCliente bllCliente = new BLLCliente();
        BLLProducto bLLProducto = new BLLProducto();
        BLLFactura bLLFactura = new BLLFactura();
        BEFactura beFactura = new BEFactura();

        public void ActualizarIdioma(Idioma idioma)
        {
            this.Text = Traductor.Instancia.Traducir(this.Name);
            TraducirControles(this.Controls);
        }

        private void TraducirControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {

                if (!string.IsNullOrEmpty(control.Name) && !(control is TextBox))
                {
                    string textoTraducido = Traductor.Instancia.Traducir(control.Name);
                    if (!string.IsNullOrEmpty(textoTraducido))
                        control.Text = textoTraducido;
                }


                if (control.HasChildren)
                    TraducirControles(control.Controls);

                if (control is TextBox)
                {
                    control.Text = String.Empty;
                }

            }

            numericUpDown2.Value = 1;

        }

        void hideComandosRegistrarCliente()
        {
            gbRegistrar.Visible = false;
        }
        void showComandosRegistrarCliente()
        {
            gbRegistrar.Visible = true;
        }

        

        void mostrar(DataGridView dtgv, object pO) 
        {
            dtgv.DataSource = null;
            dtgv.DataSource = pO;
        }

        void mostrarProductosSeleccionados(List<FacturaItem> pO)
        {
            lstBProductosSeleccionados.DataSource = null;
            lstBProductosSeleccionados.DataSource = pO;

            UpdateLabelTotal();
        }

        void mostrarProductos() 
        {
            mostrar(dtgvProductos, bLLProducto.ListarProductosConStock());
        }

        void UpdateLabelTotal() 
        {
            string[]partes = lblTotalPago.Text.Split(':');


            lblTotalPago.Text = $"{partes[0]}: {beFactura.Total} AR$";
        }

        private void ventaProductos_Load(object sender, EventArgs e)
        {
            try
            {
               mostrarProductos();
                hideComandosRegistrarCliente();

                UpdateLabelTotal();

                ActualizarIdioma(Traductor.Instancia.IdiomaActual);

                numericUpDown2.Value = 1;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ventaProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Traductor.Instancia.Desuscribir(this);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvProductos.SelectedRows.Count == 0)
                    throw new Exception("Seleccioné un producto...");

                if (numericUpDown2.Value <= 0)
                    throw new Exception("Cantidad de productos debe ser mayor a 0...");


                BEProducto ProductoTmp = dtgvProductos.CurrentRow.DataBoundItem as BEProducto;
                int pCantidad = (int)numericUpDown2.Value;

                
                FacturaItem facturaItem = new FacturaItem
                {
                    Producto = ProductoTmp,
                    Cantidad = pCantidad
                };

                beFactura.AgregarProducto(facturaItem);

                mostrarProductosSeleccionados(beFactura.ListaProductos);

                
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllCliente.EncontrarCliente((int)numericUpDown1.Value).Count == 0 )
                    throw new Exception("Usuario no registrado..." );

                mostrar(dtgvCliente, bllCliente.EncontrarCliente((int)numericUpDown1.Value));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void chBRegistrarNuevoCliente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chBRegistrarNuevoCliente.Checked) 
                {
                    showComandosRegistrarCliente();
                }
                else 
                { 
                  hideComandosRegistrarCliente() ;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == string.Empty)
                    throw new Exception("Campo nombre vacio...");
                if (txtApellido.Text == string.Empty)
                    throw new Exception("Campo Apellido vacio...");
                if (txtEmail.Text == string.Empty)
                    throw new Exception("Campo email vacio...");





                bllCliente.Alta(new BECliente((int)numDNI.Value, txtNombre.Text, txtApellido.Text, txtEmail.Text));

                
                
                mostrar(dtgvCliente, bllCliente.EncontrarCliente((int)numericUpDown1.Value));

                hideComandosRegistrarCliente();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBProductosSeleccionados.SelectedItems.Count == 0)
                    throw new Exception("Seleccioné un producto...en la lista de productos... ");

                if (numericUpDown2.Value <= 0)
                    throw new Exception("Cantidad de productos debe ser mayor a 0...");

                
                FacturaItem facturaItem = lstBProductosSeleccionados.SelectedItem as FacturaItem;

                int Cantidad = (int)numericUpDown2.Value;


                if (Cantidad > facturaItem.Cantidad)
                    throw new Exception($"{Cantidad}  es mayor qué {facturaItem.Cantidad} {facturaItem.Producto.Nombre}");

                
                

                
                beFactura.SacarProducto(facturaItem, (int)numericUpDown2.Value);

                mostrarProductosSeleccionados(beFactura.ListaProductos);

                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvCliente.SelectedRows.Count == 0)
                    throw new Exception("Selecciné o agregué Cliente...");

                if (beFactura.Total == 0)
                    throw new Exception("El total es 0.\nPor favor agregué productos");

                beFactura.Cliente = dtgvCliente.CurrentRow.DataBoundItem as BECliente;

                var paymentForm = new PaymentForm(beFactura.Total);

                var result = paymentForm.ShowDialog();
                bool paymentSuccess = paymentForm.IsPaymentSuccessful;

                if (!paymentSuccess)
                {
                    throw new Exception("Payment Failed!");
                }


                beFactura.Estado = EnumEstado.Emitida;
                
                bLLFactura.Alta(beFactura);

                //DialogResult dialogResult = MessageBox.Show("¿Quiere descargar la factura?", "Descargar PDF Factura", MessageBoxButtons.YesNo);

                //if (dialogResult == DialogResult.Yes) 
                //{
                //    GenerarFacturaSimple(beFactura.ListaProductos, beFactura.Total, $"{beFactura.Cliente.Apellido}, {beFactura.Cliente.Nombre} ");
                //}


                MostrarDocumento(GenerarResumenVenta(beFactura));





                beFactura = new BEFactura();

                mostrarProductos();
                mostrarProductosSeleccionados(beFactura.ListaProductos);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private string GenerarResumenVenta(BEFactura pFactura)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("======= TecnoCom S.R.L. =======");
            
            
            sb.AppendLine("---------------------------------");
            
            sb.AppendLine($"Cliente: {pFactura.Cliente}");
            sb.AppendLine($"DNI: {pFactura.Cliente.DNI}");
            sb.AppendLine($"{pFactura.Fecha}");


            sb.AppendLine("---------------------------------");

            sb.AppendLine("----------- Detalles ------------");

            foreach (var detalle in pFactura.ListaProductos)
            {
                sb.AppendLine($"• {detalle}");
            }

            sb.AppendLine("---------------------------------");
            sb.AppendLine($"TOTAL: {pFactura.Total:C}"); 

            return sb.ToString();
        }


        //private void MostrarDocumento(string contenido)
        //{
        //    Form vistaDocumento = new Form();
        //    vistaDocumento.Text = "Vista Previa del Documento";
        //    vistaDocumento.Size = new Size(500, 600);
        //    vistaDocumento.StartPosition = FormStartPosition.CenterParent;
        //    vistaDocumento.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    vistaDocumento.MaximizeBox = false;
        //    vistaDocumento.MinimizeBox = false;

        //    RichTextBox richText = new RichTextBox();
        //    richText.Dock = DockStyle.Fill;
        //    richText.ReadOnly = true;
        //    richText.Font = new System.Drawing.Font("Consolas", 11, FontStyle.Regular); 
        //    richText.Text = contenido;

        //    vistaDocumento.Controls.Add(richText);

        //    vistaDocumento.ShowDialog();
        //}


        private void MostrarDocumento(string contenido)
        {
            Form vistaDocumento = new Form();
            vistaDocumento.Text = "Vista Previa del Documento";
            vistaDocumento.Size = new Size(500, 600);
            vistaDocumento.StartPosition = FormStartPosition.CenterParent;
            vistaDocumento.FormBorderStyle = FormBorderStyle.FixedDialog;
            vistaDocumento.MaximizeBox = false;
            vistaDocumento.MinimizeBox = false;
            vistaDocumento.Icon = new Icon(Application.StartupPath + @"\img\TC_icon.ico");


            RichTextBox richText = new RichTextBox();
            richText.Dock = DockStyle.Fill;
            richText.ReadOnly = true;
            richText.Font = new System.Drawing.Font("Consolas", 11, FontStyle.Regular);
            richText.Text = contenido;

            
            Button btnDescargarPDF = new Button();
            btnDescargarPDF.Text = "Descargar PDF";
            btnDescargarPDF.Height = 40;
            btnDescargarPDF.Dock = DockStyle.Bottom;
            btnDescargarPDF.MouseHover += (sender, e) =>
            {
                btnDescargarPDF.BackColor = Color.LightGray;
                btnDescargarPDF.Cursor = Cursors.Hand;

            };
            btnDescargarPDF.Click += (sender, e) =>
            {
                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string carpetaPrincipal = Path.Combine(rutaEscritorio, "FacturasTecnoCom");

                
                if (!Directory.Exists(carpetaPrincipal))
                {
                    Directory.CreateDirectory(carpetaPrincipal);
                }

                
                string carpetaFacturas = Path.Combine(carpetaPrincipal, "Facturas");
                if (!Directory.Exists(carpetaFacturas))
                {
                    Directory.CreateDirectory(carpetaFacturas);
                }

                
                string carpetaEntregados = Path.Combine(carpetaPrincipal, "Facturas_Entregados");
                if (!Directory.Exists(carpetaEntregados))
                {
                    Directory.CreateDirectory(carpetaEntregados);
                }

                string rutaArchivoPDF = Path.Combine(carpetaFacturas, $"FacturaCliente{DateTime.Now:yyyyMMddHHmmss}.pdf");

                
                GuardarTextoComoPDF(contenido, rutaArchivoPDF);

                GenerarFacturaPDF(beFactura.Cliente.Nombre, beFactura.Cliente.Apellido, beFactura.Cliente.DNI.ToString(), beFactura.ListaProductos, carpetaEntregados);

            };

            
            vistaDocumento.Controls.Add(richText);
            vistaDocumento.Controls.Add(btnDescargarPDF);

            vistaDocumento.ShowDialog();
        }






        private void GuardarTextoComoPDF(string contenido, string rutaArchivo)
    {
        try
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var fuente = FontFactory.GetFont(FontFactory.COURIER, 12);
                doc.Add(new Paragraph(contenido, fuente));

                doc.Close();
                writer.Close();
            }

            MessageBox.Show("PDF generado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al generar el PDF:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


        private void GenerarFacturaPDF(string nombre, string apellido, string dni, List<FacturaItem> facturaItems, string subDirectory)
        {

            string rutaArchivo = Path.Combine(subDirectory, $"Factura_{apellido}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
            doc.Open();

            // Colores y estilos
            var colorEncabezado = new BaseColor(0, 87, 146);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, colorEncabezado);
            var fuenteBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            // Título
            Paragraph titulo = new Paragraph("TecnoCom - Factura Electrónica", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20;
            doc.Add(titulo);

            // Datos del cliente
            doc.Add(new Paragraph($"Cliente : {nombre}, {apellido}", fuenteNormal));
            
            doc.Add(new Paragraph($"DNI: {dni}", fuenteNormal));
            doc.Add(new Paragraph($"{beFactura.Fecha}", fuenteNormal));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            // Tabla de productos
            PdfPTable tabla = new PdfPTable(4);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 40, 20, 20, 20 });

            // Encabezado tabla
            string[] columnas = { "Producto", "Precio Unitario", "Cantidad", "Subtotal" };
            foreach (string col in columnas)
            {
                PdfPCell celda = new PdfPCell(new Phrase(col, fuenteBold));
                celda.BackgroundColor = colorEncabezado;
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Padding = 5;
                celda.Phrase.Font.Color = BaseColor.WHITE;
                tabla.AddCell(celda);
            }

            // Cuerpo tabla
            

            foreach (var prod in facturaItems)
            {
                tabla.AddCell(new PdfPCell(new Phrase(prod.Producto.Nombre, fuenteNormal)));

                tabla.AddCell(new PdfPCell(new Phrase($"{prod.Producto.Precio:C}", fuenteNormal))
                { HorizontalAlignment = Element.ALIGN_CENTER });

                tabla.AddCell(new PdfPCell(new Phrase(prod.Cantidad.ToString(), fuenteNormal))
                { HorizontalAlignment = Element.ALIGN_CENTER });

                tabla.AddCell(new PdfPCell(new Phrase($"{prod.TotalPrecioItem():C}", fuenteNormal))
                { HorizontalAlignment = Element.ALIGN_CENTER });

                
            }


            tabla.SpacingAfter = 15;
            doc.Add(tabla);

            
            // Total
            Paragraph totalParrafo = new Paragraph($"TOTAL: {beFactura.Total:C}", fuenteBold);
            totalParrafo.Alignment = Element.ALIGN_RIGHT;
            totalParrafo.Font.Color = BaseColor.BLACK;
            doc.Add(totalParrafo);



            // Footer
            
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            Paragraph footer = new Paragraph($"Gracias por su compra - TecnoCom © {DateTime.Now:dd/MM/yyyy}", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9, BaseColor.GRAY));
            footer.Alignment = Element.ALIGN_CENTER;
            
            doc.Add(footer);

            doc.Close();

            MessageBox.Show("Factura PDF generada correctamente.", "Éxito");
        }



    }
}
