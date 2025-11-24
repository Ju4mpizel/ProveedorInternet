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

            // Configuración visual
            if (dgv_usuarios.Columns.Contains("IdUsuario"))
            {
                dgv_usuarios.Columns["IdUsuario"].Visible = false;
            }
        }

        private void LimpiarCampos()
        {
            // Limpia los TextBoxes visibles
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
            // Asegura que el clic no sea en el encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgv_usuarios.Rows[e.RowIndex];

                // CRUCIAL: Cargar el ID al campo oculto para el UPDATE
                tb_idusuario.Text = fila.Cells["IdUsuario"].Value.ToString();

                // Cargar el resto de campos para edición
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

            // --- 2. DETERMINAR MODO (CREATE o UPDATE) ---
            // Si el campo oculto tiene un ID, es un UPDATE.
            int.TryParse(tb_idusuario.Text, out idUsuario);

            try
            {
                // 3. Crear el objeto Usuario con los datos del formulario
                Usuario usuario = new Usuario
                {
                    IdUsuario = idUsuario, // Será 0 si es CREATE, o el ID real si es UPDATE
                    Nombre = tb_nombre.Text,
                    Apellido = tb_apellido.Text,
                    Carnet = tb_carnet.Text,
                    Telefono = tb_telefono.Text,
                    Email = tb_email.Text,
                    Direccion = tb_direccion.Text
                };

                // 4. Lógica de Decisión
                if (idUsuario == 0)
                {
                    // CREATE
                    resultado = dal.GuardarUsuario(usuario);
                }
                else
                {
                    // UPDATE
                    resultado = dal.ActualizarUsuario(usuario);
                }

                // 5. Manejar el resultado
                if (resultado > 0)
                {
                    MessageBox.Show((idUsuario == 0 ? "Usuario guardado" : "Usuario actualizado") + " exitosamente.", "Éxito");
                    CargarUsuariosEnDataGridView();
                    LimpiarCampos();
                }
                else if (idUsuario != 0 && resultado == 0)
                {
                    // Caso de UPDATE que no afectó filas (ej: el usuario no existía o no se cambió nada)
                    MessageBox.Show("La operación no modificó ningún registro, verifique si los datos son iguales o si ocurrió un error.", "Advertencia");
                }
                // Los errores de SQL y duplicidad (1062) se manejan dentro de UsuarioDAL
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al procesar los datos: " + ex.Message, "Error General");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // 1. Obtener el ID del TextBox oculto
            int idUsuarioAEliminar = 0;
            int.TryParse(tb_idusuario.Text, out idUsuarioAEliminar);

            // Verificación de selección
            if (idUsuarioAEliminar == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario de la tabla para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mensaje de Confirmación
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
                    CargarUsuariosEnDataGridView(); // Refrescar la tabla
                    LimpiarCampos();             // Limpiar TextBoxes
                }
                // Los errores de restricción (ej. 1451) se manejan en UsuarioDAL
            }
        }

        private void btn_visualizarusuarios_Click(object sender, EventArgs e)
        {
            CargarUsuariosEnDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Crear instancia del destino
            FormGestionPlanes formPlanes = new FormGestionPlanes();
            formPlanes.StartPosition = FormStartPosition.CenterScreen;
            // 2. Mostrar el destino
            formPlanes.Show();

            // 3. Cerrar el formulario actual
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
