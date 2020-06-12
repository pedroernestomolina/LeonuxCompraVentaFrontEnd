using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Producto
{
    
    public class Ficha
    {

        public string Auto { get; set; }
        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoSubGrupo { get; set; }
        public string AutoMarca { get; set; }
        public string AutoTasa { get; set; }

        public string CodigoPrd { get; set; }
        public string CodigoPlu { get; set; }
        public string CodigoBarra { get; set; }
        public string NombrePrd { get; set; }
        public string Categoria { get; set; }
        public string Referencia { get; set; }

        public string CodigoDepartamento { get; set; }
        public string NombreDepartamento { get; set; }

        public string CodigoGrupo { get; set; }
        public string NombreGrupo { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Pasillo { get; set; }

        public decimal TasaImpuesto { get; set; }
        public decimal Costo { get; set; }
        public decimal CostoUnidad { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal CostoPromedioUnidad { get; set; }
        public decimal PrecioSugerido { get; set; }
        public decimal PrecioRegular { get; set; }

        public bool IsActivo { get; set; }
        public bool IsDivisa { get; set; }
        public bool IsPesado { get; set; }
        public bool IsOferta { get; set; }
        public bool IsGarantia { get; set; }
        public bool IsSerial { get; set; }

        public DateTime FechaServidor { get; set; }
        public int DiasEmpaqueGarantia { get; set; }
        public DateTime? OfertaDesde { get; set; }
        public DateTime? OfertaHasta {get;set;}
        public decimal OfertaPrecio {get;set;}

        public OOB.LibVenta.PosOffline.Precio.Ficha Precio_1 { get; set; }
        public OOB.LibVenta.PosOffline.Precio.Ficha Precio_2 { get; set; }
        public OOB.LibVenta.PosOffline.Precio.Ficha Precio_3 { get; set; }
        public OOB.LibVenta.PosOffline.Precio.Ficha Precio_4 { get; set; }
        public OOB.LibVenta.PosOffline.Precio.Ficha Precio_5 { get; set; }


        public bool IsOfertaActiva
        {
            get
            {
                var rt = false;
                if (IsOferta)
                { 
                    if (OfertaDesde!=null && OfertaHasta!=null)
                    {
                        if (FechaServidor >= OfertaDesde && FechaServidor <= OfertaHasta)
                        {
                            if (OfertaPrecio > 0)
                            {
                                rt = true;
                            }
                        }
                    }
                }
                return rt;
            }
        }

        public bool IsPreEmpaque
        {
            get
            {
                var rt = false;
                if (IsPesado && DiasEmpaqueGarantia>0 )
                {
                    rt = true;
                }
                return rt;
            }
        }

        public bool IsExento 
        {
            get 
            {
                return (TasaImpuesto == 0);
            }
        }

        public string TipoIva 
        {
            get 
            {
                var rt = "";
                if (AutoTasa == "0000000001")
                    rt = "1";
                if (AutoTasa == "0000000002")
                    rt = "2";
                if (AutoTasa == "0000000003")
                    rt = "3";
                return rt;
            }
        }

        public string TasaImpuestoDescripcion 
        {
            get 
            {
                var rt = "EXENTO";
                if (!IsExento) 
                {
                    rt = TasaImpuesto.ToString("n2");
                }
                return rt;
            }
        }


        public Ficha()
        {
            Auto = "";
            AutoDepartamento = "";
            AutoGrupo = "";
            AutoSubGrupo = "";
            AutoMarca = "";
            AutoTasa = "";

            CodigoBarra = "";
            CodigoPlu = "";
            CodigoPrd = "";
            NombrePrd = "";
            Categoria = "";
            Referencia = "";

            CodigoDepartamento = "";
            NombreDepartamento = "";
            CodigoGrupo = "";
            NombreGrupo = "";

            Marca = "";
            Modelo = "";
            Pasillo = "";

            TasaImpuesto = 0.0m;
            Costo = 0.0m;
            CostoUnidad = 0.0m;
            CostoPromedio = 0.0m;
            CostoPromedioUnidad = 0.0m;
            PrecioSugerido = 0.0m;
            PrecioRegular = 0.0m;

            IsActivo = false;
            IsDivisa = false;
            IsPesado = false;
            IsOferta = false;
            IsGarantia = false;
            IsSerial = false;

            FechaServidor = DateTime.Now.Date;
            DiasEmpaqueGarantia = 0;
            OfertaDesde = null;
            OfertaHasta = null;
            OfertaPrecio = 0.0m;

            Precio_1 = new Precio.Ficha();
            Precio_2 = new Precio.Ficha();
            Precio_3 = new Precio.Ficha();
            Precio_4 = new Precio.Ficha();
            Precio_5 = new Precio.Ficha();
        }


        public void Limpiar() 
        {
            Auto = "";
            AutoDepartamento = "";
            AutoGrupo="";
            AutoSubGrupo = "";
            AutoMarca="";
            AutoTasa="";

            CodigoBarra="";
            CodigoPlu="";
            CodigoPrd="";
            NombrePrd="";
            Categoria="";
            Referencia="";

            CodigoDepartamento="";
            NombreDepartamento="";
            CodigoGrupo="";
            NombreGrupo="";

            Marca="";
            Modelo="";
            Pasillo="";

            TasaImpuesto=0.0m;
            Costo=0.0m;
            CostoUnidad=0.0m;
            CostoPromedio=0.0m;
            CostoPromedioUnidad=0.0m;
            PrecioSugerido=0.0m;
            PrecioRegular=0.0m;

            IsActivo=false;
            IsDivisa=false;
            IsPesado=false;
            IsOferta=false;
            IsGarantia=false;
            IsSerial=false;

            FechaServidor=DateTime.Now.Date;
            DiasEmpaqueGarantia=0;
            OfertaDesde=null;
            OfertaHasta=null;
            OfertaPrecio=0.0m;

            Precio_1.Limpiar();
            Precio_2.Limpiar();
            Precio_3.Limpiar();
            Precio_4.Limpiar();
            Precio_5.Limpiar();
        }

    }

}