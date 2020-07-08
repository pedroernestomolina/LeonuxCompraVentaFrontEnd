using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Operador.Cierre
{

    public partial class CierreFrm : Form
    {


        private CtrCierre _controlador;
        private OOB.LibVenta.PosOffline.Operador.Cargar.Ficha _operador;
        private OOB.LibVenta.PosOffline.Operador.Movimiento.Ficha _movimiento;


        public CierreFrm()
        {
            InitializeComponent();
        }

        private void CierreFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            ActualizarData();
        }

        private void ActualizarData()
        {
            L_USUARIO.Text = _operador.Usuario;
            L_FECHA_HORA.Text = _operador.FechaApertura.ToShortDateString() + ", " + _operador.HoraApertura;
        }

        private void Limpiar()
        {
            L_FECHA_HORA.Text = "";
            L_USUARIO.Text = "";
        }

        public void setControlador(CtrCierre ctr)
        {
            _controlador=ctr;
        }

        public void setOperador(OOB.LibVenta.PosOffline.Operador.Cargar.Ficha ficha)
        {
            _operador = ficha;
        }

        public void setMovimientos(OOB.LibVenta.PosOffline.Operador.Movimiento.Ficha ficha)
        {
            _movimiento = ficha;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }
     
    }

}