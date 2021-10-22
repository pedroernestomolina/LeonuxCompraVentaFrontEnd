using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.DatosNegocio.Editar

{
    
    public class Gestion
    {

        private data _data;
        private bool _isEditarOk;
        private bool _isAbandonarOk;


        public string Rif { get { return _data.Rif; } }
        public string Nombre { get { return _data.Nombre; } }
        public string Direccion { get { return _data.Direccion; } }
        public string Telefonos { get { return _data.Telefono; } }
        public string Email { get { return _data.Email; } }
        public string WebSite { get { return _data.WebSite; } }
        public string CodPostal { get { return _data.CodPostal; } }
        public string Contacto { get { return _data.Contacto; } }
        public string Pais { get { return _data.Pais; } }
        public string Estado { get { return _data.Estado; } }
        public string Ciudad { get { return _data.Ciudad; } }
        public string Sucursal { get { return _data.Sucursal; } }

        public string CodSucursal { get { return _data.CodSucursal; } }
        public bool IsEditarOk { get { return _isEditarOk; } }
        public bool IsSalirOk { get { return _isEditarOk; } }
        public bool IsAbandonaOk { get { return _isAbandonarOk; } }


        public Gestion() 
        {
            _isEditarOk = false;
            _isAbandonarOk = false;
            _data = new data();
        }

        public void Inicializa() 
        {
            _isEditarOk = false;
            _isAbandonarOk = false;
            _data.Limpiar();
        }

        EditarFrm frm;
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
            var rt = true;

            var r01 = Sistema.MyData.Negocio_GetEntidad_ByAuto("0000000001");
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _data.setFicha(r01.Entidad);

            return rt;
        }

        public void setRif(string p)
        {
            _data.setRif(p);
        }

        public void setNombre(string p)
        {
            _data.setNombre(p);
        }

        public void setDireccion(string p)
        {
            _data.setDireccion(p);
        }

        public void setTelefonos(string p)
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

        public void setContacto(string p)
        {
            _data.setContacto(p);
        }

        public void setCodPostal(string p)
        {
            _data.setCodPostal(p);
        }

        public void setPais(string p)
        {
            _data.setPais(p);
        }

        public void setEstado(string p)
        {
            _data.setEstado(p);
        }

        public void setCiudad(string p)
        {
            _data.setCiudad(p);
        }


        public void Guardar()
        {
            _isEditarOk = false;
            if (_data.IsOk()) 
            {
                var msg = MessageBox.Show("Cambiar/Actualizar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.Negocio.Editar.Ficha()
                    {
                        auto = _data.Auto,
                        ciudad = _data.Ciudad,
                        codPostal = _data.CodPostal,
                        contacto = _data.Contacto,
                        direccion = _data.Direccion,
                        email = _data.Email,
                        estado = _data.Estado,
                        fax = _data.Fax,
                        nombre = _data.Nombre,
                        pais = _data.Pais,
                        rif = _data.Rif,
                        telefono = _data.Telefono,
                        webSite = _data.WebSite,
                    };
                    var r01 = Sistema.MyData.Negocio_EditarFicha(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _isEditarOk = true;
                }
            }
        }

        public void Abandonar()
        {
            _isEditarOk = false;
            var msg = MessageBox.Show("Abandonar Los Cambios Efectuados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _isAbandonarOk = true;
            }
        }

    }

}