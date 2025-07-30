using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud
{
    public partial class frmNuevoUsuario : Form
    {
        public frmNuevoUsuario()
        {
            InitializeComponent();
            Usuario = new Usuario();
            CargarRoles();
            Text = "Nuevo Usuario"; 
        }

        public Usuario Usuario { get; private set; }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {

        }

        public frmNuevoUsuario(Usuario usuario) : this()
        {
            Usuario = usuario;
            txtNombre.Text = usuario.Nombre;
            txtCorreo.Text = usuario.Correo;
            cmbRol.SelectedItem = usuario.Rol;
            Text = "Editar Usuario";
        }
        private void CargarRoles()
        {
            cmbRol.Items.AddRange(new[] { "Administrador", "Usuario", "Invitado" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Usuario.Nombre = txtNombre.Text;
            Usuario.Correo = txtCorreo.Text;
            Usuario.Rol = cmbRol.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El correo es requerido");
                return false;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rol");
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}