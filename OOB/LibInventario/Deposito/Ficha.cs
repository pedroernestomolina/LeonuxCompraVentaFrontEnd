using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Deposito
{
    
    public class Ficha
    {
        private Ficha it;


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

        public Ficha(Ficha it)
            : this()
        {
            auto = it.auto;
            autoSucursal = it.autoSucursal;
            codigo = it.codigo;
            codigoSucursal = it.codigoSucursal;
            nombre = it.nombre;
            nombreSucursal = it.nombreSucursal;
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