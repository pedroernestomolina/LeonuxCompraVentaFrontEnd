using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{
    
    public class GestionMovimiento
    {

        public GestionMovimiento()
        {
        }


        public void MovimientoTrasladoEntreSucursalPorNivelMinimo() 
        {
            var frm = new Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo.MovimientoFrm();
            frm.ShowDialog();
        }

    }

}