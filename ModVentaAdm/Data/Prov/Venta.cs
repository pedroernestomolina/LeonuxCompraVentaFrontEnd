using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Prov
{

    public partial class DataPrv : IData
    {

        public OOB.Resultado.FichaId Venta_Temporal_Encabezado_Registrar(OOB.Venta.Temporal.Encabezado.Registrar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaId();

            var fichaDTO = new DtoLibPos.VentaAdm.Temporal.Encabezado.Registrar.Ficha()
            {
                autoCliente = ficha.autoCliente,
                autoDeposito = ficha.autoDeposito,
                autoSistDocumento = ficha.autoSistDocumento,
                autoSucursal = ficha.autoSucursal,
                autoUsuario = ficha.autoUsuario,
                ciRifCliente = ficha.ciRifCliente,
                estatusPendiente = ficha.estatusPendiente,
                factorDivisa = ficha.factorDivisa,
                idEquipo = ficha.idEquipo,
                monto = ficha.monto,
                montoDivisa = ficha.montoDivisa,
                nombreDeposito = ficha.nombreDeposito,
                nombreSistDocumento = ficha.nombreSistDocumento,
                nombreSucursal = ficha.nombreSucursal,
                nombreUsuario = ficha.nombreUsuario,
                razonSocialCliente = ficha.razonSocialCliente,
                renglones = ficha.renglones,
            };
            var r01 = MyData.VentaAdm_Temporal_Encabezado_Registrar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            result.Id = r01.Id;
            return result;
        }

        public OOB.Resultado.Ficha Venta_Temporal_Encabezado_Eliminar(int idEncabezado)
        {
            var result = new OOB.Resultado.Ficha();

            var r01 = MyData.VentaAdm_Temporal_Encabezado_Eliminar(idEncabezado);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.Ficha Venta_Temporal_Encabezado_Editar(OOB.Venta.Temporal.Encabezado.Editar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.VentaAdm.Temporal.Encabezado.Editar.Ficha()
            {
                id = ficha.id,
                autoCliente = ficha.autoCliente,
                autoDeposito = ficha.autoDeposito,
                autoSucursal = ficha.autoSucursal,
                ciRifCliente = ficha.ciRifCliente,
                nombreDeposito = ficha.nombreDeposito,
                nombreSucursal = ficha.nombreSucursal,
                razonSocialCliente = ficha.razonSocialCliente,
            };
            var r01 = MyData.VentaAdm_Temporal_Encabezado_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.FichaId Venta_Temporal_Item_Registrar(OOB.Venta.Temporal.Item.Registrar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaId();

            var xenc=ficha.itemEncabezado;
            var xit = ficha.itemDetalle;
            var fichaDTO = new DtoLibPos.VentaAdm.Temporal.Item.Registrar.Ficha()
            {
                validarExistencia = ficha.validarExistencia,
                itemEncabezado = new DtoLibPos.VentaAdm.Temporal.Item.Registrar.ItemEncabezado()
                {
                    id = xenc.id,
                    monto = xenc.monto,
                    montoDivisa = xenc.montoDivisa,
                    renglones = xenc.renglones,
                },
                itemActDeposito = null,
                itemDetalle = new DtoLibPos.VentaAdm.Temporal.Item.Registrar.ItemDetalle()
                {
                    autoDepartamento = xit.autoDepartamento,
                    autoGrupo = xit.autoGrupo,
                    autoProducto = xit.autoProducto,
                    autoSubGrupo = xit.autoSubGrupo,
                    autoTasaIva = xit.autoTasaIva,
                    cantidad = xit.cantidad,
                    categroiaProducto = xit.categroiaProducto,
                    codigoProducto = xit.codigoProducto,
                    costo = xit.costo,
                    costoPromd = xit.costoPromd,
                    costoPromdUnd = xit.costoPromdUnd,
                    costoUnd = xit.costoUnd,
                    decimalesProducto = xit.decimalesProducto,
                    dsctoPorct = xit.dsctoPorct,
                    empaqueCont = xit.empaqueCont,
                    empaqueDesc = xit.empaqueDesc,
                    estatusPesadoProducto = xit.estatusPesadoProducto,
                    estatusReservaMerc = xit.estatusReservaMerc,
                    idVenta = xit.idVenta,
                    nombreProducto = xit.nombreProducto,
                    notas = xit.notas,
                    precioNeto = xit.precioNeto,
                    precioNetoDivisa = xit.precioNetoDivisa,
                    tarifaPrecio = xit.tarifaPrecio,
                    tasaIva = xit.tasaIva,
                    tipoIva = xit.tipoIva,
                },
            };
            if (ficha.itemActDeposito !=null)
            {
                var xdep=ficha.itemActDeposito;
                fichaDTO.itemActDeposito = new DtoLibPos.VentaAdm.Temporal.Item.Registrar.ItemActDeposito()
                {
                    autoDeposito = xdep.autoDeposito,
                    autoProducto = xdep.autoProducto,
                    cntActualizar = xdep.cntActualizar,
                    prdDescripcion = xdep.prdDescripcion,
                };
            }
            var r01 = MyData.VentaAdm_Temporal_Item_Registrar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            result.Id = r01.Id;
            return result;
        }

        public OOB.Resultado.Ficha Venta_Temporal_Anular(OOB.Venta.Temporal.Anular.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var fichaDTO = new DtoLibPos.VentaAdm.Temporal.Anular.Ficha()
            {
                IdEncabezado = ficha.IdEncabezado,
                Items = ficha.Items.Select(s =>
                {
                    var rg = new DtoLibPos.VentaAdm.Temporal.Anular.Item()
                    {
                        idItem = s.idItem,
                    };
                    return rg;
                }).ToList(),
                ItemsActDeposito = ficha.ItemsActDeposito.Select(s =>
                {
                    var rg = new DtoLibPos.VentaAdm.Temporal.Anular.ItemActDeposito()
                    {
                        prdDescripcion = s.prdDescripcion,
                        autoDeposito = s.autoDeposito,
                        autoProducto = s.autoProducto,
                        cntActualizar = s.cntActualizar,
                    };
                    return rg;
                }).ToList(),
            };
            var r01 = MyData.VentaAdm_Temporal_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Venta.Temporal.Item.Entidad.Ficha> Venta_Temporal_Item_GetFichaById(int idItem)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Venta.Temporal.Item.Entidad.Ficha>();

            var r01 = MyData.VentaAdm_Temporal_Item_GetFichaById(idItem);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var xit= r01.Entidad;
            result.Entidad = new OOB.Venta.Temporal.Item.Entidad.Ficha()
            {
                id=xit.id,
                autoDepartamento = xit.autoDepartamento,
                autoGrupo = xit.autoGrupo,
                autoProducto = xit.autoProducto,
                autoSubGrupo = xit.autoSubGrupo,
                autoTasaIva = xit.autoTasaIva,
                cantidad = xit.cantidad,
                categroiaProducto = xit.categroiaProducto,
                codigoProducto = xit.codigoProducto,
                costo = xit.costo,
                costoPromd = xit.costoPromd,
                costoPromdUnd = xit.costoPromdUnd,
                costoUnd = xit.costoUnd,
                decimalesProducto = xit.decimalesProducto,
                dsctoPorct = xit.dsctoPorct,
                empaqueCont = xit.empaqueCont,
                empaqueDesc = xit.empaqueDesc,
                estatusPesadoProducto = xit.estatusPesadoProducto,
                estatusReservaMerc = xit.estatusReservaMerc,
                nombreProducto = xit.nombreProducto,
                notas = xit.notas,
                precioNeto = xit.precioNeto,
                precioNetoDivisa = xit.precioNetoDivisa,
                tarifaPrecio = xit.tarifaPrecio,
                tasaIva = xit.tasaIva,
                tipoIva = xit.tipoIva,
            };
            return result;
        }

        public OOB.Resultado.Ficha Venta_Temporal_Item_Eliminar(OOB.Venta.Temporal.Item.Eliminar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var xenc = ficha.itemEncabezado;
            var xit = ficha.itemDetalle;
            var fichaDTO = new DtoLibPos.VentaAdm.Temporal.Item.Eliminar.Ficha()
            {
                itemEncabezado = new DtoLibPos.VentaAdm.Temporal.Item.Eliminar.ItemEncabezado()
                {
                    id = xenc.id,
                    monto = xenc.monto,
                    montoDivisa = xenc.montoDivisa,
                    renglones = xenc.renglones,
                },
                itemActDeposito = null,
                itemDetalle = new DtoLibPos.VentaAdm.Temporal.Item.Eliminar.ItemDetalle()
                {
                    id = xit.id,
                },
            };
            if (ficha.itemActDeposito != null)
            {
                var xdep = ficha.itemActDeposito;
                fichaDTO.itemActDeposito = new DtoLibPos.VentaAdm.Temporal.Item.Eliminar.ItemActDeposito()
                {
                    autoDeposito = xdep.autoDeposito,
                    autoProducto = xdep.autoProducto,
                    cntActualizar = xdep.cntActualizar,
                    prdDescripcion = xdep.prdDescripcion,
                };
            }
            var r01 = MyData.VentaAdm_Temporal_Item_Eliminar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado.Ficha Venta_Temporal_Item_Limpiar(OOB.Venta.Temporal.Item.Limpiar.Ficha ficha)
        {
            var result = new OOB.Resultado.Ficha();

            var xenc = ficha.itemEncabezado;
            var xit = ficha.itemDetalle;
            var fichaDTO = new DtoLibPos.VentaAdm.Temporal.Item.Limpiar.Ficha()
            {
                itemEncabezado = new DtoLibPos.VentaAdm.Temporal.Item.Limpiar.ItemEncabezado()
                {
                    id = xenc.id,
                },
                itemActDeposito = null,
                itemDetalle = xit.Select(s=> {
                    var rt = new DtoLibPos.VentaAdm.Temporal.Item.Limpiar.ItemDetalle()
                    {
                        id = s.id,
                    };
                    return rt;
                }).ToList(),
            };
            if (ficha.itemActDeposito != null)
            {
                fichaDTO.itemActDeposito = ficha.itemActDeposito.Select(s =>
                {
                    var rt = new DtoLibPos.VentaAdm.Temporal.Item.Limpiar.ItemActDeposito()
                    {
                        autoDeposito = s.autoDeposito,
                        autoProducto = s.autoProducto,
                        cntActualizar = s.cntActualizar,
                        prdDescripcion = s.prdDescripcion,
                    };
                    return rt;
                }).ToList();
            }
            var r01 = MyData.VentaAdm_Temporal_Item_Limpiar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

    }

}