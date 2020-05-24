namespace ModPos
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
            this.BT_POS = new System.Windows.Forms.Button();
            this.BT_SALIDA = new System.Windows.Forms.Button();
            this.BT_ACTUALIZAR_DATA = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BT_CONFIGURACION = new System.Windows.Forms.Button();
            this.BT_ADM_DOC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_POS
            // 
            this.BT_POS.Location = new System.Drawing.Point(12, 106);
            this.BT_POS.Name = "BT_POS";
            this.BT_POS.Size = new System.Drawing.Size(181, 23);
            this.BT_POS.TabIndex = 3;
            this.BT_POS.Text = "POS";
            this.BT_POS.UseVisualStyleBackColor = true;
            this.BT_POS.Click += new System.EventHandler(this.BT_POS_Click);
            // 
            // BT_SALIDA
            // 
            this.BT_SALIDA.Location = new System.Drawing.Point(12, 193);
            this.BT_SALIDA.Name = "BT_SALIDA";
            this.BT_SALIDA.Size = new System.Drawing.Size(75, 23);
            this.BT_SALIDA.TabIndex = 6;
            this.BT_SALIDA.Text = "SALIDA";
            this.BT_SALIDA.UseVisualStyleBackColor = true;
            this.BT_SALIDA.Click += new System.EventHandler(this.BT_SALIDA_Click);
            // 
            // BT_ACTUALIZAR_DATA
            // 
            this.BT_ACTUALIZAR_DATA.Location = new System.Drawing.Point(12, 19);
            this.BT_ACTUALIZAR_DATA.Name = "BT_ACTUALIZAR_DATA";
            this.BT_ACTUALIZAR_DATA.Size = new System.Drawing.Size(181, 23);
            this.BT_ACTUALIZAR_DATA.TabIndex = 0;
            this.BT_ACTUALIZAR_DATA.Text = "ACTUALIZAR DATA SERVIDOR";
            this.BT_ACTUALIZAR_DATA.UseVisualStyleBackColor = true;
            this.BT_ACTUALIZAR_DATA.Click += new System.EventHandler(this.BT_ACTUALIZAR_DATA_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "INICIAR JORNADA";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "ABRIR OPERADOR";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // BT_CONFIGURACION
            // 
            this.BT_CONFIGURACION.Location = new System.Drawing.Point(12, 164);
            this.BT_CONFIGURACION.Name = "BT_CONFIGURACION";
            this.BT_CONFIGURACION.Size = new System.Drawing.Size(181, 23);
            this.BT_CONFIGURACION.TabIndex = 5;
            this.BT_CONFIGURACION.Text = "CONFIGURAR SISTEMA";
            this.BT_CONFIGURACION.UseVisualStyleBackColor = true;
            this.BT_CONFIGURACION.Click += new System.EventHandler(this.BT_CONFIGURACION_Click);
            // 
            // BT_ADM_DOC
            // 
            this.BT_ADM_DOC.Location = new System.Drawing.Point(12, 135);
            this.BT_ADM_DOC.Name = "BT_ADM_DOC";
            this.BT_ADM_DOC.Size = new System.Drawing.Size(181, 23);
            this.BT_ADM_DOC.TabIndex = 4;
            this.BT_ADM_DOC.Text = "ADMINISTRADOR DOC";
            this.BT_ADM_DOC.UseVisualStyleBackColor = true;
            this.BT_ADM_DOC.Click += new System.EventHandler(this.BT_ADM_DOC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BT_ADM_DOC);
            this.Controls.Add(this.BT_CONFIGURACION);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BT_ACTUALIZAR_DATA);
            this.Controls.Add(this.BT_SALIDA);
            this.Controls.Add(this.BT_POS);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_POS;
        private System.Windows.Forms.Button BT_SALIDA;
        private System.Windows.Forms.Button BT_ACTUALIZAR_DATA;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BT_CONFIGURACION;
        private System.Windows.Forms.Button BT_ADM_DOC;
    }
}

