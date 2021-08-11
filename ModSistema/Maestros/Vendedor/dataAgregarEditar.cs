using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Vendedor
{
    
    public class dataAgregarEditar
    {

        private string _codigo; 
        private string _nombre;
        private string _ciRif;
        private string _direccion;
        private string _contacto;
        private string _telefono;
        private string _email;
        private string _webSite;
        private string _advertencia;
        private string _memo;


        public string Codigo { get { return _codigo; } }
        public string Nombre { get { return _nombre; } }
        public string CiRif { get { return _ciRif; } }
        public string Direccion { get { return _direccion; } }
        public string Contacto { get { return _contacto; } }
        public string Telefono { get { return _telefono; } }
        public string Email { get { return _email; } }
        public string WebSite { get { return _webSite; } }
        public string Advertencia { get { return _advertencia; } }
        public string Memo { get { return _memo; } }


        public dataAgregarEditar() 
        {
            limpiar();
        }


        public void Inicializa()
        {
            limpiar();
        }

        private void limpiar()
        {
            _codigo = "";
            _nombre = "";
            _ciRif = "";
            _direccion = "";
            _contacto = "";
            _telefono = "";
            _email = "";
            _webSite = "";
            _advertencia = "";
            _memo = "";
        }


        public void setCiRif(string p)
        {
            _ciRif = p;
        }

        public void setCodigo(string p)
        {
            _codigo = p;
        }

        public void setRazonSocial(string p)
        {
            _nombre = p;
        }

        public void setDirFiscal(string p)
        {
            _direccion = p;
        }

        public void setPersona(string p)
        {
            _contacto = p;
        }

        public void setTelefono(string p)
        {
            _telefono = p;
        }

        public void setEmail(string p)
        {
            _email=p;
        }

        public void setWebSite(string p)
        {
            _webSite = p;
        }

        public void setAdvertencia(string p)
        {
            _advertencia = p;
        }

        public void setMemo(string p)
        {
            _memo = p;
        }

        public bool VerificarAgregarIsOk()
        {
            var rt = true;

            if (_ciRif.Trim() == "") 
            {
                Helpers.Msg.Error("CAMPO CI/RIF NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO NOMBRE/RAZON SOCIAL NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_direccion.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO DIRECCION FISCAL NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

        public void CargarData(OOB.LibSistema.Vendedor.Entidad.Ficha ficha)
        {
            _codigo = ficha.codigo;
            _nombre=ficha.nombre;
            _ciRif=ficha.ciRif;
            _direccion=ficha.direccion;
            _contacto=ficha.contacto;
            _telefono=ficha.telefono;
            _email=ficha.email;
            _webSite = ficha.webSite;
            _advertencia=ficha.advertencia;
            _memo=ficha.memo;
        }

        public bool VerificarEditarIsOk()
        {
            var rt = true;

            if (_ciRif.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO CI/RIF NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO NOMBRE/RAZON SOCIAL NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_direccion.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO DIRECCION FISCAL NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

    }

}