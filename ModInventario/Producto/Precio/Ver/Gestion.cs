using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Ver
{
    
    public class Gestion
    {

        private string _autoPrd;
        private string _prd;
        private string _tasa;
        private bool _admDivisa;
        private string _metodoCalculoUtilidad;
        private string _tasaCambioActual;
        private data _precio1;
        private data _precio2;
        private data _precio3;
        private data _precio4;
        private data _precio5;
        private data.enumModoPrecio _modoActual;


        public string Producto { get { return _prd; } }
        public string TasaIva { get { return _tasa; } }
        public bool AdmPorDivisa { get { return _admDivisa; } }
        public string MetodoCalculoUtilidad { get { return _metodoCalculoUtilidad; } }
        public string TasaCambioActual { get { return _tasaCambioActual; } }
        public string AdmDivisa { get { return (_admDivisa ? "SI" : "NO"); } }

        public data.enumModoPrecio ModoActual { get { return _modoActual; } }
        public data Precio1 { get { return _precio1; } }
        public data Precio2 { get { return _precio2; } }
        public data Precio3 { get { return _precio3; } }
        public data Precio4 { get { return _precio4; } }
        public data Precio5 { get { return _precio5; } }


        public Gestion()
        {
            _autoPrd="";
            _prd="";
            _tasa="";
            _admDivisa= false;
            _precio1 = new data();
            _precio2 = new data();
            _precio3 = new data();
            _precio4 = new data();
            _precio5 = new data();
        }


        public void Inicia() 
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new VerFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        public void setFicha(string autoprd)
        {
            _autoPrd = autoprd;
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetPrecio(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Configuracion_TasaCambioActual ();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            var s=r01.Entidad;
            _prd = s.codigo + Environment.NewLine + s.descripcion;

            _tasa = "EXENTO";
            if (s.tasaIva > 0) 
            {
                _tasa = s.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%";
            }

            _admDivisa = false;
            if (s.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si) 
            {
                _admDivisa = true;
            };

            _tasaCambioActual = r02.Entidad.ToString("n2");
            _metodoCalculoUtilidad = r03.Entidad.ToString();

            _precio1.setData(s.contenido1, s.empaque1, s.precioNeto1, s.utilidad1, s.precioFullDivisa1, s.tasaIva, s.etiqueta1);
            _precio2.setData(s.contenido2, s.empaque2, s.precioNeto2, s.utilidad2, s.precioFullDivisa2, s.tasaIva, s.etiqueta2);
            _precio3.setData(s.contenido3, s.empaque3, s.precioNeto3, s.utilidad3, s.precioFullDivisa3, s.tasaIva, s.etiqueta3);
            _precio4.setData(s.contenido4, s.empaque4, s.precioNeto4, s.utilidad4, s.precioFullDivisa4, s.tasaIva, s.etiqueta4);
            _precio5.setData(s.contenido5, s.empaque5, s.precioNeto5, s.utilidad5, s.precioFullDivisa5, s.tasaIva, s.etiqueta5);
            _modoActual = data.enumModoPrecio.Bolivar;
            if (_admDivisa) 
            {
                _modoActual = data.enumModoPrecio.Divisa;
            }
            CambiarModo();

            return rt;
        }

        private void Limpiar()
        {
            _prd = "";
            _tasa = "";
            _admDivisa = false;
            _precio1.Limpiar();
            _precio2.Limpiar();
            _precio3.Limpiar();
            _precio4.Limpiar();
            _precio5.Limpiar();
        }

        public void CambioModoPrecio()
        {
            if (_modoActual == data.enumModoPrecio.Bolivar)
            {
                _modoActual = data.enumModoPrecio.Divisa;
            }
            else
            {
                _modoActual = data.enumModoPrecio.Bolivar;
            }
            CambiarModo();
        }

        private void CambiarModo() 
        {
            _precio1.setModoPrecioActual(_modoActual);
            _precio2.setModoPrecioActual(_modoActual);
            _precio3.setModoPrecioActual(_modoActual);
            _precio4.setModoPrecioActual(_modoActual);
            _precio5.setModoPrecioActual(_modoActual);
        }

    }

}