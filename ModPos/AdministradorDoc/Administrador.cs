using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.AdministradorDoc
{

    public class Administrador
    {

        private List<documento> _documentos;
        private BindingList<documento> _blDocumentos;
        private BindingSource _bs;
        private OOB.LibVenta.PosOffline.Permiso.AdmDocumento.Ficha _permisos;
        private ClaveSeguridad.Seguridad _seguridad;
        private Facturacion.Ticket _ticket;


        public BindingSource Source { get { return _bs; } }
        public bool NotaCreditoIsOk { get; set; }
        public int IdDoumentoNC { get; set; }


        public Administrador(ClaveSeguridad.Seguridad seguridad)
        {
            _documentos = new List<documento>();
            _blDocumentos = new BindingList<documento>(_documentos);
            _bs = new BindingSource();
            _bs.DataSource = _blDocumentos;
            _seguridad = seguridad;
            _ticket = new Facturacion.Ticket();
        }


        public void AdmDocumentos()
        {
            if (Sistema.MyJornada != null)
            {
                NotaCreditoIsOk = false;
                IdDoumentoNC = -1;
                if (Cargar())
                {
                    var frm = new Listar.ListartFrm();
                    frm.setControlador(this);
                    frm.ShowDialog();
                }
            }
            else 
            {
                Helpers.Msg.Error("NO HAY NINGUNA JORNADA ABIERTA, VERIFIQUE POR FAVOR");
            }
        }

        public bool NotaCredito()
        {
            var rt = false;

            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    if (item.IsActivo)
                    {
                        var seguir = true;
                        if (_permisos.NotaCredito.RequiereClave)
                        {
                            seguir = _seguridad.SolicitarClave();
                        }
                        if (seguir)
                        {
                            if (item.TipoDocumento != OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.NotaCredito)
                            {
                                var msg = MessageBox.Show("HACER NOTA DE CREDITO ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (msg == DialogResult.Yes)
                                {
                                    NotaCreditoIsOk = true;
                                    IdDoumentoNC = item.Id;
                                    rt = true;
                                }
                            }
                            else
                            {
                                Helpers.Sonido.Error();
                                Helpers.Msg.Error("TIPO DOCUMENTO INCORRECTO !!!");
                            }
                        }
                    }
                    else
                    {
                        Helpers.Sonido.Error();
                        Helpers.Msg.Error("ESTATUS DOCUMENTO ANULADO !!!");
                    }
                }
            }

            return rt;
        }

        public bool PrepararDocumento()
        {
            var rt = false;

            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    var seguir = true;
                    if (_permisos.ReImprimir.RequiereClave)
                    {
                        seguir = _seguridad.SolicitarClave();
                    }
                    if (seguir)
                    {
                        var r01 = Sistema.MyData2.VentaDocumento_Cargar(item.Id);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Sonido.Error();
                            Helpers.Msg.Error(r01.Mensaje);
                            return false;
                        }

                        var dt = r01.Entidad;
                        _ticket.Negocio.Limpiar();
                        _ticket.Negocio.setEmpresa(Sistema.Empresa);

                        _ticket.Cliente.Limpiar();
                        _ticket.Cliente.cirif = dt.ClienteCiRif ;
                        _ticket.Cliente.nombre_1 = dt.ClienteNombre ;
                        _ticket.Cliente.dirFiscal_1 = dt.ClienteDirFiscal ;
                        _ticket.Cliente.telefono_1 = dt.ClienteTelefono ;
                        _ticket.Cliente.condicionpago = dt.CondicionPago ;
                        _ticket.Cliente.estacion = Environment.MachineName ;
                        _ticket.Cliente.usuario= Sistema.Usuario.Descripcion;

                        var tot= Math.Round(dt.MontoTotal,0, MidpointRounding.AwayFromZero);
                        var stot = Math.Round(dt.MontoSubt, 0, MidpointRounding.AwayFromZero);
                        var sbtot = Math.Round(dt.MontoSubt, 0, MidpointRounding.AwayFromZero);

                        _ticket.Documento.Limpiar();
                        _ticket.Documento.nombre = dt.DocumentoNombre;
                        _ticket.Documento.aplicaA = dt.Aplica;
                        _ticket.Documento.numero = dt.Documento ;
                        _ticket.Documento.fecha = dt.Fecha.ToShortDateString();
                        _ticket.Documento.hora = dt.Hora ;
                        _ticket.Documento.subtotalNeto = "Bs " + sbtot.ToString("n2");
                        _ticket.Documento.subtotal = "Bs " + stot.ToString("n2");
                        _ticket.Documento.total = "Bs " + tot.ToString("n2");
                        _ticket.Documento.cambio = "Bs " + dt.CambioDar.ToString("n2");
                        _ticket.Documento.descuentoMonto = "Bs " + dt.DesctoMonto_1.ToString("n2");
                        _ticket.Documento.descuentoPorct = dt.DesctoPorc_1.ToString("n2").Trim() + "%";
                        _ticket.Documento.cargoMonto = "Bs " + dt.CargoMonto_1.ToString("n2");
                        _ticket.Documento.cargoPorct = dt.CargoPorc_1.ToString("n2").Trim() + "%";
                        _ticket.Documento.HayDescuento = dt.DesctoPorc_1 > 0.0m;
                        _ticket.Documento.HayCargo = dt.CargoPorc_1 > 0.0m;

                        foreach (var it in dt.Detalles) 
                        {
                            //PARA EL TICKET
                            var rg = new ModPos.Facturacion.Ticket.DatosDocumento.Item()
                            {
                                cantidad = it.Cantidad,
                                precio = Math.Round(it.PrecioFull, 0, MidpointRounding.AwayFromZero),
                                isExento = it.EsExento,
                                isPesado = it.EsPesado,
                                descripcion = it.NombreProducto,
                                importe = Math.Round(it.Total, 0, MidpointRounding.AwayFromZero),
                            };
                            _ticket.Documento.Items.Add(rg);
                        }

                        foreach (var fmp in dt.MediosPago)
                        {
                            if (fmp.Tasa > 1)
                            {
                                var m = fmp.MontoRecibido * fmp.Tasa;
                                var itP = new ModPos.Facturacion.Ticket.DatosDocumento.MedioPago()
                                {
                                    descripcion = "Efectivo",
                                    monto = "Bs " + m.ToString("n2"),
                                };
                                _ticket.Documento.MediosPago.Add(itP);
                            }
                            else
                            {
                                var itP = new  ModPos.Facturacion.Ticket.DatosDocumento.MedioPago()
                                {
                                    descripcion = fmp.Descripcion,
                                    monto = "Bs " + fmp.MontoRecibido.ToString("n2"),
                                };
                                _ticket.Documento.MediosPago.Add(itP);
                            }
                        }

                        return true;
                    }
                }
            }

            return rt;
        }

        public void Imprimir(System.Drawing.Printing.PrintPageEventArgs e)
        {
            _ticket.setControlador(e);
            _ticket.Imrpimir();
        }

        public void AnularDocumento()
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var item = (documento)_bs.Current;
                    if (item.IsActivo)
                    {
                        var seguir = true;
                        if (_permisos.Anular.RequiereClave)
                        {
                            seguir = _seguridad.SolicitarClave();
                        }
                        if (seguir)
                        {
                            var msg = MessageBox.Show("ESTAS SEGURO DE ANULAR DOCUMENTO ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msg == DialogResult.Yes)
                            {
                                var r01 = Sistema.MyData2.VentaDocumento_Anular(item.Id);
                                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                                {
                                    Helpers.Sonido.Error();
                                    Helpers.Msg.Error(r01.Mensaje);
                                    return;
                                }
                                item.IsActivo = false;
                                _bs.CurrencyManager.Refresh();
                            }
                        }
                    }
                    else
                    {
                        Helpers.Sonido.Error();
                        Helpers.Msg.Error("DOCUMENTO YA ANULADO !!!");
                    }
                }
            }
        }

        public bool Cargar()
        {
            var rt = false;

            var r00 = Sistema.MyData2.Permiso_AdmDocumento();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return rt;
            }
            _permisos = r00.Entidad;

            var filtro = new OOB.LibVenta.PosOffline.VentaDocumento.Filtro();
            filtro.IdJornada = Sistema.MyJornada.Id;
            var r01 = Sistema.MyData2.VentaDocumento_Lista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }

            _blDocumentos.Clear();
            _blDocumentos.RaiseListChangedEvents = false;
            foreach (var it in r01.Lista.OrderByDescending(o => o.Id).ToList())
            {
                _documentos.Add(new documento(it));
            }
            _blDocumentos.RaiseListChangedEvents = true;
            _blDocumentos.ResetBindings();
            rt = true;

            return rt;
        }

        public void Subir()
        {
            _bs.Position -= 1;
        }

        public void Bajar()
        {
            _bs.Position += 1;
        }
      
    }

}