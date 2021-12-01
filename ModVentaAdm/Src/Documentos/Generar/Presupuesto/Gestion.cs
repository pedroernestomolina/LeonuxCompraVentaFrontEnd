using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar.Presupuesto
{
    
    public class Gestion: IDocGestion
    {

        private datosDoc _datosDoc;
        private decimal _tasaDivisa;
        private AgregarEditarItem.IGestion _itemGestion;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _sistTipoDoc;


        public string TipoDocumento { get { return "PRESUPUESTO"; } }
        public IDatosDocumento HabilitarDatosDoc { get { return _datosDoc; } }
        public decimal TasaDivisa { get { return _tasaDivisa; } }
        public AgregarEditarItem.IGestion ItemGestion { get { return _itemGestion; } }
        public OOB.Sistema.TipoDocumento.Entidad.Ficha SistTipoDocumento { get { return _sistTipoDoc; } }


        public Gestion()
        {
            _tasaDivisa = 0m;
            _datosDoc = new datosDoc();
            _itemGestion = new GestionItem();
            _sistTipoDoc = null;
        }


        public void Inicializa()
        {
            _tasaDivisa = 0m;
            _sistTipoDoc = null;
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

            var r02 = Sistema.MyData.Sistema_TipoDocumento_GetFichaById("0000000005");
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _sistTipoDoc = r02.Entidad;

            return true;
        }

    }

}