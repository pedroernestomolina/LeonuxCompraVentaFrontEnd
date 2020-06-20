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

        public OOB.ResultadoEntidad<decimal> Configuracion_FactorCambio()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_FactorCambio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Entidad = r01.Entidad;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.ModoPos.Ficha> Configuracion_ModoPos()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.ModoPos.Ficha>();

            var r01 = MyData.Configuracion_ModoPos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibVenta.PosOffline.Configuracion.ModoPos.Ficha()
            {
                Modo = (OOB.LibVenta.PosOffline.Configuracion.Enumerados.EnumModoPos)r01.Entidad.Modo,
            };
            rt.Entidad = nr;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Repesaje.Ficha> Configuracion_Repesaje()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Repesaje.Ficha>();

            var r01 = MyData.Configuracion_Repesaje();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var e=r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Repesaje.Ficha()
            {
                IsActivo = e.IsActivo,
                LimiteValidoInferior = e.LimiteValidoInferior,
                LimiteValidoSuperior = e.LimiteValidoSuperior,
            };
            rt.Entidad = nr;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Serie.Ficha> Configuracion_Serie()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Serie.Ficha>();

            var r01 = MyData.Configuracion_Serie();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var e = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Serie.Ficha()
            {
                ParaFactura = e.ParaFactura,
                ParaNotaCredito = e.ParaNotaCredito,
                ParaNotaDebito = e.ParaNotaDebito,
                ParaNotaEnrega=e.ParaNotaEntrega,
                ControlParaFactura=e.ControlParaFactura,
                ControlParaNotaCredito=e.ControlParaNotaCredito,
                ControlParaNotaDebito=e.ControlParaNotaDebito,
                ControlParaNotaEnrega=e.ControlParaNotaEntrega,
            };
            rt.Entidad = nr;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Sucursal.Ficha> Configuracion_Sucursal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Sucursal.Ficha>();

            var r01 = MyData.Configuracion_Sucursal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var e = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Sucursal.Ficha()
            {
                Codigo = e.Codigo,
                EquipoNumero=e.EquipoNumero,
            };
            rt.Entidad = nr;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha> Configuracion_Vendedor()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha>();

            var r01 = MyData.Configuracion_Vendedor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent=r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha()
            {
                Auto=ent.Auto,
                Codigo=ent.Codigo,
                Nombre=ent.Nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha> Configuracion_Deposito()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha>();

            var r01 = MyData.Configuracion_Deposito();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha()
            {
                Auto = ent.Auto,
                Codigo = ent.Codigo,
                Descripcion= ent.Descripcion,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<bool> Configuracion_ActivarBusquedaPorDescripcion()
        {
            var rt = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.Configuracion_ActivarBusquedaPorDescripcion();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Cobrador.Ficha> Configuracion_Cobrador()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Cobrador.Ficha>();

            var r01 = MyData.Configuracion_Cobrador();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Cobrador.Ficha()
            {
                Auto = ent.Auto,
                Codigo = ent.Codigo,
                Nombre = ent.Nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Transporte.Ficha> Configuracion_Transporte()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Transporte.Ficha>();

            var r01 = MyData.Configuracion_Transporte();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Transporte.Ficha()
            {
                Auto = ent.Auto,
                Codigo = ent.Codigo,
                Nombre = ent.Nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Ficha> Configuracion_MedioCobro()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Ficha>();

            var r01 = MyData.Configuracion_MedioCobro();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Ficha()
            {
                Efectivo = new OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Medio() { Auto = ent.Efectivo.Auto, Codigo = ent.Efectivo.Codigo, Descripcion = ent.Efectivo.Descripcion },
                Divisa = new OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Medio() { Auto = ent.Divisa.Auto, Codigo = ent.Divisa.Codigo, Descripcion = ent.Divisa.Descripcion },
                Electronico = new OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Medio() { Auto = ent.Electronico.Auto, Codigo = ent.Electronico.Codigo, Descripcion = ent.Electronico.Descripcion },
                Otro = new OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Medio() { Auto = ent.Otro.Auto, Codigo = ent.Otro.Codigo, Descripcion = ent.Otro.Descripcion },
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.ClaveAcceso.Ficha> Configuracion_ClavePos()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.ClaveAcceso.Ficha>();

            var r01 = MyData.Configuracion_ClavePos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.ClaveAcceso.Ficha()
            {
                Clave = ent.Clave,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Configuracion_GuardarCambio(OOB.LibVenta.PosOffline.Configuracion.Guardar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibPosOffLine.Configuracion.Guardar.Ficha()
            {
                ActivarBusquedaPorDescripcion = ficha.ActivarBusquedaPorDescripcion,
                ActivarRepesaje = ficha.ActivarRepesaje,
                AutoCobrador = ficha.AutoCobrador,
                AutoMedioDivisa = ficha.AutoMedioDivisa,
                AutoMedioEfectivo = ficha.AutoMedioEfectivo,
                AutoMedioElectronico = ficha.AutoMedioElectronico,
                AutoMedioOtro = ficha.AutoMedioOtro,
                AutoTransporte = ficha.AutoTransporte,
                AutoVendedor = ficha.AutoVendedor,
                ClavePos = ficha.ClavePos,
                LimiteInferiorRepesaje = ficha.LimiteInferiorRepesaje,
                LimiteSuperiorRepesaje = ficha.LimiteSuperiorRepesaje,
                SerieFactura = ficha.SerieFactura,
                SerieNotaCredito = ficha.SerieNotaCredito,
                SerieNotaDebito = ficha.SerieNotaDebito,
                SerieNotaEntrega = ficha.SerieNotaEntrega,
                EquipoNumero = ficha.IdEquipo,
                AutoMovConceptoDevVenta = ficha.AutoMovConceptoDevVenta,
                AutoMovConceptoSalida = ficha.AutoMovConceptoSalida,
                AutoMovConceptoVenta = ficha.AutoMovConceptoVenta,
            };
            var r01 = MyData.Configuracion_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha> Configuracion_ActualCargar()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha>();

            var r01 = MyData.Configuracion_ActualCargar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var e = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha()
            {
                ActivarBusquedaPorDescripcion = e.ActivarBusquedaPorDescripcion,
                ActivarRepesaje = e.ActivarRepesaje,
                AutoCobrador = e.AutoCobrador,
                AutoDeposito = e.AutoDeposito,
                AutoMedioDivisa = e.AutoMedioDivisa,
                AutoMedioEfectivo = e.AutoMedioEfectivo,
                AutoMedioElectronico = e.AutoMedioElectronico,
                AutoMedioOtro = e.AutoMedioOtro,
                AutoTransporte = e.AutoTransporte,
                AutoVendedor = e.AutoVendedor,
                ClavePos = e.ClavePos,
                TarifaPrecio = e.TarifaPrecio,
                EtiquetarPrecioPorTipoNegocio = e.EtiquetarPrecioPorTipoNegocio,
                CodigoSucursal = e.CodigoSucursal,
                EquipoNumero = e.EquipoNumero,

                LimiteInferiorRepesaje = e.LimiteInferiorRepesaje,
                LimiteSuperiorRepesaje = e.LimiteSuperiorRepesaje,
                SerieFactura = e.SerieFactura,
                SerieNotaCredito = e.SerieNotaCredito,
                SerieNotaDebito = e.SerieNotaDebito,
                SerieNotaEntrega = e.SerieNotaEntrega,

                AutoMovConceptoDevVenta = e.AutoMovConceptoDevVenta,
                AutoMovConceptoSalida = e.AutoMovConceptoSalida,
                AutoMovConceptoVenta = e.AutoMovConceptoVenta,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<string> Configuracion_TarifaPrecio()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Configuracion_TarifaPrecio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<bool> Configuracion_EtiquetarPrecioPorTipoNegocio()
        {
            var rt = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.Configuracion_EtiquetarPrecioPorTipoNegocio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.MovConceptoInv.Ficha> Configuracion_MovConceptoInv()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.MovConceptoInv.Ficha>();

            var r01 = MyData.Configuracion_MovConceptoInv();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Configuracion.MovConceptoInv.Ficha()
            {
                Venta = new OOB.LibVenta.PosOffline.Configuracion.MovConceptoInv.ConceptoMov() { Auto = ent.Venta.Auto, Codigo = ent.Venta.Codigo, Nombre = ent.Venta.Nombre },
                DevVenta = new OOB.LibVenta.PosOffline.Configuracion.MovConceptoInv.ConceptoMov() { Auto = ent.DevVenta.Auto, Codigo = ent.DevVenta.Codigo, Nombre = ent.DevVenta.Nombre },
                Salida = new OOB.LibVenta.PosOffline.Configuracion.MovConceptoInv.ConceptoMov() { Auto = ent.Salida.Auto, Codigo = ent.Salida.Codigo, Nombre = ent.Salida.Nombre },
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}