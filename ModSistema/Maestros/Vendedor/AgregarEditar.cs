using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Vendedor
{
    
    public class AgregarEditar
    {

        private IAgregarEditar _gestion;


        public string TituloFicha { get { return _gestion.TituloFicha; } }
        public string GetRif { get { return _gestion.GetRif; } }
        public string GetCodigo { get { return _gestion.GetCodigo; } }
        public string GetRazonSocial { get { return _gestion.GetRazonSocial; } }
        public string GetDirFiscal { get { return _gestion.GetDirFiscal; } }
        public string GetPersona { get { return _gestion.GetPersona; } }
        public string GetTelefono { get { return _gestion.GetTelefono; } }
        public string GetEmail { get { return _gestion.GetEmail; } }
        public string GetWebSite { get { return _gestion.GetWebSite; } }
        public string GetAdvertencia { get { return _gestion.GetAdvertencia; } }
        public string GetMemo { get { return _gestion.GetMemo; } }
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

        public void setCiRif(string p)
        {
            _gestion.setCiRif(p);
        }

        public void setCodigo(string p)
        {
            _gestion.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _gestion.setRazonSocial(p);
        }

        public void setDirFiscal(string p)
        {
            _gestion.setDirFiscal(p);
        }

        public void setPersona(string p)
        {
            _gestion.setPersona(p);
        }

        public void setTelefono(string p)
        {
            _gestion.setTelefono(p);
        }

        public void setEmail(string p)
        {
            _gestion.setEmail(p);
        }

        public void setWebSite(string p)
        {
            _gestion.setWebSite(p);
        }

        public void setAdvertencia(string p)
        {
            _gestion.setAdvertencia(p);
        }

        public void setMemo(string p)
        {
            _gestion.setMemo(p);
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