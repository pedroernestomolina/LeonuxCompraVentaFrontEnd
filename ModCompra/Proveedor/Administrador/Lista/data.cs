using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Administrador.Lista
{
    
    public class data
    {


        public string id { get; set; }
        public string ciRif { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string codigo { get; set; } 
        public bool IsActivo { get; set; }
        public string Encabezado
        {
            get
            {
                var rt = ciRif + Environment.NewLine + nombre;
                return rt;
            }
        }


        public data() 
        {
            id = "";
            ciRif = "";
            nombre = "";
            direccion = "";
            codigo = "";
            IsActivo = true;
        }


        public data(OOB.LibCompra.Proveedor.Data.Ficha rg)
            : this()
        {
            id = rg.autoId;
            ciRif = rg.ciRif;
            nombre = rg.nombreRazonSocial;
            direccion = rg.direccionFiscal;
            codigo = rg.codigo;
            IsActivo = rg.IsActivo;
        }

    }

}