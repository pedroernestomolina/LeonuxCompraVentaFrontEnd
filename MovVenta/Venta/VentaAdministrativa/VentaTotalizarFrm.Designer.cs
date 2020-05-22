namespace MovVenta.Venta.VentaAdministrativa
{
    partial class VentaTotalizarFrm
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
            this.BT_PROCESAR = new System.Windows.Forms.Button();
            this.TB_DSCTO = new System.Windows.Forms.TextBox();
            this.L_SUB_TOTAL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_CARGO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.L_TOTAL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_PROCESAR
            // 
            this.BT_PROCESAR.Location = new System.Drawing.Point(167, 169);
            this.BT_PROCESAR.Name = "BT_PROCESAR";
            this.BT_PROCESAR.Size = new System.Drawing.Size(75, 23);
            this.BT_PROCESAR.TabIndex = 2;
            this.BT_PROCESAR.Text = "Procesar";
            this.BT_PROCESAR.UseVisualStyleBackColor = true;
            this.BT_PROCESAR.Click += new System.EventHandler(this.BT_PROCESAR_Click);
            // 
            // TB_DSCTO
            // 
            this.TB_DSCTO.Location = new System.Drawing.Point(142, 59);
            this.TB_DSCTO.Name = "TB_DSCTO";
            this.TB_DSCTO.Size = new System.Drawing.Size(113, 20);
            this.TB_DSCTO.TabIndex = 0;
            this.TB_DSCTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_DSCTO.Validating += new System.ComponentModel.CancelEventHandler(this.TB_DSCTO_Validating);
            this.TB_DSCTO.Validated += new System.EventHandler(this.TB_DSCTO_Validated);
            // 
            // L_SUB_TOTAL
            // 
            this.L_SUB_TOTAL.Location = new System.Drawing.Point(139, 43);
            this.L_SUB_TOTAL.Name = "L_SUB_TOTAL";
            this.L_SUB_TOTAL.Size = new System.Drawing.Size(116, 13);
            this.L_SUB_TOTAL.TabIndex = 2;
            this.L_SUB_TOTAL.Text = "label1";
            this.L_SUB_TOTAL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SubTotal Venta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descuento (%):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cargo (%):";
            // 
            // TB_CARGO
            // 
            this.TB_CARGO.Location = new System.Drawing.Point(142, 85);
            this.TB_CARGO.Name = "TB_CARGO";
            this.TB_CARGO.Size = new System.Drawing.Size(113, 20);
            this.TB_CARGO.TabIndex = 1;
            this.TB_CARGO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TB_CARGO.Validating += new System.ComponentModel.CancelEventHandler(this.TB_CARGO_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Monto A Cancelar:";
            // 
            // L_TOTAL
            // 
            this.L_TOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TOTAL.Location = new System.Drawing.Point(138, 110);
            this.L_TOTAL.Name = "L_TOTAL";
            this.L_TOTAL.Size = new System.Drawing.Size(117, 24);
            this.L_TOTAL.TabIndex = 8;
            this.L_TOTAL.Text = "label1";
            this.L_TOTAL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // VentaTotalizarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 261);
            this.Controls.Add(this.L_TOTAL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_CARGO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.L_SUB_TOTAL);
            this.Controls.Add(this.TB_DSCTO);
            this.Controls.Add(this.BT_PROCESAR);
            this.Name = "VentaTotalizarFrm";
            this.Text = "VentaTotalizarFrm";
            this.Load += new System.EventHandler(this.VentaTotalizarFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_PROCESAR;
        private System.Windows.Forms.TextBox TB_DSCTO;
        private System.Windows.Forms.Label L_SUB_TOTAL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_CARGO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label L_TOTAL;
    }
}