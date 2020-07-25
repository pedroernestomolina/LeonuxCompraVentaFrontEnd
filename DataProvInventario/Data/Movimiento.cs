using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo> Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(OOB.LibInventario.Movimiento.Traslado.Consultar.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo>();

            var filtroDto = new DtoLibInventario.Movimiento.Traslado.Consultar.Filtro();
            filtroDto.autoDeposito = filtro.autoDeposito;
            var r01 = MyData.Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo()
                        {
                            autoDepartamento = s.autoDepartamento,
                            autoGrupo = s.autoGrupo,
                            autoProducto = s.autoProducto,
                            categoria = s.categoria,
                            cntUndReponer = s.cntUndReponer,
                            codigoProducto = s.codigoProducto,
                            contenidEmpCompra = s.contenidEmpCompra,
                            costoFinalCompra = s.costoFinalCompra,
                            costoFinalUnd = s.costoFinalUnd,
                            decimales = s.decimales,
                            empaqueCompra = s.empaqueCompra,
                            nombreProducto = s.nombreProducto,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoAuto Producto_Movimiento_Traslado_Insertar(OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                autoConcepto = ficha.autoConcepto,
                autoDepositoDestino = ficha.autoDepositoDestino,
                autoDepositoOrigen = ficha.autoDepositoOrigen,
                autoRemision = ficha.autoRemision,
                autorizado = ficha.autorizado,
                autoUsuario = ficha.autoUsuario,
                cierreFtp = ficha.cierreFtp,
                codConcepto = ficha.codConcepto,
                codDepositoDestino = ficha.codDepositoDestino,
                codDepositoOrigen = ficha.codDepositoOrigen,
                codigoSucursal = ficha.codigoSucursal,
                codUsuario = ficha.codUsuario,
                desConcepto = ficha.desConcepto,
                desDepositoDestino = ficha.desDepositoDestino,
                desDepositoOrigen = ficha.desDepositoOrigen,
                documentoNombre = ficha.documentoNombre,
                estacion = ficha.estacion,
                estatusAnulado = ficha.estatusAnulado,
                estatusCierreContable = ficha.estatusCierreContable,
                nota = ficha.nota,
                renglones = ficha.renglones,
                situacion = ficha.situacion,
                tipo = ficha.tipo,
                total = ficha.total,
                usuario = ficha.usuario,
            };
            var listDet = ficha.detalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaDetalle()
                {
                    autoDepartamento = s.autoDepartamento,
                    autoGrupo = s.autoGrupo,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    categoria = s.categoria,
                    codigoProducto = s.codigoProducto,
                    contEmpaque = s.contEmpaque,
                    costoCompra = s.costoCompra,
                    costoUnd = s.costoUnd,
                    decimales = s.decimales,
                    empaque = s.empaque,
                    estatusAnulado = s.estatusAnulado,
                    estatusUnidad = s.estatusUnidad,
                    nombreProducto = s.nombreProducto,
                    signo = s.signo,
                    tipo = s.tipo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            fichaDTO.detalles = listDet;;

            var listKardex = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigo = s.codigo,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglas = s.siglas,
                    signo = s.signo,
                    total = s.total,
                };
                return dt;
            }).ToList();
            fichaDTO.movKardex = listKardex; ;

            var r01 = MyData.Producto_Movimiento_Traslado_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Ver.Ficha> Producto_Movimiento_GetFicha(string autoDoc)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Ver.Ficha>();

            var r01 = MyData.Producto_Movimiento_GetFicha (autoDoc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Movimiento.Ver.Ficha()
            {
                autorizadoPor = s.autorizadoPor,
                codigoConcepto = s.codigoConcepto,
                codigoDepositoDestino = s.codigoDepositoDestino,
                codigoDepositoOrigen = s.codigoDepositoOrigen,
                concepto = s.concepto,
                depositoDestino = s.depositoDestino,
                depositoOrigen = s.depositoOrigen,
                documentoNro = s.documentoNro,
                estacion = s.estacion,
                fecha = s.fecha,
                hora = s.hora,
                notas = s.notas,
                tipoDocumento = s.tipoDocumento,
                total = s.total,
                usuario = s.usuario,
                usuarioCodigo = s.usuarioCodigo,
            };
            var det = s.detalles.Select(ss =>
            {
                var dt = new OOB.LibInventario.Movimiento.Ver.Detalle()
                {
                    cantidad = ss.cantidad,
                    codigo = ss.codigo,
                    costoUnd = ss.costoUnd,
                    descripcion = ss.descripcion,
                    importe = ss.importe,
                    signo = ss.signo,
                };
                return dt;
            }).ToList();
            nr.detalles = det;
            rt.Entidad = nr;

            return rt;
        }

    }

}