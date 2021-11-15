using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Usuario
{

    public class GestionLista
    {

        public event EventHandler CambioItemActual;


        private GestionAgregarEditar _gestionAgregarEditar;
        private List<OOB.LibSistema.Usuario.Ficha> lLista;
        private BindingList<OOB.LibSistema.Usuario.Ficha> blLista;
        private BindingSource bsLista;
        private OOB.LibSistema.Usuario.Ficha item;


        public BindingSource Source { get { return bsLista; } }
        public OOB.LibSistema.Usuario.Ficha Item { get { return item; } }
        public int Items { get { return blLista.Count; } }


        public GestionLista()
        {
            _gestionAgregarEditar = new GestionAgregarEditar();
            item = new OOB.LibSistema.Usuario.Ficha();
            lLista = new List<OOB.LibSistema.Usuario.Ficha>();
            blLista = new BindingList<OOB.LibSistema.Usuario.Ficha>(lLista);
            bsLista = new BindingSource();
            bsLista.CurrentChanged += bsLista_CurrentChanged;
            bsLista.DataSource = blLista;
        }


        private void bsLista_CurrentChanged(object sender, EventArgs e)
        {
            if (bsLista.Current != null)
            {
                item = (OOB.LibSistema.Usuario.Ficha)bsLista.Current;
                EventHandler hnd = CambioItemActual;
                if (hnd != null)
                {
                    hnd(this, null);
                }
            }
        }

        public void setLista(List<OOB.LibSistema.Usuario.Ficha> lista)
        {
            blLista.Clear();
            foreach (var it in lista.OrderBy(o => o.codigo).ToList())
            {
                blLista.Add(it);
            }
        }

        public void AgregarItem()
        {
            _gestionAgregarEditar.Inicializa();
            _gestionAgregarEditar.Agregar();
            if (_gestionAgregarEditar.IsAgregarEditarOk)
            {
                var id = _gestionAgregarEditar.AutoItemAgregado;
                var r0 = Sistema.MyData.Usuario_GetFicha(id);
                if (r0.Result== OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r0.Mensaje);
                    return;
                }
                blLista.Add(r0.Entidad);
            }
        }

        public void EditarItem()
        {
            var it = (OOB.LibSistema.Usuario.Ficha)bsLista.Current;
            if (it != null)
            {
                if (it.estatus == OOB.LibSistema.Usuario.Enumerados.EnumModo.Inactivo) 
                {
                    Helpers.Msg.Alerta("USUARIO EN ESTATUS INACTIVO, VERIFIQUE POR FAVOR");
                    return;
                }

                var _id = it.auto;
                var _ind = bsLista.CurrencyManager.Position;
                _gestionAgregarEditar.Editar(it);
                if (_gestionAgregarEditar.IsAgregarEditarOk)
                {
                    var r0 = Sistema.MyData.Usuario_GetFicha(_id);
                    if (r0.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r0.Mensaje);
                        return;
                    }
                    blLista.Remove(it);
                    blLista.Insert(_ind, r0.Entidad);
                    bsLista.Position = _ind;
                }
            }
        }

        public void ActivarInactivar()
        {
            var it = (OOB.LibSistema.Usuario.Ficha)bsLista.Current;
            if (it != null)
            {
                var _id = it.auto;
                var _ind = bsLista.CurrencyManager.Position;
                if (it.estatus == OOB.LibSistema.Usuario.Enumerados.EnumModo.Activo)
                {
                    var msg = MessageBox.Show("Inactivar Usuario ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        var ficha = new OOB.LibSistema.Usuario.Inactivar()
                        {
                            auto = it.auto,
                        };
                        var r01 = Sistema.MyData.Usuario_Inactivar(ficha);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                    }
                }
                else
                {
                    var msg = MessageBox.Show("Activar Usuario ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        var ficha = new OOB.LibSistema.Usuario.Activar()
                        {
                            auto = it.auto,
                        };
                        var r01 = Sistema.MyData.Usuario_Activar(ficha);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                    }
                }
                //ACTUALIZA LISTA
                var r0 = Sistema.MyData.Usuario_GetFicha(_id);
                if (r0.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r0.Mensaje);
                    return;
                }
                blLista.Remove(it);
                blLista.Insert(_ind, r0.Entidad);
                bsLista.Position = _ind;
            }
        }

        public void Inicializa()
        {
            blLista.Clear();
            item.Limpiar();
        }

        public void EliminarItem()
        {
            var it = (OOB.LibSistema.Usuario.Ficha)bsLista.Current;
            if (it != null)
            {
                if (Sistema.UsuarioP.auto == it.auto) 
                {
                    Helpers.Msg.Error("NO PUEDES ELIMINAR AL USUARIO ACTUAL");
                    return;
                }

                var msg = "ESTAS SEGURO DE ELIMINAR ESTE USUARIO ?";
                var res = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.Usuario_Eliminar(it.auto);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    bsLista.Remove(it);
                }
            }
        }

    }

}