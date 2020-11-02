namespace ModSistema.SucursalDeposito
{
    partial class AsignarFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.L_SUCURSAL = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_DEPOSITO = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 145);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 48);
            this.panel1.TabIndex = 2;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(480, 48);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.BT_GUARDAR);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(241, 1);
            this.panel8.Margin = new System.Windows.Forms.Padding(1);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2);
            this.panel8.Size = new System.Drawing.Size(118, 46);
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
            this.BT_GUARDAR.Size = new System.Drawing.Size(114, 42);
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
            this.panel9.Location = new System.Drawing.Point(361, 1);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2);
            this.panel9.Size = new System.Drawing.Size(118, 46);
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
            this.BT_SALIR.Size = new System.Drawing.Size(114, 42);
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
            this.panel2.Size = new System.Drawing.Size(480, 35);
            this.panel2.TabIndex = 3;
            // 
            // L_TITULO
            // 
            this.L_TITULO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_TITULO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TITULO.Location = new System.Drawing.Point(2, 2);
            this.L_TITULO.Name = "L_TITULO";
            this.L_TITULO.Size = new System.Drawing.Size(476, 31);
            this.L_TITULO.TabIndex = 0;
            this.L_TITULO.Text = "Asignar Depósito A Sucursal";
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
            this.panel3.Size = new System.Drawing.Size(480, 110);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(478, 108);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.L_SUCURSAL);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(250, 104);
            this.panel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sucursal:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_SUCURSAL
            // 
            this.L_SUCURSAL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.L_SUCURSAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SUCURSAL.Location = new System.Drawing.Point(2, 35);
            this.L_SUCURSAL.Name = "L_SUCURSAL";
            this.L_SUCURSAL.Size = new System.Drawing.Size(246, 67);
            this.L_SUCURSAL.TabIndex = 1;
            this.L_SUCURSAL.Text = "label1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.CB_DEPOSITO);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(254, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(222, 104);
            this.panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Depósito A Asignar:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_DEPOSITO
            // 
            this.CB_DEPOSITO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_DEPOSITO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DEPOSITO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DEPOSITO.FormattingEnabled = true;
            this.CB_DEPOSITO.Location = new System.Drawing.Point(5, 32);
            this.CB_DEPOSITO.Name = "CB_DEPOSITO";
            this.CB_DEPOSITO.Size = new System.Drawing.Size(208, 24);
            this.CB_DEPOSITO.TabIndex = 0;
            this.CB_DEPOSITO.SelectedIndexChanged += new System.EventHandler(this.CB_DEPOSITO_SelectedIndexChanged);
            // 
            // AsignarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_SALIR;
            this.ClientSize = new System.Drawing.Size(480, 193);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "AsignarFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AsignarFrm_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BT_GUARDAR;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label L_TITULO;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label L_SUCURSAL;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_DEPOSITO;
        private System.Windows.Forms.Label label2;
    }
}