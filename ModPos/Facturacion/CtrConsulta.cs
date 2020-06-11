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
        private string _tarifaPrecio;
        private bool _etiquetarPrecioPorTipoNegocio; 
        public Consultor.Consulta Ficha { get; set; }

        public string TarifaPrecio { get { return _tarifaPrecio; } }
        public bool EtiquetarPrecioPorTipoNegocio { get { return _etiquetarPrecioPorTipoNegocio; } }


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

        public void setTarifaPrecio(string tarifa) 
        {
            _tarifaPrecio = tarifa;
        }

        public void setEtiquetarPrecioPorTipoNegocio(bool etiquetarPrecio) 
        {
            _etiquetarPrecioPorTipoNegocio = etiquetarPrecio;
        }

    }

}