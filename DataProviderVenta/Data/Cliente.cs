using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoLista<OOB.LibVenta.Cliente.Ficha> ClienteLista(OOB.LibVenta.Cliente.Filtro filtro)
        {
            var result = new OOB.ResultadoLista<OOB.LibVenta.Cliente.Ficha>();

            var filtroDTO = new DtoLibVenta.Cliente.Filtro();
            filtroDTO.cadena = filtro.cadena;
            filtroDTO.preferenciaBusqueda = (DtoLibVenta.Cliente.Enumerados.enumPreferenciaBusqueda) filtro.preferenciaBusqueda;
            var r01 = MyData.ClienteLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Lista = new List<OOB.LibVenta.Cliente.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    result.Lista = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.Cliente.Ficha()
                        {
                            Auto=s.Auto,
                            CiRif=s.CiRif,
                            Codigo=s.Codigo,
                            Nombre=s.Nombre,
                            IsActivo=s.IsActivo,
                        };
                    }).ToList();
                }
            }

            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Cliente.Ficha> ClienteFicha(string autoCliente)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Cliente.Ficha>();

            var r01 = MyData.ClienteDetalleResumen(autoCliente);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var r02 = MyData.ClienteDocPendientePorCobrar(autoCliente);
            if (r02.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r02.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var ent=r01.Entidad;
            result.Entidad = new OOB.LibVenta.Cliente.Ficha()
            {
                Auto = ent.Auto,
                AutoCobrador = ent.AutoCobrador,
                AutoEstado = ent.AutoEstado,
                AutoGrupo = ent.AutoGrupo,
                AutoVendedor = ent.AutoVendedor,
                AutoZona = ent.AutoZona,
                Aviso = ent.Aviso,
                Categoria = (OOB.LibVenta.Cliente.Enumerados.enumCategoria)ent.Categoria,
                Celular = ent.Celular,
                CiRif = ent.CiRif,
                CobradorCodigo = ent.CobradorCodigo,
                CobradorNombre = ent.CobradorNombre,
                Codigo = ent.Codigo,
                Contacto = ent.Contacto,
                DiasCredito = ent.DiasCredito,
                DireccionFiscal = ent.DireccionFiscal,
                Email = ent.Email,
                EstadoDescripcion = ent.EstadoDescripcion,
                GrupoCodigo = ent.GrupoCodigo,
                GrupoDescripcion = ent.GrupoDescripcion,
                IsActivo = ent.IsActivo,
                IsCreditoHabilitado = ent.IsCreditoHabilitado,
                LimitePorDocumento = ent.LimitePorDocumento,
                LimitePorMonto = ent.LimitePorMonto,
                Nombre = ent.Nombre,
                Notas = ent.Notas,
                PorctDescuento = ent.PorctDescuento,
                PorctRecargo = ent.PorctRecargo,
                TarifaPrecio = (OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio)ent.Tarifa,
                Telefono_1 = ent.Telefono_1,
                Telefono_2 = ent.Telefono_2,
                VendedorCodigo = ent.VendedorCodigo,
                VendedorNombre = ent.VendedorNombre,
                ZonaCodigo = ent.ZonaCodigo,
                ZonaDescripcion = ent.ZonaDescripcion, 
                DenominacionFiscal= (OOB.LibVenta.Cliente.Enumerados.enumDenominacionFiscal)ent.DenominacionFiscal,
            };

            var list = new List<OOB.LibVenta.Cliente.PorCobrar>();
            if (r02.Lista != null) 
            {
                if (r02.Lista.Count > 0) 
                {
                    list = r02.Lista.Select(s =>
                    {
                        var rg = new OOB.LibVenta.Cliente.PorCobrar()
                        {
                            Abonado=s.Abonado,
                            AutoDocumento=s.AutoDocumento,
                            Documento=s.Documento,
                            FechaEmision=s.FechaEmision,
                            IsAdministrativo=s.IsAdministrativo ,
                            MontoDocumento=s.MontoDocumento,
                            Signo=s.Signo,
                            TipoDocumento= (OOB.LibVenta.Cliente.Enumerados.enumTipoDocumentoPorCobrar)s.TipoDocumento,
                        };
                        return rg;
                    }).ToList();
                }
            }
            result.Entidad.DocumentosPendientePorCobrar = list;

            return result;
        }

        public OOB.ResultadoAuto ClienteAgregarEventual(OOB.LibVenta.Cliente.AgregarEventual ficha)
        {
            var result = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibVenta.Cliente.AgregarEventual();
            fichaDTO.CiRif = ficha.CiRif;
            fichaDTO.NombreRazonSocial = ficha.NombreRazonSocial;
            fichaDTO.DireccionFiscal = ficha.DireccionFiscal;
            fichaDTO.Telefono = ficha.Telefono;
            var r01 = MyData.ClienteAgregarEventual(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Auto = r01.Auto;
            return result;
        }

        public OOB.ResultadoLista<OOB.LibVenta.Cliente.PorCobrar> ClienteDocPendientePorCobrar(string auto)
        {
            var result = new OOB.ResultadoLista<OOB.LibVenta.Cliente.PorCobrar>();

            var r01 = MyData.ClienteDocPendientePorCobrar(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Lista = new List<OOB.LibVenta.Cliente.PorCobrar>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    result.Lista = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.Cliente.PorCobrar()
                        {
                            AutoDocumento=s.AutoDocumento,
                            Abonado=s.Abonado,
                            Documento=s.Documento,
                            FechaEmision=s.FechaEmision,
                            IsAdministrativo=s.IsAdministrativo,
                            MontoDocumento=s.MontoDocumento,
                            Signo=s.Signo,
                            TipoDocumento=(OOB.LibVenta.Cliente.Enumerados.enumTipoDocumentoPorCobrar)s.TipoDocumento,
                        };
                    }).ToList();
                }
            }

            return result;
        }

    }

}