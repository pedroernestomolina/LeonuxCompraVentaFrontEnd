using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<decimal> Configuracion_TasaCambioActual()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_TasaCambioActual();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var cnf = r01.Entidad;
            var m1 = 0.0m;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                Decimal.TryParse(cnf, style, culture, out m1);
            }
            rt.Entidad = m1;

            return rt;
        }
        public OOB.ResultadoEntidad<decimal> Configuracion_TasaRecepcionPos()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_TasaRecepcionPos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var cnf = r01.Entidad;
            var m1 = 0.0m;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                Decimal.TryParse(cnf, style, culture, out m1);
            }
            rt.Entidad = m1;

            return rt;
        }

        public OOB.Resultado Configuracion_Actualizar_TasaRecepcionPos(OOB.LibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha()
            {
                 ValorNuevo=ficha.valorNuevo,
            };
            var r01 = MyData.Configuracion_Actualizar_TasaRecepcionPos(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha> Configuracion_Actualizar_TasaDivisa_CapturarData()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha>();

            var r01 = MyData.Configuracion_Actualizar_TasaDivisa_CapturarData ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            contenido = s.contenido,
                            costoDivisa = s.costoDivisa,
                            costoMoneda = s.costoMoneda,
                            isAdmDivisa = s.isAdmDivisa,
                            precioFullDivisa_1 = s.precioFullDivisa_1,
                            precioFullDivisa_2 = s.precioFullDivisa_2,
                            precioFullDivisa_3 = s.precioFullDivisa_3,
                            precioFullDivisa_4 = s.precioFullDivisa_4,
                            precioFullDivisa_5 = s.precioFullDivisa_5,
                            precioFullDivisaMay_1 = s.precioFullDivisaMay_1,
                            precioFullDivisaMay_2 = s.precioFullDivisaMay_2,
                            precioNetoMoneda_1 = s.precioNetoMoneda_1,
                            precioNetoMoneda_2 = s.precioNetoMoneda_2,
                            precioNetoMoneda_3 = s.precioNetoMoneda_3,
                            precioNetoMoneda_4 = s.precioNetoMoneda_4,
                            precioNetoMoneda_5 = s.precioNetoMoneda_5,
                            precioNetoMonedaMay_1 = s.precioNetoMonedaMay_1,
                            precioNetoMonedaMay_2 = s.precioNetoMonedaMay_2,
                            tasaIva = s.tasaIva,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }
        public OOB.Resultado Configuracion_Actualizar_TasaDivisa_ActualizarData(OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha()
            {
                autoUsuario = ficha.autoUsuario,
                codigoUsuario = ficha.codigoUsuario,
                EstacionEquipo = ficha.EstacionEquipo,
                nombreUsuario = ficha.nombreUsuario,
                ValorDivisa = ficha.ValorDivisa,
            };

            var lstProdCostoSinDivisa = new List<DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoSinDivisa>();
            foreach (var rg in ficha.productosCostoSinDivisa)
            {
                var nr = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoSinDivisa()
                {
                    autoPrd = rg.autoPrd,
                    costoDivisa = rg.costoDivisa,
                    precioMonedaEnDivisaFull_1 = rg.precioMonedaEnDivisaFull_1,
                    precioMonedaEnDivisaFull_2 = rg.precioMonedaEnDivisaFull_2,
                    precioMonedaEnDivisaFull_3 = rg.precioMonedaEnDivisaFull_3,
                    precioMonedaEnDivisaFull_4 = rg.precioMonedaEnDivisaFull_4,
                    precioMonedaEnDivisaFull_5 = rg.precioMonedaEnDivisaFull_5,
                    precioMonedaEnDivisaFull_May_1 = rg.precioMonedaEnDivisaFull_May_1,
                    precioMonedaEnDivisaFull_May_2 = rg.precioMonedaEnDivisaFull_May_2,
                };
                lstProdCostoSinDivisa.Add(nr);
            }
            fichaDTO.productosCostoSinDivisa = lstProdCostoSinDivisa;

            var lstProdDivisaCostoPrecio = new List<DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoPrecioDivisa>();
            foreach (var rg in ficha.productosCostoPrecioDivisa)
            {
                var nr = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoPrecioDivisa()
                {
                    autoPrd = rg.autoPrd,
                    costo = rg.costo,
                    costoDivisa = rg.costoDivisa,
                    costoImportacion = rg.costoImportacion,
                    costoImportacionUnd = rg.costoImportacionUnd,
                    costoProveedor = rg.costoProveedor,
                    costoProveedorUnd = rg.costoProveedorUnd,
                    costoUnd = rg.costoUnd,
                    costoVario = rg.costoVario,
                    costoVarioUnd = rg.costoVarioUnd,
                    documento = rg.documento,
                    nota = rg.nota,
                    precio_1 = rg.precio_1,
                    precio_2 = rg.precio_2,
                    precio_3 = rg.precio_3,
                    precio_4 = rg.precio_4,
                    precio_5 = rg.precio_5,
                    precioMay_1 = rg.precioMay_1,
                    precioMay_2 = rg.precioMay_2,
                    serie = rg.serie,
                };
                lstProdDivisaCostoPrecio.Add(nr);
            }
            fichaDTO.productosCostoPrecioDivisa = lstProdDivisaCostoPrecio;

            var lstProdPrecioHistorico = new List<DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico>();
            foreach (var rg in ficha.productosPrecioHistorico)
            {
                var nr = new DtoLibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                {
                    autoPrd = rg.autoPrd,
                    idPrecio = rg.idPrecio,
                    nota = rg.nota,
                    precio = rg.precio,
                };
                lstProdPrecioHistorico.Add(nr);
            }
            fichaDTO.productosPrecioHistorico = lstProdPrecioHistorico;

            var r01 = MyData.Configuracion_Actualizar_TasaDivisa_ActualizarData(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> Configuracion_ForzarRedondeoPrecioVenta()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta>();

            var r01 = MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibSistema.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta)s;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> Configuracion_PreferenciaRegistroPrecio()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio>();

            var r01 = MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibSistema.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio)s;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha> Configuracion_Modulo_Capturar()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha>(); 

            var r01 = MyData.Configuracion_Modulo_Capturar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            var f= r01.Entidad;
            var cnt = 1000;
            if (f.cantDocVisualizar.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                int.TryParse(f.cantDocVisualizar, style, culture, out cnt);
            }

            rt.Entidad = new OOB.LibSistema.Configuracion.Modulo.Capturar.Ficha()
            {
                claveNivMaximo = f.claveNivMaximo,
                claveNivMedio = f.claveNivMedio,
                claveNivMinimo = f.claveNivMinimo,
                visualizarPrdInactivos = f.visualizarPrdInactivos.Trim().ToUpper() == "SI" ? true : false,
                cantDocVisualizar = cnt,
            };

            return rt;
        }
        public OOB.Resultado Configuracion_Modulo_Actualizar(OOB.LibSistema.Configuracion.Modulo.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.Modulo.Actualizar.Ficha()
            {
                claveNivMaximo = ficha.claveNivMaximo,
                claveNivMedio = ficha.claveNivMedio,
                claveNivMinimo = ficha.claveNivMinimo,
                visualizarPrdInactivos = ficha.visualizarPrdInactivos,
                cantDocVisualizar = ficha.cantDocVisualizar,
            };
            var r01 = MyData.Configuracion_Modulo_Actualizar(fichaDTO);
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