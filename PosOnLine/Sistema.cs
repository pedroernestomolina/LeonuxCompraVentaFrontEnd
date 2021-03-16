using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine
{
    
    public class Sistema
    {

        static public IData MyData;
        public static OOB.Usuario.Entidad.Ficha Usuario; 
        //static public OOB.LibInventario.Empresa.Data.Ficha Negocio;
        static public string _Instancia { get; set; }
        static public string _BaseDatos { get; set; }

    }

}