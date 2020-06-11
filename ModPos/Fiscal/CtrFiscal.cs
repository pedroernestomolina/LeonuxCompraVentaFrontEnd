using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Fiscal
{


    public class CtrFiscal
    {


        public class Datos
        {
            public string Rif { get; set; }
            public string Serial { get; set; }
            public string Fecha { get; set; }
            public string Hora { get; set; }
            public string Factura { get; set; }
            public string Z { get; set; }


            public Datos()
            {
                Rif = "";
                Serial="";
                Fecha="";
                Hora="";
                Factura = "";
                Z = "";
            }
        }


        public Datos DatosFiscal { get; set; }


        public CtrFiscal()
        {
            DatosFiscal = new Datos();
        }


        public void Activar() 
        {
            var frm = new FiscalFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void ObtenerDatosFiscal() 
        {
            DatosFiscal.Factura = "";
            DatosFiscal.Rif = "";
            DatosFiscal.Fecha="";
            DatosFiscal.Hora="";
            DatosFiscal.Serial="";
            DatosFiscal.Z="";
        }

        public void CorteFiscal(Enumerados.EnumCorteFiscal corte)
        {
            if (corte == Enumerados.EnumCorteFiscal.CorteZ)
            {
                var msg = MessageBox.Show("Estas Seguro De Realizar La Operación ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                }
            }
            else 
            {
            }
        }

        public void MemoriaRangoZ(int desde, int hasta)
        {
        }

        public void MemoriaRangoFecha(DateTime desde, DateTime hasta)
        {
        }

        public void ReimprimirDocumentos(Enumerados.EnumTipoDocumento tipo, int desde, int hasta)
        {
        }

    }

}