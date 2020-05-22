using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovVenta.Venta.VentaAdministrativa
{
    
    public class Totalizar
    {

        private decimal _subTotal;
        private decimal _dsctoGlobal;
        private decimal _cargoGlobal;


        public Totalizar() 
        {
            _subTotal = 0.0m;
            _dsctoGlobal = 0.0m;
            _cargoGlobal = 0.0m;
        }

        public decimal DsctGlobal 
        {
            get 
            {
                return _dsctoGlobal;
            }
        }

        public decimal MontoDsctGlobal
        {
            get
            {
                var rt = 0.0m;
                rt = _subTotal * _dsctoGlobal / 100;
                return rt ;
            }
        }

        public void setDsctoGlobal(decimal porct)
        {
            _dsctoGlobal = porct;
        }

        public decimal CargoGlobal
        {
            get
            {
                return _cargoGlobal;
            }
        }

        public decimal MontoCargoGlobal
        {
            get
            {
                var rt = 0.0m;
                rt = _subTotal * _cargoGlobal / 100;
                return rt;
            }
        }

        public decimal Total 
        {
            get 
            {
                var rt = 0.0m;
                rt = _subTotal - MontoDsctGlobal + MontoCargoGlobal;
                return rt;
            }
        }

        public void setCargoGlobal(decimal porct)
        {
            _cargoGlobal = porct;
        }

        public void setSubTotal(decimal monto)
        {
            _subTotal = monto;
        }

        public void setPermisoDsctoCargoGlobal(OOB.LibVenta.Permiso.Ficha permiso) 
        {
        }

    }

}