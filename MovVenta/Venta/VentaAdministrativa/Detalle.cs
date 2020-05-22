using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovVenta.Venta.VentaAdministrativa
{

    public class Detalle
    {

        public OOB.LibVenta.Inventario.Producto.Ficha Producto { get; set; }
        public Precio Precio { get; set; }
        public Existencia Existencia { get; set; }
        public string Notas { get; set; }


        public Detalle() 
        {
            Notas = "";
        }


        public string CodigoPrd 
        {
            get 
            {
                return Producto.CodigoPrd;
            }
        }

        public string NombrePrd
        {
            get
            {
                return Producto.NombrePrd;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return Existencia.CantUndDespachar;
            }
        }

        public bool EsPesado
        {
            get
            {
                return Producto.IsPesado ;
            }
        }

        public string EmpaqueVentaDescripcion
        {
            get
            {
                return Precio.DescEmpVenta;
            }
        }

        public decimal EmpaqueVentaContenido
        {
            get
            {
                return Precio.ContEmpVenta;
            }
        }

        public decimal PrecioVenta
        {
            get
            {
                return Precio.PrecioItem;
            }
        }

        public string TasaIva 
        {
            get
            {
                var rt = "E";
                if (Producto.TasaImpuesto != 0) 
                {
                    rt = Producto.TasaImpuesto.ToString("n2");
                }
                return rt;
            }
        }

        public decimal Importe 
        {
            get 
            {
                var rt = 0.0m;
                rt = Precio.PrecioItem * Existencia.CantUndDespachar;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }

        public decimal Total
        {
            get
            {
                var rt = 0.0m;
                rt = Precio.PrecioFull * Existencia.CantUndDespachar;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        

        public bool ItemIsExento
        {
            get 
            {
                return Producto.IsExento;
            }
        }

        public decimal ItemMontoExento
        {
            get
            {
                var rt = 0.0m;
                if (ItemIsExento) 
                {
                    rt = Precio.PrecioFinal * Existencia.CantUndDespachar;
                    rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                }
                return rt;
            }
        }

        public decimal ItemMontoBase
        {
            get
            {
                var rt = 0.0m;
                if (!ItemIsExento)
                {
                    rt = Precio.PrecioFinal * Existencia.CantUndDespachar;
                    rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                }
                return rt;
            }
        }

        public decimal ItemMontoIva 
        {
            get
            {
                var rt = 0.0m;
                rt = ItemMontoBase * (Producto.TasaImpuesto /100) ;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }


        public decimal CostoVenta
        {
            get 
            {
                var rt=0.0m;
                rt = Producto.CostoUnidad * Cantidad;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }

        public decimal VentaNeta
        {
            get
            {
                var rt = 0.0m;
                rt =  Precio.PrecioFinal * Cantidad;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }

        public decimal UtilidadMonto
        {
            get
            {
                var rt = 0.0m;
                rt = VentaNeta - CostoVenta ;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }

        public decimal UtilidadMargen
        {
            get
            {
                var rt = 0.0m;
                rt =(1- (CostoVenta/VentaNeta))*100;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }

        public decimal DescuentoMontoTotal
        {
            get
            {
                var r = 0.0m;
                r = Precio.DescuentoItemMonto * Cantidad ;
                return r;
            }
        }


        public void setHabilitarRupturaPorExistencia(bool modo)
        {
            Existencia.setHabilitarRupturaPorExistencia(modo);
        }

        public void setDescuentoGlobal(decimal porct) 
        {
            Precio.setDescuentoGlobal(porct);
        }

        public void setCargoGlobal(decimal porct)
        {
            Precio.setCargoGlobal(porct);
        }

    }

}