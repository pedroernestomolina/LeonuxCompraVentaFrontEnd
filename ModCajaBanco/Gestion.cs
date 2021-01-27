using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco
{
    
    public class Gestion
    {

        private Reportes.Movimientos.Gestion _filtroGestion;
        private Habladores.Gestion _gestionHab;


        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string Host { get { return "Base Dato: " + Sistema._Instancia + "/" + Sistema._BaseDatos; } }


        public Gestion()
        {
            _filtroGestion = new Reportes.Movimientos.Gestion();
            _gestionHab = new Habladores.Gestion();
        }

        public void Inicia() 
        {
            var frm = new Form1();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void ArqueoCajaPos()
        {
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk) 
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.autoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.autoSucursal = r00.Entidad.codigo;
                    sucursalNombre = r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.CajaBanco_ArqueoCajaPos (filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + sucursalNombre;
                var rp1 = new Reportes.Movimientos.ArqueoCajaPos (r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenInventario()
        {
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(true);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var depositoNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Deposito_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.autoDeposito = r00.Entidad.auto;
                    depositoNombre = r00.Entidad.nombre;
                }
                else 
                {
                    filtro.autoDeposito = _filtroGestion.autoDeposito;
                    var r00 = Sistema.MyData.Deposito_GetFicha(filtro.autoDeposito);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    depositoNombre = r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.Reporte_ResumenInventario(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() + 
                    Environment.NewLine+ depositoNombre;
                var rp1 = new Reportes.Movimientos.ResumenInventario.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVenta()
        {
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };
                
                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else 
                {
                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.codigoSucursal = r00.Entidad.codigo;
                    sucursalNombre= r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.Reporte_ResumenVenta (filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: "+ sucursalNombre ;
                var rp1 = new Reportes.Movimientos.ResumenVenta.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteHabladores()
        {
            _gestionHab.Inicia();
        }

        public void ReporteResumenVentaDetalle()
        {
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.codigoSucursal = r00.Entidad.codigo;
                    sucursalNombre = r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaDetalle(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.VentaDetalle.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaporProducto()
        {
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "") 
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaPorProducto(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.VentaPorProducto.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaSucursal()
        {
            if (Sistema._ActivarComoSucursal)
            {
                return;
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaSucursal(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.ResumenVentaSucursal.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaProductoSucursal()
        {
            if (Sistema._ActivarComoSucursal)
            {
                return;
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaProductoSucursal(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.VentaProductoSucursal.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void CobranzaDiaria()
        {
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codSucursal = r00.Entidad.codigo;
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codSucursal= r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_CobranzaDiaria(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.CobranzaDiaria.GestionRep(r01.Entidad, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaDiarioSucursal()
        {
            if (Sistema._ActivarComoSucursal)
            {
                return;
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDiarioSucursal.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaDiarioSucursal(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.ResumenVentaDiarioSucursal.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

    }

}