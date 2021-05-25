using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm
{
    
    public class Sistema
    {

        static public IData MyData;
        static public string Instancia;
        static public string BaseDatos;
        public static OOB.Usuario.Entidad.Ficha Usuario;
        public static OOB.Sistema.Empresa.Entidad.Ficha DatosEmpresa;
        public static string EquipoEstacion;

    }

}