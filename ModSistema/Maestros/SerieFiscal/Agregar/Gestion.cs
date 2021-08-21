using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.SerieFiscal.Agregar
{
    
    public class Gestion : IAgregarEditar
    {

        private dataAgregarEditar _data;
        private bool _salirIsOk;
        private bool _abandonarIsOk;
        private string _autoFichaAgregada;


        public string TituloFicha { get { return "Agregar Ficha"; ;} }
        public string GetSerie { get { return _data.Serie; } }
        public string GetControl { get { return _data.Control; } }
        public int GetCorrelativo { get { return _data.Correlativo; } }
        public bool SalirIsOk { get { return _salirIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool ProcesarIsOk { get { return _salirIsOk; } }
        public string AutoFichaNueva { get { return _autoFichaAgregada; } }


        public Gestion() 
        {
            _autoFichaAgregada = "";
            _salirIsOk = false;
            _abandonarIsOk = false;
            _data = new dataAgregarEditar();
        }


        public void Inicializa()
        {
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
            if (_data.VerificarAgregarIsOk())
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
            var ficha = new OOB.LibSistema.SerieFiscal.Agregar.Ficha()
            {
                control = _data.Control,
                correlativo = _data.Correlativo,
                serie = _data.Serie,
                estatusFactura = "0",
                estatusNtCredito = "0",
                estatusNtDebito = "0",
                estatusNtEntrega = "0",
            };
            var r01 = Sistema.MyData.SerieFiscal_AgregarFicha(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _salirIsOk = true;
            _autoFichaAgregada = r01.Auto;
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
            return true;
        }

        public void setFichaEditar(string p)
        {
        }

    }

}