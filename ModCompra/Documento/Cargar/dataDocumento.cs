using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar
{
    
    public class dataDocumento
    {

        private DateTime fechaServidor;


        public OOB.LibCompra.Proveedor.Data.Ficha proveedor { get; set; }
        public OOB.LibCompra.Sucursal.Data.Ficha Sucursal { get; set; }
        public OOB.LibCompra.Deposito.Data.Ficha Deposito { get; set; }

        public string documentoNro { get; set; }
        public DateTime fechaEmision { get; set; }
        public int diasCredito { get; set; }
        public string controlNro { get; set; }
        public string ordenCompra { get; set; }
        public decimal factorDivisa { get; set; }
        public string notas { get; set; }
        public string IdSucursal { get; set; }
        public string IdDeposito { get; set; }
        public string mesRelacion { get { return fechaServidor.Month.ToString().Trim().PadLeft(2,'0'); } }
        public string anoRelacion { get { return fechaServidor.Year.ToString().Trim().PadLeft(4, '0'); } }
        public DateTime fechaVencimiento { get { return fechaEmision.AddDays(diasCredito); } }
        public string ciRif 
        { 
            get 
            {
                var rt = "";
                if (proveedor!=null)
                    rt= proveedor.identidad.ciRif;
                return rt;
            }
        }
        public string nombreRazonSocial 
        { 
            get 
            {
                var rt = "";
                if (proveedor != null)
                    rt = proveedor.identidad.nombreRazonSocial;
                return rt;
            } 
        }
        public string direccionFiscal 
        { 
            get 
            {
                var rt = "";
                if (proveedor != null)
                    rt = proveedor.identidad.dirFiscal;
                return rt;
            } 
        }

        public string DepositoNombre 
        {
            get 
            {
                var rt = "";
                if (Deposito != null)
                    rt = Deposito.nombre;
                return rt;
            }
        }

        public string SucursalNombre 
        {
            get 
            {
                var rt = "";
                if (Sucursal != null)
                    rt = Sucursal.nombre;
                return rt;
            }
        }


        public dataDocumento()
        {
            limpiarData();
        }


        public void setFechaServidor(DateTime fecha)
        {
            fechaServidor = fecha;
        }

        public void setFactorDivisa(decimal p)
        {
            factorDivisa = p;
        }

        public bool ValidarEntradas()
        {
            var rt=true;

            if (proveedor== null)
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Proveedor]");
                return false;
            }
            if (documentoNro == "")
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Documento Nro]");
                return false;
            }
            if (controlNro== "")
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Control Nro]");
                return false;
            }
            if (IdSucursal == "")
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Sucursal]");
                return false;
            }
            if (IdDeposito == "")
            {
                Helpers.Msg.Alerta("Falta Por Ingresar Campo [Depósito]");
                return false;
            }


            return rt;
        }

        public void Limpiar()
        {
            limpiarData();
        }

        private void limpiarData()
        {
            proveedor = null;
            Deposito = null;
            Sucursal = null;
            documentoNro = "";
            fechaEmision = DateTime.Now.Date;
            diasCredito = 0;
            controlNro = "";
            ordenCompra = "";
            factorDivisa = 0.0m;
            notas = "";
            IdDeposito = "";
            IdSucursal = "";
        }

    }

}