using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers.Imprimir
{
    
    public class data
    {

        public class Negocio 
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string CiRif { get; set; }

            public Negocio()
            {
                Nombre = "";
                Direccion = "";
                CiRif = "";
            }
        }

        public class Encabezado
        {
            public string DocumentoNombre { get; set; }
            public string DocumentoNro { get; set; }
            public DateTime DocumentoFecha { get; set; }
            public string DocumentoControl { get; set; }
            public string DocumentoSerie { get; set; }
            public string DocumentoCondicionPago { get; set; }
            public DateTime DocumentoFechaVencimiento { get; set; }
            public int DocumentoDiasCredito { get; set; }
            public string DocumentoAplica { get; set; }

            public string NombreCli { get; set; }
            public string DireccionCli { get; set; }
            public string CiRifCli { get; set; }
            public string CodigoCli { get; set; }

            public Encabezado()
            {
                NombreCli = "";
                DireccionCli = "";
                CiRifCli = "";
                CodigoCli = "";

                DocumentoAplica = "";
                DocumentoCondicionPago = "";
                DocumentoControl = "";
                DocumentoDiasCredito = 0;
                DocumentoFecha = DateTime.Now.Date;
                DocumentoFechaVencimiento = DateTime.Now.Date;
                DocumentoNombre = "";
                DocumentoNro = "";
                DocumentoSerie = "";
            }
        }

        public class Item
        {
            public string NombrePrd { get; set; }

            public Item()
            {
                NombrePrd = "";
            }
        }


        public Negocio negocio { get; set; }
        public Encabezado encabezado { get; set; }
        public List<Item> item { get; set; }

    }

}
