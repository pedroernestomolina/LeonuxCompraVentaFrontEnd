namespace ModInventario
{
    partial class Form2
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
            this.DTP_DESDE = new System.Windows.Forms.DateTimePicker();
            this.DTP_HASTA = new System.Windows.Forms.DateTimePicker();
            this.CB_SUCURSAL = new System.Windows.Forms.ComboBox();
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.L_SUCURSAL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DTP_DESDE
            // 
            this.DTP_DESDE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_DESDE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_DESDE.Location = new System.Drawing.Point(154, 43);
            this.DTP_DESDE.Name = "DTP_DESDE";
            this.DTP_DESDE.Size = new System.Drawing.Size(200, 22);
            this.DTP_DESDE.TabIndex = 0;
            this.DTP_DESDE.ValueChanged += new System.EventHandler(this.DTP_DESDE_ValueChanged);
            // 
            // DTP_HASTA
            // 
            this.DTP_HASTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_HASTA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTP_HASTA.Location = new System.Drawing.Point(154, 68);
            this.DTP_HASTA.Name = "DTP_HASTA";
            this.DTP_HASTA.Size = new System.Drawing.Size(200, 22);
            this.DTP_HASTA.TabIndex = 1;
            this.DTP_HASTA.ValueChanged += new System.EventHandler(this.DTP_HASTA_ValueChanged);
            // 
            // CB_SUCURSAL
            // 
            this.CB_SUCURSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_SUCURSAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_SUCURSAL.FormattingEnabled = true;
            this.CB_SUCURSAL.Location = new System.Drawing.Point(154, 96);
            this.CB_SUCURSAL.Name = "CB_SUCURSAL";
            this.CB_SUCURSAL.Size = new System.Drawing.Size(200, 24);
            this.CB_SUCURSAL.TabIndex = 2;
            this.CB_SUCURSAL.SelectedIndexChanged += new System.EventHandler(this.CB_SUCURSAL_SelectedIndexChanged);
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_PROCESAR.Location = new System.Drawing.Point(255, 126);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(99, 35);
            this.BT_PROCESAR.TabIndex = 3;
            this.BT_PROCESAR.Text = "Procesar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 204);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(438, 43);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Desde La Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasta La Fecha:";
            // 
            // L_SUCURSAL
            // 
            this.L_SUCURSAL.AutoSize = true;
            this.L_SUCURSAL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_SUCURSAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_SUCURSAL.Location = new System.Drawing.Point(74, 99);
            this.L_SUCURSAL.Name = "L_SUCURSAL";
            this.L_SUCURSAL.Size = new System.Drawing.Size(63, 16);
            this.L_SUCURSAL.TabIndex = 7;
            this.L_SUCURSAL.Text = "Sucursal:";
            this.L_SUCURSAL.Click += new System.EventHandler(this.L_SUCURSAL_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 247);
            this.Controls.Add(this.L_SUCURSAL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BT_PROCESAR);
            this.Controls.Add(this.CB_SUCURSAL);
            this.Controls.Add(this.DTP_HASTA);
            this.Controls.Add(this.DTP_DESDE);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arqueo Caja/Venta Pos";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTP_DESDE;
        private System.Windows.Forms.DateTimePicker DTP_HASTA;
        private System.Windows.Forms.ComboBox CB_SUCURSAL;
        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label L_SUCURSAL;
    }
}