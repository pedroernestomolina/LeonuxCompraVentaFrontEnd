﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Configuracion.Entidad
{
    
    public class Ficha
    {

        public string idSucursal { get; set; }
        public string idDeposito { get; set; }
        public string idVendedor { get; set; }
        public string idCobrador { get; set; }
        public string idTransporte { get; set; }
        public string idMedioPagoEfectivo { get; set; }
        public string idMedioPagoDivisa { get; set; }
        public string idMedioPagoElectronico { get; set; }
        public string idMedioPagoOtros { get; set; }
        public string idConceptoVenta { get; set; }
        public string idConceptoDevVenta { get; set; }
        public string idConceptoSalida { get; set; }
        public string idClaveUsar { get; set; }
        public string idPrecioManejar { get; set; }
        public string validarExistencia { get; set; }
        public bool ValidarExistencia_Activa 
        { 
            get 
            { 
                var rt = validarExistencia.Trim().ToUpper() == "S";
                return rt;
            } 
        }


        public Ficha()
        {
            idSucursal = "";
            idDeposito = "";
            idVendedor = "";
            idCobrador = "";
            idTransporte = "";
            idMedioPagoDivisa = "";
            idMedioPagoEfectivo = "";
            idMedioPagoElectronico = "";
            idMedioPagoOtros = "";
            idConceptoDevVenta = "";
            idConceptoSalida = "";
            idConceptoVenta = "";
            idClaveUsar = "";
            idPrecioManejar = "";
            validarExistencia = "";
        }

    }

}