namespace ModPos.Facturacion.ProductoLista
{
    partial class ListaOfertaFrm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_SALIDA = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.L_TITULO_VENTANA = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.BT_SALIDA);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 434);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(609, 33);
            this.panel2.TabIndex = 2;
            // 
            // BT_SALIDA
            // 
            this.BT_SALIDA.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_SALIDA.Dock = System.Windows.Forms.DockStyle.Right;
            this.BT_SALIDA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIDA.Location = new System.Drawing.Point(530, 4);
            this.BT_SALIDA.Name = "BT_SALIDA";
            this.BT_SALIDA.Size = new System.Drawing.Size(75, 25);
            this.BT_SALIDA.TabIndex = 1;
            this.BT_SALIDA.Text = "Salir";
            this.BT_SALIDA.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.L_TITULO_VENTANA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(609, 33);
            this.panel1.TabIndex = 1;
            // 
            // L_TITULO_VENTANA
            // 
            this.L_TITULO_VENTANA.BackColor = System.Drawing.Color.AliceBlue;
            this.L_TITULO_VENTANA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_TITULO_VENTANA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_TITULO_VENTANA.Location = new System.Drawing.Point(2, 2);
            this.L_TITULO_VENTANA.Name = "L_TITULO_VENTANA";
            this.L_TITULO_VENTANA.Size = new System.Drawing.Size(605, 29);
            this.L_TITULO_VENTANA.TabIndex = 0;
            this.L_TITULO_VENTANA.Text = "Lista De Productos ( OFERTAS )";
            this.L_TITULO_VENTANA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DGV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(609, 401);
            this.panel3.TabIndex = 0;
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(4, 4);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(601, 393);
            this.DGV.TabIndex = 0;
            // 
            // ListaOfertaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BT_SALIDA;
            this.ClientSize = new System.Drawing.Size(609, 467);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "ListaOfertaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ListaOfertaFrm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SALIDA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label L_TITULO_VENTANA;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DGV;

    }
}