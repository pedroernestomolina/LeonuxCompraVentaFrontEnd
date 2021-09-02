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
        private decimal _factorCambio;
        private decimal _nuevoConoMonetario;
        private bool _habilitar_precio5_ventaMayor;

        public Consultor.Consulta Ficha { get; set; }

        public string TarifaPrecio { get { return _tarifaPrecio; } }
        public bool EtiquetarPrecioPorTipoNegocio { get { return _etiquetarPrecioPorTipoNegocio; } }

        public decimal FactorCambio { get { return _factorCambio; } }
        public decimal NuevoConoMonetario { get { return _nuevoConoMonetario; } }

        public bool Habilitar_precio5_ventaMayor { get { return _habilitar_precio5_ventaMayor; } }



        public CtrConsulta(CtrlBuscar buscar)
        {
            _nuevoConoMonetario = 0.0m;
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

        public void setFactorCambio(decimal factor)
        {
            _factorCambio = factor;
        }

        public void setHabilitar_Precio5_VentaMayor(bool p)
        {
            _habilitar_precio5_ventaMayor = p;
        }

        public void setNuevoConoMonetario(decimal p)
        {
            _nuevoConoMonetario = p;
        }

    }

}