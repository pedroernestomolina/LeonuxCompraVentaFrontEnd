using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros
{

    public class data
    {

        public string AutoProducto { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoMarca { get; set; }
        public string AutoDepartamento { get; set; }
        public string AutoDeposito { get; set; }
        public string AutoTasa { get; set; }
        public string IdAdmDivisa { get; set; }
        public string IdEstatus { get; set; }
        public string IdOrigen { get; set; }
        public string IdCategoria { get; set; }
        public string CodigoSucursal { get; set; }
        public string NombreDepartamento { get; set; }
        public string NombreDeposito { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }


        public data()
        {
            Limpiar();
        }

        public void Limpiar()
        {
            AutoGrupo = "";
            AutoMarca = "";
            AutoDepartamento = "";
            AutoDeposito = "";
            AutoTasa = "";
            IdEstatus = "";
            IdOrigen = "";
            IdCategoria = "";
            IdAdmDivisa = "";
            CodigoSucursal = "";
            NombreDepartamento = "";
            NombreDeposito = "";
            AutoProducto = "";
            Desde = DateTime.Now.Date;
            Hasta = DateTime.Now.Date;
        }

    }

}