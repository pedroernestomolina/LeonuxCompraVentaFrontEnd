using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.Cobrador.Agregar
{
    
    public class Gestion : IAgregarEditar
    {

        private dataAgregarEditar _data;
        private bool _salirIsOk;
        private bool _abandonarIsOk;
        private string _autoFichaAgregada;


        public string TituloFicha { get { return "Agregar Ficha"; ;} }
        public string GetCodigo { get { return _data.Codigo; } }
        public string GetRazonSocial { get { return _data.Nombre; } }
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

        public void setCodigo(string p)
        {
            _data.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _data.setRazonSocial(p);
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
            var ficha = new OOB.LibSistema.Cobrador.Agregar.Ficha()
            {
                codigo = _data.Codigo,
                nombre = _data.Nombre,
            };
            var r01 = Sistema.MyData.Cobrador_AgregarFicha(ficha);
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