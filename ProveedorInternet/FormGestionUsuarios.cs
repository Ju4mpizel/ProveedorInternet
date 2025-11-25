using MySql.Data.MySqlClient;

namespace ProveedorInternet
{
    public partial class FormGestionUsuarios : Form
    {
        public FormGestionUsuarios()
        {
            InitializeComponent();
            tb_idusuario.Visible = false;
            CargarUsuariosEnDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CargarUsuariosEnDataGridView()
        {
            UsuarioDAL dal = new UsuarioDAL();
            dgv_usuarios.DataSource = dal.ObtenerUsuarios();
            if (dgv_usuarios.Columns.Contains("IdUsuario"))
            {
                dgv_usuarios.Columns["IdUsuario"].Visible = false;
            }
        }

        private void LimpiarCampos()
        {
            tb_nombre.Text = string.Empty;
            tb_apellido.Text = string.Empty;
            tb_carnet.Text = string.Empty;
            tb_telefono.Text = string.Empty;
            tb_email.Text = string.Empty;
            tb_direccion.Text = string.Empty;
            tb_idusuario.Text = string.Empty;
        }

        private void dgv_usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgv_usuarios.Rows[e.RowIndex];
                tb_idusuario.Text = fila.Cells["IdUsuario"].Value.ToString();
                tb_nombre.Text = fila.Cells["Nombre"].Value.ToString();
                tb_apellido.Text = fila.Cells["Apellido"].Value.ToString();
                tb_carnet.Text = fila.Cells["Carnet"].Value.ToString();
                tb_telefono.Text = fila.Cells["Telefono"].Value.ToString();
                tb_email.Text = fila.Cells["Email"].Value.ToString();
                tb_direccion.Text = fila.Cells["Direccion"].Value.ToString();
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            UsuarioDAL dal = new UsuarioDAL();
            int resultado = 0;
            int idUsuario = 0;

            // --- 1. VALIDACIÓN BÁSICA ---
            if (string.IsNullOrWhiteSpace(tb_nombre.Text) ||
                string.IsNullOrWhiteSpace(tb_apellido.Text) ||
                string.IsNullOrWhiteSpace(tb_carnet.Text) ||
                string.IsNullOrWhiteSpace(tb_email.Text))
            {
                MessageBox.Show("Los campos Nombre, Apellido, Carnet y Email son obligatorios.", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int.TryParse(tb_idusuario.Text, out idUsuario);

            try
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario = idUsuario,
                    Nombre = tb_nombre.Text,
                    Apellido = tb_apellido.Text,
                    Carnet = tb_carnet.Text,
                    Telefono = tb_telefono.Text,
                    Email = tb_email.Text,
                    Direccion = tb_direccion.Text
                };
                if (idUsuario == 0)
                {
                    resultado = dal.GuardarUsuario(usuario);
                }
                else
                {
                    resultado = dal.ActualizarUsuario(usuario);
                }
                if (resultado > 0)
                {
                    MessageBox.Show((idUsuario == 0 ? "Usuario guardado" : "Usuario actualizado") + " exitosamente.", "Éxito");
                    CargarUsuariosEnDataGridView();
                    LimpiarCampos();
                }
                else if (idUsuario != 0 && resultado == 0)
                {
                    MessageBox.Show("La operación no modificó ningún registro, verifique si los datos son iguales o si ocurrió un error.", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al procesar los datos: " + ex.Message, "Error General");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            int idUsuarioAEliminar = 0;
            int.TryParse(tb_idusuario.Text, out idUsuarioAEliminar);
            if (idUsuarioAEliminar == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro de que desea eliminar al usuario con ID {idUsuarioAEliminar}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                UsuarioDAL dal = new UsuarioDAL();
                int resultado = dal.EliminarUsuario(idUsuarioAEliminar);

                if (resultado > 0)
                {
                    MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuariosEnDataGridView(); 
                    LimpiarCampos();            
                }
            }
        }

        private void btn_visualizarusuarios_Click(object sender, EventArgs e)
        {
            CargarUsuariosEnDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormGestionPlanes formPlanes = new FormGestionPlanes();
            formPlanes.StartPosition = FormStartPosition.CenterScreen;
            formPlanes.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
