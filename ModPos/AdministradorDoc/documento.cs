using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.AdministradorDoc
{
    
    public class documento
    {

        public int Id { get; set; }
        public string Documento { get; set; }
        public string Control { get; set; }
        public DateTime FechaEmision { get; set; }
        public string HoraEmision { get; set; }
        public string NombreRazonSocial { get; set; }
        public string CiRif { get; set; }
        public decimal Monto { get; set; }
        public OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento TipoDocumento { get; set; }
        public bool IsActivo { get; set; }
        public int Signo { get; set; }
        public int Renglones { get; set; }
        public string FechaHora 
        {
            get
            {
                return FechaEmision.ToShortDateString() + ", " + HoraEmision;
            }
        }
        public string TipoDocumentoDesc 
        {
            get 
            {
                var desc = "";
                switch (TipoDocumento) 
                {
                    case OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.Factura:
                        desc = "FACTURA";
                        break;
                    case OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.NotaCredito:
                        desc = "Nt/Crédito";
                        break;
                    case OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.NotaDebito:
                        desc = "Nt/Débito";
                        break;
                }
                return desc;
            }
        }


        public documento(OOB.LibVenta.PosOffline.VentaDocumento.Ficha ficha)
        {
            Id = ficha.Id;
            Documento = ficha.Documento;
            Control = ficha.Control;
            FechaEmision = ficha.Fecha;
            HoraEmision = ficha.Hora;
            NombreRazonSocial = ficha.ClienteNombre;
            CiRif = ficha.ClienteCiRif;
            Monto = ficha.MontoTotal;
            TipoDocumento = ficha.TipoDocumento;
            IsActivo = ficha.IsActiva;
            Signo = ficha.Signo;
            Renglones = ficha.Renglones;
        }

    }

}