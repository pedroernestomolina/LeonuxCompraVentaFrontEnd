using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Serie
{
    
    public class Ficha
    {

        public string Auto { get; set; }
        public string Serie { get; set; }
        public string Control { get; set; }

        public string Nombre 
        {
            get 
            {
                return "("+Serie.Trim().ToUpper() + ")";
            }
        }

    }

}