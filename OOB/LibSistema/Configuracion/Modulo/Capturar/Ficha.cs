using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Configuracion.Modulo.Capturar
{
    
    public class Ficha
    {

        public string claveNivMaximo { get; set; }
        public string claveNivMedio { get; set; }
        public string claveNivMinimo { get; set; }
        public bool visualizarPrdInactivos { get; set; }
        public int cantDocVisualizar { get; set; }


        public Ficha() 
        {
            claveNivMaximo = "";
            claveNivMedio = "";
            claveNivMinimo = "";
            visualizarPrdInactivos = false;
            cantDocVisualizar = 0;
        }

    }

}