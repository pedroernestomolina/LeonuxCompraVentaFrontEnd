using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalGrupo
{

    public class GestionAgregarEditar
    {

        public enum enumModo { SinDefinir=-1, Agregar=1, Editar };


        private OOB.LibSistema.SucursalGrupo.Ficha _ficha;
        private List<OOB.LibSistema.Precio.Ficha> lPrecio;
        private BindingSource bsPrecio;


        public enumModo Modo { get; set; }
        public bool IsAgregarEditarOk { get; set; }
        public BindingSource Source { get { return bsPrecio; } }
        public string Grupo { get; set; }
        public string IdPrecio { get; set; }


        public GestionAgregarEditar()
        {
            lPrecio = new List<OOB.LibSistema.Precio.Ficha>();
            bsPrecio = new BindingSource();
            bsPrecio.DataSource = lPrecio;

            Modo = enumModo.SinDefinir;
            IsAgregarEditarOk = false;
            Grupo = "";
            IdPrecio = "";
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
                frm.setTitulo("Agregar Sucursal Grupo:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            Grupo = "";
            IdPrecio = "";
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Precio_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            lPrecio.Clear();
            lPrecio.AddRange(r01.Lista);
            bsPrecio.CurrencyManager.Refresh();

            return rt;
        }

        public void Guardar()
        {
            if (Grupo.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ Nombre Grupo ] No Puede Estar Vacio");
                return;
            }
            if (IdPrecio.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Precio ] No Puede Estar Vacio");
                return;
            }


            if (Modo == enumModo.Agregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.SucursalGrupo.Agregar()
                    {
                        nombre = Grupo,
                        precioId = IdPrecio,
                    };
                    var r01 = Sistema.MyData.SucursalGrupo_Agregar(ficha);
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
                    var ficha = new OOB.LibSistema.SucursalGrupo.Editar()
                    {
                        auto= _ficha.auto,
                        nombre = Grupo,
                        precioId =  IdPrecio,
                    };
                    var r01 = Sistema.MyData.SucursalGrupo_Editar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                }
            }
        }

        public void Editar(OOB.LibSistema.SucursalGrupo.Ficha it)
        {
            if (CargarData())
            {
                var r01 = Sistema.MyData.SucursalGrupo_GetFicha(it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _ficha = r01.Entidad;
                LimpiarEntradas();
                Modo = enumModo.Editar;
                Grupo = _ficha.nombre;
                IdPrecio = _ficha.precioId;
                IsAgregarEditarOk = false;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Sucursal Grupo:");
                frm.ShowDialog();
            }
        }

    }

}