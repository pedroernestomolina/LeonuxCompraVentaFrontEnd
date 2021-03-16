using PosOnLine.Data.Prov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine
{

    public class Gestion
    {

        private Src.Identificacion.Gestion _gestionIdentifica;
        private Src.Principal.Gestion _gestionPrincipal;
        

        public Gestion()
        {
            _gestionIdentifica = new Src.Identificacion.Gestion();
            _gestionPrincipal = new Src.Principal.Gestion();
        }


        Src.Identificacion.IdentificacionFrm frm;
        public void Inicia()
        {
            if (CargarDataXML()) 
            {
                //Sistema.MyData = new DataPrv(Sistema._Instancia, Sistema._BaseDatos);
                Sistema.MyData = new DataPrv("localhost", "pita");

                _gestionIdentifica.Inicializa();
                _gestionIdentifica.Inicia();
                if (_gestionIdentifica.IsOk)
                {

                    _gestionPrincipal.Inicializa();
                    _gestionPrincipal.Inicia();
                }
            }
        }

        private bool CargarDataXML()
        {
            var rt = true;

            return rt;
        }

    }

}