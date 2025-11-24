namespace ProveedorInternet
{
    partial class FormGestionContratos
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
            label5 = new Label();
            btn_EliminarContrato = new Button();
            tb_idcontrato = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            tb_direccion = new TextBox();
            lbl_descripcion = new Label();
            lbl_precio = new Label();
            tb_estado = new TextBox();
            lbl_nombre = new Label();
            dgvContratos = new DataGridView();
            dtp_fecha = new DateTimePicker();
            label3 = new Label();
            cb_usuario = new ComboBox();
            cb_plan = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvContratos).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(478, 37);
            label5.TabIndex = 51;
            label5.Text = "Sistema Proveedor Internet - Contratos";
            // 
            // btn_EliminarContrato
            // 
            btn_EliminarContrato.Location = new Point(153, 303);
            btn_EliminarContrato.Name = "btn_EliminarContrato";
            btn_EliminarContrato.Size = new Size(92, 23);
            btn_EliminarContrato.TabIndex = 50;
            btn_EliminarContrato.Text = "Eliminar";
            btn_EliminarContrato.UseVisualStyleBackColor = true;
            btn_EliminarContrato.Click += btn_EliminarContrato_Click;
            // 
            // tb_idcontrato
            // 
            tb_idcontrato.Location = new Point(145, 49);
            tb_idcontrato.Name = "tb_idcontrato";
            tb_idcontrato.Size = new Size(100, 23);
            tb_idcontrato.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 48;
            label2.Text = "Agregado de Datos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(264, 52);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 46;
            label1.Text = "Visualizacion de Datos";
            // 
            // button1
            // 
            button1.Location = new Point(12, 303);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 45;
            button1.Text = "Guardar datos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tb_direccion
            // 
            tb_direccion.Location = new Point(14, 221);
            tb_direccion.Name = "tb_direccion";
            tb_direccion.Size = new Size(233, 23);
            tb_direccion.TabIndex = 44;
            // 
            // lbl_descripcion
            // 
            lbl_descripcion.AutoSize = true;
            lbl_descripcion.Location = new Point(12, 203);
            lbl_descripcion.Name = "lbl_descripcion";
            lbl_descripcion.Size = new Size(57, 15);
            lbl_descripcion.TabIndex = 43;
            lbl_descripcion.Text = "Direccion";
            // 
            // lbl_precio
            // 
            lbl_precio.AutoSize = true;
            lbl_precio.Location = new Point(13, 158);
            lbl_precio.Name = "lbl_precio";
            lbl_precio.Size = new Size(104, 15);
            lbl_precio.TabIndex = 41;
            lbl_precio.Text = "Fecha de Contrato";
            // 
            // tb_estado
            // 
            tb_estado.Location = new Point(14, 265);
            tb_estado.Name = "tb_estado";
            tb_estado.Size = new Size(233, 23);
            tb_estado.TabIndex = 38;
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Location = new Point(14, 247);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(42, 15);
            lbl_nombre.TabIndex = 37;
            lbl_nombre.Text = "Estado";
            // 
            // dgvContratos
            // 
            dgvContratos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContratos.Location = new Point(264, 70);
            dgvContratos.Name = "dgvContratos";
            dgvContratos.Size = new Size(701, 174);
            dgvContratos.TabIndex = 36;
            dgvContratos.CellClick += dgvContratos_CellClick;
            // 
            // dtp_fecha
            // 
            dtp_fecha.Location = new Point(14, 176);
            dtp_fecha.Name = "dtp_fecha";
            dtp_fecha.Size = new Size(231, 23);
            dtp_fecha.TabIndex = 52;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 72);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 53;
            label3.Text = "Usuario";
            // 
            // cb_usuario
            // 
            cb_usuario.FormattingEnabled = true;
            cb_usuario.Location = new Point(14, 90);
            cb_usuario.Name = "cb_usuario";
            cb_usuario.Size = new Size(233, 23);
            cb_usuario.TabIndex = 54;
            // 
            // cb_plan
            // 
            cb_plan.FormattingEnabled = true;
            cb_plan.Location = new Point(14, 134);
            cb_plan.Name = "cb_plan";
            cb_plan.Size = new Size(233, 23);
            cb_plan.TabIndex = 56;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 116);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 55;
            label4.Text = "Plan";
            // 
            // FormGestionContratos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 450);
            Controls.Add(cb_plan);
            Controls.Add(label4);
            Controls.Add(cb_usuario);
            Controls.Add(label3);
            Controls.Add(dtp_fecha);
            Controls.Add(label5);
            Controls.Add(btn_EliminarContrato);
            Controls.Add(tb_idcontrato);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(tb_direccion);
            Controls.Add(lbl_descripcion);
            Controls.Add(lbl_precio);
            Controls.Add(tb_estado);
            Controls.Add(lbl_nombre);
            Controls.Add(dgvContratos);
            Name = "FormGestionContratos";
            Text = "Form1";
            Load += FormGestionContratos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvContratos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Button btn_EliminarContrato;
        private TextBox tb_idcontrato;
        private Label label2;
        private Label label1;
        private Button button1;
        private TextBox tb_direccion;
        private Label lbl_descripcion;
        private Label lbl_precio;
        private TextBox tb_estado;
        private Label lbl_nombre;
        private DataGridView dgvContratos;
        private DateTimePicker dtp_fecha;
        private Label label3;
        private ComboBox cb_usuario;
        private ComboBox cb_plan;
        private Label label4;
    }
}