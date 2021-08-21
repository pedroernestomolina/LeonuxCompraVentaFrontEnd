using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.Vendedor.Estatus
{
    
    public class Gestion: Maestros.Estatus.IGestion
    {


        private string _autoId;
        private OOB.LibSistema.Vendedor.Entidad.Ficha _vendedor;
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
                if (_vendedor != null) 
                {
                    rt = _vendedor.ciRif +" ("+_vendedor.codigo+") "+ Environment.NewLine + _vendedor.nombre;
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

            var r01 = Sistema.MyData.Vendedor_GetFicha_ById(_autoId);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _vendedor = r01.Entidad;
            _estatus = Maestros.Estatus.Enumerados.EnumEstatus.Activo;
            if (!_vendedor.IsActivo)
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
                var ficha = new OOB.LibSistema.Vendedor.ActivarInactivar.Ficha()
                {
                    id = _autoId,
                };
                if (_estatus == Maestros.Estatus.Enumerados.EnumEstatus.Activo )
                {
                    var r01 = Sistema.MyData.Vendedor_Activar(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                }
                else
                {
                    var r01 = Sistema.MyData.Vendedor_Inactivar(ficha);
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
            _vendedor = null;
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