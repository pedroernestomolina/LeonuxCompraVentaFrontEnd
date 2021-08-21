using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.SerieFiscal.Editar
{

    public class Gestion : IAgregarEditar
    {

        private dataAgregarEditar _data;
        private bool _salirIsOk;
        private bool _abandonarIsOk;
        private string _autoFichaAgregada;
        private string _autoFichaEditar;


        public string TituloFicha { get { return "Editar Ficha"; ;} }
        public string GetSerie { get { return _data.Serie; } }
        public string GetControl{ get { return _data.Control; } }
        public int GetCorrelativo{ get { return _data.Correlativo; } }
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

        public void setSerie(string p)
        {
            _data.setSerie(p);
        }

        public void setControl(string p)
        {
            _data.setControl(p);
        }

        public void setCorrelativo(int p)
        {
            _data.setCorrelativo(p);
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
            var ficha = new OOB.LibSistema.SerieFiscal.Editar.Ficha()
            {
                id = _autoFichaEditar,
                control = _data.Control,
                correlativo = _data.Correlativo,
                serie = _data.Serie,
            };
            var r01 = Sistema.MyData.SerieFiscal_EditarFicha(ficha);
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

            var r01 = Sistema.MyData.SerieFiscal_GetFicha_ById(_autoFichaEditar);
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