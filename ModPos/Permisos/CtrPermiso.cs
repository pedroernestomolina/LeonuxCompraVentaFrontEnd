using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Permisos
{
    
    public class CtrPermiso
    {

        private List<permiso> _permisos ;
        private BindingList<permiso> _blPermisos ;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }


        public CtrPermiso()
        {
            _permisos = new List<permiso>();
            _blPermisos = new BindingList<permiso>(_permisos);
            _bs = new BindingSource();
            _bs.DataSource = _blPermisos;

        }

        public void Configurar() 
        {
            if (CargarData()) 
            {
                var frm = new PermisosFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = false;

            var r01 = Sistema.MyData2.Permiso_CargarListaActual();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _blPermisos.Clear();
            _blPermisos.RaiseListChangedEvents = false;
            foreach (var it in r01.Entidad.Permisos.OrderBy(o => o.Modulo).ThenBy(o=>o.CodigoFuncion).ToList())
            {
                _permisos.Add(new permiso(it));
            }
            _blPermisos.RaiseListChangedEvents = true;
            _blPermisos.ResetBindings();
            rt = true;

            return rt;
        }

        public bool GuardarCambios() 
        {
            var rt = false;

            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var ficha = new OOB.LibVenta.PosOffline.Permiso.Actualizar.Ficha();
                var cambios= new List<OOB.LibVenta.PosOffline.Permiso.Actualizar.Permiso>();
                foreach (var rg in _permisos) 
                {
                    var nr = new OOB.LibVenta.PosOffline.Permiso.Actualizar.Permiso()
                    {
                        Id = rg.Id,
                        RequiereClave = rg.RequiereClave,
                    };
                    cambios.Add(nr);
                }
                ficha.Cambios = cambios;

                var r01 = Sistema.MyData2.Permiso_Actualizar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                rt = true;
            }

            return rt;
        }

    }

}