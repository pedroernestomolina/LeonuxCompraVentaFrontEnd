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


        private Buscar _buscar;


        public Cliente.Ficha Ficha
        {
            get 
            {
                return _buscar.FichaCliente;
            }
        }


        public CtrCliente() 
        {
            _buscar = new Buscar();
        }


        public void Buscar()
        {
            _buscar.Busqueda();
        }

        public void BuscarId(int idCliente)
        {
            _buscar.BuscarPorId(idCliente);
        }

        public void Limpiar() 
        {
            _buscar.Limpiar();
        }

    }

}