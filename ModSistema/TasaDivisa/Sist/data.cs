using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.TasaDivisa.Sist
{
    
    public class data
    {
        
        private OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha it;
        private decimal valorDivisa;
        private OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta modoRedondeo ;
        private OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio prefPrecio ;

        public string AutoPrd { get { return it.autoPrd; } }
        public decimal CostoDivisa { get { return it.costoDivisa; } }

        public decimal CostoNuevo 
        {
            get 
            {
                var rt = 0.0m;
                rt = it.costoDivisa * valorDivisa;
                return rt;
            }
        }

        public decimal CostoNuevoUnd
        {
            get
            {
                var rt = 0.0m;
                rt = CostoNuevo/it.contenido;
                return rt;
            }
        }

        public decimal CostoVarios { get { return 0.0m; } }
        public decimal CostoVariosUnd { get { return 0.0m; } }
        public decimal CostoImportacion { get { return 0.0m; } }
        public decimal CostoImportacionUnd { get { return 0.0m; } }
        public decimal CostoProveedor { get { return CostoNuevo; } }
        public decimal CostoProveedorUnd { get { return CostoNuevoUnd; } }
        public decimal Precio_1 { get { return CalculoPrecio(it.precioFullDivisa_1); } }
        public decimal Precio_2 { get { return CalculoPrecio(it.precioFullDivisa_2); } }
        public decimal Precio_3 { get { return CalculoPrecio(it.precioFullDivisa_3); } }
        public decimal Precio_4 { get { return CalculoPrecio(it.precioFullDivisa_4); } }
        public decimal Precio_5 { get { return CalculoPrecio(it.precioFullDivisa_5); } }
        public decimal PrecioMay_1 { get { return CalculoPrecio(it.precioFullDivisaMay_1); } }
        public decimal PrecioMay_2 { get { return CalculoPrecio(it.precioFullDivisaMay_2); } }


        public data(OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha it, decimal montoDivisa, 
            OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta redondeo, 
            OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio preferenciaPrecio)
        {
            this.it = it;
            this.valorDivisa = montoDivisa;
            prefPrecio = preferenciaPrecio;
            modoRedondeo = redondeo;
        }


        private decimal CalculoPrecio(decimal p) 
        {
            var pr = 0.0m;

            if (p > 0)
            {
                pr = p * valorDivisa;
                if (prefPrecio != OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full)
                {
                    pr = pr / ((it.tasaIva / 100) + 1);
                }

                switch (modoRedondeo)
                {
                    case OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinRedeondeo:
                        break;
                    case OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                        if (pr > int.MaxValue)
                        {
                            pr = Helpers.MetodosExtension.RoundUnidad((long)pr);
                        }
                        else 
                        {
                            pr = Helpers.MetodosExtension.RoundUnidad((int)pr);
                        }
                        break;
                    case OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                        if (pr > int.MaxValue)
                        {
                            pr = Helpers.MetodosExtension.RoundDecena((long)pr);
                        }
                        else
                        {
                            pr = Helpers.MetodosExtension.RoundDecena((int)pr);
                        }
                        break;
                }

                if (prefPrecio == OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full) 
                {
                    pr = pr / ((it.tasaIva / 100) + 1);
                }

            }

            return pr;
        }

    }

}