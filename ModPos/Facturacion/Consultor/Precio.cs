using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion.Consultor
{

    public class Precio
    {

        private decimal _precioNeto;
        private int _contEmpaque;
        private string _empaque;
        private decimal _tasaIva;


        public decimal Neto
        {
            get
            {
                var rt = 0.0m;
                rt = _precioNeto; 
                return rt;
            }
        }

        public decimal Iva
        {
            get
            {
                var rt = 0.0m;
                rt = _precioNeto * _tasaIva / 100;
                return rt;
            }
        }

        public decimal Full
        {
            get
            {
                var rt = 0.0m;
                rt = Neto + Iva;
                return rt;
            }
        }

        public string ContenidoDescripcion 
        {
            get 
            {
                var rt = "";
                rt = _contEmpaque.ToString("n0")+" Unidades";
                return rt;
            }
        }

        public string EmpaqueContenidoDescripcion
        {
            get
            {
                var rt = "";
                rt = _empaque+"("+_contEmpaque.ToString("n0") +")";
                return rt;
            }
        }

        public Precio()
        {
            Limpiar();
        }

        public void setEntidad(OOB.LibVenta.PosOffline.Precio.Ficha ficha, decimal tasa)
        {
            _tasaIva = tasa;
            _precioNeto = ficha.PrecioNeto;
            _contEmpaque = ficha.ContEmpVenta;
            _empaque = ficha.DescEmpVenta;
        }

        public void Limpiar()
        {
            _tasaIva = 0.0m;
            _precioNeto = 0.0m;
            _contEmpaque = 1;
            _empaque = "";
        }

    }

}