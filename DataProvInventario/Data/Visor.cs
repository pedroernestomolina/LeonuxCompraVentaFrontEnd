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

        public OOB.ResultadoLista<OOB.LibInventario.Visor.Existencia.Ficha> Visor_Existencia(OOB.LibInventario.Visor.Existencia.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.Existencia.Ficha >();

            var filtroDto = new DtoLibInventario.Visor.Existencia.Filtro();
            filtroDto.autoDepartamento = filtro.autoDepartamento;
            filtroDto.autoDeposito = filtro.autoDeposito;
            filtroDto.filtrarPor=  (DtoLibInventario.Visor.Existencia.Enumerados.enumFiltrarPor) filtro.filtrarPor;

            var r01 = MyData.Visor_Existencia(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Visor.Existencia.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Visor.Existencia.Ficha()
                        {
                            autoDepart = s.autoDepart,
                            autoDeposito = s.autoDeposito,
                            autoPrd = s.autoPrd,
                            cntFisica = s.cntFisica,
                            codigoDepart = s.codigoDepart,
                            codigoDeposito = s.codigoDeposito,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                            nivelMinimo = s.nivelMinimo,
                            nivelOptimo = s.nivelOptimo,
                            nombreDepart = s.nombreDepart,
                            nombreDeposito = s.nombreDeposito,
                            nombrePrd = s.nombrePrd,
                            esPesado=s.esPesado,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Visor.CostoEdad.Ficha> Visor_CostoEdad(OOB.LibInventario.Visor.CostoEdad.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Visor.CostoEdad.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.CostoEddad.Filtro();
            filtroDto.autoDepartamento = filtro.autoDepartamento;

            var r01 = MyData.Visor_CostoEdad(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Entidad = new OOB.LibInventario.Visor.CostoEdad.Ficha();
            rt.Entidad.fechaServidor = DateTime.Now.Date;
            var list = new List<OOB.LibInventario.Visor.CostoEdad.FichaDetalle>();
            if (r01.Entidad != null)
            {
                var se = r01.Entidad;
                if (se.detalles != null)
                {
                    if (se.detalles.Count > 0)
                    {
                        list = se.detalles.Select(s =>
                        {
                            return new OOB.LibInventario.Visor.CostoEdad.FichaDetalle()
                            {
                                autoDepart = s.autoDepart,
                                autoDeposito = s.autoDeposito,
                                autoPrd = s.autoPrd,
                                cntFisica = s.cntFisica,
                                codigoDepart = s.codigoDepart,
                                codigoDeposito = s.codigoDeposito,
                                codigoPrd = s.codigoPrd,
                                decimales = s.decimales,
                                nivelMinimo = s.nivelMinimo,
                                nivelOptimo = s.nivelOptimo,
                                nombreDepart = s.nombreDepart,
                                nombreDeposito = s.nombreDeposito,
                                nombrePrd = s.nombrePrd,
                                costoUnd = s.costoUnd,
                                fechaUltActCosto = s.fechaUltActCosto,
                                fechaUltVenta = s.fechaUltVenta,
                                costoDivisaUnd = s.costoDivisaUnd,
                                esAdmDivisa = s.esAdmDivisa,
                                esPesado = s.esPesado,
                            };
                        }).ToList();
                    }
                }
                rt.Entidad.fechaServidor = se.fechaServidor;
            }
            rt.Entidad.detalles = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Visor.Traslado.Ficha> Visor_Traslado(OOB.LibInventario.Visor.Traslado.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Visor.Traslado.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.Traslado.Filtro();
            filtroDto.ano = filtro.ano;
            filtroDto.mes = filtro.mes;

            var r01 = MyData.Visor_Traslado(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Visor.Traslado.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Visor.Traslado.Ficha()
                        {
                            autoDepositoDestino = s.autoDepositoDestino,
                            autoDepositoOrigen = s.autoDepositoOrigen,
                            autoPrd = s.autoPrd,
                            autoUsuario = s.autoUsuario,
                            cantidad = s.cantidad,
                            codigoDepositoDestino = s.codigoDepositoDestino,
                            codigoDepositoOrigen = s.codigoDepositoOrigen,
                            codigoPrd = s.codigoPrd,
                            codigoUsuario = s.codigoUsuario,
                            decimales = s.decimales,
                            documentoNombre = s.documentoNombre,
                            documentoNro = s.documentoNro,
                            fecha = s.fecha,
                            hora = s.hora,
                            nombreDepositoDestino = s.nombreDepositoDestino,
                            nombreDepositoOrigen = s.nombreDepositoOrigen,
                            nombrePrd = s.nombrePrd,
                            nombreUsuario = s.nombreUsuario,
                            nota = s.nota,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Visor.Ajuste.Ficha> Visor_Ajuste(OOB.LibInventario.Visor.Ajuste.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Visor.Ajuste.Ficha>();

            var filtroDto = new DtoLibInventario.Visor.Ajuste.Filtro();
            filtroDto.ano = filtro.ano;
            filtroDto.mes = filtro.mes;

            var r01 = MyData.Visor_Ajuste(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Entidad = new OOB.LibInventario.Visor.Ajuste.Ficha();
            var list = new List<OOB.LibInventario.Visor.Ajuste.FichaDetalle>();
            rt.Entidad.montoVentaNeto = 0.0m;
            if (r01.Entidad != null)
            {
                var se = r01.Entidad;
                if (se.detalles != null)
                {
                    if (se.detalles.Count > 0)
                    {
                        list = se.detalles.Select(s =>
                        {
                            return new OOB.LibInventario.Visor.Ajuste.FichaDetalle()
                            {
                                autoDepositoOrigen = s.autoDepositoOrigen,
                                autoPrd = s.autoPrd,
                                autoUsuario = s.autoUsuario,
                                cantidadUnd = s.cantidadUnd,
                                codigoDepositoOrigen = s.codigoDepositoOrigen,
                                codigoPrd = s.codigoPrd,
                                codigoUsuario = s.codigoUsuario,
                                costoUnd = s.costoUnd,
                                decimales = s.decimales,
                                documentoNro = s.documentoNro,
                                fecha = s.fecha,
                                hora = s.hora,
                                importe = s.importe,
                                nombreDepositoOrigen = s.nombreDepositoOrigen,
                                nombrePrd = s.nombrePrd,
                                nombreUsuario = s.nombreUsuario,
                                nota = s.nota,
                                signo = s.signo,
                            };
                        }).ToList();
                    }
                }
                rt.Entidad.montoVentaNeto = se.montoVentaNeto;
            }
            rt.Entidad.detalles = list;

            return rt;
        }

    }

}