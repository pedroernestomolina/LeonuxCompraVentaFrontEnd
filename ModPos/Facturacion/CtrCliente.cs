using ModPos.Facturacion.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{
    
    public class CtrCliente
    {

        private Ficha _cliente;
        public Ficha Cliente 
        {
            get 
            {
                return _cliente;
            }
        }


        public CtrCliente() 
        {
            _cliente = new Ficha();
        }

        public void Buscar()
        {
            var frm = new Cliente.BuscarAgregarFrm();
            frm.ShowDialog();
            if (frm.Cliente != null) 
            {
                _cliente = frm.Cliente;
            }
        }

        public void setCliente(OOB.LibVenta.PosOffline.Cliente.Ficha ficha) 
        {
            _cliente.setEntidad(ficha);
        }

        public void Limpiar() 
        {
            _cliente.Limpiar();
        }

    }

}