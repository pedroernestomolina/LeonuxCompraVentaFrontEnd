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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_ARCHIVO_SALIR = new System.Windows.Forms.ToolStripMenuItem();
            this.maestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_MAESTROS_Departamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_MAESTRO_Grupo = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_MAESTRO_Marcas = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_MAESTRO_EmpaquesMedida = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.conceptosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_AJUSTE_DefinirNivelMinimoMaximo = new System.Windows.Forms.ToolStripMenuItem();
            this.movimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.L_VERSION = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 247);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 54);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 54);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BT_SALIR);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(406, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(136, 52);
            this.panel2.TabIndex = 0;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Location = new System.Drawing.Point(2, 2);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(132, 48);
            this.BT_SALIR.TabIndex = 0;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.maestrosToolStripMenuItem,
            this.ajustesToolStripMenuItem,
            this.movimientosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(543, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_ARCHIVO_SALIR});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // TSM_ARCHIVO_SALIR
            // 
            this.TSM_ARCHIVO_SALIR.Name = "TSM_ARCHIVO_SALIR";
            this.TSM_ARCHIVO_SALIR.Size = new System.Drawing.Size(96, 22);
            this.TSM_ARCHIVO_SALIR.Text = "Salir";
            this.TSM_ARCHIVO_SALIR.Click += new System.EventHandler(this.TSM_ARCHIVO_SALIR_Click);
            // 
            // maestrosToolStripMenuItem
            // 
            this.maestrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.TSM_MAESTROS_Departamentos,
            this.TSM_MAESTRO_Grupo,
            this.TSM_MAESTRO_Marcas,
            this.TSM_MAESTRO_EmpaquesMedida,
            this.toolStripMenuItem1,
            this.conceptosToolStripMenuItem});
            this.maestrosToolStripMenuItem.Name = "maestrosToolStripMenuItem";
            this.maestrosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.maestrosToolStripMenuItem.Text = "Maestros";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // TSM_MAESTROS_Departamentos
            // 
            this.TSM_MAESTROS_Departamentos.Name = "TSM_MAESTROS_Departamentos";
            this.TSM_MAESTROS_Departamentos.Size = new System.Drawing.Size(277, 22);
            this.TSM_MAESTROS_Departamentos.Text = "Departamentos";
            this.TSM_MAESTROS_Departamentos.Click += new System.EventHandler(this.TSM_MAESTROS_Departamentos_Click);
            // 
            // TSM_MAESTRO_Grupo
            // 
            this.TSM_MAESTRO_Grupo.Name = "TSM_MAESTRO_Grupo";
            this.TSM_MAESTRO_Grupo.Size = new System.Drawing.Size(277, 22);
            this.TSM_MAESTRO_Grupo.Text = "Grupos";
            this.TSM_MAESTRO_Grupo.Click += new System.EventHandler(this.TSM_MAESTRO_Grupo_Click);
            // 
            // TSM_MAESTRO_Marcas
            // 
            this.TSM_MAESTRO_Marcas.Name = "TSM_MAESTRO_Marcas";
            this.TSM_MAESTRO_Marcas.Size = new System.Drawing.Size(277, 22);
            this.TSM_MAESTRO_Marcas.Text = "Marcas";
            this.TSM_MAESTRO_Marcas.Click += new System.EventHandler(this.TSM_MAESTRO_Marcas_Click);
            // 
            // TSM_MAESTRO_EmpaquesMedida
            // 
            this.TSM_MAESTRO_EmpaquesMedida.Name = "TSM_MAESTRO_EmpaquesMedida";
            this.TSM_MAESTRO_EmpaquesMedida.Size = new System.Drawing.Size(277, 22);
            this.TSM_MAESTRO_EmpaquesMedida.Text = "Unidades Empaque/Medidas";
            this.TSM_MAESTRO_EmpaquesMedida.Click += new System.EventHandler(this.TSM_MAESTRO_EmpaquesMedida_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(274, 6);
            // 
            // conceptosToolStripMenuItem
            // 
            this.conceptosToolStripMenuItem.Name = "conceptosToolStripMenuItem";
            this.conceptosToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.conceptosToolStripMenuItem.Text = "Conceptos Movimientos De Inventario";
            // 
            // ajustesToolStripMenuItem
            // 
            this.ajustesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_AJUSTE_DefinirNivelMinimoMaximo});
            this.ajustesToolStripMenuItem.Name = "ajustesToolStripMenuItem";
            this.ajustesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.ajustesToolStripMenuItem.Text = "Ajustes";
            // 
            // TSM_AJUSTE_DefinirNivelMinimoMaximo
            // 
            this.TSM_AJUSTE_DefinirNivelMinimoMaximo.Name = "TSM_AJUSTE_DefinirNivelMinimoMaximo";
            this.TSM_AJUSTE_DefinirNivelMinimoMaximo.Size = new System.Drawing.Size(323, 22);
            this.TSM_AJUSTE_DefinirNivelMinimoMaximo.Text = "Definir Nivel Minimo/Maximo de los Productos";
            this.TSM_AJUSTE_DefinirNivelMinimoMaximo.Click += new System.EventHandler(this.TSM_AJUSTE_DefinirNivelMinimoMaximo_Click);
            // 
            // movimientosToolStripMenuItem
            // 
            this.movimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO});
            this.movimientosToolStripMenuItem.Name = "movimientosToolStripMenuItem";
            this.movimientosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.movimientosToolStripMenuItem.Text = "Movimientos";
            // 
            // TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO
            // 
            this.TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO.Name = "TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO";
            this.TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO.Size = new System.Drawing.Size(356, 22);
            this.TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO.Text = "Traslado Mercancia Por Existencia Debajo del Minimo";
            this.TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO.Click += new System.EventHandler(this.TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Azure;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 223);
            this.panel3.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.32781F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.67219F));
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(543, 223);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 187);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(292, 35);
            this.panel4.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(288, 31);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 1);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(200, 29);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tools De Inventario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.L_VERSION);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(203, 1);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(105, 29);
            this.panel6.TabIndex = 1;
            // 
            // L_VERSION
            // 
            this.L_VERSION.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_VERSION.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_VERSION.Location = new System.Drawing.Point(2, 2);
            this.L_VERSION.Name = "L_VERSION";
            this.L_VERSION.Size = new System.Drawing.Size(101, 25);
            this.L_VERSION.TabIndex = 0;
            this.L_VERSION.Text = "Ver 1.0.0.0";
            this.L_VERSION.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 301);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools De Inventario";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSM_ARCHIVO_SALIR;
        private System.Windows.Forms.ToolStripMenuItem ajustesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSM_AJUSTE_DefinirNivelMinimoMaximo;
        private System.Windows.Forms.ToolStripMenuItem movimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label L_VERSION;
        private System.Windows.Forms.ToolStripMenuItem maestrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSM_MAESTROS_Departamentos;
        private System.Windows.Forms.ToolStripMenuItem TSM_MAESTRO_Grupo;
        private System.Windows.Forms.ToolStripMenuItem TSM_MAESTRO_Marcas;
        private System.Windows.Forms.ToolStripMenuItem TSM_MAESTRO_EmpaquesMedida;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem conceptosToolStripMenuItem;
    }
}

