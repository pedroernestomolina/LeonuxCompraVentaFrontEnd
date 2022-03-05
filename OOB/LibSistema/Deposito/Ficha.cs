using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Deposito
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estatus { get; set; }
        public string autoSucursal { get; set; }
        public string codigoSucursal { get; set; }
        public string sucursal { get; set; }
        public bool isActivo { get { return estatus.Trim().ToUpper() == "1" ? true : false; } }


        public Ficha()
        {
            auto = "";
            codigo = "";
            nombre = "";
            estatus = "";
            autoSucursal = "";
            codigoSucursal = "";
            sucursal = "";
        }


        public void setEstatusInactivo()
        {
            estatus = "0";
        }

        public void setEstatusActivo()
        {
            estatus = "1";
        }

    }

}