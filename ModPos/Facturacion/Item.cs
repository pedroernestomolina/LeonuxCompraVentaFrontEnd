using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{
    
    public class Item
    {

        public int Id { get; set; }
        public string AutoId { get; set; }
        public string NombrePrd { get; set; }
        public decimal  Cantidad { get; set; }
        public decimal TasaIva { get; set; }
        public decimal PrecioNeto { get; set; }
        public bool EsPesado { get; set; }
        public string TipoIva { get; set; }
        public decimal CostoUnd { get; set; }
        public decimal CostoPromUnd { get; set; }
        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoSubGrupo { get; set; }
        public string AutoTasa { get; set; }
        public string CodigoPrd { get; set; }
        public string Decimales { get; set; }
        public string Categoria { get; set; }
        public string EmpaqueCodigo { get; set; }
        public string EmpaqueDescripcion { get; set; }
        public int EmpaqueContenido { get; set; }
        public int DiasEmpaqueGarantia { get; set; }
        public string TarifaPrecio { get; set; }
        public decimal PrecioSugerido { get; set; }
        public OOB.LibVenta.PosOffline.VentaDocumento.FichaDetalle DetalleItem { get; set; }


        public int CantItem 
        {
            get 
            {
                var rt = (int)Cantidad;
                if (EsPesado)
                {
                    rt = 1;
                }
                return rt;
            }
        }

        public decimal TotalPeso 
        {
            get
            {
                var rt = Cantidad;
                if (!EsPesado)
                {
                    rt = 0.0m;
                }
                return rt;
            }
        }

        public string TasaIvaDesc 
        {
            get 
            {
                var rt = "Ex";
                if (TasaIva > 0) 
                {
                    rt = TasaIva.ToString("n2");
                }
                return rt;
            }
        }

        public decimal Iva 
        {
            get 
            {
                var rt = 0.0m;
                rt = PrecioNeto * TasaIva/100;
                return rt; 
            } 
        }

        public decimal PrecioFull // PRECIO NETO CON IVA
        { 
            get 
            {
                var rt = 0.0m;
                rt = PrecioNeto + Iva ;
                return rt; 
            } 
        }

        public decimal DescuentoItem  // DESCUENTOS DADOS AL ITEM
        {
            get 
            {
                var rt = 0.0m;
                return rt;
            }
        }

        public decimal PrecioItem // PRECIO NETO  MENOS LOS DESCUENTOS DEL ITEM 
        {
            get
            {
                var rt = 0.0m;
                rt = PrecioNeto-DescuentoItem;
                return rt;
            }
        }

        public decimal TotalDescuentoItem  // TOTAL DESCUENTOS DADOS AL ITEM
        {
            get
            {
                var rt = 0.0m;
                return rt;
            }
        }

        public decimal Importe 
        { 
            get 
            {
                return PrecioFull;
            } 
        }

        public decimal Total 
        {
            get 
            {
                var rt = 0.0m;
                rt = Cantidad * Importe;
                return rt; 
            } 
        }

        public decimal TotalNeto
        {
            get
            {
                var rt = 0.0m;
                rt = Cantidad * PrecioNeto;
                return rt;
            }
        }

        public bool EsExento 
        {
            get 
            {
                return (TasaIva == 0.0m);
            }
        }


        public decimal DsctoNeto 
        {
            get
            {
                var rt = 0.0m;
                rt = PrecioNeto * _dsctoGlobal / 100 ;
                return rt;
            }
        }

        public decimal MontoDsctoNeto
        {
            get
            {
                var rt = 0.0m;
                rt = (PrecioNeto * Cantidad) * (_dsctoGlobal / 100);
                return rt;
            }
        }

        public decimal MontoDscto
        {
            get
            {
                var rt = 0.0m;
                rt = (PrecioFull * Cantidad) * (_dsctoGlobal / 100);
                return rt;
            }
        }

        public decimal PrecioFinalNeto
        {
            get 
            {
                var rt = 0.0m;
                rt = PrecioNeto - DsctoNeto;
                return rt;
            }
        }

        public decimal MontoExento 
        {
            get 
            {
                var rt = 0.0m;
                if (EsExento) 
                {
                    rt = PrecioFinalNeto * Cantidad;
                }
                return rt;
            }
        }

        public decimal MontoBase
        {
            get
            {
                var rt = 0.0m;
                if (!EsExento)
                {
                    rt = PrecioFinalNeto * Cantidad;
                }
                return rt;
            }
        }

        public decimal MontoImpuesto
        {
            get
            {
                var rt = 0.0m;
                if (!EsExento)
                {
                    rt = MontoBase* TasaIva/100;
                }
                return rt;
            }
        }

        public decimal CostoVenta 
        {
            get 
            {
                var rt = 0.0m;
                rt = (CostoUnd * Cantidad);
                return rt;
            }
        }

        public decimal VentaNeta 
        {
            get 
            {
                var rt = 0.0m;
                rt = MontoExento + MontoBase;
                return rt;
            }
        }

        public decimal UtilidadNetaMonto 
        {
            get
            {
                var rt = 0.0m;
                rt = VentaNeta - CostoVenta;
                return rt;
            }
        }

        public decimal UtilidadNetaPorct
        {
            get
            {
                var rt = 0.0m;
                rt = (1- (CostoVenta/VentaNeta))*100 ;
                return rt;
            }
        }


        public Item() 
        {
            Id = -1;
            AutoId = "";
            NombrePrd = "";
            Cantidad = 0.0m;
            PrecioNeto = 0.0m;
            TasaIva = 0.0m;
            EsPesado = false;
            TipoIva = "";
            CostoUnd = 0.0m;
            CostoPromUnd = 0.0m;
            AutoDepartamento = "";
            AutoGrupo = "";
            AutoSubGrupo = "";
            AutoTasa = "";
            Categoria = "";
            CodigoPrd = "";
            Decimales="";
            EmpaqueCodigo = "";
            EmpaqueDescripcion = "";
            EmpaqueContenido = 1;
            DiasEmpaqueGarantia = 0;
            TarifaPrecio = "";
            PrecioSugerido = 0.0m;
        }

        public Item(Item it)
            : this()
        {
            Id = it.Id;
            AutoId = it.AutoId;
            NombrePrd = it.NombrePrd;
            Cantidad = it.Cantidad;
            PrecioNeto = it.PrecioNeto;
            TasaIva = it.TasaIva;
            EsPesado = it.EsPesado;
            TipoIva = it.TipoIva;
            CostoUnd = it.CostoUnd;
            CostoPromUnd = it.CostoPromUnd;
            AutoDepartamento = it.AutoDepartamento;
            AutoGrupo = it.AutoGrupo;
            AutoSubGrupo = it.AutoSubGrupo;
            AutoTasa = it.AutoTasa;
            Categoria = it.Categoria;
            CodigoPrd = it.CodigoPrd;
            Decimales = it.Decimales;
            EmpaqueCodigo = it.EmpaqueCodigo;
            EmpaqueDescripcion = it.EmpaqueDescripcion;
            EmpaqueContenido = it.EmpaqueContenido;
            DiasEmpaqueGarantia = it.DiasEmpaqueGarantia;
            TarifaPrecio = it.TarifaPrecio;
            PrecioSugerido = it.PrecioSugerido;
        }

        public Item(OOB.LibVenta.PosOffline.Item.Ficha it) 
            : this()
        {
            Id = it.Id;
            AutoId = it.AutoPrd;
            NombrePrd = it.NombrePrd;
            Cantidad = it.Cantidad;
            PrecioNeto=it.PrecioNeto;
            TasaIva = it.TasaImpuesto;
            EsPesado = it.EsPesado;
            TipoIva = it.TipoIva;
            CostoUnd = it.CostoCompraUnd;
            CostoPromUnd = it.CostoPromedioUnd;
            AutoDepartamento = it.AutoDepartamento;
            AutoGrupo = it.AutoGrupo;
            AutoSubGrupo = it.AutoSubGrupo;
            AutoTasa = it.AutoTasaIva;
            Categoria = it.Categoria;
            CodigoPrd = it.CodigoPrd;
            Decimales = it.Decimales;
            EmpaqueCodigo = it.EmpCodigo;
            EmpaqueDescripcion = it.EmpDescripcion;
            EmpaqueContenido = it.EmpContenido;
            DiasEmpaqueGarantia = it.DiasEmpaqueGarantia;
            TarifaPrecio = it.Tarifa;
            PrecioSugerido = it.PrecioSugerido;
        }

        public Item(OOB.LibVenta.PosOffline.VentaDocumento.FichaDetalle it)
            : this()
        {
            Id = it.Id;
            AutoId = it.AutoProducto;
            NombrePrd = it.NombreProducto;
            Cantidad = it.Cantidad;
            PrecioNeto = it.PrecioNeto;
            TasaIva = it.TasaIva;
            EsPesado = it.EsPesado;
            TipoIva = it.TipoIva;
            CostoUnd = it.CostoCompraUnd;
            CostoPromUnd = it.CostoPromedioUnd;
            AutoDepartamento = it.AutoDepartamento;
            AutoGrupo = it.AutoGrupo;
            AutoSubGrupo = it.AutoSubGrupo;
            AutoTasa = it.AutoTasa;
            Categoria = it.Categoria;
            CodigoPrd = it.CodigoProducto;
            Decimales = it.Decimales;
            EmpaqueCodigo = it.EmpaqueCodigo ;
            EmpaqueDescripcion = it.EmpaqueDescripcion;
            EmpaqueContenido = it.EmpaqueContenido;
            DiasEmpaqueGarantia = it.DiaEmpaqueGarantia;
            TarifaPrecio = it.Tarifa;
            PrecioSugerido = it.PrecioSugerido;
            DetalleItem = it;
        }

        private decimal _dsctoGlobal;
        public void setDescuentoGlobal(decimal dct) 
        {
            _dsctoGlobal = dct;
        }

        private decimal _cargoGlobal;
        public void setCargoGlobal(decimal cargo) 
        {
            _cargoGlobal = cargo;
        }

    }

}