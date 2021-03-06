﻿using System;
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
            _desde= DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _porFecha = false;
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

            return filt;
        }

    }

}