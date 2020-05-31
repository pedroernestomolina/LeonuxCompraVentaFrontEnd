using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion.Consultor
{

    public class Consulta
    {

        public string CodigoPrd { get; set; }
        public string CodigoPlu { get; set; } 
        public string CodigoBarra { get; set; } 
        public string NombrePrd { get; set; } 
        public string Departamento { get; set; } 
        public string Grupo { get; set; } 
        public string Marca { get; set; } 
        public string Modelo { get; set; }
        public string Pasillo { get; set; } 
        public decimal Tasa { get; set; } 
        public string Referencia { get; set; } 
        public bool IsInactivo { get; set; } 
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


        public Consulta() 
        {
            Precio_1 = new Precio();
            Precio_2 = new Precio();
            Precio_3 = new Precio();
            Precio_4 = new Precio();
        }

        public void setEntidad(OOB.LibVenta.PosOffline.Producto.Ficha ficha) 
        {

            CodigoPrd=ficha.CodigoPrd; 
            CodigoPlu = ficha.CodigoPlu; 
            CodigoBarra = ficha.CodigoBarra; 
            NombrePrd = ficha.NombrePrd; 
            Departamento = ficha.NombreDepartamento; 
            Grupo = ficha.NombreGrupo ; 
            Marca = ficha.Marca; 
            Modelo = ficha.Modelo; 
            Pasillo = ficha.Pasillo; 
            Tasa = ficha.TasaImpuesto; 
            Referencia = ficha.Referencia; 
            IsInactivo = !ficha.IsActivo; 
            Precio_1.setEntidad (ficha.Precio_1, Tasa);
            Precio_2 .setEntidad (ficha.Precio_2, Tasa);
            Precio_3.setEntidad (ficha.Precio_3, Tasa);
            Precio_4.setEntidad (ficha.Precio_4, Tasa);
        }

        public void Limpiar() 
        {
            CodigoPrd = "";
            CodigoPlu = "";
            CodigoBarra = "";
            NombrePrd = "";
            Departamento = "";
            Grupo = "";
            Marca = "";
            Modelo = "";
            Pasillo = "";
            Tasa = 0.0m;
            Referencia = "";
            IsInactivo = false; 

            Precio_1.Limpiar();
            Precio_2.Limpiar();
            Precio_3.Limpiar();
            Precio_4.Limpiar();
        }

    }

}