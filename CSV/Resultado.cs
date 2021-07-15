using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSV
{
    
    public class Resultado
    {

        public bool isError { get; set; }
        public string mensaje { get; set; }


        public Resultado() 
        {
            isError = false;
            mensaje = "";
        }

    }

}