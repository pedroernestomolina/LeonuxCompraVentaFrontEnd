using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{
    
    public class Sistema
    {

        static public DataProvInventario.InfraEstructura.IData MyData;
        static public OOB.LibInventario.Usuario.Ficha UsuarioP;
        static public string _Instancia { get; set; }
        static public string _BaseDatos { get; set; }

    }

}