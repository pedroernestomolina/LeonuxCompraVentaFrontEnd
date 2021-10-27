using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> Producto_Lista(string aBuscar)
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha>();

            var r01 = MyData.Producto_Lista (aBuscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Producto.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.Producto.Ficha()
                        {
                            Auto=s.Auto,
                            CodigoPrd=s.CodigoPrd,
                            NombrePrd=s.NombrePrd,
                            IsActivo=s.IsActivo,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<string> Producto_BuscarPorCodigoBarraPlu(string aBuscar)
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Producto_BuscarPorCodigoBarraPlu(aBuscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Producto.Ficha> Producto(string aBuscar)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Producto.Ficha>();

            var r01 = MyData.Producto(aBuscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var prd = r01.Entidad;
            var pv1 = new OOB.LibVenta.PosOffline.Precio.Ficha() 
            {
                 Id="1",
                 ContEmpVenta=prd.Precio_1.Contenido,
                 Decimales = prd.Precio_1.Decimales,
                 PrecioNeto = prd.Precio_1.Neto,
                 DescEmpVenta= prd.Precio_1.Empaque ,
            };
            var pv2 = new OOB.LibVenta.PosOffline.Precio.Ficha()
            {
                Id = "2",
                ContEmpVenta = prd.Precio_2.Contenido,
                Decimales = prd.Precio_2.Decimales,
                PrecioNeto = prd.Precio_2.Neto,
                DescEmpVenta = prd.Precio_2.Empaque,
            };
            var pv3 = new OOB.LibVenta.PosOffline.Precio.Ficha()
            {
                Id = "3",
                ContEmpVenta = prd.Precio_3.Contenido,
                Decimales = prd.Precio_3.Decimales,
                PrecioNeto = prd.Precio_3.Neto,
                DescEmpVenta = prd.Precio_3.Empaque,
            };
            var pv4 = new OOB.LibVenta.PosOffline.Precio.Ficha()
            {
                Id = "4",
                ContEmpVenta = prd.Precio_4.Contenido,
                Decimales = prd.Precio_4.Decimales,
                PrecioNeto = prd.Precio_4.Neto,
                DescEmpVenta = prd.Precio_4.Empaque,
            };
            var pv5 = new OOB.LibVenta.PosOffline.Precio.Ficha()
            {
                Id = "5",
                ContEmpVenta = prd.Precio_5.Contenido,
                Decimales = prd.Precio_5.Decimales,
                PrecioNeto = prd.Precio_5.Neto,
                DescEmpVenta = prd.Precio_5.Empaque,
            };
            var pvMay1 = new OOB.LibVenta.PosOffline.Precio.Ficha()
            {
                Id = "6",
                ContEmpVenta = prd.PrecioMay_1.Contenido,
                Decimales = prd.PrecioMay_1.Decimales,
                PrecioNeto = prd.PrecioMay_1.Neto,
                DescEmpVenta = prd.PrecioMay_1.Empaque,
            };
            var pvMay2 = new OOB.LibVenta.PosOffline.Precio.Ficha()
            {
                Id = "7",
                ContEmpVenta = prd.PrecioMay_2.Contenido,
                Decimales = prd.PrecioMay_2.Decimales,
                PrecioNeto = prd.PrecioMay_2.Neto,
                DescEmpVenta = prd.PrecioMay_2.Empaque,
            };

            var nr= new OOB.LibVenta.PosOffline.Producto.Ficha()
            {
                 Auto= prd.Auto,
                 AutoDepartamento= prd.AutoDepartamento,
                 AutoGrupo= prd.AutoGrupo,
                 AutoMarca= prd.AutoMarca,
                 AutoSubGrupo= prd.AutoSubGrupo,
                 AutoTasa= prd.AutoTasaIva,

                 Categoria= prd.Categoria,
                 CodigoBarra="",
                 CodigoDepartamento=prd.CodDepartamento,
                 CodigoGrupo=prd.CodGrupo,
                 CodigoPrd=prd.CodigoPrd,
                 Costo=prd.Costo,
                 CostoPromedio=prd.CostoPromedio,
                 CostoPromedioUnidad=prd.CostoPromedioUnidad,
                 CostoUnidad=prd.CostoUnidad,

                 DiasEmpaqueGarantia=prd.DiasEmpaqueGarantia,
                 IsActivo=prd.IsActivo,
                 IsDivisa=prd.IsDivisa,
                 IsOferta=prd.IsOferta,
                 IsPesado=prd.IsPesado,
                 IsSerial=false,
                 IsGarantia=false,

                 Marca=prd.Marca,
                 Modelo=prd.Modelo,
                 NombreDepartamento=prd.NombreDepartamento,
                 NombreGrupo=prd.NombreGrupo,
                 NombrePrd=prd.NombrePrd,
                 OfertaDesde=prd.OfertaDesde,
                 OfertaHasta=prd.OfertaHasta,
                 Pasillo=prd.Pasillo,
                 CodigoPlu=prd.CodigoPLU,
                 OfertaPrecio=prd.OfertaPrecio,
                 PrecioSugerido=0.0m,
                 Referencia=prd.Referencia,
                 TasaImpuesto=prd.TasaImpuesto,
                 FechaServidor=prd.FechaServidor,
            };
            nr.Precio_1 = pv1;
            if (nr.IsOfertaActiva) 
            {
                nr.Precio_1.PrecioNeto = nr.OfertaPrecio;
            }
            nr.Precio_2=pv2;
            nr.Precio_3=pv3;
            nr.Precio_4=pv4;
            nr.Precio_5=pv5;
            nr.PrecioMay_1 = pvMay1;
            nr.PrecioMay_2 = pvMay2;
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> ProductoListaPlu()
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha>();

            var r01 = MyData.ProductoListaPlu() ;
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Producto.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.Producto.Ficha()
                        {
                            Auto = s.Auto,
                            CodigoPrd = s.CodigoPrd,
                            NombrePrd = s.NombrePrd,
                            IsActivo = s.IsActivo,
                            CodigoPlu=s.CodigoPlu,
                            DiasEmpaqueGarantia=s.DiasEmpaqueGarantia,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> ProductoListaOferta()
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha>();

            var r01 = MyData.ProductoListaOferta();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Producto.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.Producto.Ficha()
                        {
                            Auto = s.Auto,
                            CodigoPrd = s.CodigoPrd,
                            NombrePrd = s.NombrePrd,
                            IsActivo = s.IsActivo,
                            IsOferta= true,
                            CodigoPlu = s.CodigoPlu,
                            OfertaDesde=s.OfertaDesde,
                            OfertaHasta=s.OfertaHasta,
                            OfertaPrecio=s.PrecioOferta,
                            FechaServidor=s.FechaServidor,
                            PrecioRegular=s.PrecioRegular,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}