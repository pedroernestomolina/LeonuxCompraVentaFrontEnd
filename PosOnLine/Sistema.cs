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
        static public Lib.Controles.BalanzaSoloPeso.IBalanza MyBalanza;

        //static public OOB.LibInventario.Empresa.Data.Ficha Negocio;
        static public string Instancia;
        static public string BaseDatos;
        public static OOB.Usuario.Entidad.Ficha Usuario;
        public static OOB.Pos.EnUso.Ficha PosEnUso;
        public static OOB.Configuracion.Entidad.Ficha ConfiguracionActual;
        public static OOB.Sucursal.Entidad.Ficha Sucursal;
        public static string IdEquipo;
        public static string EquipoEstacion;
        public static string FuncionPosAnularVenta = "0816020000";

    }

}