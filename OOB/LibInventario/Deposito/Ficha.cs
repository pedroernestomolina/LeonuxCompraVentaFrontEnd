using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Deposito
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string autoSucursal { get; set; }
        public string nombreSucursal { get; set; }
        public string codigoSucursal { get; set; }


        public Ficha()
        {
            Limpiar();
        }

        public void Limpiar() 
        {
            auto = "";
            autoSucursal = "";
            codigo = "";
            codigoSucursal = "";
            nombre = "";
            nombreSucursal = "";
        }

    }

}