using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Usuario
{
    
    public class GestionAgregarEditar
    {

        public enum enumModo { SinDefinir = -1, Agregar = 1, Editar };


        private List<OOB.LibSistema.UsuarioGrupo.Ficha> lGrupo;
        private BindingSource bsGrupo;
        private OOB.LibSistema.Usuario.Ficha _ficha;
        private string _autoItemAgregado;


        public enumModo Modo { get; set; }
        public bool IsAgregarEditarOk { get; set; }
        public BindingSource Source { get { return bsGrupo; } }
        public string AutoGrupo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string AutoItemAgregado { get { return _autoItemAgregado; } }


        public GestionAgregarEditar()
        {
            _autoItemAgregado = "";

            lGrupo = new List<OOB.LibSistema.UsuarioGrupo.Ficha>();
            bsGrupo = new BindingSource();
            bsGrupo.DataSource = lGrupo;

            Modo = enumModo.SinDefinir;
            IsAgregarEditarOk = false;
            LimpiarEntradas();
        }

        AgregarEditarFrm frm;
        public void Agregar()
        {
            LimpiarEntradas();
            if (CargarData())
            {
                Modo = enumModo.Agregar;
                IsAgregarEditarOk = false;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Agregar Usuario:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            AutoGrupo = "";
            Codigo = "";
            Nombre = "";
            Apellido = "";
            Clave = "";
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.UsuarioGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            lGrupo.Clear();
            lGrupo.AddRange(r01.Lista.OrderBy(o => o.nombre).ToList());
            bsGrupo.CurrencyManager.Refresh();

            return rt;
        }

        public void Guardar()
        {
            if (AutoGrupo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Grupo ] No Puede Estar Vacio");
                return;
            }
            if (Codigo .Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Codigo ] No Puede Estar Vacio");
                return;
            }
            if (Nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Nombre ] No Puede Estar Vacio");
                return;
            }
            if (Apellido.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Apellido ] No Puede Estar Vacio");
                return;
            }

            if (Modo == enumModo.Agregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.Usuario.Agregar()
                    {
                        autoGrupo = AutoGrupo,
                        codigo = Codigo,
                        nombre = Nombre,
                        apellido = Apellido,
                        clave = Clave,
                        estatus = "Activo",
                    };
                    var r01 = Sistema.MyData.Usuario_Agregar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _autoItemAgregado = r01.Auto;
                    IsAgregarEditarOk = true;
                }
            }
            if (Modo == enumModo.Editar)
            {
                var msg = MessageBox.Show("Cambiar/Actualizar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.Usuario.Editar()
                    {
                        auto = _ficha.auto,
                        nombre = Nombre,
                        autoGrupo = AutoGrupo,
                        codigo = Codigo,
                        apellido = Apellido,
                        clave = Clave,
                    };
                    var r01 = Sistema.MyData.Usuario_Editar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                }
            }
        }

        public void Editar(OOB.LibSistema.Usuario.Ficha it)
        {
            if (CargarData())
            {
                var r01 = Sistema.MyData.Usuario_GetFicha(it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _ficha = r01.Entidad;
                LimpiarEntradas();
                Modo = enumModo.Editar;
                Nombre = _ficha.nombre;
                Codigo = _ficha.codigo;
                Apellido = _ficha.apellido;
                Clave = _ficha.clave;
                AutoGrupo = _ficha.autoGrupo;

                IsAgregarEditarOk = false;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Usuario:");
                frm.ShowDialog();
            }
        }

        public void Inicializa()
        {
            _autoItemAgregado = "";
            IsAgregarEditarOk = false;
        }

    }

}