using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario
{

    public class GestionInv
    {


        private GestionMovimiento _gestionMovimiento;


        public GestionInv()
        {
            var rt1= Sistema.MyData.FechaServidor();
            _gestionMovimiento = new GestionMovimiento();
        }


        public void Inicia() 
        {
            var frm = new Form1();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            _gestionMovimiento.MovimientoTrasladoEntreSucursalPorNivelMinimo();
        }

    }

}