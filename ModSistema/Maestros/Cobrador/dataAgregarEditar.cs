using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Cobrador
{
    
    public class dataAgregarEditar
    {

        private string _codigo; 
        private string _nombre;


        public string Codigo { get { return _codigo; } }
        public string Nombre { get { return _nombre; } }


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
        }


        public void setCodigo(string p)
        {
            _codigo = p;
        }

        public void setRazonSocial(string p)
        {
            _nombre = p;
        }

        public bool VerificarAgregarIsOk()
        {
            var rt = true;

            if (_codigo.Trim() == "") 
            {
                Helpers.Msg.Error("CAMPO CODIGO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO NOMBRE/RAZON SOCIAL NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

        public void CargarData(OOB.LibSistema.Cobrador.Entidad.Ficha ficha)
        {
            _codigo = ficha.codigo;
            _nombre=ficha.nombre;
        }

        public bool VerificarEditarIsOk()
        {
            var rt = true;

            if (_codigo.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO CODIGO NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_nombre.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO NOMBRE/RAZON SOCIAL NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

    }

}