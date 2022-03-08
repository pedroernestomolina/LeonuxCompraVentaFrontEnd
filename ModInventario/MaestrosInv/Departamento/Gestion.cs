using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv.Departamento
{
    
    public class Gestion: IMaestroTipo
    {

        private data _itemAgregarEditar;
        private List<data> _lst;


        public string Titulo { get { return "Maestro: DEPARTAMENTOS"; } }
        public bool AgregarIsOk { get { return false; } }
        public bool EditarIsOk { get { return false; } }
        public bool EliminarIsOK { get { return false; } }
        public List<data> ListaData { get { return _lst; } }


        public Gestion(ISeguridadAccesoSistema seguridad, 
            IAgregarEditar agregar, 
            IAgregarEditar editar) 
        {
            _itemAgregarEditar = null;
            _lst = new List<data>();
        }


        public void Inicializa()
        {
            _itemAgregarEditar = null;
            _lst.Clear();
        }

        public bool CargarData()
        {
            var r01 = Sistema.MyData.Departamento_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _lst.Clear();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lst.Add(new data(rg.auto, rg.codigo, rg.nombre));
            }
            return true;
        }

    }

}