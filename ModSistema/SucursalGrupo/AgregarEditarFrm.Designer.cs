namespace ModSistema.SucursalGrupo
{
    partial class AgregarEditarFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BT_GUARDAR = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.L_TITULO = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TB_NOMBRE = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.CB_PRECIO = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 154);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 48);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.panel8, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel9, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(403, 48);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.BT_GUARDAR);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(201, 1);
            this.panel8.Margin = new System.Windows.Forms.Padding(1);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2);
            this.panel8.Size = new System.Drawing.Size(98, 46);
            this.panel8.TabIndex = 0;
            // 
            // BT_GUARDAR
            // 
            this.BT_GUARDAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_GUARDAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_GUARDAR.Image = global::ModSistema.Properties.Resources.bt_ok_3;
            this.BT_GUARDAR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_GUARDAR.Location = new System.Drawing.Point(2, 2);
            this.BT_GUARDAR.Name = "BT_GUARDAR";
            this.BT_GUARDAR.Size = new System.Drawing.Size(94, 42);
            this.BT_GUARDAR.TabIndex = 1;
            this.BT_GUARDAR.Text = "Guardar";
            this.BT_GUARDAR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_GUARDAR.UseVisualStyleBackColor = true;
            this.BT_GUARDAR.Click += new System.EventHandler(this.BT_GUARDAR_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BT_SALIR);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(301, 1);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2);
            this.panel9.Size = new System.Drawing.Size(101, 46);
            this.panel9.TabIndex = 1;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Image = global::ModSistema.Properties.Resources.bt_salida_2;
            this.BT_SALIR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_SALIR.Location = new System.Drawing.Point(2, 2);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(97, 42);
            this.BT_SALIR.TabIndex = 2;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Controls.Add(this.L_TITULO);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(403, 35);
            this.panel2.TabIndex = 2;
            // 
            // L_TITULO
            // 
            this.L_TITULO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TITULO.Location = new System.Drawing.Point(2, 2);
            this.L_TITULO.Name = "L_TITULO";
            this.L_TITULO.Size = new System.Drawing.Size(399, 31);
            this.L_TITULO.TabIndex = 0;
            this.L_TITULO.Text = "Agregar Item";
            this.L_TITULO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(403, 119);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.5277F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.47231F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 31);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(113, 25);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TB_NOMBRE);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(117, 31);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(226, 25);
            this.panel5.TabIndex = 0;
            // 
            // TB_NOMBRE
            // 
            this.TB_NOMBRE.BackColor = System.Drawing.Color.Yellow;
            this.TB_NOMBRE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_NOMBRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_NOMBRE.Location = new System.Drawing.Point(2, 2);
            this.TB_NOMBRE.MaxLength = 60;
            this.TB_NOMBRE.Name = "TB_NOMBRE";
            this.TB_NOMBRE.Size = new System.Drawing.Size(222, 22);
            this.TB_NOMBRE.TabIndex = 0;
            this.TB_NOMBRE.TextChanged += new System.EventHandler(this.TB_NOMBRE_TextChanged);
            this.TB_NOMBRE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_KeyDown);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(2, 58);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(113, 28);
            this.panel6.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Precio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.CB_PRECIO);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(117, 58);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(2);
            this.panel7.Size = new System.Drawing.Size(226, 28);
            this.panel7.TabIndex = 1;
            // 
            // CB_PRECIO
            // 
            this.CB_PRECIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_PRECIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PRECIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_PRECIO.FormattingEnabled = true;
            this.CB_PRECIO.Location = new System.Drawing.Point(2, 2);
            this.CB_PRECIO.Name = "CB_PRECIO";
            this.CB_PRECIO.Size = new System.Drawing.Size(222, 24);
            this.CB_PRECIO.TabIndex = 0;
            this.CB_PRECIO.SelectedIndexChanged += new System.EventHandler(this.CB_PRECIO_SelectedIndexChanged);
            this.CB_PRECIO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_KeyDown);
            // 
            // AgregarEditarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_SALIR;
            this.ClientSize = new System.Drawing.Size(403, 202);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "AgregarEditarFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AgregarEditarFrm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label L_TITULO;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox TB_NOMBRE;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox CB_PRECIO;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BT_GUARDAR;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BT_SALIR;
    }
}