using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Extra
    {

        public string lugar { get; set; }
        public Enumerados.EnumPesado esPesado { get; set; }
        public string plu { get; set; }
        public int diasEmpaque { get; set; }
        public List<string> codigosAlterno { get; set; }
        public List<Proveedor> proveedores { get; set; }
        public byte[] imagen { get; set; }


        public Extra()
        {
            lugar = "";
            esPesado = Enumerados.EnumPesado.SnDefinir;
            plu = "";
            diasEmpaque = 0;
            codigosAlterno = null;
            proveedores = null;
            imagen = null;
        }

    }

}