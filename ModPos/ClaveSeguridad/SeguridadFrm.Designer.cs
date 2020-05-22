namespace ModPos.ClaveSeguridad
{
    partial class SeguridadFrm
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
            this.TB_CLAVE = new System.Windows.Forms.TextBox();
            this.BT_ACEPTAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave De Acceso:";
            // 
            // TB_CLAVE
            // 
            this.TB_CLAVE.Location = new System.Drawing.Point(45, 57);
            this.TB_CLAVE.Name = "TB_CLAVE";
            this.TB_CLAVE.Size = new System.Drawing.Size(220, 20);
            this.TB_CLAVE.TabIndex = 0;
            // 
            // BT_ACEPTAR
            // 
            this.BT_ACEPTAR.Location = new System.Drawing.Point(190, 83);
            this.BT_ACEPTAR.Name = "BT_ACEPTAR";
            this.BT_ACEPTAR.Size = new System.Drawing.Size(75, 23);
            this.BT_ACEPTAR.TabIndex = 1;
            this.BT_ACEPTAR.Text = "Aceptar";
            this.BT_ACEPTAR.UseVisualStyleBackColor = true;
            this.BT_ACEPTAR.Click += new System.EventHandler(this.BT_ACEPTAR_Click);
            // 
            // SeguridadFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 141);
            this.Controls.Add(this.BT_ACEPTAR);
            this.Controls.Add(this.TB_CLAVE);
            this.Controls.Add(this.label1);
            this.Name = "SeguridadFrm";
            this.Text = "SeguridadFrm";
            this.Load += new System.EventHandler(this.SeguridadFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_CLAVE;
        private System.Windows.Forms.Button BT_ACEPTAR;
    }
}