using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovVenta.Venta.VentaAdministrativa
{
    
    public class Precio
    {

        public Precio(OOB.LibVenta.Inventario.Precio.Ficha _ficha) 
        {
            Id = _ficha.Id;
            PrecioNeto = _ficha.PrecioNeto;
            UtilidadMargen = _ficha.UtilidadMargen;
            ContEmpVenta = _ficha.ContEmpVenta;
            DescEmpVenta = _ficha.DescEmpVenta;
            Decimales = _ficha.Decimales;
            _precioFinal = 0.0m;
            _dsctoGlobal = 0.0m;
            _cargoGlobal = 0.0m;
        }


        public string Id { get; set; }
        public decimal PrecioNeto { get; set; }
        public decimal UtilidadMargen { get; set; }
        public int ContEmpVenta { get; set; }
        public string DescEmpVenta { get; set; }
        public string Decimales { get; set; }

        private decimal _precioFinal;
        private decimal _dsctoGlobal;
        private decimal _cargoGlobal;


        private decimal _descuentoItemPorct;
        public decimal DescuentoItemPorcentaje
        {
            get
            {
                return _descuentoItemPorct;
            }
        }

        private decimal _tasaImpuesto;
        public decimal TasaImpuesto
        {
            get
            {
                return _tasaImpuesto;
            }
        }

        private decimal _costoUnd;
        public decimal CostoUnd 
        {
            get 
            {
                return _costoUnd;
            }
        }

        public decimal DescuentoItemMonto
        {
            get
            {
                var r = 0.0m;
                r = PrecioNeto * (DescuentoItemPorcentaje / 100);
                return r;
            }
        }

        public decimal PrecioItem
        {
            get
            {
                var r = 0.0m;
                r = (PrecioNeto - DescuentoItemMonto);
                return r;
            }
        }

        public decimal Iva
        {
            get
            {
                var r = 0.0m;
                r = PrecioItem * (_tasaImpuesto / 100);
                return r;
            }
        }

        public decimal PrecioFull
        {
            get
            {
                var r = 0.0m;
                r = PrecioItem + Iva;
                return r;
            }
        }


        public decimal DescuentoGlobal
        {
            get
            {
                return _dsctoGlobal;
            }
        }

        public decimal DescuentoGlobalMonto
        {
            get
            {
                var r = 0.0m;
                r = PrecioItem * (DescuentoGlobal / 100);
                return r;
            }
        }

        public decimal CargoGlobal
        {
            get
            {
                return _cargoGlobal;
            }
        }

        public decimal CargoGlobalMonto
        {
            get
            {
                var r = 0.0m;
                r = PrecioItem * (CargoGlobal / 100);
                return r;
            }
        }

        public decimal PrecioFinal
        {
            get
            {
                var r = 0.0m;
                r = (PrecioItem - DescuentoGlobalMonto + CargoGlobalMonto);
                return r;
            }
        }

        public decimal IvaFinal
        {
            get
            {
                var r = 0.0m;
                r = PrecioFinal * (_tasaImpuesto / 100);
                return r;
            }
        }

        public decimal PrecioFinalFull
        {
            get
            {
                var r = 0.0m;
                r = (PrecioFinal + IvaFinal);
                return r;
            }
        }


        public void SetPrecio(decimal precio)
        {
            PrecioNeto = precio;
        }

        public void SetTasaImpuesto(decimal tasa)
        {
            _tasaImpuesto = tasa;
        }

        public void SetDescuentoItem(decimal porct)
        {
            _descuentoItemPorct = porct;
        }

        public void SetCostoUnd(decimal costo) 
        {
            _costoUnd = costo;
        }

        public void setDescuentoGlobal(decimal porct) 
        {
            _dsctoGlobal = porct;
        }

        public void setCargoGlobal(decimal porct)
        {
            _cargoGlobal = porct;
        }

        public bool VerificarPrecio(decimal p) 
        {
            var rt = true;
            var pn = p;
            pn -= (_descuentoItemPorct / 100);

            if (pn <= 0) 
            {
                return false;
            }

            if (pn < _costoUnd)
            {
                return false;
            }

            return rt;
        }

        public bool VerificarDscto (decimal dscto)
        {
            var rt = true;

            var pn = PrecioNeto;
            pn -= (pn *(dscto / 100));

            if (pn <= 0)
            {
                return false;
            }

            if (pn < _costoUnd)
            {
                return false;
            }

            return rt;
        }

    }

}