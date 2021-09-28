using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MonitorPos.Src.Principal
{

    public partial class PrincipalFrm : Form
    {

        private Timer _timer;
        private bool _estatusIsActivo;


        public PrincipalFrm()
        {
            InitializeComponent();
            _timer = timer1;
            _timer.Interval = Sistema.TiempoMonitorCierreResumen;
            _timer.Tick+= _timer_Tick;
            _estatusIsActivo = false;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            notifyIcon1.ShowBalloonTip(500, "Importante", "HACIENDO EL MONITOREO", ToolTipIcon.Info);
            Monitorear();
            _timer.Start();
        }

        private void ActivarMonitoreo()
        {
            var msg = MessageBox.Show("Activar WIFI Telefono Para Realizar Monitoreo ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                Monitorear();
            }
        }

        private void Monitorear()
        {
            Monitor.ResumenDia(Sistema.IdEquipo);
            if (Sistema.ActivarMonitorCierreResumen)
                Monitor.Resumen();
        }

        private void PrincipalFrm_Move(object sender, EventArgs e)
        {
            if (this.WindowState== FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "Importante", "MONITOR POS EN ACCION", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void MENU_PRINCIPAL_SALIDA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MENU_PRINCIPAL_SHOW_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void MENU_PRINCIPAL_ACTIVAR_Click(object sender, EventArgs e)
        {
            Activar();
        }

        private void Activar()
        {
            _timer.Start();
            _estatusIsActivo = true;
            Estatus();
        }

        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
            if (Sistema.ActivarMonitorCierreResumen)
                Activar();
        }

        private void MENU_PRINCIPAL_INACTIVAR_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _estatusIsActivo = false;
            Estatus();
        }

        private void Estatus()
        {
            if (_estatusIsActivo) 
            {
                L_ESTATUS.Text = "ACTIVO";
                P_MONITOR.BackColor = Color.Green;
            }
            else
            {
                L_ESTATUS.Text = "INACTIVO";
                P_MONITOR.BackColor = Color.Red;
            }
        }

        private void enviarDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            ActivarMonitoreo();
            _timer.Start();
        }

    }

}