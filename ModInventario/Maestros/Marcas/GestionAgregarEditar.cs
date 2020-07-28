using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.Marcas
{
    
    public class GestionAgregarEditar
    {

        public enum enumModo { SinDefinir = -1, Agregar = 1, Editar };


        private OOB.LibInventario.Marca.Ficha _ficha;


        public enumModo Modo { get; set; }
        public bool IsAgregarEditarOk { get; set; }
        public string Nombre { get; set; }


        public GestionAgregarEditar()
        {
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
                frm.setTitulo("Agregar Marca:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            IsAgregarEditarOk = false;
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
                Helpers.Msg.Error("Campo [ Nombre Marca ] No Puede Estar Vacio");
                return;
            }

            if (Modo == enumModo.Agregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibInventario.Marca.Agregar()
                    {
                        nombre = Nombre,
                    };
                    var r01 = Sistema.MyData.Marca_Agregar(ficha);
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
                    var ficha = new OOB.LibInventario.Marca.Editar()
                    {
                        auto = _ficha.auto,
                        nombre = Nombre,
                    };
                    var r01 = Sistema.MyData.Marca_Editar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                }
            }
        }

        public void Editar(OOB.LibInventario.Marca.Ficha it)
        {
            LimpiarEntradas();
            if (CargarData())
            {
                var r01 = Sistema.MyData.Marca_GetFicha(it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Modo = enumModo.Editar;
                _ficha = r01.Entidad;
                Nombre = _ficha.nombre;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Marca:");
                frm.ShowDialog();
            }
        }

    }

}