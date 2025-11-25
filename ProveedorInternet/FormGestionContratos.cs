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
            tb_idcontrato.Visible = false;
            CargarDatosEnComboboxes();
            cb_usuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_plan.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarContratosEnDataGridView();
        }
        private void CargarContratosEnDataGridView()
        {
            ContratoDAL dal = new ContratoDAL();
            dgvContratos.DataSource = dal.ObtenerContratos();
            if (dgvContratos.Columns.Contains("IdContrato"))
            {
                dgvContratos.Columns["IdContrato"].Visible = false;
            }
            if (dgvContratos.Columns.Contains("IdUsuarioFK"))
            {
                dgvContratos.Columns["IdUsuarioFK"].Visible = false;
            }
            if (dgvContratos.Columns.Contains("IdPlanFK"))
            {
                dgvContratos.Columns["IdPlanFK"].Visible = false;
            }
            if (dgvContratos.Columns.Contains("NombreUsuario"))
            {
                dgvContratos.Columns["NombreUsuario"].HeaderText = "Cliente";
            }
            if (dgvContratos.Columns.Contains("NombrePlan"))
            {
                dgvContratos.Columns["NombrePlan"].HeaderText = "Plan Contratado";
            }
        }
        private void CargarDatosEnComboboxes()
        {
            UsuarioDAL usuarioDal = new UsuarioDAL();
            List<Usuario> usuarios = usuarioDal.ObtenerUsuarios();

            cb_usuario.DataSource = usuarios;
            cb_usuario.DisplayMember = "NombreCompleto";
            cb_usuario.ValueMember = "IdUsuario";
            cb_usuario.SelectedIndex = -1;


            PlanDAL planDal = new PlanDAL();
            List<Plan> planes = planDal.ObtenerPlanes();

   
            cb_plan.DataSource = planes;
            cb_plan.DisplayMember = "NombrePlan"; 
            cb_plan.ValueMember = "IdPlan"; 
            cb_plan.SelectedIndex = -1;
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

            if (cb_usuario.SelectedValue == null || cb_plan.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar un Cliente y un Plan válidos.", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int.TryParse(tb_idcontrato.Text, out idContrato);

            try
            {
                Contrato contrato = new Contrato
                {
                    IdContrato = idContrato,
                    IdUsuarioFK = (int)cb_usuario.SelectedValue,
                    IdPlanFK = (int)cb_plan.SelectedValue,
                    FechaInicio = dtp_fecha.Value,
                    DireccionInstalacion = tb_direccion.Text,
                    EstadoContrato = tb_estado.Text 
                };

                if (idContrato == 0)
                {
                    resultado = dal.GuardarContrato(contrato);
                }
                else
                {
                    resultado = dal.ActualizarContrato(contrato);
                }
                if (resultado > 0)
                {
                    string mensaje = (idContrato == 0 ? "Contrato creado" : "Contrato actualizado") + " exitosamente.";
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarContratosEnDataGridView(); 
                    LimpiarCamposContratos();     
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
                tb_idcontrato.Text = fila.Cells["IdContrato"].Value.ToString();
                cb_usuario.SelectedValue = fila.Cells["IdUsuarioFK"].Value;
                cb_plan.SelectedValue = fila.Cells["IdPlanFK"].Value;
                dtp_fecha.Value = (DateTime)fila.Cells["FechaInicio"].Value;
                tb_direccion.Text = fila.Cells["DireccionInstalacion"].Value.ToString();
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
            }
            LimpiarCamposContratos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormGestionPlanes formPlanes = new FormGestionPlanes();
            formPlanes.StartPosition = FormStartPosition.CenterScreen;
            formPlanes.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimpiarCamposContratos();
        }
    }
}
