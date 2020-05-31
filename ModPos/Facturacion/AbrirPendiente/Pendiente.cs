using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.AbrirPendiente
{

    public class Pendiente
    {


        private List<OOB.LibVenta.PosOffline.Pendiente.Ficha> _items;
        private BindingList<OOB.LibVenta.PosOffline.Pendiente.Ficha> _bItems;
        private BindingSource _bs;
        private ClaveSeguridad.Seguridad _seguridad;
        private OOB.LibVenta.PosOffline.Permiso.Pos.Ficha _permiso;


        public BindingSource Source
        {
            get
            {
                return _bs;
            }
        }

        public int IdClienteAbrir { get; set; }
        public bool CtaAbrirIsOk { get; set; }
        public List<OOB.LibVenta.PosOffline.Item.Ficha> ListaItemAbrir { get; set; }


        public Pendiente(ClaveSeguridad.Seguridad seguridad)
        {
            _seguridad = seguridad;
            _items = new List<OOB.LibVenta.PosOffline.Pendiente.Ficha>();
            _bItems = new BindingList<OOB.LibVenta.PosOffline.Pendiente.Ficha>(_items);
            _bs = new BindingSource();
            _bs.DataSource = _bItems;
        }


        AbrirPendiente.AbrirPendienteFrm frm;
        public void Listar()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AbrirPendiente.AbrirPendienteFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData2.Pendiente_Lista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _bItems.Clear();
            foreach (var rg in r01.Lista.OrderByDescending(o => o.Id))
            {
                _bItems.Add(rg);
            }

            return rt;
        }

        public void EliminarCta()
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {

                    var seguir = true;
                    if (_permiso.DejarCtaPendiente.RequiereClave)
                    {
                        seguir = _seguridad.SolicitarClave();
                    }
                    if (seguir) 
                    {
                        var it = (OOB.LibVenta.PosOffline.Pendiente.Ficha)_bs.Current;
                        if (it != null)
                        {
                            Eliminar(it);
                        }
                    }
                }
            }
        }

        private void Eliminar(OOB.LibVenta.PosOffline.Pendiente.Ficha it)
        {
            var msg = MessageBox.Show("Eliminar Cuenta Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Sistema.MyData2.Pendiente_EliminarCta(it.Id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _bItems.Remove(it);
            }
        }

        public void AbrirCta()
        {
            IdClienteAbrir = -1;
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var it = (OOB.LibVenta.PosOffline.Pendiente.Ficha)_bs.Current;
                    if (it != null)
                    {
                        if (Abrir(it)) 
                        {
                            CtaAbrirIsOk = true;
                            frm.Close();
                        }
                    }
                }
            }
        }

        private bool Abrir(OOB.LibVenta.PosOffline.Pendiente.Ficha it)
        {
            var rt = false;

            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var msg = MessageBox.Show("Abrir Cuenta Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r01 = Sistema.MyData2.Pendiente_AbrirCta(it.Id);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return false;
                        }
                        IdClienteAbrir = r01.Entidad.IdCliente ;
                        ListaItemAbrir = r01.Entidad.Items;
                        return true;
                    }
                }
            }

            return rt;
        }

        public void setPermisos(OOB.LibVenta.PosOffline.Permiso.Pos.Ficha permiso) 
        {
            _permiso = permiso;
        }

    }

}