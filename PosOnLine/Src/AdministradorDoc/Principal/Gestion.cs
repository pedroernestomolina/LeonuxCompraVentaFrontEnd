using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Principal
{
    
    public class Gestion
    {


        private bool _notaCreditoIsOk;


        public string TotItems { get { return _gestionLista.TotItems; } }
        private Lista.Gestion _gestionLista;
        public bool NotaCreditoIsOk { get { return _notaCreditoIsOk; } }
        public Lista.data DocAplicaNotaCredito { get { return _gestionLista.DocAplicarNotaCredito; } }
        public BindingSource Source { get { return _gestionLista.Source; } }


        public Gestion()
        {
            _notaCreditoIsOk = false;
            _gestionLista = new Lista.Gestion();
        }


        public void Inicializa() 
        {
            _gestionLista.Inicializa();
            _notaCreditoIsOk = false;
        }

        AdmDocFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AdmDocFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.Documento.Lista.Filtro() { idArqueo = Sistema.PosEnUso.idAutoArqueoCierre };
            var r01 = Sistema.MyData.Documento_Get_Lista (filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _gestionLista.setData(r01.ListaD);

            return rt;
        }


        public void SubirItem()
        {
            _gestionLista.SubirItem();
        }

        public void BajarItem()
        {
            _gestionLista.BajarItem();
        }

        public void NotaCredito()
        {
            _notaCreditoIsOk = false;
            if (_gestionLista.AplicaParaNotaCredito()) 
            {
                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmNotaCredito)) 
                {
                    _notaCreditoIsOk = true;
                }
            }
        }

        public void AnularDocumento()
        {
            if (_gestionLista.AplicaParaAnular())
            {
                if (Helpers.PassWord.PassWIsOk(Sistema.FuncionAdmAnularDocumento))
                {
                    var rt = false;
                    switch (_gestionLista.DocAplicaParaAulacion.DocTipo) 
                    {
                        case Lista.data.enumTipoDoc.NotaEntrega:
                            rt=AnularNotaEntrega(_gestionLista.DocAplicaParaAulacion.idDocumento);
                            break;
                        case Lista.data.enumTipoDoc.NotaCredito:
                            rt = AnularNotaCredito(_gestionLista.DocAplicaParaAulacion.idDocumento);
                            break;
                        case Lista.data.enumTipoDoc.Factura:
                            rt = AnularFactura(_gestionLista.DocAplicaParaAulacion.idDocumento);
                            break;
                    }
                    if (rt) 
                    {
                        _gestionLista.setAnularDoc();
                        Helpers.Msg.EliminarOk();
                    }
                }
            }
        }

        private bool AnularNotaEntrega(string idDoc)
        {
            var r01 = Sistema.MyData.Documento_GetById(idDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var ficha = new OOB.Documento.Anular.NotaEntrega.Ficha()
            {
                autoDocumento = idDoc,
                CodigoDocumento = r01.Entidad.Tipo,
                auditoria = new OOB.Documento.Anular.NotaEntrega.FichaAuditoria
                {
                    autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoNotaEntrega,
                    autoUsuario = Sistema.Usuario.id,
                    codigo = Sistema.Usuario.codigo,
                    estacion = Sistema.EquipoEstacion,
                    motivo = "PRUEBA",
                    usuario = Sistema.Usuario.nombre,
                },
                deposito = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.Documento.Anular.NotaEntrega.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantidadUnd,
                        nombrePrd = s.Nombre,
                    };
                    return nr;
                }).ToList(),
                resumen = new OOB.Documento.Anular.NotaEntrega.FichaResumen()
                {
                    idResumen = Sistema.PosEnUso.idResumen,
                    monto = r01.Entidad.Total,
                },
            };
            var r03 = Sistema.MyData.Documento_Anular_NotaEntrega(ficha);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            return true;
        }

        private bool AnularNotaCredito(string idDoc)
        {
            var r01 = Sistema.MyData.Documento_GetById(idDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var ficha = new OOB.Documento.Anular.NotaCredito.Ficha()
            {
                autoDocumento = idDoc,
                autoDocCxC = r01.Entidad.AutoDocCxC,
                CodigoDocumento = r01.Entidad.Tipo,
                auditoria = new OOB.Documento.Anular.NotaCredito.FichaAuditoria
                {
                    autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoDevVenta,
                    autoUsuario = Sistema.Usuario.id,
                    codigo = Sistema.Usuario.codigo,
                    estacion = Sistema.EquipoEstacion,
                    motivo = "PRUEBA",
                    usuario = Sistema.Usuario.nombre,
                },
                deposito = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.Documento.Anular.NotaCredito.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantidadUnd,
                        nombrePrd = s.Nombre,
                    };
                    return nr;
                }).ToList(),
                resumen = new OOB.Documento.Anular.NotaCredito.FichaResumen()
                {
                    idResumen = Sistema.PosEnUso.idResumen,
                    monto = r01.Entidad.Total,
                },
            };
            var r03 = Sistema.MyData.Documento_Anular_NotaCredito(ficha);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            return true;
        }

        private bool AnularFactura(string idDoc)
        {
            var r01 = Sistema.MyData.Documento_GetById(idDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var ficha = new OOB.Documento.Anular.Factura.Ficha()
            {
                autoDocumento = idDoc,
                autoDocCxC = r01.Entidad.AutoDocCxC,
                autoReciboCxC = r01.Entidad.AutoReciboCxC,
                CodigoDocumento = r01.Entidad.Tipo,
                auditoria = new OOB.Documento.Anular.Factura.FichaAuditoria
                {
                    autoSistemaDocumento = Sistema.ConfiguracionActual.idTipoDocumentoDevVenta,
                    autoUsuario = Sistema.Usuario.id,
                    codigo = Sistema.Usuario.codigo,
                    estacion = Sistema.EquipoEstacion,
                    motivo = "PRUEBA",
                    usuario = Sistema.Usuario.nombre,
                },
                deposito = r01.Entidad.items.Select(s =>
                {
                    var nr = new OOB.Documento.Anular.Factura.FichaDeposito()
                    {
                        AutoDeposito = s.AutoDeposito,
                        AutoProducto = s.AutoProducto,
                        CantUnd = s.CantidadUnd,
                        nombrePrd = s.Nombre,
                    };
                    return nr;
                }).ToList(),
                resumen = new OOB.Documento.Anular.Factura.FichaResumen()
                {
                    idResumen = Sistema.PosEnUso.idResumen,
                    monto = r01.Entidad.Total,
                },
            };
            var r03 = Sistema.MyData.Documento_Anular_Factura(ficha);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            return true;
        }

    }

}