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

        //FUNCIONES DEL POS
        public static string FuncionPosDevolucion           = "0816010000";
        public static string FuncionPosAnularVenta          = "0816020000";
        public static string FuncionPosTeclaSumar           = "0816030000";
        public static string FuncionPosTeclaMultiplicar     = "0816040000";
        public static string FuncionPosTeclaRestar          = "0816050000";
        public static string FuncionPosTeclaPendiente       = "0816060000";
        public static string FuncionPosTeclaPendienteAnular = "0816070000";
        public static string FuncionPosTeclaDescuento       = "0816080000";
        public static string FuncionPosTeclaCredito         = "0816090000";
        public static string FuncionPosElaborarNotaEntrega  = "0816130000";
        public static string FuncionAdmAnularDocumento      = "0816100000";
        public static string FuncionAdmNotaCredito          = "0816110000";
        public static string FuncionAdmReimprimirDocumento  = "0816120000";

        //METODOS DE IMPRESION DOCUMENTO
        public static Helpers.Imprimir.IDocumento ImprimirFactura;
        public static Helpers.Imprimir.IDocumento ImprimirNotaCredito;
        public static Helpers.Imprimir.IDocumento ImprimirNotaEntrega;

        //
        public static string CLAVE_ADMINISTRADOR = "71277128";

    }

}