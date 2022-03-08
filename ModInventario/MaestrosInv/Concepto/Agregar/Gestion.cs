using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv.Concepto.Agregar
{

    public class Gestion : IAgregarEditar
    {


        private string _codigo;
        private string _nombre;
        private bool _procesarIsOk;
        private bool _abandonarIsOK;
        private string _itemAgregarId;


        public string Nombre { get { return _nombre; } }
        public string Codigo { get { return _codigo; } }
        public bool IsOk { get { return _procesarIsOk; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOK; } }
        public string ItemAgregarId { get { return _itemAgregarId; } }
        public string Titulo { get { return "Agregar Item: CONCEPTO INVENTARIO"; } }


        public Gestion()
        {
            _codigo = "";
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOK = false;
            _itemAgregarId = ""; 
        }


        public void Abandonar()
        {
            _abandonarIsOK = false;
            var xmsg = "Abandonar Cambios ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOK = true;
            }
        }

        public void Inicializa()
        {
            _itemAgregarId = "";
            _codigo = "";
            _nombre = "";
            _procesarIsOk = false;
            _abandonarIsOK = false;
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setCodigo(string p)
        {
            _codigo = p;
        }
        public void setNombre(string p)
        {
            _nombre = p;
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            if (_codigo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ CODIGO ] No Puede Estar Vacio");
                return;
            }
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ NOMBRE ] No Puede Estar Vacio");
                return;
            }

            var xmsg = "Guardar Data ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var xficha = new OOB.LibInventario.Concepto.Agregar()
                {
                    nombre = _nombre,
                    codigo = _codigo,
                };
                var r01 = Sistema.MyData.Concepto_Agregar(xficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _procesarIsOk = true;
                _itemAgregarId = r01.Auto;
                Helpers.Msg.AgregarOk();
            }

        }

        public void setItemEditar(string id)
        {
        }

    }

}