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
        private Permisos.CtrPermiso _permisos;
        private Operador.Cierre.CtrCierre _cierreOperador;
        private List<OOB.LibVenta.PosOffline.Permiso.Actual.Permiso> _litsActualPermisos; 
        private string _bdRemota;
        private string _bdLocal;


        public string IdSucursal { get { return Sistema.CodigoSucursal; } }
        public string InformacionBD { get { return "Ruta Remota: "+_bdRemota + Environment.NewLine + "Ruta Local: "+_bdLocal; } }
        public string JornadaNro 
        { 
            get 
            {
                var xr = "";
                if (Sistema.MyJornada !=null)
                    xr=Sistema.MyJornada.Id.ToString().PadLeft(6,'0');
                return xr;
            } 
        }


        public bool IsBdActualizada 
        { 
            get 
            {
                var rt = true;
                if (Sistema.FechaUltimaActualizacion == null)
                {
                    return false;
                }
                var dif = -1;
                dif = (Sistema.FechaUltimaActualizacion.Value.Date - DateTime.Now.Date).Days;
                if (dif != 0)
                {
                    rt=false;
                }
                return rt;
            } 
        }

        public bool HabilitarBotonActualizarDataServidor 
        {
            get 
            {
                var rt=false;

                if (Sistema.Usuario.IsInvitado)
                    rt = true;

                return rt;
            } 
        }


        public Sistema_()
        {
            Sistema.MyBalanza = new Lib.BalanzaSoloPeso.BalanzaManual.Balanza();
            _seguridad = new ClaveSeguridad.Seguridad();
            _configuracion = new Configuracion.configurar();
            _administrador = new AdministradorDoc.Administrador(_seguridad);
            _venta = new Facturacion.Venta(_seguridad);
            _fiscal = new Fiscal.CtrFiscal();
            _permisos = new Permisos.CtrPermiso();
            _cierreOperador = new Operador.Cierre.CtrCierre();
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

            var r05 = Sistema.MyData2.Permiso_CargarListaActual ();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            _litsActualPermisos = r05.Entidad.Permisos;

            var r06 = Sistema.MyData2.Empresa_Datos();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            Sistema.Empresa = r06.Entidad;

            var r07 = Sistema.MyData2.FechaUltimaActualizacionBDServidor();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            Sistema.FechaUltimaActualizacion = r07.Entidad;

            var r08 = Sistema.MyData2.CodigoSucursal();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return false;
            }
            Sistema.CodigoSucursal = r08.Entidad;

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
            //if (!Sistema.Usuario.IsInvitado)
            //{
            //    Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
            //    return;
            //}

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
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
                return;
            }

            if (Sistema.FechaUltimaActualizacion == null)
            {
                Helpers.Msg.Alerta("POR FAVOR, DEBES IR A ACTUALIZAR DATA DEL SERVIDOR");
                return;
            }

            var dif = (Sistema.FechaUltimaActualizacion.Value.Date- DateTime.Now.Date).Days ;
            if (dif != 0)
            {
                Helpers.Msg.Alerta("POR FAVOR, DEBES IR A ACTUALIZAR DATA DEL SERVIDOR");
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

        public void ConfigurarPermisos() 
        {
            if (!Sistema.Usuario.IsInvitado)
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
                return;
            }

            _permisos.Configurar();
        }

        public bool VerificarPermiso(int modulo, string codigo) 
        {
            var rt = true;

            if (!Sistema.Usuario.IsInvitado)
            {
                var permiso = _litsActualPermisos.FirstOrDefault(f => f.Modulo == modulo  && f.CodigoFuncion == codigo);
                if (permiso != null)
                {
                    if (permiso.RequiereClave)
                    {
                        rt = _seguridad.SolicitarClave();
                    }
                }
                else
                {
                    rt=false ;
                }
            }

            return rt;
        }

        public void ImportarDataDelServidor() 
        {
            var r = VerificarPermiso(1, "01");
            if (!r)
            {
                return;
            }

            //if (Sistema.MyOperador != null) 
            //{
            //    Helpers.Msg.Error("HAY UN OPERADOR ABIERTO, VERIFIQUE POR FAVOR");
            //    return;
            //}

            var msg = MessageBox.Show("Importar Data Del Servidor ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                ImportarData();

                //var r01 = Sistema.MyData2.Servidor_Test();
                //if (r01.Result == OOB.Enumerados.EnumResult.isError)
                //{
                //    Helpers.Msg.Error(r01.Mensaje);
                //    return;
                //}

                //var r02 = Sistema.MyData2.Servidor_ActualizarData();
                //if (r02.Result == OOB.Enumerados.EnumResult.isError)
                //{
                //    Helpers.Msg.Error(r02.Mensaje);
                //    return;
                //}

                //var r03 = Sistema.MyData2.FechaUltimaActualizacionBDServidor();
                //if (r03.Result == OOB.Enumerados.EnumResult.isError)
                //{
                //    Helpers.Msg.Error(r03.Mensaje);
                //    return;
                //}
                //Sistema.FechaUltimaActualizacion = r03.Entidad;

                Helpers.Msg.EditarOk();
            }
        }

        public bool ImportarData() 
        {
            var r01 = Sistema.MyData2.Servidor_Test();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData2.Servidor_ActualizarData();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData2.FechaUltimaActualizacionBDServidor();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            Sistema.FechaUltimaActualizacion = r03.Entidad;

            return true;
        }

        public void ConfiguracionActivar() 
        {
            if (!Sistema.Usuario.IsInvitado)
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
                return;
            }

            if (Sistema.MyOperador!=null)
            {
                Helpers.Msg.Alerta("HAY UN OPERADOR ACTIVO"+Environment.NewLine+"DEBES CERRAR EL OPERADOR PARA PODER CONFIGURAR");
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
            var r = VerificarPermiso(1, "07");
            if (!r)
            {
                return;
            }

            _fiscal.Activar();
        }

        public void AbrirJornada() 
        {
            var r = VerificarPermiso(1, "03");
            if (!r)
            {
                return;
            }

            AbreJornada();
        }

        public void AbreJornada()
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
                //Helpers.Msg.Alerta("SE ABRIO LA JORNADA DE MANERA EXITOSA !!!!!");
            }
            else
            {
               // Helpers.Msg.Error("YA EXISTE UNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public void CerrarJornada() 
        {
            var r = VerificarPermiso(1, "04");
            if (!r)
            {
                return;
            }

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

                CierraJornada();
            }
            else
            {
                Helpers.Msg.Error("NO HAY NINGUNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public void CierraJornada() 
        {
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

        public void AbrirOperador() 
        {
            var r = VerificarPermiso(1, "05");
            if (!r)
            {
                return;
            }

            if (Sistema.Usuario.IsInvitado) 
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
                return;
            }

            var r00 = Sistema.MyData2.Configuracion_ActualCargar();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            var prefijo = r00.Entidad.CodigoSucursal + r00.Entidad.EquipoNumero;

            AbreJornada();

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
                        Prefijo= prefijo,
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
                   // Helpers.Msg.Alerta("SE ABRIO EL OPERADOR DE MANERA EXITOSA !!!!!");
                }
                else
                {
                    //Helpers.Msg.Error("YA EXISTE UN OPERADOR ABIERTO, VERIFIQUE POR FAVOR");
                }
            }
            else
            {
               // Helpers.Msg.Error("NO HAY UNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public void CerrarOperador() 
        {
            var r = VerificarPermiso(1, "06");
            if (!r)
            {
                return;
            }

            if (Sistema.MyOperador != null)
            {
                _cierreOperador.Cierre();
                if (_cierreOperador.IsOperadorCerrado) 
                {
                    CierraJornada();
                    EnviarData();
                }
            }
            else
            {
                Helpers.Msg.Error("NO HAY NINGUN OPERADOR ABIERTO, VERIFIQUE POR FAVOR");
            }
        }

        public void InicializarBDLocal() 
        {
            if (!Sistema.Usuario.IsInvitado)
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA ESTE USUARIO");
                return;
            }
            if (_seguridad.SolicitarClaveSeguridad()) 
            {
                var msg = MessageBox.Show("Estas Seguro De Limpiar BD Local ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == System.Windows.Forms.DialogResult.Yes)
                {
                    var r01 = Sistema.MyData2.Inicializar_BdLocal();
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }

                    Helpers.Msg.OK("PROCESO REALIZADO CON EXITO !!!");
                }
            }
        }

        public void EnviarDataAlServidor() 
        {
            var r = VerificarPermiso(1, "02");
            if (!r)
            {
                return;
            }
            EnviarData();
        }

        public void EnviarData()
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
                        var ficha = new OOB.LibVenta.PosOffline.Servidor.EnviarData.Ficha(r01.Entidad);
                        var r02 = Sistema.MyData2.Servidor_EnviarData(ficha);
                        if (r02.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r02.Mensaje);
                            return;
                        }
                        Helpers.Msg.AgregarOk();
                    }
                }
            }
        }
      
    }

}
