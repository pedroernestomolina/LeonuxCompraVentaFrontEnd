﻿using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Prov
{
    
    public partial class DataPrv : IData
    {

        public OOB.Resultado.Lista<OOB.Maestro.Cliente.Entidad.Ficha> Cliente_GetLista(OOB.Maestro.Cliente.Lista.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Maestro.Cliente.Entidad.Ficha>();

            var filtroDto = new DtoLibPos.Cliente.Lista.Filtro()
            {
                cadena = filtro.cadena,
                preferenciaBusqueda = (DtoLibPos.Cliente.Lista.Enumerados.enumPreferenciaBusqueda)filtro.metodoBusqueda,
            };
            var r01 = MyData.Cliente_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Maestro.Cliente.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Maestro.Cliente.Entidad.Ficha()
                        {
                            Id = s.auto,
                            CiRif = s.ciRif,
                            Codigo = s.codigo,
                            Nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }

        public OOB.Resultado.Lista<OOB.Maestro.Cliente.Documento.Ficha> Cliente_Documentos_GetLista(OOB.Maestro.Cliente.Documento.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Maestro.Cliente.Documento.Ficha>();

            var filtroDto = new DtoLibPos.Cliente.Documento.Filtro()
            {
                autoCliente = filtro.autoCliente,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Cliente_Documento_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Maestro.Cliente.Documento.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var rg = new OOB.Maestro.Cliente.Documento.Ficha()
                        {
                            codTipoDoc = s.codTipoDoc,
                            documento = s.documento,
                            estatus = s.estatus,
                            fecha = s.fecha,
                            monto = s.monto,
                            montoDivisa = s.montoDivisa,
                            serie = s.serie,
                            tasaDivisa = s.tasaDivisa,
                            nombreTipoDoc = s.nombreTipoDoc,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }

        public OOB.Resultado.FichaEntidad<OOB.Maestro.Cliente.Entidad.Ficha> Cliente_GetFicha(string autoCliente)
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.Maestro.Cliente.Entidad.Ficha>();

            var r01 = MyData.Cliente_GetFichaById(autoCliente);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.Maestro.Cliente.Entidad.Ficha()
            {
                Id = s.Id,
                CiRif = s.CiRif,
                Codigo = s.Codigo,
                DireccionFiscal = s.DireccionFiscal,
                Nombre = s.Nombre,
                Telefono = s.Telefono,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado.Lista<OOB.Maestro.Cliente.Articulos.Ficha> Cliente_ArticulosVenta_GetLista(OOB.Maestro.Cliente.Articulos.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Maestro.Cliente.Articulos.Ficha>();

            var filtroDto = new DtoLibPos.Cliente.Articulos.Filtro()
            {
                autoCliente=filtro.autoCliente,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Cliente_ArticuloVenta_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.Maestro.Cliente.Articulos.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var rg = new OOB.Maestro.Cliente.Articulos.Ficha()
                        {
                            cantidad = s.cantidad,
                            cantUnd = s.cantUnd,
                            codigoPrd = s.codigoPrd,
                            codTipoDoc = s.codTipoDoc,
                            nombreTipoDoc = s.nombreTipoDoc,
                            contenidoEmp = s.contenidoEmp,
                            documento = s.documento,
                            empaque = s.empaque,
                            estatus = s.estatus,
                            fecha = s.fecha,
                            nombrePrd = s.nombrePrd,
                            serie = s.serie,
                            signo = s.signo,
                            tasaCambio = s.tasaCambio,
                            precioUnd = s.precioUnd,
                        };
                        return rg;
                    }).ToList();
                }
            }
            rt.ListaD = list;

            return rt;
        }

        public OOB.Resultado.FichaAuto Cliente_Agregar(OOB.Maestro.Cliente.Agregar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaAuto();

            var fichaDTO = new DtoLibPos.Cliente.Agregar.Ficha()
            {
                codigo = ficha.codigo,
                nombre = "",
                ciRif = ficha.ciRif,
                razonSocial = ficha.razonSocial,
                autoGrupo = ficha.autoGrupo,
                dirFiscal = ficha.dirFiscal,
                dirDespacho = ficha.dirDespacho,
                contacto = ficha.contacto,
                telefono = ficha.telefono,
                email = ficha.email,
                webSite = ficha.webSite,
                pais = ficha.pais,
                denominacionFiscal = ficha.denominacionFiscal,
                autoEstado = ficha.autoEstado,
                autoZona = ficha.autoZona,
                codigoPostal = ficha.codigoPostal,
                retencionIva = ficha.retencionIva,
                retencionIslr = ficha.retencionIslr,
                autoVendedor = ficha.autoVendedor,

                tarifa = ficha.tarifa,
                descuento = ficha.descuento,
                recargo = ficha.recargo,
                estatusCredito = ficha.estatusCredito,
                diasCredito = ficha.diasCredito,
                limiteCredito = ficha.limiteCredito,
                docPendientes = ficha.docPendientes,
                estatusMorosidad = ficha.estatusMorosidad,
                estatusLunes = ficha.estatusLunes,
                estatusMartes = ficha.estatusMartes,
                estatusMiercoles = ficha.estatusMiercoles,
                estatusJueves = ficha.estatusJueves,
                estatusViernes = ficha.estatusViernes,
                estatusSabado = ficha.estatusSabado,
                estatusDomingo = ficha.estatusDomingo,
                autoCobrador = ficha.autoCobrador,
                anticipos = ficha.anticipos,
                debitos = ficha.debitos,
                creditos = ficha.creditos,
                saldo = ficha.saldo,
                disponible = ficha.disponible,

                memo = ficha.memo,
                aviso = ficha.aviso,
                estatus = ficha.estatus,
                cuenta = ficha.cuenta,
                iban = ficha.iban,
                swit = ficha.swit,
                autoAgencia = ficha.autoAgencia,
                dirBanco = ficha.dirBanco,
                autoCodigoCobrar = ficha.autoCodigoCobrar,
                autoCodigoIngreso = ficha.autoCodigoIngreso,
                autoCodigoAnticipos = ficha.autoCodigoAnticipos,
                categoria = ficha.categoria,
                descuentoProntoPago = ficha.descuentoProntoPago,
                importeUltPago = ficha.importeUltPago,
                importeUltVenta = ficha.importeUltVenta,
                telefono2 = ficha.telefono2,
                fax = ficha.fax,
                celular = ficha.celular,

                abc = ficha.abc,
                montoClasificacion = ficha.montoClasificacion,
            };
            var r01 = MyData.Cliente_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            result.Auto = r01.Auto;
            return result;
        }

    }

}