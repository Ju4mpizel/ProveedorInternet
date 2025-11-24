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
    public partial class FormGestionPlanes : Form
    {
        public FormGestionPlanes()
        {
            InitializeComponent();
            tb_idplan.Visible = false;
            CargarPlanesEnDataGridView();
        }
        private void FormGestionPlanes_Load(object sender, EventArgs e)
        {

        }

        // Dentro de la clase FormGestionPlanes...


        private void CargarPlanesEnDataGridView()
        {
            // 1. Crear una instancia de la capa de acceso a datos
            PlanDAL dal = new PlanDAL();

            // 2. Llamar al método ObtenerPlanes()
            // Esto recupera la lista desde MySQL

            // 3. Asignar la lista como fuente de datos del DataGridView
            dgvPlanes.DataSource = dal.ObtenerPlanes();

            // Opcional: Ocultar columnas que no son relevantes para el usuario
            if (dgvPlanes.Columns.Contains("IdPlan"))
            {
                dgvPlanes.Columns["IdPlan"].Visible = false;
            }
            // Opcional: Cambiar el título de las columnas
            if (dgvPlanes.Columns.Contains("NombrePlan"))
            {
                dgvPlanes.Columns["NombrePlan"].HeaderText = "Nombre del Plan";
            }
        }
        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Método simple para limpiar los TextBoxes
        private void LimpiarCampos()
        {
            tb_nombre.Text = string.Empty;
            tb_velocidad.Text = string.Empty;
            tb_precio.Text = string.Empty;
            tb_descripcion.Text = string.Empty;
            tb_idplan.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlanDAL dal = new PlanDAL();
            int resultado = 0;
            int idPlan = 0;

            // Intentamos obtener el ID. Si no se puede, idPlan será 0 (lo que indica CREATE)
            int.TryParse(tb_idplan.Text, out idPlan);

            try
            {
                // 1. Capturar Datos
                Plan plan = new Plan
                {
                    IdPlan = idPlan, // El ID será 0 si es CREATE, o el ID real si es UPDATE
                    NombrePlan = tb_nombre.Text,
                    Velocidad = int.Parse(tb_velocidad.Text),
                    Precio = decimal.Parse(tb_precio.Text),
                    Descripcion = tb_descripcion.Text
                };

                // 2. Lógica de Decisión
                if (idPlan == 0)
                {
                    // Es un registro nuevo (CREATE)
                    resultado = dal.GuardarPlan(plan);
                }
                else
                {
                    // Estamos actualizando un registro existente (UPDATE)
                    resultado = dal.ActualizarPlan(plan);
                }

                // 3. Manejar el resultado
                if (resultado > 0)
                {
                    MessageBox.Show((idPlan == 0 ? "Plan guardado" : "Plan actualizado") + " exitosamente.", "Éxito");
                    CargarPlanesEnDataGridView();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo completar la operación.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Verifica que los campos numéricos estén correctos. " + ex.Message, "Error de Datos");
            }
        }

        private void btn_visualizarplanes_Click(object sender, EventArgs e)
        {
            CargarPlanesEnDataGridView();
        }

        private void dgvPlanes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Aseguramos que el clic sea en una fila válida (no en el encabezado)
            if (e.RowIndex >= 0)
            {
                // 1. Obtener la fila completa donde se hizo clic
                DataGridViewRow fila = dgvPlanes.Rows[e.RowIndex];

                // 2. Mapear los valores de la fila a los TextBoxes

                // El ID debe guardarse en el TextBox oculto para saber qué registro actualizar
                tb_idplan.Text = fila.Cells["IdPlan"].Value.ToString();

                // Mapear el resto de los campos para la edición
                tb_nombre.Text = fila.Cells["NombrePlan"].Value.ToString();
                tb_velocidad.Text = fila.Cells["Velocidad"].Value.ToString();
                tb_precio.Text = fila.Cells["Precio"].Value.ToString();
                tb_descripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            }
        }

        private void btn_EliminarPlan_Click(object sender, EventArgs e)
        {
            // 1. Obtener el ID del TextBox oculto
            int idPlanAEliminar = 0;
            int.TryParse(tb_idplan.Text, out idPlanAEliminar);

            // Verificación de selección
            if (idPlanAEliminar == 0)
            {
                MessageBox.Show("Por favor, selecciona un plan de la tabla antes de intentar eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mensaje de Confirmación (¡Obligatorio en DELETE!)
            DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este plan?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacion == DialogResult.Yes)
            {
                PlanDAL dal = new PlanDAL();
                int resultado = dal.EliminarPlan(idPlanAEliminar);

                if (resultado > 0)
                {
                    MessageBox.Show("Plan eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPlanesEnDataGridView(); // Refrescar la tabla
                    LimpiarCampos();             // Limpiar TextBoxes (incluyendo tb_idplan)
                }
                else if (resultado == 0)
                {
                    // Este caso puede ocurrir si el plan no se encontró o si hubo un error silencioso.
                    // La excepción 1451 se maneja dentro de PlanDAL.
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Crear instancia del destino
            FormGestionUsuarios formUsuarios = new FormGestionUsuarios();
            formUsuarios.StartPosition = FormStartPosition.CenterScreen;
            // 2. Mostrar el destino
            formUsuarios.Show();

            // 3. Cerrar el formulario actual
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Crear instancia del destino
            FormGestionContratos formContratos = new FormGestionContratos();
            formContratos.StartPosition = FormStartPosition.CenterScreen;
            // 2. Mostrar el destino
            formContratos.Show();

            // 3. Cerrar el formulario actual
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
