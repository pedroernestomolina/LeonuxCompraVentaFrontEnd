using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Cobrador
{
    
    public class AgregarEditar
    {

        private IAgregarEditar _gestion;


        public string TituloFicha { get { return _gestion.TituloFicha; } }
        public string GetCodigo { get { return _gestion.GetCodigo; } }
        public string GetRazonSocial { get { return _gestion.GetRazonSocial; } }
        public bool SalirIsOk { get { return _gestion.SalirIsOk; } }
        public bool AbandonarIsOk { get { return _gestion.AbandonarIsOk; } }
        public bool ProcesarIsOk { get { return _gestion.ProcesarIsOk; } }
        public string AutoFichaNueva { get { return _gestion.AutoFichaNueva; } }


        public AgregarEditar() 
        {
        }


        public void Inicializa() 
        {
            _gestion.Inicializa();
        }

        private AgregarEditarFrm _frm;
        public void Inicia()
        {
            if (_gestion.CargarData()) 
            {
                if (_frm == null) 
                {
                    _frm = new AgregarEditarFrm();
                    _frm.setContolador(this);
                }
                _frm.ShowDialog();
            }
        }

        public void setGestion(IAgregarEditar gestion)
        {
            _gestion = gestion;
        }

        public void setCodigo(string p)
        {
            _gestion.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _gestion.setRazonSocial(p);
        }

        public void Procesar()
        {
            _gestion.Procesar();
        }

        public void Salir()
        {
            _gestion.Salir();
        }

        public void setFichaEditar(string p)
        {
            _gestion.setFichaEditar(p);
        }

    }

}