namespace MovVenta
{
    partial class Form1
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
            this.BT_VENTA = new System.Windows.Forms.Button();
            this.BT_SALIDA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_VENTA
            // 
            this.BT_VENTA.Location = new System.Drawing.Point(12, 12);
            this.BT_VENTA.Name = "BT_VENTA";
            this.BT_VENTA.Size = new System.Drawing.Size(75, 23);
            this.BT_VENTA.TabIndex = 0;
            this.BT_VENTA.Text = "Venta";
            this.BT_VENTA.UseVisualStyleBackColor = true;
            this.BT_VENTA.Click += new System.EventHandler(this.BT_VENTA_Click);
            // 
            // BT_SALIDA
            // 
            this.BT_SALIDA.Location = new System.Drawing.Point(12, 41);
            this.BT_SALIDA.Name = "BT_SALIDA";
            this.BT_SALIDA.Size = new System.Drawing.Size(75, 23);
            this.BT_SALIDA.TabIndex = 1;
            this.BT_SALIDA.Text = "Salida";
            this.BT_SALIDA.UseVisualStyleBackColor = true;
            this.BT_SALIDA.Click += new System.EventHandler(this.BT_SALIDA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BT_SALIDA);
            this.Controls.Add(this.BT_VENTA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_VENTA;
        private System.Windows.Forms.Button BT_SALIDA;
    }
}

