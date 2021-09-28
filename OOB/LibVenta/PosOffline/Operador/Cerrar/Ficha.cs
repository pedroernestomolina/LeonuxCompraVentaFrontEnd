using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Operador.Cerrar
{
    
    public class Ficha
    {

        public int IdJornada { get; set; }
        public int IdOperador { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Estatus { get; set; }
        public Movimiento Movimientos { get; set; }


        public Ficha() 
        {
            IdJornada = -1;
            IdOperador = -1;
            Fecha = DateTime.Now.Date;
            Hora = "";
            Estatus = "";
            Movimientos = new Movimiento();
        }

    }

}