namespace MovVenta.Venta.VentaAdministrativa
{
    partial class VentaDetalleAdmFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_CANTIDAD = new System.Windows.Forms.TextBox();
            this.TB_PRECIO = new System.Windows.Forms.TextBox();
            this.BT_GUARDAR = new System.Windows.Forms.Button();
            this.TB_NOTAS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_DSCTO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_IMPORTE = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Precio:";
            // 
            // TB_CANTIDAD
            // 
            this.TB_CANTIDAD.Location = new System.Drawing.Point(89, 103);
            this.TB_CANTIDAD.Name = "TB_CANTIDAD";
            this.TB_CANTIDAD.Size = new System.Drawing.Size(100, 20);
            this.TB_CANTIDAD.TabIndex = 2;
            this.TB_CANTIDAD.Validating += new System.ComponentModel.CancelEventHandler(this.TB_CANTIDAD_Validating);
            this.TB_CANTIDAD.Validated += new System.EventHandler(this.TB_CANTIDAD_Validated);
            // 
            // TB_PRECIO
            // 
            this.TB_PRECIO.Location = new System.Drawing.Point(89, 129);
            this.TB_PRECIO.Name = "TB_PRECIO";
            this.TB_PRECIO.Size = new System.Drawing.Size(100, 20);
            this.TB_PRECIO.TabIndex = 3;
            this.TB_PRECIO.Validating += new System.ComponentModel.CancelEventHandler(this.TB_PRECIO_Validating);
            this.TB_PRECIO.Validated += new System.EventHandler(this.TB_PRECIO_Validated);
            // 
            // BT_GUARDAR
            // 
            this.BT_GUARDAR.Location = new System.Drawing.Point(221, 265);
            this.BT_GUARDAR.Name = "BT_GUARDAR";
            this.BT_GUARDAR.Size = new System.Drawing.Size(75, 23);
            this.BT_GUARDAR.TabIndex = 4;
            this.BT_GUARDAR.Text = "Guardar";
            this.BT_GUARDAR.UseVisualStyleBackColor = true;
            this.BT_GUARDAR.Click += new System.EventHandler(this.BT_GUARDAR_Click);
            // 
            // TB_NOTAS
            // 
            this.TB_NOTAS.Location = new System.Drawing.Point(89, 207);
            this.TB_NOTAS.Multiline = true;
            this.TB_NOTAS.Name = "TB_NOTAS";
            this.TB_NOTAS.Size = new System.Drawing.Size(207, 40);
            this.TB_NOTAS.TabIndex = 5;
            this.TB_NOTAS.Validated += new System.EventHandler(this.TB_NOTAS_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nota:";
            // 
            // TB_DSCTO
            // 
            this.TB_DSCTO.Location = new System.Drawing.Point(89, 155);
            this.TB_DSCTO.Name = "TB_DSCTO";
            this.TB_DSCTO.Size = new System.Drawing.Size(100, 20);
            this.TB_DSCTO.TabIndex = 7;
            this.TB_DSCTO.Validating += new System.ComponentModel.CancelEventHandler(this.TB_DSCTO_Validating);
            this.TB_DSCTO.Validated += new System.EventHandler(this.TB_DSCTO_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dscto(%):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Importe:";
            // 
            // TB_IMPORTE
            // 
            this.TB_IMPORTE.Location = new System.Drawing.Point(89, 181);
            this.TB_IMPORTE.Name = "TB_IMPORTE";
            this.TB_IMPORTE.ReadOnly = true;
            this.TB_IMPORTE.Size = new System.Drawing.Size(100, 20);
            this.TB_IMPORTE.TabIndex = 10;
            // 
            // VentaDetalleAdmFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 429);
            this.Controls.Add(this.TB_IMPORTE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_DSCTO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_NOTAS);
            this.Controls.Add(this.BT_GUARDAR);
            this.Controls.Add(this.TB_PRECIO);
            this.Controls.Add(this.TB_CANTIDAD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VentaDetalleAdmFrm";
            this.Text = "VentaDetalleAdmFrm";
            this.Load += new System.EventHandler(this.VentaDetalleAdmFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_CANTIDAD;
        private System.Windows.Forms.TextBox TB_PRECIO;
        private System.Windows.Forms.Button BT_GUARDAR;
        private System.Windows.Forms.TextBox TB_NOTAS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_DSCTO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_IMPORTE;
    }
}