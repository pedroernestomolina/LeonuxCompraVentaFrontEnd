using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Sucursal
{
    
    public class GestionAgregarEditar
    {

        public enum enumModo { SinDefinir = -1, Agregar = 1, Editar };


        private OOB.LibSistema.Sucursal.Ficha _ficha;
        private List<OOB.LibSistema.SucursalGrupo.Ficha> lGrupo;
        private BindingSource bsGrupo;


        public enumModo Modo { get; set; }
        public bool IsAgregarEditarOk { get; set; }
        public BindingSource Source { get { return bsGrupo; } }
        public string Sucursal { get; set; }
        public string Codigo { get; set; }
        public string AutoGrupo { get; set; }


        public GestionAgregarEditar()
        {
            lGrupo = new List<OOB.LibSistema.SucursalGrupo.Ficha>();
            bsGrupo = new BindingSource();
            bsGrupo.DataSource = lGrupo;

            Modo = enumModo.SinDefinir;
            IsAgregarEditarOk = false;
            Sucursal= "";
            Codigo = "";
            AutoGrupo = "";
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
                frm.setTitulo("Agregar Sucursal:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            Sucursal = "";
            Codigo = "";
            AutoGrupo = "";
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.SucursalGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            lGrupo.Clear();
            lGrupo.AddRange(r01.Lista);

            return rt;
        }

        public void Guardar()
        {
            if (Sucursal.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Nombre Sucursal ] No Puede Estar Vacio");
                return;
            }
            if (Codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Codigo Sucursal ] No Puede Estar Vacio");
                return;
            }
            if (AutoGrupo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Precio ] No Puede Estar Vacio");
                return;
            }


            if (Modo == enumModo.Agregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.Sucursal.Agregar()
                    {
                        nombre = Sucursal,
                        codigo = Codigo,
                        autoGrupo = AutoGrupo,
                    };
                    var r01 = Sistema.MyData.Sucursal_Agregar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                }
            }
            if (Modo == enumModo.Editar)
            {
                var msg = MessageBox.Show("Cambiar/Actualizar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.Sucursal.Editar()
                    {
                        auto = _ficha.auto,
                        nombre = Sucursal,
                        codigo = Codigo,
                        autoGrupo = AutoGrupo,
                    };
                    var r01 = Sistema.MyData.Sucursal_Editar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                }
            }
        }

        public void Editar(OOB.LibSistema.Sucursal.Ficha it)
        {
            if (CargarData())
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _ficha = r01.Entidad;
                LimpiarEntradas();
                Modo = enumModo.Editar;
                Codigo = _ficha.codigo;
                Sucursal= _ficha.nombre;
                AutoGrupo= _ficha.autoGrupoSucursal;
                IsAgregarEditarOk = false;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Sucursal:");
                frm.ShowDialog();
            }
        }

    }

}