using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class Precio
    {

        public enum enumModo { Financiero = 1, Lineal };
        public enum enumModoRedondeo { SinRedondeo = 1, Unidad, Decena };


        private enumModo modoCalculoUtilidad;
        private enumModoRedondeo modoRedondeo;


        public void setCalculoUtilidad(enumModo modo)
        {
            modoCalculoUtilidad = modo;
        }

        public void setData()
        {
        }

    }

}