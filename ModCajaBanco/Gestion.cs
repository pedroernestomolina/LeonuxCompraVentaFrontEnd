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


        public string Version { get { return "Ver. " + Application.ProductVersion; } }


        public Gestion()
        {
            _filtroGestion = new Reportes.Movimientos.Gestion();
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

    }

}