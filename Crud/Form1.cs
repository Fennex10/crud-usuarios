using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly Repositorio _repo = new Repositorio();
        private Usuario _usuarioSeleccionado;

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = _repo.GetAll();
            dgvUsuarios.Columns["Id"].Visible = false; // Ocultar columna ID
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            var frm = new frmNuevoUsuario();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _repo.Add(frm.Usuario);
                CargarUsuarios();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            _usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
            var frm = new frmNuevoUsuario(_usuarioSeleccionado);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _repo.Update(frm.Usuario);
                CargarUsuarios();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            _usuarioSeleccionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Eliminar a {_usuarioSeleccionado.Nombre}?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repo.Delete(_usuarioSeleccionado.Id);
                CargarUsuarios();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNuevoUsuario frmNuevo = new frmNuevoUsuario();

            if (frmNuevo.ShowDialog() == DialogResult.OK)
            {
                _repo.Add(frmNuevo.Usuario);
                CargarUsuarios();
            }
        }
    }
}