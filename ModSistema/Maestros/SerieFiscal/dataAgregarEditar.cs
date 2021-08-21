using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.SerieFiscal
{
    
    public class dataAgregarEditar
    {

        private string _serie; 
        private int _correlativo;
        private string _control;


        public string Serie { get { return _serie; } }
        public int Correlativo { get { return _correlativo; } }
        public string Control { get { return _control; } }


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
            _serie = "";
            _correlativo = 0;
            _control = "";
        }


        public void setSerie(string p)
        {
            _serie= p;
        }

        public void setCorrelativo(int p)
        {
            _correlativo= p;
        }

        public void setControl (string p)
        {
            _control= p;
        }


        public bool VerificarAgregarIsOk()
        {
            var rt = true;

            if (_serie.Trim() == "") 
            {
                Helpers.Msg.Error("CAMPO SERIE NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

        public void CargarData(OOB.LibSistema.SerieFiscal.Entidad.Ficha ficha)
        {
            _serie = ficha.serie;
            _correlativo = ficha.correlativo;
            _control = ficha.control;
        }

        public bool VerificarEditarIsOk()
        {
            var rt = true;

            if (_serie.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO SERIE NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }

    }

}