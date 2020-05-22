using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.Inventario.Existencia
{

    public class Ficha
    {

        public string autoDeposito { get; set; }
        public string CodigoDeposito { get; set; }
        public string DescripcionDeposito { get; set; }
        public decimal CantUndFisica { get; set; }
        public decimal CantUndReservada { get; set; }
        public decimal CantUndDisponible { get; set; }
        public string Ubicacion { get; set; }

    }

}