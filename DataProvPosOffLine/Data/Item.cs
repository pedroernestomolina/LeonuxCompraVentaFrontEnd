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

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Item.Ficha> Item(int id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Item.Ficha>();

            var r01 = MyData.Item(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var c = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Item.Ficha ()
            {
                Id = c.Id,
                AutoPrd=c.AutoPrd,
                NombrePrd=c.NombrePrd,
                Cantidad=c.Cantidad,
                TasaImpuesto=c.TasaImpuesto,
                PrecioNeto=c.PrecioNeto,
                EsPesado=c.EsPesado,
                TipoIva=c.TipoIva,
                CostoCompraUnd=c.CostoCompraUnd,
                CostoPromedioUnd=c.CostoPromedioUnd,
                AutoDepartamento=c.AutoDepartamento,
                AutoGrupo=c.AutoGrupo,
                AutoSubGrupo=c.AutoSubGrupo,
                AutoTasaIva=c.AutoTasaIva,
                Categoria=c.Categoria,
                CodigoPrd=c.CodigoPrd,
                Decimales=c.Decimales,
                DiasEmpaqueGarantia = c.DiasEmpaqueGarantia,
                EmpCodigo = c.EmpCodigo,
                EmpDescripcion = c.EmpDescripcion,
                EmpContenido = c.EmpContenido,
                Tarifa = c.TarifaPrecio,
                PrecioSugerido = c.PrecioSugerido,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoId Item_Agregar(OOB.LibVenta.PosOffline.Item.Agregar ficha)
        {
            var rt = new OOB.ResultadoId();

            var agregarDTO = new DtoLibPosOffLine.Item.Agregar()
            {
                 AutoPrd=ficha.AutoPrd,
                 NombrePrd=ficha.NombrePrd,
                 Cantidad=ficha.Cantidad,
                 TasaImpuesto=ficha.TasaImpuesto,
                 PrecioNeto=ficha.PrecioNeto,
                 EsPesado=ficha.EsPesado?1:0,
                 TipoIva=ficha.TipoIva,
                 CostoCompraUnd=ficha.CostoCompraUnd,
                 CostoPromedioUnd=ficha.CostoPromedioUnd,
                 AutoDepartamento = ficha.AutoDepartamento,
                 AutoGrupo = ficha.AutoGrupo,
                 AutoSubGrupo = ficha.AutoSubGrupo,
                 AutoTasaIva = ficha.AutoTasaIva,
                 Categoria = ficha.Categoria,
                 CodigoPrd = ficha.CodigoPrd,
                 Decimales = ficha.Decimales,
                 DiasEmpaqueGarantia=ficha.DiasEmpaqueGarantia,
                 EmpCodigo=ficha.EmpCodigo,
                 EmpDescripcion=ficha.EmpDescripcion,
                 EmpContenido=ficha.EmpContenido,
                 TarifaPrecio=ficha.Tarifa,
                 PrecioSugerido=ficha.PrecioSugerido,
                 CostoCompra=ficha.CostoCompra,
                 CostoPromedio=ficha.CostoPromedio,
            };
            var r01 = MyData.Item_Agregar(agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Item.Ficha> Item_Cargar()
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Item.Ficha>();

            var r01 = MyData.Item_Cargar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Item.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibVenta.PosOffline.Item.Ficha()
                        {
                            Id = s.Id,
                            AutoPrd = s.AutoPrd,
                            NombrePrd = s.NombrePrd,
                            Cantidad = s.Cantidad,
                            TasaImpuesto = s.TasaImpuesto,
                            PrecioNeto = s.PrecioNeto,
                            EsPesado = s.EsPesado,
                            TipoIva=s.TipoIva,
                            CostoCompraUnd = s.CostoCompraUnd,
                            CostoPromedioUnd = s.CostoPromedioUnd,
                            AutoDepartamento = s.AutoDepartamento,
                            AutoGrupo = s.AutoGrupo,
                            AutoSubGrupo = s.AutoSubGrupo,
                            AutoTasaIva = s.AutoTasaIva,
                            Categoria = s.Categoria,
                            CodigoPrd = s.CodigoPrd,
                            Decimales = s.Decimales,
                            DiasEmpaqueGarantia=s.DiasEmpaqueGarantia,
                            EmpCodigo=s.EmpCodigo,
                            EmpDescripcion=s.EmpDescripcion,
                            EmpContenido=s.EmpContenido,
                            Tarifa=s.TarifaPrecio,
                            PrecioSugerido=s.PrecioSugerido,
                            CostoCompra = s.CostoCompra,
                            CostoPromedio = s.CostoPromedio,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Item_Limpiar()
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Item_Limpiar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Item_Actualizar(OOB.LibVenta.PosOffline.Item.Actualizar ficha)
        {
            var rt = new OOB.Resultado();

            var actualizarDTO = new DtoLibPosOffLine.Item.Actualizar()
            {
                Id=ficha.Id,
                Cantidad = ficha.Cantidad,
                Precio=ficha.precio,
                Tarifa=ficha.tarifa,
            };
            var r01 = MyData.Item_Actualizar(actualizarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Item_Eliminar(int id)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Item_Eliminar(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}