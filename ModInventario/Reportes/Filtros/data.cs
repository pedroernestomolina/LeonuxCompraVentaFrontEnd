using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros
{

    public class data
    {

        private bool _porFecha;
        private DateTime _desde;
        private DateTime _hasta;
        private ficha _producto;


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

        public ficha Producto { get { return _producto; } }
        public bool ProductoIsOk { get { return _producto == null ? false : true; } }
        public string ProductoAFiltrar { get { return ProductoIsOk ? _producto.desc : ""; } }

        
        public DateTime Desde 
        {
            get { return _desde; }
            set { _desde = value; _porFecha = true; } 
        }

        public DateTime Hasta 
        {
            get { return _hasta; }
            set { _hasta = value; _porFecha = true; } 
        }


        public data()
        {
            _producto = null;
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
            _desde= DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _porFecha = false;
            _producto = null;
        }

        public string TextoFiltro()
        {
            var filt = "";

            if (_porFecha)
                filt+="DESDE: " + Desde.ToShortDateString() + ", HASTA: " + Hasta.ToShortDateString();
            if (AutoDeposito != "")
                filt += ", DEPOSITO: " + NombreDeposito;
            if (AutoDepartamento  != "")
                filt += ", DEPARTAMENTO: " + NombreDepartamento;
            if (ProductoIsOk)
                filt += ", PRODUCTO: "+ _producto;
            return filt;
        }

        public void setProducto(fichaSeleccion ficha)
        {
            _producto = new ficha(ficha.id, ficha.codigo, ficha.desc);
        }
        public void LimpiarProducto()
        {
            _producto = null;
        }

    }

}