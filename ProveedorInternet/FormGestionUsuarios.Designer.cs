namespace ProveedorInternet
{
    partial class FormGestionUsuarios
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_eliminar = new Button();
            tb_idusuario = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btn_guardar = new Button();
            tb_direccion = new TextBox();
            lbl_descripcion = new Label();
            tb_telefono = new TextBox();
            tb_apellido = new TextBox();
            lbl_velocidad = new Label();
            tb_nombre = new TextBox();
            dgv_usuarios = new DataGridView();
            lbl_precio = new Label();
            lbl_nombre = new Label();
            tb_carnet = new TextBox();
            label3 = new Label();
            label4 = new Label();
            tb_email = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_usuarios).BeginInit();
            SuspendLayout();
            // 
            // btn_eliminar
            // 
            btn_eliminar.Location = new Point(157, 342);
            btn_eliminar.Name = "btn_eliminar";
            btn_eliminar.Size = new Size(92, 23);
            btn_eliminar.TabIndex = 27;
            btn_eliminar.Text = "Eliminar";
            btn_eliminar.UseVisualStyleBackColor = true;
            btn_eliminar.Click += btn_eliminar_Click;
            // 
            // tb_idusuario
            // 
            tb_idusuario.Location = new Point(149, 49);
            tb_idusuario.Name = "tb_idusuario";
            tb_idusuario.Size = new Size(100, 23);
            tb_idusuario.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 52);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 25;
            label2.Text = "Agregado de Datos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(268, 52);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 23;
            label1.Text = "Visualizacion de Datos";
            // 
            // btn_guardar
            // 
            btn_guardar.Location = new Point(16, 342);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(115, 23);
            btn_guardar.TabIndex = 22;
            btn_guardar.Text = "Guardar datos";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // tb_direccion
            // 
            tb_direccion.Location = new Point(16, 313);
            tb_direccion.Name = "tb_direccion";
            tb_direccion.Size = new Size(233, 23);
            tb_direccion.TabIndex = 21;
            // 
            // lbl_descripcion
            // 
            lbl_descripcion.AutoSize = true;
            lbl_descripcion.Location = new Point(16, 295);
            lbl_descripcion.Name = "lbl_descripcion";
            lbl_descripcion.Size = new Size(57, 15);
            lbl_descripcion.TabIndex = 20;
            lbl_descripcion.Text = "Direccion";
            // 
            // tb_telefono
            // 
            tb_telefono.Location = new Point(16, 221);
            tb_telefono.Name = "tb_telefono";
            tb_telefono.Size = new Size(233, 23);
            tb_telefono.TabIndex = 19;
            // 
            // tb_apellido
            // 
            tb_apellido.Location = new Point(16, 132);
            tb_apellido.Name = "tb_apellido";
            tb_apellido.Size = new Size(233, 23);
            tb_apellido.TabIndex = 18;
            // 
            // lbl_velocidad
            // 
            lbl_velocidad.AutoSize = true;
            lbl_velocidad.Location = new Point(16, 114);
            lbl_velocidad.Name = "lbl_velocidad";
            lbl_velocidad.Size = new Size(51, 15);
            lbl_velocidad.TabIndex = 17;
            lbl_velocidad.Text = "Apellido";
            // 
            // tb_nombre
            // 
            tb_nombre.Location = new Point(16, 88);
            tb_nombre.Name = "tb_nombre";
            tb_nombre.Size = new Size(233, 23);
            tb_nombre.TabIndex = 16;
            // 
            // dgv_usuarios
            // 
            dgv_usuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_usuarios.Location = new Point(268, 70);
            dgv_usuarios.Name = "dgv_usuarios";
            dgv_usuarios.Size = new Size(708, 174);
            dgv_usuarios.TabIndex = 15;
            dgv_usuarios.CellClick += dgv_usuarios_CellClick;
            // 
            // lbl_precio
            // 
            lbl_precio.AutoSize = true;
            lbl_precio.Location = new Point(16, 203);
            lbl_precio.Name = "lbl_precio";
            lbl_precio.Size = new Size(52, 15);
            lbl_precio.TabIndex = 28;
            lbl_precio.Text = "Telefono";
            // 
            // lbl_nombre
            // 
            lbl_nombre.AutoSize = true;
            lbl_nombre.Location = new Point(16, 70);
            lbl_nombre.Name = "lbl_nombre";
            lbl_nombre.Size = new Size(51, 15);
            lbl_nombre.TabIndex = 29;
            lbl_nombre.Text = "Nombre";
            // 
            // tb_carnet
            // 
            tb_carnet.Location = new Point(16, 177);
            tb_carnet.Name = "tb_carnet";
            tb_carnet.Size = new Size(233, 23);
            tb_carnet.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 159);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 30;
            label3.Text = "Carnet";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 251);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 33;
            label4.Text = "Email";
            // 
            // tb_email
            // 
            tb_email.Location = new Point(16, 269);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(233, 23);
            tb_email.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(464, 37);
            label5.TabIndex = 34;
            label5.Text = "Sistema Proveedor Internet - Usuarios";
            // 
            // FormGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tb_email);
            Controls.Add(tb_carnet);
            Controls.Add(label3);
            Controls.Add(lbl_nombre);
            Controls.Add(lbl_precio);
            Controls.Add(btn_eliminar);
            Controls.Add(tb_idusuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_guardar);
            Controls.Add(tb_direccion);
            Controls.Add(lbl_descripcion);
            Controls.Add(tb_telefono);
            Controls.Add(tb_apellido);
            Controls.Add(lbl_velocidad);
            Controls.Add(tb_nombre);
            Controls.Add(dgv_usuarios);
            Name = "FormGestionUsuarios";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_usuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_eliminar;
        private TextBox tb_idusuario;
        private Label label2;
        private Label label1;
        private Button btn_guardar;
        private TextBox tb_direccion;
        private Label lbl_descripcion;
        private TextBox tb_telefono;
        private TextBox tb_apellido;
        private Label lbl_velocidad;
        private TextBox tb_nombre;
        private DataGridView dgv_usuarios;
        private Label lbl_precio;
        private Label lbl_nombre;
        private TextBox tb_carnet;
        private Label label3;
        private Label label4;
        private TextBox tb_email;
        private Label label5;
    }
}
