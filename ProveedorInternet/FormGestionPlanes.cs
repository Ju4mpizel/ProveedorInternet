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
        private void CargarPlanesEnDataGridView()
        {
            PlanDAL dal = new PlanDAL();
            dgvPlanes.DataSource = dal.ObtenerPlanes();
            if (dgvPlanes.Columns.Contains("IdPlan"))
            {
                dgvPlanes.Columns["IdPlan"].Visible = false;
            }
            if (dgvPlanes.Columns.Contains("NombrePlan"))
            {
                dgvPlanes.Columns["NombrePlan"].HeaderText = "Nombre del Plan";
            }
        }
        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
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
            int.TryParse(tb_idplan.Text, out idPlan);

            try
            {
                Plan plan = new Plan
                {
                    IdPlan = idPlan,
                    NombrePlan = tb_nombre.Text,
                    Velocidad = int.Parse(tb_velocidad.Text),
                    Precio = decimal.Parse(tb_precio.Text),
                    Descripcion = tb_descripcion.Text
                };
                if (idPlan == 0)
                {
                    resultado = dal.GuardarPlan(plan);
                }
                else
                {
                    resultado = dal.ActualizarPlan(plan);
                }
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPlanes.Rows[e.RowIndex];
                tb_idplan.Text = fila.Cells["IdPlan"].Value.ToString();
                tb_nombre.Text = fila.Cells["NombrePlan"].Value.ToString();
                tb_velocidad.Text = fila.Cells["Velocidad"].Value.ToString();
                tb_precio.Text = fila.Cells["Precio"].Value.ToString();
                tb_descripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            }
        }

        private void btn_EliminarPlan_Click(object sender, EventArgs e)
        {
            int idPlanAEliminar = 0;
            int.TryParse(tb_idplan.Text, out idPlanAEliminar);
            if (idPlanAEliminar == 0)
            {
                MessageBox.Show("Por favor, selecciona un plan de la tabla antes de intentar eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                    CargarPlanesEnDataGridView(); 
                    LimpiarCampos();             
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
            FormGestionUsuarios formUsuarios = new FormGestionUsuarios();
            formUsuarios.StartPosition = FormStartPosition.CenterScreen;
            formUsuarios.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormGestionContratos formContratos = new FormGestionContratos();
            formContratos.StartPosition = FormStartPosition.CenterScreen;
            formContratos.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
