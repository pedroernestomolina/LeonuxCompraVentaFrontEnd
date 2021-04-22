namespace PosOnLine.Src.Principal
{
    partial class PrincipalFrm
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
            this.BT_ABRIR_POS = new System.Windows.Forms.Button();
            this.BT_CERRAR_POS = new System.Windows.Forms.Button();
            this.BT_SALIDA = new System.Windows.Forms.Button();
            this.BT_ADM_DOCUMENTOS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_ABRIR_POS
            // 
            this.BT_ABRIR_POS.Location = new System.Drawing.Point(12, 76);
            this.BT_ABRIR_POS.Name = "BT_ABRIR_POS";
            this.BT_ABRIR_POS.Size = new System.Drawing.Size(75, 23);
            this.BT_ABRIR_POS.TabIndex = 0;
            this.BT_ABRIR_POS.Text = "Abrir Pos";
            this.BT_ABRIR_POS.UseVisualStyleBackColor = true;
            this.BT_ABRIR_POS.Click += new System.EventHandler(this.BT_ABRIR_POS_Click);
            // 
            // BT_CERRAR_POS
            // 
            this.BT_CERRAR_POS.Location = new System.Drawing.Point(12, 135);
            this.BT_CERRAR_POS.Name = "BT_CERRAR_POS";
            this.BT_CERRAR_POS.Size = new System.Drawing.Size(75, 23);
            this.BT_CERRAR_POS.TabIndex = 1;
            this.BT_CERRAR_POS.Text = "Cerrar Pos";
            this.BT_CERRAR_POS.UseVisualStyleBackColor = true;
            this.BT_CERRAR_POS.Click += new System.EventHandler(this.BT_CERRAR_POS_Click);
            // 
            // BT_SALIDA
            // 
            this.BT_SALIDA.Location = new System.Drawing.Point(383, 342);
            this.BT_SALIDA.Name = "BT_SALIDA";
            this.BT_SALIDA.Size = new System.Drawing.Size(75, 23);
            this.BT_SALIDA.TabIndex = 2;
            this.BT_SALIDA.Text = "SALIDA";
            this.BT_SALIDA.UseVisualStyleBackColor = true;
            this.BT_SALIDA.Click += new System.EventHandler(this.BT_SALIDA_Click);
            // 
            // BT_ADM_DOCUMENTOS
            // 
            this.BT_ADM_DOCUMENTOS.Location = new System.Drawing.Point(12, 106);
            this.BT_ADM_DOCUMENTOS.Name = "BT_ADM_DOCUMENTOS";
            this.BT_ADM_DOCUMENTOS.Size = new System.Drawing.Size(75, 23);
            this.BT_ADM_DOCUMENTOS.TabIndex = 3;
            this.BT_ADM_DOCUMENTOS.Text = "Documentos";
            this.BT_ADM_DOCUMENTOS.UseVisualStyleBackColor = true;
            this.BT_ADM_DOCUMENTOS.Click += new System.EventHandler(this.BT_ADM_DOCUMENTOS_Click);
            // 
            // PrincipalFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 390);
            this.Controls.Add(this.BT_ADM_DOCUMENTOS);
            this.Controls.Add(this.BT_SALIDA);
            this.Controls.Add(this.BT_CERRAR_POS);
            this.Controls.Add(this.BT_ABRIR_POS);
            this.KeyPreview = true;
            this.Name = "PrincipalFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrincipalFrm";
            this.Load += new System.EventHandler(this.PrincipalFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_ABRIR_POS;
        private System.Windows.Forms.Button BT_CERRAR_POS;
        private System.Windows.Forms.Button BT_SALIDA;
        private System.Windows.Forms.Button BT_ADM_DOCUMENTOS;
    }
}