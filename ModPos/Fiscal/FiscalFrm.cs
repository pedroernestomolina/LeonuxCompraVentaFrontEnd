using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Fiscal
{

    public partial class FiscalFrm : Form
    {


        private CtrFiscal _controlador;


        public FiscalFrm()
        {
            InitializeComponent();
        }

        private void FiscalFrm_Load(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void LimpiarDatos()
        {
            L_FACTURA.Text = "";
            L_FECHA.Text="";
            L_HORA.Text="";
            L_RIF.Text="";
            L_SERIAL.Text="";
            L_Z.Text="";
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void RB_RANGO_Z_CheckedChanged(object sender, EventArgs e)
        {
            TB_RANGO_DESDE.Enabled = RB_RANGO_Z.Checked;
            TB_RANGO_HASTA.Enabled = RB_RANGO_Z.Checked;  
        }

        private void RB_RANGO_FECHA_CheckedChanged(object sender, EventArgs e)
        {
            DTP_DESDE.Enabled = RB_RANGO_FECHA.Checked;
            DTP_HASTA.Enabled = RB_RANGO_FECHA.Checked;
        }

        private void BT_FISCAL_Click(object sender, EventArgs e)
        {
            DatosFiscal();
            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            L_FACTURA.Text = _controlador.DatosFiscal.Factura ;
            L_FECHA.Text = _controlador.DatosFiscal.Fecha;
            L_HORA.Text = _controlador.DatosFiscal.Hora;
            L_RIF.Text = _controlador.DatosFiscal.Rif;
            L_SERIAL.Text = _controlador.DatosFiscal.Serial;
            L_Z.Text = _controlador.DatosFiscal.Z;
        }

        private void DatosFiscal()
        {
            _controlador.ObtenerDatosFiscal();
            ActualizarDatos();
        }

        private void BT_CORTE_CIERRE_Click(object sender, EventArgs e)
        {
            CorteCierre();
        }

        private void CorteCierre()
        {
            if (RB_X_FISCAL.Checked)
            {
                _controlador.CorteFiscal(Enumerados.EnumCorteFiscal.CorteX);
            }
            if (RB_Z_FISCAL.Checked)
            {
                _controlador.CorteFiscal(Enumerados.EnumCorteFiscal.CorteZ);
            }
        }

        private void BT_MEMORIA_Click(object sender, EventArgs e)
        {
            MemoriaFiscal();
        }

        private void MemoriaFiscal()
        {
            if (RB_RANGO_Z.Checked) 
            {
                var desde = int.Parse(TB_RANGO_DESDE.Text);
                var hasta = int.Parse(TB_RANGO_HASTA.Text);
                _controlador.MemoriaRangoZ(desde, hasta);
            }
            if (RB_RANGO_FECHA.Checked)
            {
                var desde = DTP_DESDE.Value.Date;
                var hasta = DTP_HASTA.Value.Date;
                _controlador.MemoriaRangoFecha(desde, hasta);
            }
        }

        private void BT_REIMPRESION_Click(object sender, EventArgs e)
        {
            ReimpresionDocumentos();
        }

        private void ReimpresionDocumentos()
        {
            var tipoDocumento = Enumerados.EnumTipoDocumento.SinDefinir;
            if (CB_TIPO_DOCUMENTO.SelectedIndex == 0)
                tipoDocumento = Enumerados.EnumTipoDocumento.Factura;
            if (CB_TIPO_DOCUMENTO.SelectedIndex == 1)
                tipoDocumento = Enumerados.EnumTipoDocumento.NotaCredito;
            var desde = int.Parse(TB_DOCUMENTO_DESDE.Text);
            var hasta = int.Parse(TB_DOCUMENTO_HASTA.Text);
            _controlador.ReimprimirDocumentos(tipoDocumento, desde, hasta);
        }

        public void setControlador(CtrFiscal ctr) 
        {
            _controlador = ctr;
        }

    }

}