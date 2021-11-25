using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar.Pedido
{
    
    public class Gestion: IDocGestion
    {

        private bool _abandonarDocIsOk;
        private datosDoc _datosDoc;
        private decimal _tasaDivisa;


        public bool AbandonarDocIsOk { get { return _abandonarDocIsOk; } }
        public string TipoDocumento { get { return "PEDIDO"; } }
        public IDatosDocumento HabilitarDatosDoc { get { return _datosDoc; } }
        public decimal TasaDivisa { get { return _tasaDivisa; } }


        public Gestion() 
        {
            _datosDoc = new datosDoc();
            _tasaDivisa = 0m;
        }


        public void Inicializa()
        {
            _abandonarDocIsOk = false;
            _tasaDivisa = 0m;
        }

        public bool CargarData()
        {
            var r01 = Sistema.MyData.Configuracion_FactorDivisa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _tasaDivisa = r01.Entidad;
            return true;
        }

        public void AbandonarDoc()
        {
            _abandonarDocIsOk = false;
            var msg = "Abandonar Documento En Cuestión ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                _abandonarDocIsOk = true;
            }
        }

    }

}