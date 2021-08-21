using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.SerieFiscal.Estatus
{

    public class Gestion : Maestros.Estatus.IGestion
    {


        private string _autoId;
        private OOB.LibSistema.SerieFiscal.Entidad.Ficha _serie;
        private Maestros.Estatus.Enumerados.EnumEstatus _estatus;
        private bool _procesarIsOk;
        private bool _abandonarIsOk;


        public Maestros.Estatus.Enumerados.EnumEstatus Estatus { get { return _estatus; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        public bool AbandonarIsOk { get { return _abandonarIsOk; } }
        public bool CambioEstatusIsOk { get { return _procesarIsOk; } }


        public string Ficha
        {
            get
            {
                var rt = "";
                if (_serie!= null)
                {
                    rt = _serie.serie + " (" + _serie.control+ ") ";
                }
                return rt;
            }
        }


        public Gestion()
        {
            Limpiar();
        }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.SerieFiscal_GetFicha_ById(_autoId);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _serie = r01.Entidad;
            _estatus = Maestros.Estatus.Enumerados.EnumEstatus.Activo;
            if (!_serie.IsActivo)
                _estatus = Maestros.Estatus.Enumerados.EnumEstatus.Inactivo;

            return rt;
        }


        public void setFicha(string autoId)
        {
            _autoId = autoId;
        }

        public void setEstatusActivo()
        {
            _estatus = Maestros.Estatus.Enumerados.EnumEstatus.Activo;
        }

        public void setEstatusInactivo()
        {
            _estatus = Maestros.Estatus.Enumerados.EnumEstatus.Inactivo;
        }

        public void Procesar()
        {
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var ficha = new OOB.LibSistema.SerieFiscal.ActivarInactivar.Ficha()
                {
                    id = _autoId,
                };
                if (_estatus == Maestros.Estatus.Enumerados.EnumEstatus.Activo)
                {
                    var r01 = Sistema.MyData.SerieFiscal_ActivarFicha(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                }
                else
                {
                    var r01 = Sistema.MyData.SerieFiscal_InactivarFicha(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                }
                Helpers.Msg.EditarOk();
                _procesarIsOk = true;
            }
        }

        public void Inicializa()
        {
            _autoId = "";
            _procesarIsOk = false;
            _abandonarIsOk = false;
            _serie= null;
        }

        public void Salir()
        {
            _abandonarIsOk = false;
            var msg = MessageBox.Show("Abandonar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _abandonarIsOk = true;
            }
        }

        public void Limpiar()
        {
            Inicializa();
        }

    }

}