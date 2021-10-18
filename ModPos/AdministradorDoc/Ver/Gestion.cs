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
                    xr = documento.MontoTotal* documento.Signo ;
                }
                return xr;
            }
        }

        public string TipoDocumento { get { return documento.DocumentoNombre; } }


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