using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.TasaDivisa.Sist
{
    
    public class Gestion: IGestion
    {

        private decimal _valorNuevo { get; set; }
        private List<data> _dataDivisa { get; set; }
        private List<data2> _dataSinDivisa { get; set; }


        public string TituloFuncion
        {
            get { return "Tasa Divisa Actual ?"; }
        }

        public decimal ValorNuevo
        {
            set { _valorNuevo = value; }
        }

        public decimal ValorActual { get; set; }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                rt = false;
            }

            ValorActual = r01.Entidad;
            return rt;
        }

        public bool Procesar()
        {
            var rt = false;
            _dataDivisa = new List<data>();
            _dataSinDivisa = new List<data2>();

            if (_valorNuevo > 0)
            {
                var msg = MessageBox.Show("Actualizar Tasa Divisa ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.Configuracion_Actualizar_TasaDivisa_CapturarData();
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return false;
                    }

                    var r02 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta ();
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return false;
                    }

                    var r03 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
                    if (r03.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r03.Mensaje);
                        return false;
                    }

                    if (r01.Lista != null) 
                    {
                        if (r01.Lista.Count > 0) 
                        {
                            foreach (var it in r01.Lista.Where(f => !f.isAdmDivisa).ToList())
                            {
                                _dataSinDivisa.Add(new data2(it, _valorNuevo));
                            }
                            foreach (var it in r01.Lista.Where(f=>f.isAdmDivisa).ToList())
                            {
                                _dataDivisa.Add(new data(it, _valorNuevo, r02.Entidad, r03.Entidad));
                            }

                            rt= ProcesarCambios();
                        }
                    }
                }
            }

            return rt;
        }

        private bool ProcesarCambios()
        {
            var rt = true;

            var ficha = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.Ficha()
            {
                autoUsuario = Sistema.UsuarioP.auto,
                codigoUsuario = Sistema.UsuarioP.codigo,
                EstacionEquipo = Environment.MachineName,
                nombreUsuario = Sistema.UsuarioP.nombre,
                ValorDivisa = _valorNuevo,
            };
            var lst = new List<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoPrecioDivisa>();
            var lst2 = new List<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico>();
            var lst3 = new List<OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoSinDivisa>();

            foreach (var rg in _dataSinDivisa) 
            {
                var nr = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoSinDivisa()
                {
                    autoPrd = rg.AutoPrd,
                    costoDivisa = rg.CostoDivisa,
                    precioMonedaEnDivisaFull_1 = rg.precioFullMoneda_EnDivisa(1),
                    precioMonedaEnDivisaFull_2 = rg.precioFullMoneda_EnDivisa(2),
                    precioMonedaEnDivisaFull_3 = rg.precioFullMoneda_EnDivisa(3),
                    precioMonedaEnDivisaFull_4 = rg.precioFullMoneda_EnDivisa(4),
                    precioMonedaEnDivisaFull_5 = rg.precioFullMoneda_EnDivisa(5),
                    precioMonedaEnDivisaFull_May_1 = rg.precioFullMoneda_EnDivisa(6),
                    precioMonedaEnDivisaFull_May_2 = rg.precioFullMoneda_EnDivisa(7),
                };
                lst3.Add(nr);
            }
            ficha.productosCostoSinDivisa = lst3;

            foreach (var rg in _dataDivisa) 
            {
                var nr = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoCostoPrecioDivisa()
                {
                    autoPrd = rg.AutoPrd,
                    costo = rg.CostoNuevo,
                    costoDivisa = rg.CostoDivisa,
                    costoImportacion = rg.CostoImportacion,
                    costoImportacionUnd = rg.CostoImportacionUnd,
                    costoProveedor = rg.CostoProveedor,
                    costoProveedorUnd = rg.CostoProveedorUnd,
                    costoUnd = rg.CostoNuevoUnd,
                    costoVario = rg.CostoVarios,
                    costoVarioUnd = rg.CostoVariosUnd,
                    documento = "",
                    nota = "",
                    precio_1 = rg.Precio_1,
                    precio_2 = rg.Precio_2,
                    precio_3 = rg.Precio_3,
                    precio_4 = rg.Precio_4,
                    precio_5 = rg.Precio_5,
                    precioMay_1= rg.PrecioMay_1,
                    precioMay_2 = rg.PrecioMay_2,
                    serie = "MAN",
                };
                lst.Add(nr);

                if (rg.Precio_1>0)
                {
                    var ph1 = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                    {
                        autoPrd = rg.AutoPrd,
                        nota = "CAMBIO MASIVO",
                        idPrecio = "1",
                        precio = rg.Precio_1,
                    };
                    lst2.Add(ph1);
                }

                if (rg.Precio_2 > 0)
                {
                    var ph2 = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                    {
                        autoPrd = rg.AutoPrd,
                        nota = "CAMBIO MASIVO",
                        idPrecio = "2",
                        precio = rg.Precio_2,
                    };
                    lst2.Add(ph2);
                }

                if (rg.Precio_3 > 0)
                {
                    var ph3 = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                    {
                        autoPrd = rg.AutoPrd,
                        nota = "CAMBIO MASIVO",
                        idPrecio = "3",
                        precio = rg.Precio_3,
                    };
                    lst2.Add(ph3);
                }

                if (rg.Precio_4 > 0)
                {
                    var ph4 = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                    {
                        autoPrd = rg.AutoPrd,
                        nota = "CAMBIO MASIVO",
                        idPrecio = "4",
                        precio = rg.Precio_4,
                    };
                    lst2.Add(ph4);
                }

                if (rg.Precio_5 > 0)
                {
                    var ph5 = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                    {
                        autoPrd = rg.AutoPrd,
                        nota = "CAMBIO MASIVO",
                        idPrecio = "PTO",
                        precio = rg.Precio_5,
                    };
                    lst2.Add(ph5);
                }

                if (rg.PrecioMay_1 > 0)
                {
                    var phM1 = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                    {
                        autoPrd = rg.AutoPrd,
                        nota = "CAMBIO MASIVO",
                        idPrecio = "MY1",
                        precio = rg.PrecioMay_1,
                    };
                    lst2.Add(phM1);
                }

                if (rg.PrecioMay_2 > 0)
                {
                    var phM2 = new OOB.LibSistema.Configuracion.ActualizarTasaDivisa.ActualizarData.FichaProductoPrecioHistorico()
                    {
                        autoPrd = rg.AutoPrd,
                        nota = "CAMBIO MASIVO",
                        idPrecio = "MY2",
                        precio = rg.PrecioMay_2,
                    };
                    lst2.Add(phM2);
                }

            }
            ficha.productosCostoPrecioDivisa = lst;
            ficha.productosPrecioHistorico = lst2;

            var r01 = Sistema.MyData.Configuracion_Actualizar_TasaDivisa_ActualizarData(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            Helpers.Msg.EditarOk();

            return rt;
        }

    }

}