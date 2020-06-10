using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos
{
    
    public class Sistema_
    {

        private Configuracion.configurar _configuracion;
        private AdministradorDoc.Administrador _administrador;
        private ClaveSeguridad.Seguridad _seguridad;
        private Facturacion.Venta _venta;
        private Fiscal.CtrFiscal _fiscal;
        private string _bdRemota;
        private string _bdLocal;


        public string InformacionBD { get { return _bdRemota + Environment.NewLine + _bdLocal; } }


        public Sistema_()
        {
            Sistema.MyBalanza = new Lib.BalanzaSoloPeso.BalanzaManual.Balanza();
            _seguridad = new ClaveSeguridad.Seguridad();
            _configuracion = new Configuracion.configurar();
            _administrador = new AdministradorDoc.Administrador(_seguridad);
            _venta = new Facturacion.Venta(_seguridad);
            _fiscal = new Fiscal.CtrFiscal();
        }

        public bool CargarData() 
        {
            var rt = true;

            var r00 = Sistema.MyData2.InformacionBD();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return false;
            }
            _bdRemota = r00.Entidad.RemotoBD;
            _bdLocal = r00.Entidad.LocalBD;

            var r01 = Sistema.MyData2.Jornada_Activa();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            if (r01.Entidad != -1)
            {
                var idJornadaActiva = r01.Entidad;
                var r02 = Sistema.MyData2.Jornada_Cargar(idJornadaActiva);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                Sistema.MyJornada = r02.Entidad;

                var r03 = Sistema.MyData2.Operador_Activo();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r03.Mensaje);
                    return false;
                }

                if (r03.Entidad != -1)
                {
                    var idOperadorActivo = r03.Entidad;
                    var r04 = Sistema.MyData2.Operador_Cargar(idOperadorActivo);
                    if (r04.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r04.Mensaje);
                        return false;
                    }
                    Sistema.MyOperador = r04.Entidad;
                }
            }

            return rt;
        }

        public void Arranca() 
        {
            var frmPos = new Form1();
            frmPos.setControlador(this);
            frmPos.ShowDialog();
        }

        public void TestBD() 
        {
            if (!Sistema.Usuario.IsInvitado)
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
                return;
            }

            var r01 = Sistema.MyData2.Servidor_Test();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Helpers.Msg.Alerta("BASE DE DATOS CONECTADA CON EXITO !!!");
        }

        public void ActivarPos() 
        {
            if (Sistema.Usuario.IsInvitado)
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA USUARIO [ INVITADO]");
                return;
            }

            //var r01 = Sistema.MyData.PosOffLine_Permiso_ModuloVenta(Sistema._usuario.AutoGrupo);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}
            //var permiso = r01.Entidad;
            //if (!permiso.IsHabilitado)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}

            var pass = true;
            //if (permiso.NivelSeguridad != OOB.LibVenta.PosOffline.Permiso.Enumerados.enumNivelSeguridad.Ninguna)
            //{
            //    pass = Helpers.VerificaPassword.Verificar();
            //}

            if (pass)
            {
                if (Sistema.MyOperador != null)
                {
                    if (Sistema.MyOperador.AutoUsuario == Sistema.Usuario.Auto)
                    {
                        _venta.ActivarPos();
                    }
                    else 
                    {
                        Helpers.Msg.Error("USUARIO INCORRECTO PARA ABRIR EL POS, VERIFIQUE POR FAVOR");
                        return;
                    }
                }
                else
                {
                    Helpers.Msg.Error("NO HAY UN OPERADOR ACTIVO, VERIFIQUE POR FAVOR");
                    return;
                }
            }
        }

        public void ImportarDataDelServidor() 
        {
            var msg = MessageBox.Show("Importar Data Del Servidor ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Sistema.MyData2.Servidor_Test();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var r02 = Sistema.MyData2.Servidor_ActualizarData();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }

                Helpers.Msg.EditarOk();
            }
        }

        public void ConfiguracionActivar() 
        {
            if (!Sistema.Usuario.IsInvitado)
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
                return;
            }

            _configuracion.Configura();
        }

        public void AdministradorDocumentosActivar() 
        {
            _administrador.AdmDocumentos();
            if (_administrador.NotaCreditoIsOk)
            {
                _venta.setModoNotaCredito(_administrador.IdDoumentoNC);
                _venta.ActivarPos();
            }
        }

        public void FiscalActivar() 
        {
            _fiscal.Activar();
        }

        public void AbrirJornada() 
        {
            if (Sistema.MyJornada == null)
            {
                var ficha = new OOB.LibVenta.PosOffline.Jornada.Abrir.Ficha()
                {
                    Estatus = "A",
                    Fecha = DateTime.Now,
                    Hora = DateTime.Now.ToShortTimeString(),
                };
                var r01 = Sistema.MyData2.Jornada_Abrir(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var idJornada = r01.Id;
                var r02 = Sistema.MyData2.Jornada_Cargar(idJornada);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                Sistema.MyJornada = r02.Entidad;
                Helpers.Msg.Alerta("SE ABRIO LA JORNADA DE MANERA EXITOSA !!!!!");
            }
            else
            {
                Helpers.Msg.Error("YA EXISTE UNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public void CerrarJornada() 
        {
            if (Sistema.MyJornada != null)
            {
                if (Sistema.MyOperador != null)
                {
                    Helpers.Msg.Error("EXISTE UN OPERADOR ABIERTO, VERIFIQUE POR FAVOR");
                    return;
                }

                var msg = MessageBox.Show("Estas Seguro De Cerrar La Jornada ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                var ficha = new OOB.LibVenta.PosOffline.Jornada.Cerrar.Ficha()
                {
                    IdJornada = Sistema.MyJornada.Id,
                    Estatus = "C",
                    Fecha = DateTime.Now,
                    Hora = DateTime.Now.ToShortTimeString(),
                };
                var r01 = Sistema.MyData2.Jornada_Cerrar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Sistema.MyJornada = null;
                Helpers.Msg.Alerta("JORNADA CERRRADA EXITOSAMENTE !!!!!");
            }
            else
            {
                Helpers.Msg.Error("NO HAY NINGUNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public void AbrirOperador() 
        {
            if (Sistema.Usuario.IsInvitado) 
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA USUARIO [ INVITADO]");
                return;
            }

            if (Sistema.MyJornada != null)
            {
                if (Sistema.MyOperador == null)
                {
                    var ficha = new OOB.LibVenta.PosOffline.Operador.Abrir.Ficha()
                    {
                        IdJornada = Sistema.MyJornada.Id,
                        AutoUsuario = Sistema.Usuario.Auto,
                        CodigoUsuario = Sistema.Usuario.Codigo,
                        Usuario = Sistema.Usuario.Descripcion,
                        Estatus = "A",
                        Fecha = DateTime.Now,
                        Hora = DateTime.Now.ToShortTimeString(),
                    };
                    var r01 = Sistema.MyData2.Operador_Abrir(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var idOperador = r01.Id;
                    var r02 = Sistema.MyData2.Operador_Cargar(idOperador);
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    Sistema.MyOperador = r02.Entidad;
                    Helpers.Msg.Alerta("SE ABRIO EL OPERADOR DE MANERA EXITOSA !!!!!");
                }
                else
                {
                    Helpers.Msg.Error("YA EXISTE UN OPERADOR ABIERTO, VERIFIQUE POR FAVOR");
                }
            }
            else
            {
                Helpers.Msg.Error("NO HAY UNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public void CerrarOperador() 
        {
            if (Sistema.MyOperador != null)
            {
                var msg = MessageBox.Show("Estas Seguro De Cerrar Este Operador ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                var ficha = new OOB.LibVenta.PosOffline.Operador.Cerrar.Ficha()
                {
                    IdOperador = Sistema.MyOperador.Id,
                    Estatus = "C",
                    Fecha = DateTime.Now,
                    Hora = DateTime.Now.ToShortTimeString(),
                };
                var r01 = Sistema.MyData2.Operador_Cerrar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Sistema.MyOperador = null;
                Helpers.Msg.Alerta("OPERADOR CERRRADO EXITOSAMENTE !!!!!");
            }
            else
            {
                Helpers.Msg.Error("NO HAY NINGUN OPERADOR ABIERTO, VERIFIQUE POR FAVOR");
            }
        }

        public void EniviarDataAlServidor() 
        {

            var r01 = Sistema.MyData2.Servidor_PrepararData();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            if (r01.Entidad != null) 
            {
                if (r01.Entidad.Jornadas != null)
                {
                    if (r01.Entidad.Jornadas.Count > 0) 
                    {

                    }
                }
            }

            //var r01 = Sistema.MyData2.Servidor_EnviarData();
            //if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}

        }

    }

}
