namespace ModPos.Identificacion
{
    partial class IdentificacionFrm
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
            this.BT_ACEPTAR = new System.Windows.Forms.Button();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.TB_CODIGO = new System.Windows.Forms.TextBox();
            this.TB_CLAVE = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_ACEPTAR
            // 
            this.BT_ACEPTAR.Location = new System.Drawing.Point(214, 149);
            this.BT_ACEPTAR.Name = "BT_ACEPTAR";
            this.BT_ACEPTAR.Size = new System.Drawing.Size(75, 23);
            this.BT_ACEPTAR.TabIndex = 2;
            this.BT_ACEPTAR.Text = "Aceptar";
            this.BT_ACEPTAR.UseVisualStyleBackColor = true;
            this.BT_ACEPTAR.Click += new System.EventHandler(this.BT_ACEPTAR_Click);
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Location = new System.Drawing.Point(295, 149);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(75, 23);
            this.BT_SALIR.TabIndex = 3;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // TB_CODIGO
            // 
            this.TB_CODIGO.Location = new System.Drawing.Point(59, 62);
            this.TB_CODIGO.Name = "TB_CODIGO";
            this.TB_CODIGO.Size = new System.Drawing.Size(163, 20);
            this.TB_CODIGO.TabIndex = 0;
            // 
            // TB_CLAVE
            // 
            this.TB_CLAVE.Location = new System.Drawing.Point(59, 102);
            this.TB_CLAVE.Name = "TB_CLAVE";
            this.TB_CLAVE.Size = new System.Drawing.Size(163, 20);
            this.TB_CLAVE.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Clave:";
            // 
            // IdentificacionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 184);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_CLAVE);
            this.Controls.Add(this.TB_CODIGO);
            this.Controls.Add(this.BT_SALIR);
            this.Controls.Add(this.BT_ACEPTAR);
            this.Name = "IdentificacionFrm";
            this.Text = "IdentificacionFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IdentificacionFrm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_ACEPTAR;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.TextBox TB_CODIGO;
        private System.Windows.Forms.TextBox TB_CLAVE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}