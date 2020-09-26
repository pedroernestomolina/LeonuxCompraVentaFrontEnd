using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Visor.CostoEdad
{
    
    public class Filtro
    {

        public string autoDepartamento { get; set; }
        public string cadena { get; set; }
        public int dias { get; set; }


        public Filtro()
        {
            autoDepartamento = "";
            cadena = "";
            dias = 0;
        }

    }

}