﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroInventario
{
    
    public class Filtros: IFiltros
    {

        public bool ActivarDepartamento
        {
            get { return true ; }
        }

        public bool ActivarDeposito
        {
            get { return true; }
        }

        public bool ActivarSucursal
        {
            get { return false ; }
        }

        public bool ActivarAdmDivisa
        {
            get { return true ; }
        }

        public bool ActivarProducto
        {
            get { return false; }
        }

        public bool ActivarDesde
        {
            get { return false; }
        }

        public bool ActivarHasta
        {
            get { return false; }
        }

        public bool ActivarTasaIva
        {
            get { return false ; }
        }

        public bool ActivarEstatus
        {
            get { return true ; }
        }

        public bool ActivarOrigen
        {
            get { return false ; }
        }

        public bool ActivarCategoria
        {
            get { return false ; }
        }

        public bool ActivarMarca
        {
            get { return false; }
        }

        public bool ActivarGrupo
        {
            get { return false; }
        }

        public bool ActivarPrecio
        {
            get { return false; }
        }


        public Filtros()
        {
        }

    }

}