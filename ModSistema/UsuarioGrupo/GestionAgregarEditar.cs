using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.UsuarioGrupo
{
    
    public class GestionAgregarEditar
    {

        public enum enumModo { SinDefinir = -1, Agregar = 1, Editar };


        private OOB.LibSistema.UsuarioGrupo.Ficha _ficha;
        private List<OOB.LibSistema.Funcion.Ficha> _funciones;


        public enumModo Modo { get; set; }
        public bool IsAgregarEditarOk { get; set; }
        public string Nombre { get; set; }


        public GestionAgregarEditar()
        {
            Modo = enumModo.SinDefinir;
            IsAgregarEditarOk = false;
            Nombre = "";
        }

        AgregarEditarFrm frm;
        public void Agregar()
        {
            LimpiarEntradas();
            if (CargarData())
            {
                var r01 = Sistema.MyData.Funcion_GetLista();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _funciones = r01.Lista;

                Modo = enumModo.Agregar;
                IsAgregarEditarOk = false;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Agregar Grupo:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            Nombre = "";
        }

        private bool CargarData()
        {
            var rt = true;

            return rt;
        }

        public void Guardar()
        {
            if (Nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Nombre Grupo ] No Puede Estar Vacio");
                return;
            }

            if (Modo == enumModo.Agregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.UsuarioGrupo.Agregar()
                    {
                        nombre = Nombre.ToUpper(),
                        permisos = _funciones.Select(s => 
                        {
                            var p = new OOB.LibSistema.UsuarioGrupo.PermisoAgregar()
                            {
                                codigoFuncion = s.codigo,
                                estatus = "0",
                                seguridad = "Ninguna",
                            };
                            return p;
                        }).ToList(),
                    };
                    var r01 = Sistema.MyData.UsuarioGrupo_Agregar(ficha);
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
                    var ficha = new OOB.LibSistema.UsuarioGrupo.Editar()
                    {
                        auto = _ficha.auto,
                        nombre = Nombre.ToUpper(),
                    };
                    var r01 = Sistema.MyData.UsuarioGrupo_Editar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                }
            }
        }

        public void Editar(OOB.LibSistema.UsuarioGrupo.Ficha it)
        {
            if (CargarData())
            {
                var r01 = Sistema.MyData.UsuarioGrupo_GetFicha(it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _ficha = r01.Entidad;
                LimpiarEntradas();
                Modo = enumModo.Editar;
                Nombre = _ficha.nombre;
                IsAgregarEditarOk = false;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Grupo:");
                frm.ShowDialog();
            }
        }

    }

}