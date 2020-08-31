using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema
{
    
    public class Sistema
    {

        static public DataProvSistema.Infra.IData MyData;
        static public OOB.LibSistema.Usuario.Ficha UsuarioP;
        static public string _Instancia { get; set; }
        static public string _BaseDatos { get; set; }
        static public string Host 
        {
            get 
            {
                var rt="";
                rt=_Instancia+"/"+_BaseDatos;
                return rt;
            }
        }

    }

}