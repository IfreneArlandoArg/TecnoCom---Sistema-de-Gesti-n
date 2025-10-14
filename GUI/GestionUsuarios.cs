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
    public partial class GestionUsuarios : Form, IIdiomaObserver
    {
        public GestionUsuarios()
        {
            InitializeComponent();
            Traductor.Instancia.Suscribir(this);
        }
        
        BLLUsuario bllUsuario = new BLLUsuario();
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
                
                        

                        if (!string.IsNullOrEmpty(control.Name) && !(control is TextBox) && !(control is DateTimePicker))
                        {
                            string textoTraducido = Traductor.Instancia.Traducir(control.Name);
                            if (!string.IsNullOrEmpty(textoTraducido))
                                control.Text = textoTraducido;
                        }


                        if (control.HasChildren && !(control is DateTimePicker))
                            TraducirControles(control.Controls);

                        if (control is TextBox)
                        {
                            control.Text = String.Empty;
                        }
                    

                
                

            }

           

        }


        void mostrarLstBox(ListBox lstB, object pO)
        {
            lstB.DataSource = null;
            lstB.DataSource = pO;
        }


        void mostrar(DataGridView dtgv, object pO) 
        {
            dtgv.DataSource = null;
            dtgv.DataSource = pO;
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

        void mostrarUsuarios()
        {
            mostrar(dtgvUsuarios, bllUsuario.Listar());
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarIdioma(Traductor.Instancia.IdiomaActual);

                mostrarUsuarios();

                mostrarLstBox(listBox1, null);
                lblNombreUsuarioTmp.Text = string.Empty;

                MostrarJerarquia(treeView2);



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GestionUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Traductor.Instancia.Desuscribir(this);

        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                

               
                if(txtApellido.Text == string.Empty)
                    throw new Exception("Campo vacio...");

                if (txtNombre.Text == string.Empty)
                    throw new Exception("Campo vacio...");

                if (txtPassword.Text == string.Empty)
                    throw new Exception("Campo vacio...");

                if (txtEmail.Text == string.Empty)
                    throw new Exception("Campo vacio...");


                

                

                DateTime fecha = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day); 
                    

               
                

                BEUsuario tmpUsuario = new BEUsuario(txtNombre.Text, txtApellido.Text, fecha , txtEmail.Text, Encriptador.HashearConSHA256(txtPassword.Text));

                

                bllUsuario.Alta(tmpUsuario);

                mostrarUsuarios();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvUsuarios.SelectedRows.Count == 0)
                    throw new Exception("Seleccione un usuario a modificar...");

            

                if (txtApellido.Text == string.Empty)
                    throw new Exception("Campo vacio...");

                if (txtNombre.Text == string.Empty)
                    throw new Exception("Campo vacio...");

                if (txtPassword.Text == string.Empty)
                    throw new Exception("Campo vacio...");

                if (txtEmail.Text == string.Empty)
                    throw new Exception("Campo vacio...");


                



                DateTime fecha = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);





                BEUsuario tmpUsuario = dtgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                tmpUsuario.Nombre = txtNombre.Text;
                tmpUsuario.Apellido = txtApellido.Text;
                
                tmpUsuario.Email = txtEmail.Text;
                tmpUsuario.FechaNacimiento = fecha;
                tmpUsuario.PasswordHash = Encriptador.HashearConSHA256(txtPassword.Text);

                bllUsuario.Modificar(tmpUsuario);


                mostrarUsuarios();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvUsuarios.SelectedRows.Count == 0)
                    throw new Exception("Seleccione un usuario a modificar...");

                bllUsuario.Baja(dtgvUsuarios.CurrentRow.DataBoundItem as BEUsuario);

                mostrarUsuarios();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtgvUsuarios.SelectedRows.Count == 0) 
                { 
                    mostrarLstBox(listBox1, null);
                    lblNombreUsuarioTmp.Text = string.Empty;


                }
                else 
                {
                    BEUsuario tmp = dtgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                   mostrarLstBox(listBox1, tmp.Permisos);
                    lblNombreUsuarioTmp.Text = $"{tmp.Apellido}, {tmp.Nombre}";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvUsuarios.SelectedRows.Count == 0)
                    throw new Exception("Seleccione un usuario...");

                if (treeView2.SelectedNode == null)
                    throw new Exception("Seleccione un permiso/familia...");


                BEUsuario tmpUsuario = dtgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                Componente tmpComponente = treeView2.SelectedNode.Tag as Componente;


                


                foreach (Componente c in tmpUsuario.Permisos) 
                {
                   if(c.Id == tmpComponente.Id)
                        throw new Exception($"El usuario {tmpUsuario.Apellido}, {tmpUsuario.Nombre} ya tiene asignado {tmpComponente}.");

                    if (c.Validar(tmpComponente))
                        throw new Exception($"El usuario {tmpUsuario.Apellido}, {tmpUsuario.Nombre} ya tiene asignado el permiso/familia {tmpComponente}.");



                }




                bllUsuario.AltaPermisoUsuario(tmpUsuario.IdUsuario, tmpComponente.Id);

                mostrarUsuarios();

                if(dtgvUsuarios.SelectedRows.Count > 0)
                mostrarLstBox(listBox1, (dtgvUsuarios.CurrentRow.DataBoundItem as BEUsuario).Permisos);




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvUsuarios.SelectedRows.Count == 0)
                    throw new Exception("Seleccione un usuario...");

                if (listBox1.SelectedItem == null)
                    throw new Exception("Seleccione un permiso/familia...");

                BEUsuario tmpUsuario = dtgvUsuarios.CurrentRow.DataBoundItem as BEUsuario;

                Componente tmpComponente = listBox1.SelectedItem as Componente;

                bllUsuario.BajaPermisoUsuario(tmpUsuario.IdUsuario, tmpComponente.Id);

                mostrarUsuarios();

                if (dtgvUsuarios.SelectedRows.Count > 0)
                    mostrarLstBox(listBox1, (dtgvUsuarios.CurrentRow.DataBoundItem as BEUsuario).Permisos);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
