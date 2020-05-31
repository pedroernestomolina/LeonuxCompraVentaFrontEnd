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

        public OOB.Resultado Pendiente_DejarCtaEnPendiente(OOB.LibVenta.PosOffline.Pendiente.DejarEnPendiente.Agregar ficha)
        {
            var rt = new OOB.Resultado();

            var agregarDTO = new DtoLibPosOffLine.Pendiente.DejarEnPendiente.Agregar()
            {
                IdCliente = ficha.IdCliente,
                Monto = ficha.Monto,
                Renglones = ficha.Renglones,
            };
            var agregarItemDto = ficha.Items.Select(s =>
            {
                var t = new DtoLibPosOffLine.Pendiente.DejarEnPendiente.AgregarItem()
                {
                    IdItem = s.IdItem,
                };
                return t;
            }).ToList();
            agregarDTO.Items = agregarItemDto;

            var r01 = MyData.Pendiente_DejarCtaEnPendiente(agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Pendiente.Ficha> Pendiente_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Pendiente.Ficha>();

            var r01 = MyData.Pendiente_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Pendiente.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.Pendiente.Ficha()
                        {
                            Id = s.Id,
                            IdCliente=s.IdCliente,
                            Cliente = s.Cliente,
                            Fecha = s.Fecha,
                            Monto = s.Monto,
                            Renglones = s.Renglones,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Pendiente_EliminarCta(int id)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Pendiente_EliminarCtaEnPendiente(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Pendiente.CtaAbrir.Ficha> Pendiente_AbrirCta(int id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Pendiente.CtaAbrir.Ficha>();

            var r01 = MyData.Pendiente_AbrirCtaEnPendiente(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var ent=r01.Entidad ;
            var nr = new OOB.LibVenta.PosOffline.Pendiente.CtaAbrir.Ficha()
            {
                IdCliente = ent.IdCliente,
                Items = ent.Items.Select(s =>
                {
                    var r = new OOB.LibVenta.PosOffline.Item.Ficha() 
                    {
                        Id = s.Id,
                        AutoPrd = s.AutoPrd,
                        NombrePrd = s.NombrePrd,
                        Cantidad = s.Cantidad,
                        TasaImpuesto = s.TasaImpuesto,
                        PrecioNeto = s.PrecioNeto,
                        EsPesado = s.EsPesado,
                        TipoIva = s.TipoIva,
                        CostoCompraUnd = s.CostoCompraUnd,
                        CostoPromedioUnd = s.CostoPromedioUnd,
                        AutoDepartamento = s.AutoDepartamento,
                        AutoGrupo = s.AutoGrupo,
                        AutoSubGrupo = s.AutoSubGrupo,
                        AutoTasaIva = s.AutoTasaIva,
                        Categoria = s.Categoria,
                        CodigoPrd = s.CodigoPrd,
                        Decimales = s.Decimales,
                        DiasEmpaqueGarantia = s.DiasEmpaqueGarantia,
                        EmpCodigo = s.EmpCodigo,
                        EmpDescripcion = s.EmpDescripcion,
                        EmpContenido = s.EmpContenido,
                        Tarifa = s.TarifaPrecio,
                        PrecioSugerido = s.PrecioSugerido,
                    };
                    return r;
                }).ToList(),
            };
            rt.Entidad=nr;

            return rt;
        }


    }

}