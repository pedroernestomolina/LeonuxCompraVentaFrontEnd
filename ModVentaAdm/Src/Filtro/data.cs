using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Filtro
{
    
    public class data
    {


        private DateTime _desde;
        private DateTime _hasta;
        private OOB.Sucursal.Entidad.Ficha _sucursal;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _tipoDoc;


        public DateTime Desde { get { return _desde; } }
        public DateTime Hasta { get { return _hasta; } }
        public OOB.Sucursal.Entidad.Ficha Sucursal;
        public OOB.Sistema.TipoDocumento.Entidad.Ficha TipoDocumento;


        public data()
        {
            limpiar();
        }


        public void Inicializar()
        {
            limpiar();
        }

        private void limpiar()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _sucursal = null;
            _tipoDoc = null;
        }

        public void setFechaDesde(DateTime fecha)
        {
            _desde = fecha;
        }

        public void setFechaHasta(DateTime fecha)
        {
            _hasta = fecha;
        }

        public void setSucursal(OOB.Sucursal.Entidad.Ficha ficha)
        {
            _sucursal = ficha;
        }

        public void setTipoDoc(OOB.Sistema.TipoDocumento.Entidad.Ficha ficha)
        {
            _tipoDoc = ficha;
        }

        public bool FechaIsOk()
        {
            return _hasta >= _desde;
        }

    }

}