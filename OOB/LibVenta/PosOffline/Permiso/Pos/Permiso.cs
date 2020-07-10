using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Permiso.Pos
{
    
    public class Permiso
    {

        public enum EnumAcceso { SinDefinir = -1, SinAcceso = 0, PedirClave, Libre }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public EnumAcceso RequiereClave { get; set; }


        public Permiso()
        {
            Codigo = "";
            Descripcion = "";
            RequiereClave = EnumAcceso.SinDefinir;
        }

        public Permiso(string codigo, string descripcion, EnumAcceso requiereClave) 
            :this()
        {
            Codigo = codigo;
            Descripcion = descripcion;
            RequiereClave = requiereClave;
        }

    }

}