namespace MonitorPos.Src.Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalFrm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_PRINCIPAL_ACTIVAR = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_PRINCIPAL_INACTIVAR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MENU_PRINCIPAL_SALIDA = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.P_MONITOR = new System.Windows.Forms.Panel();
            this.L_ESTATUS = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.P_MONITOR.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Settings";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.enviarDataToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(357, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENU_PRINCIPAL_ACTIVAR,
            this.MENU_PRINCIPAL_INACTIVAR,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.MENU_PRINCIPAL_SALIDA});
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.showToolStripMenuItem.Text = "Principal";
            // 
            // MENU_PRINCIPAL_ACTIVAR
            // 
            this.MENU_PRINCIPAL_ACTIVAR.Name = "MENU_PRINCIPAL_ACTIVAR";
            this.MENU_PRINCIPAL_ACTIVAR.Size = new System.Drawing.Size(152, 22);
            this.MENU_PRINCIPAL_ACTIVAR.Text = "Activar";
            this.MENU_PRINCIPAL_ACTIVAR.Click += new System.EventHandler(this.MENU_PRINCIPAL_ACTIVAR_Click);
            // 
            // MENU_PRINCIPAL_INACTIVAR
            // 
            this.MENU_PRINCIPAL_INACTIVAR.Name = "MENU_PRINCIPAL_INACTIVAR";
            this.MENU_PRINCIPAL_INACTIVAR.Size = new System.Drawing.Size(152, 22);
            this.MENU_PRINCIPAL_INACTIVAR.Text = "Inactivar";
            this.MENU_PRINCIPAL_INACTIVAR.Click += new System.EventHandler(this.MENU_PRINCIPAL_INACTIVAR_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // MENU_PRINCIPAL_SALIDA
            // 
            this.MENU_PRINCIPAL_SALIDA.Name = "MENU_PRINCIPAL_SALIDA";
            this.MENU_PRINCIPAL_SALIDA.Size = new System.Drawing.Size(152, 22);
            this.MENU_PRINCIPAL_SALIDA.Text = "Salir";
            this.MENU_PRINCIPAL_SALIDA.Click += new System.EventHandler(this.MENU_PRINCIPAL_SALIDA_Click);
            // 
            // enviarDataToolStripMenuItem1
            // 
            this.enviarDataToolStripMenuItem1.Name = "enviarDataToolStripMenuItem1";
            this.enviarDataToolStripMenuItem1.Size = new System.Drawing.Size(78, 20);
            this.enviarDataToolStripMenuItem1.Text = "Enviar Data";
            this.enviarDataToolStripMenuItem1.Click += new System.EventHandler(this.enviarDataToolStripMenuItem1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.P_MONITOR, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(357, 69);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(176, 62);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 58);
            this.label1.TabIndex = 3;
            this.label1.Text = "MONITOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P_MONITOR
            // 
            this.P_MONITOR.BackColor = System.Drawing.Color.DarkGreen;
            this.P_MONITOR.Controls.Add(this.L_ESTATUS);
            this.P_MONITOR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_MONITOR.ForeColor = System.Drawing.Color.White;
            this.P_MONITOR.Location = new System.Drawing.Point(179, 1);
            this.P_MONITOR.Margin = new System.Windows.Forms.Padding(1);
            this.P_MONITOR.Name = "P_MONITOR";
            this.P_MONITOR.Padding = new System.Windows.Forms.Padding(2);
            this.P_MONITOR.Size = new System.Drawing.Size(177, 62);
            this.P_MONITOR.TabIndex = 1;
            // 
            // L_ESTATUS
            // 
            this.L_ESTATUS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.L_ESTATUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_ESTATUS.Location = new System.Drawing.Point(2, 2);
            this.L_ESTATUS.Name = "L_ESTATUS";
            this.L_ESTATUS.Size = new System.Drawing.Size(173, 58);
            this.L_ESTATUS.TabIndex = 4;
            this.L_ESTATUS.Text = "ACTIVO";
            this.L_ESTATUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrincipalFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 93);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PrincipalFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MONITOR POS";
            this.Load += new System.EventHandler(this.PrincipalFrm_Load);
            this.Move += new System.EventHandler(this.PrincipalFrm_Move);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.P_MONITOR.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MENU_PRINCIPAL_SALIDA;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel P_MONITOR;
        private System.Windows.Forms.Label L_ESTATUS;
        private System.Windows.Forms.ToolStripMenuItem MENU_PRINCIPAL_ACTIVAR;
        private System.Windows.Forms.ToolStripMenuItem MENU_PRINCIPAL_INACTIVAR;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem enviarDataToolStripMenuItem1;
    }
}