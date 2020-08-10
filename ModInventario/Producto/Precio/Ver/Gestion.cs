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
        private data _precio1;
        private data _precio2;
        private data _precio3;
        private data _precio4;
        private data _precio5;


        public string Producto { get { return _prd; } }
        public string TasaIva { get { return _tasa; } }

        public data Precio1 { get { return _precio1; } }
        public data Precio2 { get { return _precio2; } }
        public data Precio3 { get { return _precio3; } }
        public data Precio4 { get { return _precio4; } }
        public data Precio5 { get { return _precio5; } }


        public Gestion()
        {
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

            var s=r01.Entidad;
            _prd = s.codigo + Environment.NewLine + s.descripcion;
            _tasa = s.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%, " + s.nombreTasaIva;
            _precio1.setData(s.contenido1, s.empaque1, s.precioNeto1, s.utilidad1, s.precioFullDivisa1, s.tasaIva, s.etiqueta1);
            _precio2.setData(s.contenido2, s.empaque2, s.precioNeto2, s.utilidad2, s.precioFullDivisa2, s.tasaIva, s.etiqueta2);
            _precio3.setData(s.contenido3, s.empaque3, s.precioNeto3, s.utilidad3, s.precioFullDivisa3, s.tasaIva, s.etiqueta3);
            _precio4.setData(s.contenido4, s.empaque4, s.precioNeto4, s.utilidad4, s.precioFullDivisa4, s.tasaIva, s.etiqueta4);
            _precio5.setData(s.contenido5, s.empaque5, s.precioNeto5, s.utilidad5, s.precioFullDivisa5, s.tasaIva, s.etiqueta5);

            return rt;
        }

        private void Limpiar()
        {
        }

        public void CambioModoPrecio()
        {
            _precio1.setModoPrecio();
            _precio2.setModoPrecio();
            _precio3.setModoPrecio();
            _precio4.setModoPrecio();
            _precio5.setModoPrecio();
        }

    }

}