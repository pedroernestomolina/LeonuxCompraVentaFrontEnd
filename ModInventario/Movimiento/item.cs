using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{

    public class item
    {

        private OOB.LibInventario.Producto.Data.Ficha ficha;
        private decimal _cnt;
        private decimal _costo;
        private enumerados.enumTipoEmpaque _empaque;
        private decimal _tasaCambio;
        private decimal _importe;
        private decimal _importeMonedaLocal;


        public OOB.LibInventario.Producto.Data.Ficha FichaPrd { get { return ficha; } }
        public string CodigoPrd { get { return ficha.CodigoPrd; } }
        public string DescripcionPrd { get { return ficha.DescripcionPrd; } }
        public bool EsAdmDivisa { get { return ficha.identidad.AdmPorDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si ? true : false; } }
        public decimal Cantidad { get { return _cnt; } }
        public decimal Costo { get { return _costo; } }
        public decimal Importe { get { return _importe; } }
        public decimal ImporteMonedaLocal { get { return _importeMonedaLocal; } }
        public enumerados.enumTipoEmpaque TipoEmpaqueSeleccionado { get { return _empaque; } }
        public string Empaque 
        { 
            get 
            {
                var _emp = ficha.Empaque; 
                if (TipoEmpaqueSeleccionado == enumerados.enumTipoEmpaque.PorUnidad) 
                {
                    _emp = "UNIDAD (1)";
                }
                return _emp ; 
            } 
        }


        public item(OOB.LibInventario.Producto.Data.Ficha ficha, decimal cnt, decimal costo, enumerados.enumTipoEmpaque emp, 
            decimal tasaCambio, decimal importe, decimal importeMonedaLocal )
        {
            this.ficha = ficha;
            _cnt = cnt;
            _costo = costo;
            _empaque = emp;
            _tasaCambio = tasaCambio;
            _importe = importe;
            _importeMonedaLocal = importeMonedaLocal;
        }

    }

}