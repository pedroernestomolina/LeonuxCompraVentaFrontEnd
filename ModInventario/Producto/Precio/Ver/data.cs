using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Ver
{
    
    public class data
    {

        public enum enumModoPrecio { Bolivar = 0, Divisa };


        private enumModoPrecio modoActual;

        
        public decimal tasaIva { get; set; }
        public string etiqueta { get; set; }
        public string empaque { get; set; }
        public int contenido { get; set; }
        public decimal precioNeto { get; set; }
        public decimal precioFullDivisa { get; set; }
        public decimal utilidadPorc { get; set; }
        public decimal iva 
        { 
            get 
            {
                var t = 0.0m;
                t = precioNeto * tasaIva / 100;
                return t;
            } 
        }
        public decimal precioFull 
        {
            get 
            {
                var t = 0.0m;
                t = precioNeto + iva;
                return t;
            } 
        }
        public decimal precioNetoDivisa 
        {
            get 
            {
                var t = 0.0m;
                t = precioFullDivisa / (1 + (tasaIva / 100));
                return t;
            }
        }

        public decimal PN 
        {
            get
            {
                var p = precioNeto;
                if (modoActual != enumModoPrecio.Bolivar)
                {
                    p = precioNetoDivisa;
                }
                return p;
            }
        }

        public decimal PF
        {
            get
            {
                var p = precioFull;
                if (modoActual != enumModoPrecio.Bolivar)
                {
                    p = precioFullDivisa;
                }
                return p;
            }
        }


        public data()
        {
            modoActual = enumModoPrecio.Bolivar;
            etiqueta = "";
            empaque = "";
            contenido = 1;
            precioNeto = 0.0m;
            precioFullDivisa = 0.0m;
            utilidadPorc = 0.0m;
            tasaIva = 0.0m;
        }


        public data(int p1, string p2, decimal p3, decimal p4, decimal p5, decimal p6, string etiqueta)
            :this()
        {
            this.contenido = p1;
            this.empaque = p2;
            this.precioNeto = p3;
            this.utilidadPorc = p4;
            this.precioFullDivisa = p5;
            this.tasaIva = p6;
            this.etiqueta = etiqueta;
        }

        public void setData(int cont, string empaque, decimal precioNeto , decimal utilidad , decimal preciofulldivisa , decimal tasaIva, string etiq)
        {
            this.contenido = cont;
            this.empaque = empaque;
            this.precioNeto = precioNeto;
            this.utilidadPorc = utilidad;
            this.precioFullDivisa = preciofulldivisa;
            this.tasaIva = tasaIva;
            this.etiqueta = etiq;
        }

        public void setModoPrecio()
        {
            if (modoActual== enumModoPrecio.Bolivar)
            {
                modoActual = enumModoPrecio.Divisa;
            }
            else
            {
                modoActual = enumModoPrecio.Bolivar;
            }
        }

    }

}