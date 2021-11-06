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
            filtroDto.autoDepartamento = filtro.autoDepartamento;
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
                factorCambio = ficha.factorCambio,
                montoDivisa = ficha.montoDivisa,
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
                    codigo = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglas = s.siglasMov,
                    signo = s.signoMov,
                    total = s.total,
                    codigoConcepto=s.codigoConcepto,
                    nombreConcepto=s.nombreConcepto,
                    codigoDeposito=s.codigoDeposito,
                    nombreDeposito=s.nombreDeposito,
                };
                return dt;
            }).ToList();
            fichaDTO.movKardex = listKardex; ;

            var listPrdDep = ficha.prdDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaPrdDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDepositoOrigen = s.autoDepositoOrigen,
                    autoDepositoDestino = s.autoDepositoDestino,
                    cantidadUnd = s.cantidadUnd,
                };
                return dt;
            }).ToList();
            fichaDTO.prdDeposito = listPrdDep;

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
                nombreDocumento = s.nombreDocumento,
                estatusAnulado=s.estatusAnulado,
                docTipo=  (OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento) s.docTipo,
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
                    cantidadUnd = ss.cantidadUnd,
                    contenido = ss.contenido,
                    empaque = ss.empaque,
                    esUnidad = ss.esUnidad,
                    decimales = ss.decimales,
                };
                return dt;
            }).ToList();
            nr.detalles = det;
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Producto_Movimiento_Cargo_Insertar(OOB.LibInventario.Movimiento.Cargo.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Movimiento.Cargo.Insertar.Ficha()
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
                factorCambio = ficha.factorCambio,
                montoDivisa = ficha.montoDivisa,
            };
            var listDet = ficha.detalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaDetalle()
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
            fichaDTO.detalles = listDet; ;

            var listKardex = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            fichaDTO.movKardex = listKardex;

            var listPrdDep = ficha.prdDeposito.Select(s => 
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                };
                return dt;
            }).ToList();
            fichaDTO.prdDeposito=listPrdDep;

            var listPrdCosto= ficha.prdCosto.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdCosto()
                {
                    autoProducto = s.autoProducto,
                    cantidadEntranteUnd = s.cantidadEntranteUnd,
                    costoDivisa = s.costoDivisa,
                    costoFinal = s.costoFinal,
                    costoFinalUnd = s.costoFinalUnd,
                };
                return dt;
            }).ToList();
            fichaDTO.prdCosto = listPrdCosto;

            var listPrdCostoHistorico = ficha.prdCostoHistorico.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdCostoHistorico()
                {
                    autoProducto = s.autoProducto,
                    costo = s.costo,
                    divisa = s.divisa,
                    nota = s.nota,
                    tasaCambio = s.tasaCambio,
                    serie=s.serie,
                };
                return dt;
            }).ToList();
            fichaDTO.prdCostoHistorico = listPrdCostoHistorico;

            var listPrdPrecio = ficha.prdPrecio.Select(s =>
            {
                 DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p1 = null;
                 DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p2 = null;
                 DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p3 = null;
                 DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p4 = null;
                 DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio p5 = null;

                if (s.precio_1 != null)
                {
                    p1 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_1.precioNeto, precio_divisa_full = s.precio_1.precio_divisa_full };
                };
                if (s.precio_2 != null)
                {
                    p2 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_2.precioNeto, precio_divisa_full = s.precio_2.precio_divisa_full };
                };
                if (s.precio_3 != null)
                {
                    p3 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_3.precioNeto, precio_divisa_full = s.precio_3.precio_divisa_full };
                };
                if (s.precio_4 != null)
                {
                    p4 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_4.precioNeto, precio_divisa_full = s.precio_4.precio_divisa_full };
                };
                if (s.precio_5 != null)
                {
                    p5 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = s.precio_5.precioNeto, precio_divisa_full = s.precio_5.precio_divisa_full };
                };
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecio()
                {
                     autoProducto=s.autoProducto,
                     precio_1 = p1,
                     precio_2 = p2,
                     precio_3 = p3,
                     precio_4 = p4,
                     precio_5 = p5,
                };
                return dt;
            }).ToList();
            fichaDTO.prdPrecio = listPrdPrecio;

            var listPrdPrecioMargen = ficha.prdPrecioMargen.Select(s =>
            {
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p1 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p2 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p3 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p4 = null;
                DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen p5 = null;

                if (s.precio_1 != null)
                {
                    p1 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_1.utilidad };
                };
                if (s.precio_2 != null)
                {
                    p2 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_2.utilidad };
                };
                if (s.precio_3 != null)
                {
                    p3 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_3.utilidad };
                };
                if (s.precio_4 != null)
                {
                    p4 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_4.utilidad };
                };
                if (s.precio_5 != null)
                {
                    p5 = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = s.precio_5.utilidad };
                };
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioMargen()
                {
                    autoProducto = s.autoProducto,
                    precio_1 = p1,
                    precio_2 = p2,
                    precio_3 = p3,
                    precio_4 = p4,
                    precio_5 = p5,
                };
                return dt;
            }).ToList();
            fichaDTO.prdPrecioMargen = listPrdPrecioMargen;

            var listPrdPrecioHistorico = ficha.prdPrecioHistorico.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                {
                    autoProducto = s.autoProducto,
                    precio = s.precio,
                    precio_id = s.precio_id,
                    nota = s.nota,
                };
                return dt;
            }).ToList();
            fichaDTO.prdPrecioHistorico = listPrdPrecioHistorico;

            var r01 = MyData.Producto_Movimiento_Cargo_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.ResultadoAuto Producto_Movimiento_DesCargo_Insertar(OOB.LibInventario.Movimiento.DesCargo.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Movimiento.DesCargo.Insertar.Ficha()
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
                factorCambio = ficha.factorCambio,
                montoDivisa = ficha.montoDivisa,
            };
            var listDet = ficha.detalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.DesCargo.Insertar.FichaDetalle()
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
            fichaDTO.detalles = listDet; ;

            var listKardex = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.DesCargo.Insertar.FichaKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            fichaDTO.movKardex = listKardex;

            var listPrdDep = ficha.prdDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.DesCargo.Insertar.FichaPrdDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                };
                return dt;
            }).ToList();
            fichaDTO.prdDeposito = listPrdDep;

            var r01 = MyData.Producto_Movimiento_DesCargo_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.ResultadoAuto Producto_Movimiento_Ajuste_Insertar(OOB.LibInventario.Movimiento.Ajuste.Insertar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Movimiento.Ajuste.Insertar.Ficha()
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
                factorCambio = ficha.factorCambio,
                montoDivisa = ficha.montoDivisa,
            };
            var listDet = ficha.detalles.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Ajuste.Insertar.FichaDetalle()
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
            fichaDTO.detalles = listDet; ;

            var listKardex = ficha.movKardex.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Ajuste.Insertar.FichaKardex()
                {
                    autoConcepto = s.autoConcepto,
                    autoDeposito = s.autoDeposito,
                    autoProducto = s.autoProducto,
                    cantidad = s.cantidad,
                    cantidadBono = s.cantidadBono,
                    cantidadUnd = s.cantidadUnd,
                    codigoMov = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglasMov = s.siglasMov,
                    signoMov = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            fichaDTO.movKardex = listKardex;

            var listPrdDep = ficha.prdDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Ajuste.Insertar.FichaPrdDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDeposito = s.autoDeposito,
                    cantidadUnd = s.cantidadUnd,
                };
                return dt;
            }).ToList();
            fichaDTO.prdDeposito = listPrdDep;

            var r01 = MyData.Producto_Movimiento_Ajuste_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha> Producto_Movimiento_GetLista(OOB.LibInventario.Movimiento.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Movimiento.Lista.Ficha>();

            var filtroDto = new DtoLibInventario.Movimiento.Lista.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                TipoDocumento = (DtoLibInventario.Movimiento.enumerados.EnumTipoDocumento)filtro.TipoDocumento,
                IdSucursal = filtro.IdSucursal,
                IdDepDestino = filtro.IdDepDestino,
                IdDepOrigen = filtro.IdDepOrigen,
                IdConcepto=filtro.IdConcepto,
                Estatus = (DtoLibInventario.Movimiento.enumerados.EnumEstatus)filtro.Estatus,
                IdProducto=filtro.IdProducto,
            };
            var r01 = MyData.Producto_Movimiento_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Movimiento.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Movimiento.Lista.Ficha()
                        {
                            autoId = s.autoId,
                            fecha = s.fecha,
                            hora = s.hora,
                            docConcepto = s.docConcepto,
                            docMonto = s.docMonto,
                            docMotivo = s.docMotivo,
                            docNro = s.docNro,
                            docRenglones = s.docRenglones,
                            docSituacion = s.docSituacion,
                            docSucursal = s.docSucursal,
                            docTipo = (OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento)s.docTipo,
                            estacion = s.estacion,
                            isDocAnulado = s.isDocAnulado,
                            usuario = s.usuario,
                            depositoOrigen=s.depositoOrigen,
                            depositoDestino=s.depositoDestino,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Producto_Movimiento_Cargo_Anular(OOB.LibInventario.Movimiento.Anular.Cargo.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Cargo.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Cargo_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Producto_Movimiento_Descargo_Anular(OOB.LibInventario.Movimiento.Anular.Descargo.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Descargo.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Descargo_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Producto_Movimiento_Traslado_Anular(OOB.LibInventario.Movimiento.Anular.Traslado.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Traslado.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Traslado_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Producto_Movimiento_Ajuste_Anular(OOB.LibInventario.Movimiento.Anular.Ajuste.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Movimiento.Anular.Ajuste.Ficha()
            {
                autoDocumento = ficha.autoDocumento,
                autoSistemaDocumento = ficha.autoSistemaDocumento,
                autoUsuario = ficha.autoUsuario,
                codigo = ficha.codigoUsuario,
                estacion = ficha.estacion,
                motivo = ficha.motivo,
                usuario = ficha.nombreUsuario,
            };
            var r01 = MyData.Producto_Movimiento_Ajuste_Anular(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoAuto Producto_Movimiento_Traslado_Devolucion_Insertar(OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha ficha)
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
                factorCambio = ficha.factorCambio,
                montoDivisa = ficha.montoDivisa,
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
            fichaDTO.detalles = listDet; ;

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
                    codigo = s.codigoMov,
                    codigoSucursal = s.codigoSucursal,
                    costoUnd = s.costoUnd,
                    entidad = s.entidad,
                    estatusAnulado = s.estatusAnulado,
                    modulo = s.modulo,
                    nota = s.nota,
                    precioUnd = s.precioUnd,
                    siglas = s.siglasMov,
                    signo = s.signoMov,
                    total = s.total,
                    codigoConcepto = s.codigoConcepto,
                    nombreConcepto = s.nombreConcepto,
                    codigoDeposito = s.codigoDeposito,
                    nombreDeposito = s.nombreDeposito,
                };
                return dt;
            }).ToList();
            fichaDTO.movKardex = listKardex; ;

            var listPrdDep = ficha.prdDeposito.Select(s =>
            {
                var dt = new DtoLibInventario.Movimiento.Traslado.Insertar.FichaPrdDeposito()
                {
                    autoProducto = s.autoProducto,
                    nombreProducto = s.nombreProducto,
                    autoDepositoOrigen = s.autoDepositoOrigen,
                    autoDepositoDestino = s.autoDepositoDestino,
                    cantidadUnd = s.cantidadUnd,
                };
                return dt;
            }).ToList();
            fichaDTO.prdDeposito = listPrdDep;

            var r01 = MyData.Producto_Movimiento_Traslado_Devolucion_Insertar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

//

        public OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha> Capturar_ProductosPorDebajoNivelMinimo(OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha>();

            var filtroDto = new DtoLibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Filtro();
            filtroDto.autoDepositoVerificarNivel = filtro.autoDepositoVerificarNivel;
            filtroDto.autoDepositoOrigen = filtro.autoDepositoOrigen;
            filtroDto.autoDepartamento = filtro.autoDepartamento;
            var r01 = MyData.Capturar_ProductosPorDebajoNivelMinimo(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Ficha()
                        {
                            autoDepartamento = s.autoDepartamento,
                            autoDeposito = s.autoDeposito,
                            autoGrupo = s.autoGrupo,
                            autoPrd = s.autoPrd,
                            categoria = s.categoria,
                            codigoDeposito = s.codigoDeposito,
                            codigoPrd = s.codigoPrd,
                            costoDivisa = s.costoDivisa,
                            costoUnd = s.costoUnd,
                            decimales = s.decimales,
                            empCompra = s.empCompra,
                            empCompraCont = s.empCompraCont,
                            estatusDivisa = s.estatusDivisa,
                            exDisponible = s.exDisponible,
                            exFisica = s.exFisica,
                            exReserva = s.exReserva,
                            nivelMinimo = s.nivelMinimo,
                            nivelOptimo = s.nivelOptimo,
                            nombreDeposito = s.nombreDeposito,
                            nombrePrd = s.nombrePrd,
                            //
                            autoDepositoOrigen = s.autoDepositoOrigen,
                            codigoDepositoOrigen = s.codigoDepositoOrigen,
                            nombreDepositoOrigen = s.nombreDepositoOrigen,
                            exFisicaOrigen = s.exFisicaOrigen,
                            exReservaOrigen = s.exReservaOrigen,
                            exDisponibleOrigen = s.exDisponibleOrigen,
                            //
                            fechaUltActualizacion = s.fechaUltActualizacion.Date,
                            tasaIva = s.tasaIva,
                            tasaIvaNombre = s.tasaIvaNombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}