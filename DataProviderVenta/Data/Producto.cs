using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoLista<OOB.LibVenta.Inventario.Producto.Ficha> ProductoLista(OOB.LibVenta.Inventario.Producto.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibVenta.Inventario.Producto.Ficha>();

            var filtroDTO = new DtoLibVenta.Inventario.Producto.Filtro();
            filtroDTO.cadena = filtro.cadena;
            filtroDTO.preferenciaBusqueda = (DtoLibVenta.Inventario.Enumerados.enumPreferenciaBusqueda)filtro.preferenciaBusqueda;
            var r01 = MyData.ProductoLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Lista = new List<OOB.LibVenta.Inventario.Producto.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    result.Lista = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.Inventario.Producto.Ficha()
                        {
                            Auto=s.Auto,
                            CodigoPrd=s.CodigoPrd,
                            NombrePrd=s.NombrePrd,
                            Referencia=s.ReferenciaPrd,
                            IsActivo=s.IsActivo,
                        };
                    }).ToList();
                }
            }

            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Producto.Ficha> ProductoDetalle(string auto)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Producto.Ficha>();

            var r01 = MyData.ProductoDetalle(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var r02 = MyData.ProductoExistencia (auto);
            if (r02.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r02.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var r03 = MyData.ProductoPrecios(auto);
            if (r03.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r03.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var s = r01.Entidad;
            var ent = new OOB.LibVenta.Inventario.Producto.Ficha()
            {
                Auto=s.Auto,
                CodigoPrd=s.CodigoPrd,
                Comentarios=s.Comentarios,
                ContenidoEmpCompra=s.ContenidoEmpCompra,
                CostoUnidad=s.CostoUnidad,
                NombreDepartamento=s.Departamento,
                DescripcionPrd=s.DescripcionPrd,
                FechaUltActCosto =s.FechaUltActCosto,
                FechaUltActPrecio=s.FechaUltActPrecio,
                FechaUltVenta=s.FechaUltVenta,
                NombreGrupo=s.Grupo,
                IsActivo=s.IsActivo,
                IsDivisa=s.IsDivisa,
                IsPesado=s.IsPesado,
                Marca=s.Marca,
                Modelo=s.Modelo,
                MontoDivisa=s.MontoDivisa,
                NombreEmpCompra=s.NombreEmpCompra,
                NombrePrd=s.NombrePrd,
                PLU=s.PLU,
                PrecioSugerido=s.PrecioSugerido,
                Referencia=s.Referencia,
                TasaImpuesto=s.TasaImpuesto,
            };

            result.Entidad = ent;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Producto.Ficha> Producto(string auto)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Producto.Ficha>();

            var r01 = MyData.Producto(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var s = r01.Entidad;
            var ent = new OOB.LibVenta.Inventario.Producto.Ficha()
            {
                Auto = s.Auto,
                AutoDepartamento=s.AutoDepartamento ,
                AutoGrupo=s.AutoGrupo ,
                AutoMarca=s.AutoMarca ,
                AutoSubGrupo=s.AutoSubGrupo ,
                AutoTasa=s.AutoTasa,
                Categoria=s.Categoria,
                CodigoDepartamento=s.CodigoDepartamento,
                CodigoGrupo=s.CodigoGrupo,
                CodigoPrd = s.CodigoPrd,
                Comentarios = s.Comentarios,
                ContenidoEmpCompra = s.ContenidoEmpCompra,
                Costo=s.Costo,
                CostoUnidad = s.CostoUnidad,
                CostoPromedioUnidad=s.CostoPromedioUnidad,
                CostoPromedio=s.CostoPromedio,
                NombreDepartamento = s.NombreDepartamento,
                DescripcionPrd = s.DescripcionPrd,
                FechaUltActCosto = s.FechaUltActCosto,
                FechaUltActPrecio = s.FechaUltActPrecio,
                FechaUltVenta = s.FechaUltVenta,
                NombreGrupo = s.NombreGrupo ,
                IsActivo = s.IsActivo,
                IsDivisa = s.IsDivisa,
                IsPesado = s.IsPesado,
                IsSerial=s.IsSerial,
                IsGarantia=s.IsGarantia,
                Marca = s.Marca,
                Modelo = s.Modelo,
                MontoDivisa = s.MontoDivisa,
                NombreEmpCompra = s.NombreEmpCompra,
                NombrePrd = s.NombrePrd,
                PLU = s.PLU,
                PrecioSugerido = s.PrecioSugerido,
                Referencia = s.Referencia,
                TasaImpuesto = s.TasaImpuesto,
                DiasGarantia= s.DiasGarantia,
                Decimales=s.Decimales,
            };

            result.Entidad = ent;
            return result;
        }

    }

}