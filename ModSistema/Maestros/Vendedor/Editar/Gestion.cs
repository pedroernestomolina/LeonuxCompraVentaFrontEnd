using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.Vendedor.Editar
{

    public class Gestion : IAgregarEditar
    {

        private dataAgregarEditar _data;
        private bool _salirIsOk;
        private bool _abandonarIsOk;
        private string _autoFichaAgregada;
        private string _autoFichaEditar;


        public string TituloFicha { get { return "Editar Ficha"; ;} }
        public string GetRif { get { return _data.CiRif; } }
        public string GetCodigo { get { return _data.Codigo; } }
        public string GetRazonSocial { get { return _data.Nombre; } }
        public string GetDirFiscal { get { return _data.Direccion; } }
        public string GetPersona { get { return _data.Contacto; } }
        public string GetTelefono { get { return _data.Telefono; } }
        public string GetEmail { get { return _data.Email; } }
        public string GetWebSite { get { return _data.WebSite; } }
        public string GetAdvertencia { get { return _data.Advertencia; } }
        public string GetMemo { get { return _data.Memo; } }
        public bool SalirIsOk { get { return _salirIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _salirIsOk; } }
        public string AutoFichaNueva { get { return _autoFichaAgregada; } }


        public Gestion()
        {
            _autoFichaAgregada = "";
            _autoFichaEditar = "";
            _salirIsOk = false;
            _abandonarIsOk = false;
            _data = new dataAgregarEditar();
        }


        public void Inicializa()
        {
            _autoFichaEditar = "";
            _autoFichaAgregada = "";
            _salirIsOk = false;
            _abandonarIsOk = false;
            _data.Inicializa();
        }

        public void setCiRif(string p)
        {
            _data.setCiRif(p);
        }

        public void setCodigo(string p)
        {
            _data.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _data.setRazonSocial(p);
        }

        public void setDirFiscal(string p)
        {
            _data.setDirFiscal(p);
        }

        public void setPersona(string p)
        {
            _data.setPersona(p);
        }

        public void setTelefono(string p)
        {
            _data.setTelefono(p);
        }

        public void setEmail(string p)
        {
            _data.setEmail(p);
        }

        public void setWebSite(string p)
        {
            _data.setWebSite(p);
        }

        public void setAdvertencia(string p)
        {
            _data.setAdvertencia(p);
        }

        public void setMemo(string p)
        {
            _data.setMemo(p);
        }

        public void Procesar()
        {
            if (_data.VerificarEditarIsOk())
            {
                var msg = MessageBox.Show("Guardar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    GuardarFicha();
                }
            }
        }

        private void GuardarFicha()
        {
            var ficha = new OOB.LibSistema.Vendedor.Editar.Ficha()
            {
                id = _autoFichaEditar,
                advertencia = _data.Advertencia,
                ciRif = _data.CiRif,
                codigo = _data.Codigo,
                contacto = _data.Contacto,
                direccion = _data.Direccion,
                email = _data.Email,
                memo = _data.Memo,
                nombre = _data.Nombre,
                telefono = _data.Telefono,
                webSite = _data.WebSite,
            };
            var r01 = Sistema.MyData.Vendedor_EditarFicha(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _salirIsOk = true;
        }

        public void Salir()
        {
            var msg = MessageBox.Show("Abandonar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public bool CargarData()
        {
            var rt=true;

            var r01 = Sistema.MyData.Vendedor_GetFicha_ById(_autoFichaEditar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _data.CargarData(r01.Entidad);

            return rt;
        }

        public void setFichaEditar(string p)
        {
            _autoFichaEditar = p;
        }

    }

}