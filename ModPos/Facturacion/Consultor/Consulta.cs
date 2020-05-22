using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion.Consultor
{

    public class Consulta
    {

        private OOB.LibVenta.PosOffline.Producto.Ficha _ficha;
        public string CodigoPrd { get { return _ficha.CodigoPrd; } }
        public string CodigoPlu { get { return _ficha.CodigoPlu; } }
        public string CodigoBarra { get { return _ficha.CodigoBarra; } }
        public string NombrePrd { get { return _ficha.NombrePrd; } }
        public string Departamento { get { return _ficha.NombreDepartamento; } }
        public string Grupo { get { return _ficha.NombreGrupo ; } }
        public string Marca { get { return _ficha.Marca; } }
        public string Modelo { get { return _ficha.Modelo; } }
        public string Pasillo { get{ return _ficha.Pasillo; } } 
        public decimal Tasa { get { return _ficha.TasaImpuesto; } }
        public string Referencia { get { return _ficha.Referencia; } }
        public bool IsInactivo { get { return !_ficha.IsActivo; } }
        public Precio Precio_1 { get; set; }
        public Precio Precio_2 { get; set; }
        public Precio Precio_3 { get; set; }
        public Precio Precio_4 { get; set; }

        public string TasaDescripcion 
        {
            get 
            {
                var rt = "EXENTO";
                if (Tasa > 0) 
                {
                    rt = Tasa.ToString("n2") + "%";
                }
                return rt ;
            }
        }


        public Consulta(OOB.LibVenta.PosOffline.Producto.Ficha ficha) 
        {
            _ficha = ficha;
            Precio_1 = new Precio(ficha.Precio_1 ,Tasa);
            Precio_2 = new Precio(ficha.Precio_2, Tasa);
            Precio_3 = new Precio(ficha.Precio_3, Tasa);
            Precio_4 = new Precio(ficha.Precio_4, Tasa);
        }

    }

}