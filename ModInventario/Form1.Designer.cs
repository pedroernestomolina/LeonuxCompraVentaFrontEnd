namespace ModInventario
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
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO
            // 
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO.Location = new System.Drawing.Point(12, 12);
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO.Name = "BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO";
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO.Size = new System.Drawing.Size(208, 68);
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO.TabIndex = 0;
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO.Text = "TRASLADO MERC A SUCURSAL POR EXISTENCIA DEBAJO DEL MINIMO";
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO.UseVisualStyleBackColor = true;
            this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO.Click += new System.EventHandler(this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 429);
            this.Controls.Add(this.BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion De Inventario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO;
    }
}

