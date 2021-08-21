using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.Estatus
{

    public class Gestion
    {

        private IGestion _gestion;


        public string Ficha { get { return _gestion.Ficha; } }
        public Estatus.Enumerados.EnumEstatus Estatus { get { return _gestion.Estatus; } }
        public bool ProcesarIsOk { get { return _gestion.ProcesarIsOk; } }
        public bool AbandonarIsOk { get { return _gestion.AbandonarIsOk; } }
        public bool CambioEstatusIsOk { get { return _gestion.CambioEstatusIsOk; } }


        public Gestion()
        {
        }


        EstatusFrm frm;
        public void Inicia()
        {
            if (_gestion.CargarData())
            {
                if (frm == null) 
                {
                    frm = new EstatusFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            _gestion.Limpiar();
        }

        public void setFicha(string autoId)
        {
            _gestion.setFicha(autoId);
        }

        public void setEstatusActivo()
        {
            _gestion.setEstatusActivo();
        }

        public void setEstatusInactivo()
        {
            _gestion.setEstatusInactivo();
        }

        public void Procesar()
        {
            _gestion.Procesar();
        }

        public void Inicializa()
        {
            _gestion.Inicializa();
        }

        public void Salir()
        {
            _gestion.Salir();
        }

        public void setGestion(Maestros.Estatus.IGestion gestion)
        {
            _gestion = gestion;
        }

    }

}