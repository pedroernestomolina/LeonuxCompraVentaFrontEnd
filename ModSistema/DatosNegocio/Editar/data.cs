using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.DatosNegocio.Editar
{
    
    public class data
    {

        private string _auto;
        private string _nombre;
        private string _rif;
        private string _direccion;
        private string _telefono;
        private string _contacto;
        private string _fax;
        private string _email;
        private string _webSite;
        private string _pais;
        private string _estado;
        private string _ciudad;
        private string _codPostal;
        private string _sucursal;
        private string _codSucursal;


        public string Auto { get { return _auto; } }
        public string Nombre { get { return _nombre; } }
        public string Rif { get { return _rif; } }
        public string Direccion { get { return _direccion; } }
        public string Telefono { get { return _telefono; } }
        public string Contacto { get { return _contacto; } }
        public string Fax { get { return _fax; } }
        public string Email { get { return _email; } }
        public string WebSite { get { return _webSite; } }
        public string Pais { get { return _pais; } }
        public string Estado { get { return _estado; } }
        public string Ciudad { get { return _ciudad; } }
        public string CodPostal { get { return _codPostal; } }
        public string Sucursal { get { return _sucursal; } }
        public string CodSucursal { get { return _codSucursal; } }


        public data() 
        {
            limpiar();
        }


        private void limpiar()
        {
            _auto = "";
            _nombre = "";
            _rif = "";
            _direccion = "";
            _telefono = "";
            _contacto = "";
            _fax = "";
            _email = "";
            _webSite = "";
            _pais = "";
            _estado = "";
            _ciudad = "";
            _codPostal = "";
            _sucursal = "";
            _codSucursal = "";
        }

        public void setNombre(string p) 
        {
            _nombre = p;
        }

        public void setRif(string p)
        {
            _rif= p;
        }

        public void setDireccion(string p)
        {
            _direccion= p;
        }

        public void setTelefono(string p)
        {
            _telefono= p;
        }

        public void setContacto(string p)
        {
            _contacto = p;
        }

        public void setFax(string p)
        {
            _fax = p;
        }

        public void setEmail(string p)
        {
            _email= p;
        }

        public void setWebSite(string p)
        {
            _webSite= p;
        }

        public void setPais(string p)
        {
            _pais= p;
        }

        public void setEstado(string p)
        {
            _estado = p;
        }

        public void setCiudad(string p)
        {
            _ciudad= p;
        }

        public void setCodPostal(string p)
        {
            _codPostal= p;
        }

        public void setSucursal(string p)
        {
            _sucursal= p;
        }

        public void setCodSucursal(string p)
        {
            _codSucursal = p;
        }

        public void Limpiar()
        {
            limpiar();
        }

        public void setFicha(OOB.LibSistema.Negocio.Entidad.Ficha ficha)
        {
            limpiar();
            _auto = ficha.auto;
            setCiudad(ficha.ciudad);
            setCodPostal(ficha.codPostal);
            setContacto(ficha.contacto);
            setDireccion(ficha.direccion);
            setEmail(ficha.email);
            setEstado(ficha.estado);
            setFax(ficha.fax);
            setNombre(ficha.nombre);
            setPais(ficha.pais);
            setRif(ficha.rif);
            setTelefono(ficha.telefono);
            setWebSite(ficha.webSite);
            setSucursal(ficha.sucursal);
            setCodSucursal(ficha.codSucursal);
        }

        public bool IsOk()
        {
            var rt = true;

            if (_rif.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ RIF ] NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_nombre.Trim() == "") 
            {
                Helpers.Msg.Error("CAMPO [ NOMBRE DEL NEGOCIO ] NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_direccion.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ DIRECCION FISCAL ] NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

    }

}