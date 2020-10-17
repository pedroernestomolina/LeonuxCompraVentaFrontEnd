using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros
{

    public class data
    {

        public string AutoDepartamento { get; set; }
        public string AutoDeposito { get; set; }
        public string AutoTasa { get; set; }
        public string IdAdmDivisa { get; set; }
        public string IdEstatus { get; set; }
        public string IdOrigen { get; set; }
        public string IdCategoria { get; set; }
        public string CodigoSucursal { get; set; }


        public data()
        {
            Limpiar();
        }

        public void Limpiar()
        {
            AutoDepartamento = "";
            AutoDeposito = "";
            AutoTasa = "";
            IdEstatus = "";
            IdOrigen = "";
            IdCategoria = "";
            IdAdmDivisa = "";
            CodigoSucursal = "";
        }

    }

}