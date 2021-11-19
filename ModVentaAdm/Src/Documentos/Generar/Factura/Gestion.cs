using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar.Factura
{
    
    public class Gestion: IDocGestion
    {

        private bool _abandonarDocIsOk;
        private datosDoc _datosDoc;
        private decimal _tasaDivisa;


        public bool AbandonarDocIsOk { get { return _abandonarDocIsOk; } }
        public string TipoDocumento { get { return "FACTURA"; } }
        public IDatosDocumento HabilitarDatosDoc { get { return _datosDoc; } }
        public decimal TasaDivisa { get { return _tasaDivisa; ; } }


        public Gestion() 
        {
            _tasaDivisa = 0m;
            _datosDoc = new datosDoc();
        }


        public void Inicializa()
        {
            _tasaDivisa = 0m;
            _abandonarDocIsOk = false;
        }

        public bool CargarData()
        {
            _tasaDivisa = 5m;
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