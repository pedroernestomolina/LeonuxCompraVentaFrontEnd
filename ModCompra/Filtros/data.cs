using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Filtros
{
    
    public class data
    {
        
        private DateTime _fechaDesde;
        private DateTime _fechaHasta;
        private OOB.LibCompra.Sucursal.Data.Ficha _sucursal;
        private tipoDoc _tipoDoc;


        public DateTime FechaDesde { get { return _fechaDesde; } }
        public DateTime FechaHasta { get { return _fechaHasta; } }
        public OOB.LibCompra.Sucursal.Data.Ficha Sucursal { get { return _sucursal; } }
        public tipoDoc TipoDoc { get { return _tipoDoc; } }


        public data()
        {
            InicializarFiltros();
        }


        public void InicializarFiltros()
        {
            _fechaDesde = DateTime.Now.Date;
            _fechaHasta = DateTime.Now.Date;
            _sucursal = null;
            _tipoDoc = null;
        }

        public void setFechaDesde(DateTime fecha)
        {
            _fechaDesde = fecha;
        }

        public void setFechaHasta(DateTime fecha)
        {
            _fechaHasta= fecha;
        }

        public bool FechaIsOk()
        {
            if (_fechaDesde.Date > _fechaHasta.Date)
            {
                Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                return false;
            }
            else
                return true;
        }

        public void setSucursal(OOB.LibCompra.Sucursal.Data.Ficha ficha)
        {
            _sucursal = ficha;
        }

        public void setTipoDoc(tipoDoc tipoDoc)
        {
            _tipoDoc = tipoDoc;
        }

    }

}