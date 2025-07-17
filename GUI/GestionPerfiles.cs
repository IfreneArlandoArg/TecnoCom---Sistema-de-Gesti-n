using BE;
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

namespace GUI
{
    public partial class GestionPerfiles : Form, IIdiomaObserver
    {
        public GestionPerfiles()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }

        BLLComponente bllComponente = new BLLComponente();

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
        }

        private void MostrarJerarquia(TreeView ptreeView)
        {

            List<Componente> jerarquia = bllComponente.ObtenerJerarquia();

            ptreeView.Nodes.Clear();

            foreach (Componente c in jerarquia)
            {
                TreeNode nodo = CrearNodo(c);
                ptreeView.Nodes.Add(nodo);
            }

            ptreeView.ExpandAll();
        }

        private TreeNode CrearNodo(Componente c)
        {
            TreeNode nodo = new TreeNode(c.Nombre)
            {
                Tag = c
            };

            if (c.Hijos != null)
            {
                foreach (var hijo in c.Hijos)
                {
                    nodo.Nodes.Add(CrearNodo(hijo));
                }
            }

            return nodo;
        }


        void mostrarLstBox(ListBox lstB, Object pO) 
        {
            lstB.DataSource = null;
            lstB.DataSource = pO;



        }

       void MostrarJerarquia() 
        {
            MostrarJerarquia(treeView1);
            mostrarLstBox(listBox1, bllComponente.Listar());
        }
        
        private void GestionPerfiles_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarIdioma(Traductor.Instancia.IdiomaActual);
                MostrarJerarquia();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error");
            }

        }

        private void GestionPerfiles_FormClosed(object sender, FormClosedEventArgs e)
        {
            Traductor.Instancia.Desuscribir(this);

        }



        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {


                string nombre = Prompt("Ingrese nombre del permiso:");
               if (string.IsNullOrWhiteSpace(nombre)) 
                    throw new Exception("");

                 bool esPatente = MessageBox.Show("¿Es una Patente?", "Tipo", MessageBoxButtons.YesNo) == DialogResult.Yes;

                Componente nuevo;
                 if (esPatente)
                  nuevo = new Patente(0, nombre);
                 else
                nuevo = new Familia(0, nombre);

                int? idPadre = null;
                if (treeView1.SelectedNode != null)
                   idPadre = (treeView1.SelectedNode.Tag as Componente).Id ;

                bllComponente.Alta(nuevo, idPadre);
                MostrarJerarquia();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null) 
                    throw new Exception("Seleccioné patente(s) a dar de baja..."); ;

               int id = (treeView1.SelectedNode.Tag as Componente).Id;
               
               if (MessageBox.Show("¿Eliminar este permiso?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                 
                    bllComponente.Baja(id);
                 
                    MostrarJerarquia();
               }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null) return;

                int id = (treeView1.SelectedNode.Tag as Componente).Id;
                string nombreNuevo = Prompt("Nuevo nombre:", treeView1.SelectedNode.Text);
                if (string.IsNullOrWhiteSpace(nombreNuevo)) return;

                Componente modificado = new Familia(id, nombreNuevo); // asume familia por defecto
                bllComponente.Modificar(modificado);
                MostrarJerarquia();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error");
            }
        }

        public static string Prompt(string mensaje, string valorInicial = "")
        {
            Form prompt = new Form() { Width = 400, Height = 150, Text = mensaje };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = mensaje, Width = 340 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = valorInicial };
            Button confirmation = new Button() { Text = "OK", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            // Agregá esto antes de mostrar el prompt
            prompt.Icon = new Icon(Application.StartupPath + @"\img\TC_icon.ico");


            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem == null || treeView1.SelectedNode == null)
                    throw new Exception("Debe seleccionar un permiso y una familia para asignar.");

                

                Componente componenteSeleccionado = (Componente)listBox1.SelectedItem;
                Componente componentePadre = (Componente)treeView1.SelectedNode.Tag;

                
                if (componentePadre is Patente)
                    throw new Exception("No se puede asignar un permiso a una patente. Solo las familias pueden tener hijos.");

                if (componentePadre.Validar(componenteSeleccionado)) 
                    throw new Exception($"{componentePadre.Nombre} ya tiene {componenteSeleccionado.Nombre}");

                bllComponente.AsignarHijo(componentePadre.Id, componenteSeleccionado.Id);
              

                MostrarJerarquia();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            try
            {

                if (listBox1.SelectedItem == null || treeView1.SelectedNode == null)
                    throw new Exception("Debe seleccionar un permiso y una familia para asignar.");

                Componente componenteSeleccionado = (Componente)listBox1.SelectedItem;
                Componente componentePadre = (Componente)treeView1.SelectedNode.Tag;


                if (componentePadre is Patente)
                    throw new Exception("No se puede sacar una patente/familia  a otra patente. ");

                bllComponente.DesasignarHijo(componentePadre.Id, componenteSeleccionado.Id);
               

                MostrarJerarquia();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error");
            }

        }
    }
}
