using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Filtros
{
    
    public class data
    {
        
        private DateTime? _fechaDesde;
        private DateTime? _fechaHasta;


        public DateTime? FechaDesde { get { return _fechaDesde; } }
        public DateTime? FechaHasta { get { return _fechaHasta; } }


        public data()
        {
            InicializarFiltros();
        }


        public void InicializarFiltros()
        {
            _fechaDesde = DateTime.Now.Date;
            _fechaHasta = DateTime.Now.Date;
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
            var r = false;

            if (_fechaHasta.HasValue)
                if (_fechaDesde.HasValue)
                    if (_fechaDesde.Value.Date > _fechaHasta.Value.Date)
                    {
                        Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                        return false;
                    }
                    else
                        return true;

            return r;
        }

    }

}