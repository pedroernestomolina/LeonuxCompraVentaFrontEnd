using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos
{
    
    public class Sistema
    {

        public enum EnumModoRolloTicket { SinDefinir=-1, Grande=1, Pequeno };


        static public OOB.LibVenta.PosOffline.Usuario.Ficha Usuario;
        static public DataProvPosOffLine.InfraEstructura.IData MyData2;
        static public Lib.BalanzaSoloPeso.IBalanza MyBalanza;
        static public OOB.LibVenta.PosOffline.Jornada.Cargar.Ficha MyJornada ;
        static public OOB.LibVenta.PosOffline.Operador.Cargar.Ficha MyOperador;
        static public OOB.LibVenta.PosOffline.Empresa.Ficha Empresa;
        static public EnumModoRolloTicket ImpresoraTicket;
        static public DateTime? FechaUltimaActualizacion;

    }

}