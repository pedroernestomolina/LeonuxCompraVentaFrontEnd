namespace ModInventario.Filtros
{
    partial class FiltroFrm
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.panel17 = new System.Windows.Forms.Panel();
            this.BT_FILTRAR = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BT_LIMPIAR = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.CB_DEP_DESTINO = new System.Windows.Forms.ComboBox();
            this.panel22 = new System.Windows.Forms.Panel();
            this.L_ESTATUS = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.L_DEP_DESTINO = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.CB_DEP_ORIGEN = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.L_DEP_ORIGEN = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.CB_ESTATUS = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 40);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel9, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel17, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 40);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.BT_SALIR);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(340, 1);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2);
            this.panel9.Size = new System.Drawing.Size(114, 38);
            this.panel9.TabIndex = 1;
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_SALIR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_SALIR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_SALIR.Image = global::ModInventario.Properties.Resources.bt_salida_2;
            this.BT_SALIR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_SALIR.Location = new System.Drawing.Point(2, 2);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(110, 34);
            this.BT_SALIR.TabIndex = 2;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_SALIR.UseVisualStyleBackColor = true;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.BT_FILTRAR);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(227, 1);
            this.panel17.Margin = new System.Windows.Forms.Padding(1);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2);
            this.panel17.Size = new System.Drawing.Size(111, 38);
            this.panel17.TabIndex = 0;
            // 
            // BT_FILTRAR
            // 
            this.BT_FILTRAR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BT_FILTRAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_FILTRAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_FILTRAR.Image = global::ModInventario.Properties.Resources.bt_ok_3;
            this.BT_FILTRAR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BT_FILTRAR.Location = new System.Drawing.Point(2, 2);
            this.BT_FILTRAR.Name = "BT_FILTRAR";
            this.BT_FILTRAR.Size = new System.Drawing.Size(107, 34);
            this.BT_FILTRAR.TabIndex = 3;
            this.BT_FILTRAR.Text = "Procesar";
            this.BT_FILTRAR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.BT_FILTRAR.UseVisualStyleBackColor = true;
            this.BT_FILTRAR.Click += new System.EventHandler(this.BT_FILTRAR_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(455, 29);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar Por:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BT_LIMPIAR
            // 
            this.BT_LIMPIAR.BackgroundImage = global::ModInventario.Properties.Resources.bt_limpiar;
            this.BT_LIMPIAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BT_LIMPIAR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_LIMPIAR.Location = new System.Drawing.Point(2, 2);
            this.BT_LIMPIAR.Name = "BT_LIMPIAR";
            this.BT_LIMPIAR.Size = new System.Drawing.Size(58, 26);
            this.BT_LIMPIAR.TabIndex = 0;
            this.toolTip1.SetToolTip(this.BT_LIMPIAR, "LImpiar Filtros de Busqueda");
            this.BT_LIMPIAR.UseVisualStyleBackColor = true;
            this.BT_LIMPIAR.Click += new System.EventHandler(this.BT_LIMPIAR_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.41497F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.58503F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel22, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel16, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel23, 1, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 456);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.CB_DEP_DESTINO);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(147, 63);
            this.panel8.Margin = new System.Windows.Forms.Padding(1);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2);
            this.panel8.Size = new System.Drawing.Size(243, 28);
            this.panel8.TabIndex = 2;
            // 
            // CB_DEP_DESTINO
            // 
            this.CB_DEP_DESTINO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_DEP_DESTINO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DEP_DESTINO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DEP_DESTINO.FormattingEnabled = true;
            this.CB_DEP_DESTINO.Location = new System.Drawing.Point(2, 2);
            this.CB_DEP_DESTINO.Name = "CB_DEP_DESTINO";
            this.CB_DEP_DESTINO.Size = new System.Drawing.Size(239, 24);
            this.CB_DEP_DESTINO.TabIndex = 1;
            this.CB_DEP_DESTINO.SelectedIndexChanged += new System.EventHandler(this.CB_DEP_DESTINO_SelectedIndexChanged);
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.L_ESTATUS);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(1, 93);
            this.panel22.Margin = new System.Windows.Forms.Padding(1);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(2);
            this.panel22.Size = new System.Drawing.Size(144, 28);
            this.panel22.TabIndex = 14;
            // 
            // L_ESTATUS
            // 
            this.L_ESTATUS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_ESTATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_ESTATUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ESTATUS.ForeColor = System.Drawing.Color.Blue;
            this.L_ESTATUS.Location = new System.Drawing.Point(2, 2);
            this.L_ESTATUS.Name = "L_ESTATUS";
            this.L_ESTATUS.Size = new System.Drawing.Size(140, 24);
            this.L_ESTATUS.TabIndex = 4;
            this.L_ESTATUS.Text = "Estatus:";
            this.L_ESTATUS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.L_ESTATUS.Click += new System.EventHandler(this.L_ESTATUS_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.L_DEP_DESTINO);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(1, 63);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(2);
            this.panel7.Size = new System.Drawing.Size(144, 28);
            this.panel7.TabIndex = 1;
            // 
            // L_DEP_DESTINO
            // 
            this.L_DEP_DESTINO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_DEP_DESTINO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_DEP_DESTINO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DEP_DESTINO.ForeColor = System.Drawing.Color.Blue;
            this.L_DEP_DESTINO.Location = new System.Drawing.Point(2, 2);
            this.L_DEP_DESTINO.Name = "L_DEP_DESTINO";
            this.L_DEP_DESTINO.Size = new System.Drawing.Size(140, 24);
            this.L_DEP_DESTINO.TabIndex = 1;
            this.L_DEP_DESTINO.Text = "Depósito Destinio:";
            this.L_DEP_DESTINO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.L_DEP_DESTINO.Click += new System.EventHandler(this.L_DEP_DESTINO_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.CB_DEP_ORIGEN);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(147, 33);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(243, 28);
            this.panel6.TabIndex = 1;
            // 
            // CB_DEP_ORIGEN
            // 
            this.CB_DEP_ORIGEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_DEP_ORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DEP_ORIGEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_DEP_ORIGEN.FormattingEnabled = true;
            this.CB_DEP_ORIGEN.Location = new System.Drawing.Point(2, 2);
            this.CB_DEP_ORIGEN.Name = "CB_DEP_ORIGEN";
            this.CB_DEP_ORIGEN.Size = new System.Drawing.Size(239, 24);
            this.CB_DEP_ORIGEN.TabIndex = 0;
            this.CB_DEP_ORIGEN.SelectedIndexChanged += new System.EventHandler(this.CB_DEP_ORIGEN_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.L_DEP_ORIGEN);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(1, 33);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(144, 28);
            this.panel5.TabIndex = 1;
            // 
            // L_DEP_ORIGEN
            // 
            this.L_DEP_ORIGEN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.L_DEP_ORIGEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_DEP_ORIGEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_DEP_ORIGEN.ForeColor = System.Drawing.Color.Blue;
            this.L_DEP_ORIGEN.Location = new System.Drawing.Point(2, 2);
            this.L_DEP_ORIGEN.Name = "L_DEP_ORIGEN";
            this.L_DEP_ORIGEN.Size = new System.Drawing.Size(140, 24);
            this.L_DEP_ORIGEN.TabIndex = 0;
            this.L_DEP_ORIGEN.Text = "Depósito Origen:";
            this.L_DEP_ORIGEN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.L_DEP_ORIGEN.Click += new System.EventHandler(this.L_DEP_ORIGEN_Click);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.BT_LIMPIAR);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(392, 1);
            this.panel16.Margin = new System.Windows.Forms.Padding(1);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(2);
            this.panel16.Size = new System.Drawing.Size(62, 30);
            this.panel16.TabIndex = 14;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.CB_ESTATUS);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel23.Location = new System.Drawing.Point(147, 93);
            this.panel23.Margin = new System.Windows.Forms.Padding(1);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2);
            this.panel23.Size = new System.Drawing.Size(243, 28);
            this.panel23.TabIndex = 8;
            // 
            // CB_ESTATUS
            // 
            this.CB_ESTATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CB_ESTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ESTATUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_ESTATUS.FormattingEnabled = true;
            this.CB_ESTATUS.Location = new System.Drawing.Point(2, 2);
            this.CB_ESTATUS.Name = "CB_ESTATUS";
            this.CB_ESTATUS.Size = new System.Drawing.Size(239, 24);
            this.CB_ESTATUS.TabIndex = 5;
            this.CB_ESTATUS.SelectedIndexChanged += new System.EventHandler(this.CB_ESTATUS_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(455, 456);
            this.panel3.TabIndex = 5;
            // 
            // FiltroFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.BT_SALIR;
            this.ClientSize = new System.Drawing.Size(455, 525);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "FiltroFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FiltroFrm_Load);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Button BT_FILTRAR;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox CB_DEP_DESTINO;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label L_ESTATUS;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label L_DEP_DESTINO;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox CB_DEP_ORIGEN;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label L_DEP_ORIGEN;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button BT_LIMPIAR;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.ComboBox CB_ESTATUS;
        private System.Windows.Forms.Panel panel3;

    }
}