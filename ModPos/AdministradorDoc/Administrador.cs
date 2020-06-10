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
        private OOB.LibVenta.PosOffline.Permiso.AdmDocumento.Ficha _permisos;
        private ClaveSeguridad.Seguridad _seguridad;


        public BindingSource Source { get { return _bs; } }
        public bool NotaCreditoIsOk { get; set; }
        public int IdDoumentoNC { get; set; }


        public Administrador(ClaveSeguridad.Seguridad seguridad)
        {
            _documentos = new List<documento>();
            _blDocumentos = new BindingList<documento>(_documentos);
            _bs = new BindingSource();
            _bs.DataSource = _blDocumentos;
            _seguridad = seguridad;
        }


        public void AdmDocumentos()
        {
            if (Sistema.MyJornada != null)
            {
                NotaCreditoIsOk = false;
                IdDoumentoNC = -1;
                if (Cargar())
                {
                    var frm = new Listar.ListartFrm();
                    frm.setControlador(this);
                    frm.ShowDialog();
                }
            }
            else 
            {
                Helpers.Msg.Error("NO HAY NINGUNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public bool NotaCredito()
        {
            var rt = false;

            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    if (item.IsActivo)
                    {
                        var seguir = true;
                        if (_permisos.NotaCredito.RequiereClave)
                        {
                            seguir = _seguridad.SolicitarClave();
                        }
                        if (seguir)
                        {
                            if (item.TipoDocumento != OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.NotaCredito)
                            {
                                var msg = MessageBox.Show("HACER NOTA DE CREDITO ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (msg == DialogResult.Yes)
                                {
                                    NotaCreditoIsOk = true;
                                    IdDoumentoNC = item.Id;
                                    rt = true;
                                }
                            }
                            else
                            {
                                Helpers.Sonido.Error();
                                Helpers.Msg.Error("TIPO DOCUMENTO INCORRECTO !!!");
                            }
                        }
                    }
                    else
                    {
                        Helpers.Sonido.Error();
                        Helpers.Msg.Error("ESTATUS DOCUMENTO ANULADO !!!");
                    }
                }
            }

            return rt;
        }

        public void ReImprimirDocumento()
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    var seguir = true;
                    if (_permisos.ReImprimir.RequiereClave)
                    {
                        seguir = _seguridad.SolicitarClave();
                    }
                    if (seguir)
                    {

                    }
                }
            }
        }

        public void AnularDocumento()
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    if (item.IsActivo)
                    {
                        var seguir = true;
                        if (_permisos.Anular.RequiereClave)
                        {
                            seguir = _seguridad.SolicitarClave();
                        }
                        if (seguir)
                        {
                            var msg = MessageBox.Show("ESTAS SEGURO DE ANULAR DOCUMENTO ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msg == DialogResult.Yes)
                            {
                                var r01 = Sistema.MyData2.VentaDocumento_Anular(item.Id);
                                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                                {
                                    Helpers.Sonido.Error();
                                    Helpers.Msg.Error(r01.Mensaje);
                                    return;
                                }
                                item.IsActivo = false;
                                _bs.CurrencyManager.Refresh();
                            }
                        }
                    }
                    else
                    {
                        Helpers.Sonido.Error();
                        Helpers.Msg.Error("DOCUMENTO YA ANULADO !!!");
                    }
                }
            }
        }

        public bool Cargar()
        {
            var rt = false;

            var r00 = Sistema.MyData2.Permiso_AdmDocumento();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return rt;
            }
            _permisos = r00.Entidad;

            var filtro = new OOB.LibVenta.PosOffline.VentaDocumento.Filtro();
            filtro.IdJornada = Sistema.MyJornada.Id;
            var r01 = Sistema.MyData2.VentaDocumento_Lista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }

            _blDocumentos.Clear();
            _blDocumentos.RaiseListChangedEvents = false;
            foreach (var it in r01.Lista.OrderByDescending(o => o.Id).ToList())
            {
                _documentos.Add(new documento(it));
            }
            _blDocumentos.RaiseListChangedEvents = true;
            _blDocumentos.ResetBindings();
            rt = true;

            return rt;
        }

        public void Subir()
        {
            _bs.Position -= 1;
        }

        public void Bajar()
        {
            _bs.Position += 1;
        }

    }

}