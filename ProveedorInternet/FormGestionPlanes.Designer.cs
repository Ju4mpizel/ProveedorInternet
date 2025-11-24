namespace ProveedorInternet
{
    partial class FormGestionPlanes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPlanes = new DataGridView();
            lbl_nombre = new Label();
            tb_nombre = new TextBox();
            tb_velocidad = new TextBox();
            lbl_velocidad = new Label();
            tb_precio = new TextBox();
            lbl_precio = new Label();
            tb_descripcion = new TextBox();
            lbl_descripcion = new Label();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            tb_idplan = new TextBox();
            btn_EliminarPlan = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).BeginInit();
            SuspendLayout();
            // 
            // dgvPlanes
            // 
            dgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlanes.Location = new Point(264, 71);
            dgvPlanes.Name = "dgvPlanes";
            dgvPlanes.Size = new Size(675, 174);
            dgvPlanes.TabIndex = 0;
            dgvPlanes.CellClick += dgvPlanes_CellClick_1;
            dgvPlanes.CellContentClick += dgvPlanes_CellContentClick;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Location = new Point(12, 71);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(51, 15);
            lbl_nombre.TabIndex = 1;
            lbl_nombre.Text = "Nombre";
            // 
            // tb_nombre
            // 
            tb_nombre.Location = new Point(12, 89);
            tb_nombre.Name = "tb_nombre";
            tb_nombre.Size = new Size(233, 23);
            tb_nombre.TabIndex = 2;
            // 
            // tb_velocidad
            // 
            tb_velocidad.Location = new Point(12, 133);
            tb_velocidad.Name = "tb_velocidad";
            tb_velocidad.Size = new Size(233, 23);
            tb_velocidad.TabIndex = 4;
            // 
            // lbl_velocidad
            // 
            lbl_velocidad.AutoSize = true;
            lbl_velocidad.Location = new Point(12, 115);
            lbl_velocidad.Name = "lbl_velocidad";
            lbl_velocidad.Size = new Size(58, 15);
            lbl_velocidad.TabIndex = 3;
            lbl_velocidad.Text = "Velocidad";
            // 
            // tb_precio
            // 
            tb_precio.Location = new Point(12, 177);
            tb_precio.Name = "tb_precio";
            tb_precio.Size = new Size(233, 23);
            tb_precio.TabIndex = 6;
            // 
            // lbl_precio
            // 
            lbl_precio.AutoSize = true;
            lbl_precio.Location = new Point(13, 159);
            lbl_precio.Name = "lbl_precio";
            lbl_precio.Size = new Size(40, 15);
            lbl_precio.TabIndex = 5;
            lbl_precio.Text = "Precio";
            // 
            // tb_descripcion
            // 
            tb_descripcion.Location = new Point(12, 222);
            tb_descripcion.Name = "tb_descripcion";
            tb_descripcion.Size = new Size(233, 23);
            tb_descripcion.TabIndex = 8;
            // 
            // lbl_descripcion
            // 
            lbl_descripcion.AutoSize = true;
            lbl_descripcion.Location = new Point(12, 204);
            lbl_descripcion.Name = "lbl_descripcion";
            lbl_descripcion.Size = new Size(69, 15);
            lbl_descripcion.TabIndex = 7;
            lbl_descripcion.Text = "Descripcion";
            // 
            // button1
            // 
            button1.Location = new Point(12, 251);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 9;
            button1.Text = "Guardar datos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(264, 53);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 10;
            label1.Text = "Visualizacion de Datos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 12;
            label2.Text = "Agregado de Datos";
            // 
            // tb_idplan
            // 
            tb_idplan.Location = new Point(145, 50);
            tb_idplan.Name = "tb_idplan";
            tb_idplan.Size = new Size(100, 23);
            tb_idplan.TabIndex = 13;
            // 
            // btn_EliminarPlan
            // 
            btn_EliminarPlan.Location = new Point(153, 251);
            btn_EliminarPlan.Name = "btn_EliminarPlan";
            btn_EliminarPlan.Size = new Size(92, 23);
            btn_EliminarPlan.TabIndex = 14;
            btn_EliminarPlan.Text = "Eliminar";
            btn_EliminarPlan.UseVisualStyleBackColor = true;
            btn_EliminarPlan.Click += btn_EliminarPlan_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(12, 10);
            label5.Name = "label5";
            label5.Size = new Size(438, 37);
            label5.TabIndex = 35;
            label5.Text = "Sistema Proveedor Internet - Planes";
            // 
            // FormGestionPlanes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 450);
            Controls.Add(label5);
            Controls.Add(btn_EliminarPlan);
            Controls.Add(tb_idplan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(tb_descripcion);
            Controls.Add(lbl_descripcion);
            Controls.Add(tb_precio);
            Controls.Add(lbl_precio);
            Controls.Add(tb_velocidad);
            Controls.Add(lbl_velocidad);
            Controls.Add(tb_nombre);
            Controls.Add(lbl_nombre);
            Controls.Add(dgvPlanes);
            Name = "FormGestionPlanes";
            Text = "Formulario Gestion de Planes";
            Load += FormGestionPlanes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPlanes;
        private Label lbl_nombre;
        private TextBox tb_nombre;
        private TextBox tb_velocidad;
        private Label lbl_velocidad;
        private TextBox tb_precio;
        private Label lbl_precio;
        private TextBox tb_descripcion;
        private Label lbl_descripcion;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox tb_idplan;
        private Button btn_EliminarPlan;
        private Label label5;
    }
}