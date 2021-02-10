using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.AdministradorDoc.Ver
{
    
    public class Gestion
    {


        private int autoDoc;
        private List<detalle> detalles;
        private BindingSource bs;
        private OOB.LibVenta.PosOffline.VentaDocumento.Ficha documento;


        public BindingSource Source { get { return bs; } }
        public string Fecha 
        { 
            get 
            {
                var xr = "";
                if (documento !=null)
                    xr=documento.Fecha.ToShortDateString();
                return xr;
            } 
        }
        public string DocumentoNro 
        { 
            get 
            {
                var xr = "";
                if (documento !=null)
                    xr=documento.Documento;
                return xr;
            } 
        }
        public string DatosCliente 
        { 
            get 
            {
                var xr = "";
                if (documento != null) 
                {
                    xr += documento.ClienteCiRif + Environment.NewLine + documento.ClienteNombre + Environment.NewLine + documento.ClienteDirFiscal;
                }
                return xr;
            } 
        }
        public decimal TotalDocumento
        {
            get
            {
                var xr = 0.0m;
                if (documento != null)
                {
                    xr = documento.MontoTotal ;
                }
                return xr;
            }
        }


        public Gestion()
        {
            autoDoc = -1;
            detalles = new List<detalle>();
            bs = new BindingSource();
            bs.DataSource = detalles;
            documento = null;
        }


        private VerFrm frm;
        public void Inicia() 
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new VerFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setDocumento(documento item)
        {
            autoDoc=item.Id;
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData2.VentaDocumento_Cargar(autoDoc);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Sonido.Error();
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            documento = r01.Entidad;
            detalles.Clear();
            foreach (var it in r01.Entidad.Detalles) 
            {
                var nr = new detalle(it);
                detalles.Add(nr);
            }
            bs.CurrencyManager.Refresh();


            //var dt = r01.Entidad;
            //_ticket.Negocio.Limpiar();
            //_ticket.Negocio.setEmpresa(Sistema.Empresa);

            //_ticket.Cliente.Limpiar();
            //_ticket.Cliente.cirif = dt.ClienteCiRif;
            //_ticket.Cliente.nombre_1 = dt.ClienteNombre;
            //_ticket.Cliente.dirFiscal_1 = dt.ClienteDirFiscal;
            //_ticket.Cliente.telefono_1 = dt.ClienteTelefono;
            //_ticket.Cliente.condicionpago = dt.CondicionPago;
            //_ticket.Cliente.estacion = Environment.MachineName;
            //_ticket.Cliente.usuario = Sistema.Usuario.Descripcion;

            //var tot = Math.Round(dt.MontoTotal, 0, MidpointRounding.AwayFromZero);
            //var stot = Math.Round(dt.MontoSubt, 0, MidpointRounding.AwayFromZero);
            //var sbtot = Math.Round(dt.MontoSubt, 0, MidpointRounding.AwayFromZero);

            //_ticket.Documento.Limpiar();
            //_ticket.Documento.nombre = dt.DocumentoNombre;
            //_ticket.Documento.aplicaA = dt.Aplica;
            //_ticket.Documento.numero = dt.Documento;
            //_ticket.Documento.fecha = dt.Fecha.ToShortDateString();
            //_ticket.Documento.hora = dt.Hora;
            //_ticket.Documento.subtotalNeto = "Bs " + sbtot.ToString("n2");
            //_ticket.Documento.subtotal = "Bs " + stot.ToString("n2");
            //_ticket.Documento.total = "Bs " + tot.ToString("n2");
            //_ticket.Documento.cambio = "Bs " + dt.CambioDar.ToString("n2");
            //_ticket.Documento.descuentoMonto = "Bs " + dt.DesctoMonto_1.ToString("n2");
            //_ticket.Documento.descuentoPorct = dt.DesctoPorc_1.ToString("n2").Trim() + "%";
            //_ticket.Documento.cargoMonto = "Bs " + dt.CargoMonto_1.ToString("n2");
            //_ticket.Documento.cargoPorct = dt.CargoPorc_1.ToString("n2").Trim() + "%";
            //_ticket.Documento.HayDescuento = dt.DesctoPorc_1 > 0.0m;
            //_ticket.Documento.HayCargo = dt.CargoPorc_1 > 0.0m;

            //foreach (var it in dt.Detalles)
            //{
            //    //PARA EL TICKET
            //    var rg = new ModPos.Facturacion.Ticket.DatosDocumento.Item()
            //    {
            //        cantidad = it.Cantidad,
            //        precio = Math.Round(it.PrecioFull, 0, MidpointRounding.AwayFromZero),
            //        isExento = it.EsExento,
            //        isPesado = it.EsPesado,
            //        descripcion = it.NombreProducto,
            //        importe = Math.Round(it.Total, 0, MidpointRounding.AwayFromZero),
            //    };
            //    _ticket.Documento.Items.Add(rg);
            //}

            //foreach (var fmp in dt.MediosPago)
            //{
            //    if (fmp.Tasa > 1)
            //    {
            //        var m = fmp.MontoRecibido * fmp.Tasa;
            //        var itP = new ModPos.Facturacion.Ticket.DatosDocumento.MedioPago()
            //        {
            //            descripcion = "Efectivo",
            //            monto = "Bs " + m.ToString("n2"),
            //        };
            //        _ticket.Documento.MediosPago.Add(itP);
            //    }
            //    else
            //    {
            //        var itP = new ModPos.Facturacion.Ticket.DatosDocumento.MedioPago()
            //        {
            //            descripcion = fmp.Descripcion,
            //            monto = "Bs " + fmp.MontoRecibido.ToString("n2"),
            //        };
            //        _ticket.Documento.MediosPago.Add(itP);
            //    }
            //}

            return rt;
        }

        public void Inicializa()
        {
            autoDoc = -1;
            detalles.Clear();
            documento = null;
        }

    }

}