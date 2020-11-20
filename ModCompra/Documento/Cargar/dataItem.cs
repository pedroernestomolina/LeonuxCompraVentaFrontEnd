﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar
{
    
    public class dataItem
    {


        private decimal factorDivisa;
        private decimal _dscto_1_m;
        private decimal _dscto_2_m;
        private decimal _dscto_3_m;
        private OOB.LibCompra.Producto.Data.Ficha producto;


        public OOB.LibCompra.Producto.Data.Ficha Producto { get { return producto; } }
        public decimal FactorCpmpraDivisa { get { return factorDivisa; } }
        public string codigoPrd { get { return producto.codigo; } }
        public string descripcionPrd { get { return producto.descripcion; } }
        public string cnt { get { return cantidad.ToString("n"+producto.decimales); } }
        public string empaqueCont { get { return producto.empaqueCompra.Trim() + "/ " + producto.contenidoCompra.ToString("n0").Trim(); } }
        public string costoCompra { get { return costoMoneda.ToString("n2"); } }
        public string costoDivisaCompra { get { return costoDivisa.ToString("n2"); } }
        public string tasaIvaPrd { get { return producto.tasaIva.ToString("n2").Trim()+"%"; } }
        public decimal DsctoMonto { get { return _dscto_1_m + _dscto_2_m + _dscto_3_m; } }


        public string CodRefPrv { get; set; }
        public decimal cantidad { get; set; }
        public decimal costoMoneda { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal dsct_1_m { get { return _dscto_1_m; } }
        public decimal dsct_2_m { get { return _dscto_2_m; } }
        public decimal dsct_3_m { get { return _dscto_3_m; } }
        public decimal dsct_1_p { get; set; }
        public decimal dsct_2_p { get; set; }
        public decimal dsct_3_p { get; set; }
        public decimal costoMoneda_2 { get; set; }
        public decimal costoDivisa_2 { get; set; }

        public int CantidadUnd
        {
            get
            {
                var rt = 0;
                rt = (int) cantidad* Producto.contenidoCompra;
                return rt;
            }
        }

        public decimal costoMonedaUnd 
        {
            get 
            {
                var rt = 0.0m;
                rt = costoMoneda / Producto.contenidoCompra;
                return rt;
            } 
        }

        public decimal costoDivisaUnd 
        {
            get 
            {
                var rt = 0.0m;
                rt = costoDivisa / Producto.contenidoCompra;
                return rt;
            } 
        }

        public decimal subTotal_1 
        {
            get 
            {
                var rt = 0.0m;
                rt = cantidad * costoMoneda;
                return rt;
            }
        }

        public decimal subTotal_2
        {
            get
            {
                var rt = 0.0m;
                rt = (cantidad * costoMoneda_2);
                return rt;
            }
        }

        public decimal importe 
        { 
            get 
            {
                var rt = 0.0m;
                rt = subTotal_2;
                return rt; 
            } 
        }

        public decimal impuesto 
        { 
            get 
            {
                var rt = 0.0m;
                rt = importe * producto.tasaIva / 100;
                return rt; 
            } 
        }

        public decimal total 
        { 
            get 
            {
                var rt = 0.0m;
                rt = importe + impuesto;
                return rt; 
            } 
        }

        public decimal totalDivisa
        {
            get
            {
                var rt = 0.0m;
                rt = total / factorDivisa;
                return rt;
            }
        }

        public string ProductoDetalle 
        { 
            get 
            {
                var rt = "";
                if (Producto != null) 
                {
                    rt += Producto.codigo + Environment.NewLine + Producto.descripcion;
                }
                return rt;
            } 
        }

        public string ProductoTasaIvaDesc 
        {
            get 
            {
                var rt = "";
                if (Producto != null)
                {
                    if (Producto.tasaIva == 0)
                        rt = "EXENTO";
                    else
                        rt = Producto.tasaIva.ToString("n2").Trim()+"%, "+Producto.nombreTasaIva;
                }
                return rt;
            } 
        }

        public string ProductoAdmDivisaDesc 
        {
            get 
            {
                var rt = "";
                if (Producto != null)
                {
                    rt = Producto.AdmPorDivisa.ToString();
                }
                return rt;
            } 
        }

        public string ProductoEmpaqueDesc 
        {
            get 
            {
                var rt = "";
                if (Producto != null)
                {
                    rt = Producto.empaqueCompra;
                }
                return rt;
            } 
        }

        public string ProductoContEmpaqueDesc
        {
            get
            {
                var rt = "";
                if (Producto != null)
                {
                    rt = Producto.contenidoCompra.ToString("n0");
                }
                return rt;
            }
        }

        public decimal ProductoCosto 
        {
            get
            {
                var rt = 0.0m;
                if (Producto != null)
                {
                    rt = Producto.costo;
                }
                return rt;
            }
        }

        public decimal ProductoCostoDivisa
        {
            get
            {
                var rt = 0.0m;
                if (Producto != null)
                {
                    rt = Producto.costoDivisa;
                }
                return rt;
            }
        }


        public dataItem()
        {
            factorDivisa = 0.0m;
            producto = null;
        }

        public dataItem(dataItem it)
        {
            this.factorDivisa = it.factorDivisa;
            this.producto = it.producto;
            this.CodRefPrv = it.CodRefPrv;
            this.cantidad = it.cantidad;
            this.costoMoneda = it.costoMoneda;
            this.costoDivisa = it.costoDivisa;
            this.dsct_1_p = it.dsct_1_p;
            this.dsct_2_p = it.dsct_2_p;
            this.dsct_3_p = it.dsct_3_p;
            ActualizarCosto();
            ActualizarCostoDivisa();
            CalculaDscto();
        }


        public void setFactorDivisa(decimal p)
        {
            this.factorDivisa = p;
        }

        public void setProducto(OOB.LibCompra.Producto.Data.Ficha prd) 
        {
            this.producto = prd;
        }

        public void ActualizarCosto()
        {
            costoMoneda = costoDivisa * factorDivisa;
            CalculaDscto();
        }

        public void ActualizarCostoDivisa()
        {
            costoDivisa = costoMoneda  / factorDivisa;
            CalculaDscto();
        }

        public void CalculaDscto()
        {
            var rt = 0.0m;
            rt = costoMoneda;
            if (dsct_1_p >= 0) 
            {
                _dscto_1_m = (rt * dsct_1_p / 100);
                rt -= _dscto_1_m ;
            }
            if (dsct_2_p >= 0)
            {
                _dscto_2_m = (rt * dsct_2_p / 100);
                rt -= _dscto_2_m ;
            }
            if (dsct_3_p >= 0)
            {
                _dscto_3_m = (rt * dsct_3_p / 100);
                rt -= _dscto_3_m ;
            }
            costoMoneda_2 = rt;
        }

        public void Limpiar()
        {
            cantidad = 0.0m;
            costoMoneda = 0.0m;
            costoDivisa = 0.0m;
            dsct_1_p = 0.0m;
            dsct_2_p = 0.0m;
            dsct_3_p = 0.0m;
            ActualizarCosto();
            ActualizarCostoDivisa();
            CalculaDscto();
        }

    }

}