using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{

    public class CtrConsulta
    {


        private CtrlBuscar _ctrBuscar;
        public Consultor.Consulta Ficha { get; set; }


        public CtrConsulta(CtrlBuscar buscar)
        {
            _ctrBuscar=buscar;
            Ficha = new Consultor.Consulta();
        }

        public void Consultor()
        {
            var frm = new Consultor.ConsultorFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void BuscarProducto(string buscar)
        {
            Ficha.Limpiar();
            if (_ctrBuscar.ActivarBusqueda(buscar)) 
            {
                Ficha.setEntidad(_ctrBuscar.Producto);
            };
        }

    }

}