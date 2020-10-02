using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.Grupos
{
    
    public class GestionAgregarEditar
    {

        public enum enumModo { SinDefinir = -1, Agregar = 1, Editar };


        private OOB.LibInventario.Grupo.Ficha _ficha;


        public enumModo Modo { get; set; }
        public bool IsAgregarEditarOk { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool IsCerrarOk { get; set; }


        public GestionAgregarEditar()
        {
            IsCerrarOk = false;
            Modo = enumModo.SinDefinir;
            LimpiarEntradas();
        }

        AgregarEditarFrm frm;
        public void Agregar()
        {
            LimpiarEntradas();
            if (CargarData())
            {
                Modo = enumModo.Agregar;
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
            IsCerrarOk = false;
            IsAgregarEditarOk = false;
            Nombre = "";
            Codigo = "";
        }

        private bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void Guardar()
        {
            if (Codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Codigo Grupo ] No Puede Estar Vacio");
                return;
            }
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
                    var ficha = new OOB.LibInventario.Grupo.Agregar()
                    {
                        nombre = Nombre,
                        codigo = Codigo,
                    };
                    var r01 = Sistema.MyData.Grupo_Agregar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                    IsCerrarOk = true;
                }
            }
            if (Modo == enumModo.Editar)
            {
                var msg = MessageBox.Show("Cambiar/Actualizar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibInventario.Grupo.Editar()
                    {
                        auto = _ficha.auto,
                        nombre = Nombre,
                        codigo = Codigo,
                    };
                    var r01 = Sistema.MyData.Grupo_Editar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                    IsCerrarOk = true;
                }
            }
        }

        public void Editar(OOB.LibInventario.Grupo.Ficha it)
        {
            LimpiarEntradas();
            if (CargarData())
            {
                var r01 = Sistema.MyData.Grupo_GetFicha (it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Modo = enumModo.Editar;
                _ficha = r01.Entidad;
                Codigo = _ficha.codigo;
                Nombre = _ficha.nombre;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Grupo:");
                frm.ShowDialog();
            }
        }

        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Abandonar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }

    }

}