using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.AdministradorDoc.Ver
{
    
    public class detalle
    {

        private OOB.LibVenta.PosOffline.VentaDocumento.FichaDetalle it;


        public string CodigoPrd { get { return it.CodigoProducto; } }
        public string NombrePrd { get { return it.NombreProducto; } }
        public decimal Cantidad { get { return it.CantidadUnd; } }
        public decimal Precio { get { return it.PrecioFull; } }
        public decimal Importe { get { return it.Total; } }
        public string EmpaqueCont { get { return it.EmpaqueDescripcion+"/"+it.EmpaqueContenido.ToString().Trim(); } }


        public detalle(OOB.LibVenta.PosOffline.VentaDocumento.FichaDetalle it)
        {
            this.it = it;
        }

    }

}