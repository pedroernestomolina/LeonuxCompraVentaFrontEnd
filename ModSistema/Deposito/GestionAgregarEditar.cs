using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Deposito
{
    
    public class GestionAgregarEditar
    {

        public enum enumModo { SinDefinir = -1, Agregar = 1, Editar };


        private OOB.LibSistema.Deposito.Ficha _ficha;
        private List<OOB.LibSistema.Sucursal.Ficha> lSucursal;
        private BindingSource bsSucursal;


        public enumModo Modo { get; set; }
        public bool IsAgregarEditarOk { get; set; }
        public BindingSource Source { get { return bsSucursal; } }
        public string Deposito { get; set; }
        public string Codigo { get; set; }
        public string AutoSucursal { get; set; }


        public GestionAgregarEditar()
        {
            lSucursal = new List<OOB.LibSistema.Sucursal.Ficha>();
            bsSucursal = new BindingSource();
            bsSucursal.DataSource = lSucursal;

            Modo = enumModo.SinDefinir;
            IsAgregarEditarOk = false;
            Deposito = "";
            Codigo = "";
            AutoSucursal = "";
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
                frm.setTitulo("Agregar Depósito:");
                frm.ShowDialog();
            }
        }

        private void LimpiarEntradas()
        {
            Deposito = "";
            Codigo = "";
            AutoSucursal = "";
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Sucursal_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            lSucursal.Clear();
            lSucursal.AddRange(r01.Lista.OrderBy(o=>o.nombre).ToList());

            var r02 = Sistema.MyData.Deposito_GeneraCodigoAutomatico();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            Codigo = r02.Entidad.ToString().Trim().PadLeft(2, '0');

            return rt;
        }

        public void Guardar()
        {
            if (Deposito.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Nombre Depósito ] No Puede Estar Vacio");
                return;
            }
            if (Codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Codigo Depósito ] No Puede Estar Vacio");
                return;
            }
            if (AutoSucursal.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Sucursal ] No Puede Estar Vacio");
                return;
            }

            var r00 = Sistema.MyData.Sucursal_GetFicha(AutoSucursal);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Modo == enumModo.Agregar)
            {
                var msg = MessageBox.Show("Guardar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.Deposito.Agregar()
                    {
                        nombre = Deposito.Trim().ToUpper(),
                        codigo = Codigo.Trim().ToUpper(),
                        autoSucursal = r00.Entidad.auto,
                        codigoSucursal = r00.Entidad.codigo,
                    };
                    var r01 = Sistema.MyData.Deposito_Agregar(ficha);
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
                    var ficha = new OOB.LibSistema.Deposito.Editar()
                    {
                        auto = _ficha.auto,
                        nombre = Deposito.Trim().ToUpper(),
                        codigo = Codigo.Trim().ToUpper(),
                        autoSucursal = r00.Entidad.auto,
                        codigoSucursal = r00.Entidad.codigo,
                    };
                    var r01 = Sistema.MyData.Deposito_Editar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    IsAgregarEditarOk = true;
                }
            }
        }

        public void Editar(OOB.LibSistema.Deposito.Ficha it)
        {
            if (CargarData())
            {
                var r01 = Sistema.MyData.Deposito_GetFicha(it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _ficha = r01.Entidad;
                LimpiarEntradas();
                Modo = enumModo.Editar;
                Codigo = _ficha.codigo;
                Deposito = _ficha.nombre;
                AutoSucursal = _ficha.autoSucursal;
                IsAgregarEditarOk = false;
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.setTitulo("Editar Depósito:");
                frm.ShowDialog();
            }
        }

    }

}