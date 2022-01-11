using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Cliente.Editar
{
    
    public class Gestion
    {

        private Ficha _ficha;
        private data _data;
        private bool _editarIsOk;
        private bool _abandonarCambiosIsOk;


        public string GetCiRif { get { return _data.GetCiRif; } }
        public string GetNombreRazonSocial { get { return _data.GetNombreRazonSocial; } }
        public string GetDireccion { get { return _data.GetDireccion; } }
        public string GetTelefono { get { return _data.GetTelefono; } }
        public bool IsEditarOk { get { return _editarIsOk; } }
        public bool AbandonarCambiosIsOk { get { return _abandonarCambiosIsOk; } }


        public Gestion() 
        {
            _editarIsOk = false;
            _abandonarCambiosIsOk = false;
            _data = new data();
        }


        public void Inicializa() 
        {
            _editarIsOk = false;
            _abandonarCambiosIsOk = false;
        }

        private EditarFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new EditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();

            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setCliente(Ficha FichaCliente)
        {
            _data.Limpiar();
            _ficha=FichaCliente;
            _data.setCiRif(FichaCliente.CiRif);
            _data.setNombreRazonSocial(FichaCliente.NombreRazaonSocial);
            _data.setDireccion(FichaCliente.DirFiscal);
            _data.setTelefono(FichaCliente.Telefono);
        }

        public void GuardarCambios()
        {
            if (_ficha == null) 
            {
                return;
            }
            if (_ficha.Id ==-1)
            {
                return;
            }
            if (_data.GetNombreRazonSocial == "") 
            {
                Helpers.Msg.Error("CAMPO [ NOMBRE / RAZON SOCIAL ] VACIO");
                return;
            }
            if (_data.GetDireccion == "")
            {
                Helpers.Msg.Error("CAMPO [ DIRECCION ] VACIO");
                return;
            }
            if (_data.GetTelefono == "")
            {
                Helpers.Msg.Error("CAMPO [ TELEFONO ] VACIO");
                return;
            }
            var msg = "Guardar Cambios ?";
            var dg = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dg == DialogResult.Yes) 
            {
                var ficha = new OOB.LibVenta.PosOffline.Cliente.Editar.Ficha()
                {
                    Id = _ficha.Id,
                    NombreRazonSocial = _data.GetNombreRazonSocial,
                    DirFiscal = _data.GetDireccion,
                    Telefono = _data.GetTelefono,
                };
                var r01 = Sistema.MyData2.Cliente_Editar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _editarIsOk = true;
            }
        }

        public void setNombre(string p)
        {
            _data.setNombreRazonSocial(p);
        }

        public void setDireccion(string p)
        {
            _data.setDireccion(p);
        }

        public void setTelefono(string p)
        {
            _data.setTelefono(p);
        }

        public void AbandonarCambios()
        {
            var msg = "Abandonar Cambios ?";
            var dg = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dg == DialogResult.Yes)
            {
                _abandonarCambiosIsOk = true;
            }
        }

    }

}