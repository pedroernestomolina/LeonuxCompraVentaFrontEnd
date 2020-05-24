using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.AdministradorDoc
{

    public class Administrador
    {

        private List<documento> _documentos;
        private BindingList<documento> _blDocumentos;
        private BindingSource _bs;


        public Administrador()
        {
            _documentos = new List<documento>();
            _blDocumentos = new BindingList<documento>(_documentos);
            _bs = new BindingSource();
            _bs.DataSource = _blDocumentos;
        }


        public void AdmDocumentos() 
        {
            if (Cargar()) 
            {
                var frm = new Listar.ListartFrm();
                frm.AnularFire+=frm_AnularFire;
                frm.ImprimirFire+=frm_ImprimirFire;
                frm.NotaCreditoFire+=frm_NotaCreditoFire;
                frm.setSource(_bs);
                frm.ShowDialog();
            }
        }

        private void frm_NotaCreditoFire(object sender, EventArgs e)
        {
            NotaCredito();
        }

        private void NotaCredito()
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    if (item.IsActivo)
                    {
                        if (item.TipoDocumento != OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.NotaCredito)
                        {
                            var msg = MessageBox.Show("HACER NOTA DE CREDITO ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msg == DialogResult.Yes)
                            {
                            }
                        }
                        else
                        {
                            Helpers.Msg.Error("TIPO DOCUMENTO INCORRECTO !!!");
                        }
                    }
                    else 
                    {
                        Helpers.Msg.Error("ESTATUS DOCUMENTO ANULADO !!!");
                    }
                }
            }
        }

        private void frm_ImprimirFire(object sender, EventArgs e)
        {
        }

        private void frm_AnularFire(object sender, EventArgs e)
        {
            AnularDocumento();
        }

        private void AnularDocumento()
        {
            if (_bs != null) 
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    if (item.IsActivo)
                    {
                        var msg = MessageBox.Show("ESTAS SEGURO DE ANULAR DOCUMENTO ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (msg == DialogResult.Yes)
                        {
                            item.IsActivo = false;
                            _bs.CurrencyManager.Refresh();
                        }
                    }
                    else 
                    {
                        Helpers.Msg.Error("DOCUMENTO YA ANULADO !!!");
                    }
                }
            }
        }

        public bool Cargar() 
        {
            var rt = false;

            var filtro = new OOB.LibVenta.PosOffline.VentaDocumento.Filtro();
            var r01 = Sistema.MyData2.VentaDocumento_Lista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }

            _blDocumentos.Clear();
            _blDocumentos.RaiseListChangedEvents = false;
            foreach (var it in r01.Lista.OrderByDescending(o=>o.Id).ToList()) 
            {
                _documentos.Add(new documento(it));
            }
            _blDocumentos.RaiseListChangedEvents = true;
            _blDocumentos.ResetBindings();
            rt = true;

            return rt;
        }

    }

}
