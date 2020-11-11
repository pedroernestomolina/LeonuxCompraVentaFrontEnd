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
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk) 
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.Filtro();
                filtro.desdeFecha = _filtroGestion.desdeFecha ;
                filtro.hastaFecha = _filtroGestion.hastaFecha ;
                filtro.autoSucursal = _filtroGestion.autoSucursal ;
                var r01 = Sistema.MyData.CajaBanco_ArqueoCajaPos (filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var rp1 = new Reportes.Movimientos.ArqueoCajaPos (r01.Lista, _filtroGestion.desdeFecha, _filtroGestion.hastaFecha);
                rp1.Generar();
            }
        }

        public void ReporteResumenInventario()
        {
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var r00 = Sistema.MyData.Deposito_GetPrincipal();
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }

                filtro.autoDeposito = r00.Entidad.auto;
                var r01 = Sistema.MyData.Reporte_ResumenInventario(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() + 
                    Environment.NewLine+ r00.Entidad.nombre;
                var rp1 = new Reportes.Movimientos.ResumenInventario.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVenta()
        {
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }

                filtro.codigoSucursal = r00.Entidad.codigo;
                var r01 = Sistema.MyData.Reporte_ResumenVenta (filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: "+ r00.Entidad.nombre;
                var rp1 = new Reportes.Movimientos.ResumenVenta.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteHabladores()
        {
            _gestionHab.Inicia();
        }

    }

}