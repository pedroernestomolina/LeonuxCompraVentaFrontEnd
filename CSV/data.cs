using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSV
{

    public class data
    {
        public string ciRif { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }


        public data()
        {
            ciRif = "";
            nombre = "";
            direccion = "";
            telefono = "";
        }

    }

}
