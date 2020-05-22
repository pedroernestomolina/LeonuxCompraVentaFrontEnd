namespace MovVenta.Cliente.AgregarEventual
{
    partial class AgregarEventualFrm
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
            this.TB_CI_RIF = new System.Windows.Forms.TextBox();
            this.TB_NOMBRE = new System.Windows.Forms.TextBox();
            this.TB_DIRECCION = new System.Windows.Forms.TextBox();
            this.TB_TELEFONO = new System.Windows.Forms.TextBox();
            this.BT_AGREGAR = new System.Windows.Forms.Button();
            this.BT_LIMPIAR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TB_CI_RIF
            // 
            this.TB_CI_RIF.Location = new System.Drawing.Point(30, 53);
            this.TB_CI_RIF.Name = "TB_CI_RIF";
            this.TB_CI_RIF.Size = new System.Drawing.Size(150, 20);
            this.TB_CI_RIF.TabIndex = 0;
            // 
            // TB_NOMBRE
            // 
            this.TB_NOMBRE.Location = new System.Drawing.Point(30, 92);
            this.TB_NOMBRE.Multiline = true;
            this.TB_NOMBRE.Name = "TB_NOMBRE";
            this.TB_NOMBRE.Size = new System.Drawing.Size(210, 31);
            this.TB_NOMBRE.TabIndex = 1;
            // 
            // TB_DIRECCION
            // 
            this.TB_DIRECCION.Location = new System.Drawing.Point(30, 142);
            this.TB_DIRECCION.Multiline = true;
            this.TB_DIRECCION.Name = "TB_DIRECCION";
            this.TB_DIRECCION.Size = new System.Drawing.Size(210, 31);
            this.TB_DIRECCION.TabIndex = 2;
            // 
            // TB_TELEFONO
            // 
            this.TB_TELEFONO.Location = new System.Drawing.Point(30, 193);
            this.TB_TELEFONO.Multiline = true;
            this.TB_TELEFONO.Name = "TB_TELEFONO";
            this.TB_TELEFONO.Size = new System.Drawing.Size(210, 31);
            this.TB_TELEFONO.TabIndex = 3;
            // 
            // BT_AGREGAR
            // 
            this.BT_AGREGAR.Location = new System.Drawing.Point(165, 230);
            this.BT_AGREGAR.Name = "BT_AGREGAR";
            this.BT_AGREGAR.Size = new System.Drawing.Size(75, 23);
            this.BT_AGREGAR.TabIndex = 5;
            this.BT_AGREGAR.Text = "Agregar";
            this.BT_AGREGAR.UseVisualStyleBackColor = true;
            this.BT_AGREGAR.Click += new System.EventHandler(this.BT_AGREGAR_Click);
            // 
            // BT_LIMPIAR
            // 
            this.BT_LIMPIAR.Location = new System.Drawing.Point(84, 230);
            this.BT_LIMPIAR.Name = "BT_LIMPIAR";
            this.BT_LIMPIAR.Size = new System.Drawing.Size(75, 23);
            this.BT_LIMPIAR.TabIndex = 4;
            this.BT_LIMPIAR.Text = "Limpiar";
            this.BT_LIMPIAR.UseVisualStyleBackColor = true;
            this.BT_LIMPIAR.Click += new System.EventHandler(this.BT_LIMPIAR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "CI/RIF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "NOMBRE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DIRECCION:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "TELEFONO:";
            // 
            // AgregarEventualFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 294);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_LIMPIAR);
            this.Controls.Add(this.BT_AGREGAR);
            this.Controls.Add(this.TB_TELEFONO);
            this.Controls.Add(this.TB_DIRECCION);
            this.Controls.Add(this.TB_NOMBRE);
            this.Controls.Add(this.TB_CI_RIF);
            this.Name = "AgregarEventualFrm";
            this.Text = "AgregarEventualFrm";
            this.Load += new System.EventHandler(this.AgregarEventualFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_CI_RIF;
        private System.Windows.Forms.TextBox TB_NOMBRE;
        private System.Windows.Forms.TextBox TB_DIRECCION;
        private System.Windows.Forms.TextBox TB_TELEFONO;
        private System.Windows.Forms.Button BT_AGREGAR;
        private System.Windows.Forms.Button BT_LIMPIAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}