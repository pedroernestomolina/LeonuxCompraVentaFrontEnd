using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    
    public partial class DataPrv: IData
    {

        public OOB.Resultado.FichaAuto Producto_BusquedaByCodigo(string buscar)
        {
            var result = new OOB.Resultado.FichaAuto();

            var r01 = MyData.Producto_BusquedaByCodigo(buscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }

        public OOB.Resultado.FichaAuto Producto_BusquedaByPlu(string buscar)
        {
            var result = new OOB.Resultado.FichaAuto();

            var r01 = MyData.Producto_BusquedaByPlu(buscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }

        public OOB.Resultado.FichaAuto Producto_BusquedaByCodigoBarra(string buscar)
        {
            var result = new OOB.Resultado.FichaAuto();

            var r01 = MyData.Producto_BusquedaByCodigoBarra(buscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Auto = r01.Auto;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Producto.Entidad.Ficha> Producto_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Producto.Entidad.Ficha>();

            var r01 = MyData.Producto_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent= r01.Entidad;
            var nr = new OOB.Producto.Entidad.Ficha()
            {
                Auto = ent.Auto,
                AutoDepartamento = ent.AutoDepartamento,
                AutoGrupo = ent.AutoGrupo,
                AutoMarca = ent.AutoMarca,
                AutoSubGrupo = ent.AutoSubGrupo,
                AutoTasaIva = ent.AutoTasaIva,
                AutoMedidaEmpaque_1 = ent.AutoMedidaEmpaque_1,
                AutoMedidaEmpaque_2 = ent.AutoMedidaEmpaque_2,
                AutoMedidaEmpaque_3 = ent.AutoMedidaEmpaque_3,
                AutoMedidaEmpaque_4 = ent.AutoMedidaEmpaque_4,
                AutoMedidaEmpaque_5 = ent.AutoMedidaEmpaque_5,
                Categoria = ent.Categoria,
                CodDepartamento = ent.CodDepartamento,
                CodGrupo = ent.CodGrupo,
                CodigoPLU = ent.CodigoPLU,
                CodigoPrd = ent.CodigoPrd,
                Estatus = ent.Estatus,
                EstatusDivisa = ent.EstatusDivisa,
                EstatusOferta = ent.EstatusOferta,
                EstatusPesado = ent.EstatusPesado,
                Marca = ent.Marca,
                Modelo = ent.Modelo,
                NombreDepartamento = ent.NombreDepartamento,
                NombreGrupo = ent.NombreGrupo,
                NombrePrd = ent.NombrePrd,
                NombreTasa = ent.NombreTasa,
                Pasillo = ent.Pasillo,
                Referencia = ent.Referencia,
                TasaImpuesto = ent.TasaImpuesto,
                pneto_1 = ent.pneto_1,
                pneto_2 = ent.pneto_2,
                pneto_3 = ent.pneto_3,
                pneto_4 = ent.pneto_4,
                pneto_5 = ent.pneto_5,
                pdf_1 = ent.pdf_1,
                pdf_2 = ent.pdf_2,
                pdf_3 = ent.pdf_3,
                pdf_4 = ent.pdf_4,
                pdf_5 = ent.pdf_5,
                contenido_1 = ent.contenido_1,
                contenido_2 = ent.contenido_2,
                contenido_3 = ent.contenido_3,
                contenido_4 = ent.contenido_4,
                contenido_5 = ent.contenido_5,
                empaque_1 = ent.empaque_1,
                empaque_2 = ent.empaque_2,
                empaque_3 = ent.empaque_3,
                empaque_4 = ent.empaque_4,
                empaque_5 = ent.empaque_5,
                decimales_1 = ent.decimales_1,
                decimales_2 = ent.decimales_2,
                decimales_3 = ent.decimales_3,
                decimales_4 = ent.decimales_4,
                decimales_5 = ent.decimales_5,
                Costo=ent.Costo,
                CostoPromedio=ent.CostoPromedio,
                CostoPromedioUnidad=ent.CostoPromedioUnidad,
                CostoUnidad=ent.CostoUnidad,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Producto.Lista.Ficha> Producto_GetLista(OOB.Producto.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Producto.Lista.Ficha>();

            var filtroDTO = new DtoLibPos.Producto.Lista.Filtro()
            {
                AutoDeposito = filtro.autoDeposito,
                IdPrecioManejar = filtro.idPrecioManejar,
                Cadena = filtro.cadena,
                IsPorPlu=filtro.isPorPlu,
            };
            var r01 = MyData.Producto_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Producto.Lista.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Producto.Lista.Ficha()
                        {
                            Auto = s.Auto,
                            Codigo = s.Codigo,
                            Contenido = s.Contenido,
                            Decimales = s.Decimales,
                            Empaque = s.Empaque,
                            Estatus = s.Estatus,
                            EstatusDivisa = s.EstatusDivisa,
                            EstatusPesado = s.EstatusPesado,
                            ExDisponible = s.ExDisponible,
                            ExFisica = s.ExFisica,
                            Nombre = s.Nombre,
                            PrecioFullDivisa = s.PrecioFullDivisa,
                            PrecioNeto = s.PrecioNeto,
                            TasaIva = s.TasaIva,
                            PLU=s.PLU,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Producto.Existencia.Entidad.Ficha> Producto_Existencia_GetByPrdDeposito(OOB.Producto.Existencia.Buscar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Producto.Existencia.Entidad.Ficha>();

            var fichaDTO = new DtoLibPos.Producto.Existencia.Buscar.Ficha()
            {
                autoDeposito = ficha.autoDeposito,
                autoPrd = ficha.autoPrd,
            };
            var r01 = MyData.Producto_Existencia_GetByPrdDeposito(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent= r01.Entidad;
            var nr = new OOB.Producto.Existencia.Entidad.Ficha()
            {
                autoDeposito = ent.autoDeposito,
                autoPrd = ent.autoPrd,
                codigoDeposito = ent.codigoDeposito,
                codigoPrd = ent.codigoPrd,
                exDisponible = ent.exDisponible,
                exFisica = ent.exFisica,
                nombreDeposito = ent.nombreDeposito,
                nombrePrd = ent.nombrePrd,
            };
            result.Entidad=nr;

            return result;
        }

    }

}