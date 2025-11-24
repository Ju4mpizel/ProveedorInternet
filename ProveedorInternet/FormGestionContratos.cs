using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProveedorInternet
{
    public partial class FormGestionContratos : Form
    {
        public FormGestionContratos()
        {
            InitializeComponent();
            CargarDatosEnComboboxes();
            cb_usuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_plan.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarContratosEnDataGridView();
        }
        private void CargarContratosEnDataGridView()
        {
            ContratoDAL dal = new ContratoDAL();

            // 1. Obtener la lista de Contratos (que incluye Nombres de Usuario y Plan)
            dgvContratos.DataSource = dal.ObtenerContratos();

            // 2. Configuración visual (Opcional pero recomendado para ocultar IDs)
            if (dgvContratos.Columns.Contains("IdContrato"))
            {
                dgvContratos.Columns["IdContrato"].Visible = false;
            }
            if (dgvContratos.Columns.Contains("IdUsuarioFK")) // Oculta la clave foránea del usuario
            {
                dgvContratos.Columns["IdUsuarioFK"].Visible = false;
            }
            if (dgvContratos.Columns.Contains("IdPlanFK")) // Oculta la clave foránea del plan
            {
                dgvContratos.Columns["IdPlanFK"].Visible = false;
            }

            // Opcional: Cambiar títulos
            if (dgvContratos.Columns.Contains("NombreUsuario"))
            {
                dgvContratos.Columns["NombreUsuario"].HeaderText = "Cliente";
            }
            if (dgvContratos.Columns.Contains("NombrePlan"))
            {
                dgvContratos.Columns["NombrePlan"].HeaderText = "Plan Contratado";
            }
            // ... y el resto de los encabezados
        }
        private void CargarDatosEnComboboxes()
        {
            // 1. CARGAR USUARIOS (CLIENTES)
            UsuarioDAL usuarioDal = new UsuarioDAL();
            List<Usuario> usuarios = usuarioDal.ObtenerUsuarios();

            // Configuración del ComboBox de Usuarios
            cb_usuario.DataSource = usuarios;
            cb_usuario.DisplayMember = "NombreCompleto"; // Muestra la propiedad 'Nombre' en el ComboBox
            cb_usuario.ValueMember = "IdUsuario"; // El valor interno (el que se guarda) es 'IdUsuario'
            cb_usuario.SelectedIndex = -1; // Deja el ComboBox sin seleccionar nada inicialmente


            // 2. CARGAR PLANES
            PlanDAL planDal = new PlanDAL();
            List<Plan> planes = planDal.ObtenerPlanes();

            // Configuración del ComboBox de Planes
            cb_plan.DataSource = planes;
            cb_plan.DisplayMember = "NombrePlan"; // Muestra la propiedad 'NombrePlan'
            cb_plan.ValueMember = "IdPlan"; // El valor interno (el que se guarda) es 'IdPlan'
            cb_plan.SelectedIndex = -1; // Deja el ComboBox sin seleccionar nada inicialmente
        }

        private void FormGestionContratos_Load(object sender, EventArgs e)
        {

        }
        private void LimpiarCamposContratos()
        {
            tb_direccion.Text = string.Empty;
            cb_plan.Text = string.Empty;
            cb_usuario.Text = string.Empty;
            tb_estado.Text = string.Empty;
            tb_idcontrato.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContratoDAL dal = new ContratoDAL();
            int resultado = 0;
            int idContrato = 0;

            // 1. VALIDACIÓN DE CLAVES FORÁNEAS (ComboBoxes)
            if (cb_usuario.SelectedValue == null || cb_plan.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar un Cliente y un Plan válidos.", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. DETERMINAR MODO (CREATE o UPDATE)
            // Lee el ID del campo oculto. Si falla (está vacío), idContrato será 0 (CREATE).
            int.TryParse(tb_idcontrato.Text, out idContrato);

            try
            {
                // 3. Crear/Llenar el objeto Contrato
                Contrato contrato = new Contrato
                {
                    IdContrato = idContrato,

                    // Lectura de Claves Foráneas: Se obtiene el ID (el ValueMember)
                    IdUsuarioFK = (int)cb_usuario.SelectedValue,
                    IdPlanFK = (int)cb_plan.SelectedValue,

                    // Lectura de otros campos
                    FechaInicio = dtp_fecha.Value,
                    DireccionInstalacion = tb_direccion.Text,
                    EstadoContrato = tb_estado.Text // O el control que uses para el estado
                };

                // 4. Lógica de Decisión y Ejecución
                if (idContrato == 0)
                {
                    // CREATE: Llamada al método de inserción
                    resultado = dal.GuardarContrato(contrato);
                }
                else
                {
                    // UPDATE: Llamada al método de actualización
                    resultado = dal.ActualizarContrato(contrato);
                }

                // 5. Manejar el resultado
                if (resultado > 0)
                {
                    string mensaje = (idContrato == 0 ? "Contrato creado" : "Contrato actualizado") + " exitosamente.";
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarContratosEnDataGridView(); // Refrescar la tabla
                    LimpiarCamposContratos();        // Resetear los controles
                }
                else
                {
                    MessageBox.Show("No se pudo completar la operación. Verifique si la conexión está activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar los datos del contrato: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvContratos.Rows[e.RowIndex];

                // 1. Cargar el ID del Contrato (CRUCIAL para UPDATE/DELETE)
                tb_idcontrato.Text = fila.Cells["IdContrato"].Value.ToString();

                // 2. Cargar los IDs de las FKs a los ComboBoxes (ValueMember)
                // Esto automáticamente selecciona el Nombre/Apellido visible
                cb_usuario.SelectedValue = fila.Cells["IdUsuarioFK"].Value;
                cb_plan.SelectedValue = fila.Cells["IdPlanFK"].Value;

                // 3. Cargar el resto de campos
                dtp_fecha.Value = (DateTime)fila.Cells["FechaInicio"].Value;
                tb_direccion.Text = fila.Cells["DireccionInstalacion"].Value.ToString();
                // Asumiendo que tienes un ComboBox/TextBox para el EstadoContrato:
                tb_estado.Text = fila.Cells["EstadoContrato"].Value.ToString();
            }
        }

        private void btn_EliminarContrato_Click(object sender, EventArgs e)
        {
            int idContratoAEliminar = 0;
            int.TryParse(tb_idcontrato.Text, out idContratoAEliminar);

            if (idContratoAEliminar == 0)
            {
                MessageBox.Show("Selecciona un contrato para eliminar.", "Advertencia");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar este contrato?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                ContratoDAL dal = new ContratoDAL();
                int resultado = dal.EliminarContrato(idContratoAEliminar);

                if (resultado > 0)
                {
                    MessageBox.Show("Contrato eliminado exitosamente.", "Éxito");
                    CargarContratosEnDataGridView();
                    LimpiarCamposContratos();
                }
                // Los errores de SQL se manejan en el DAL
            }
            LimpiarCamposContratos();
        }
    }
}
