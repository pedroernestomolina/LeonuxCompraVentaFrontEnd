using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{
    
    public class CtrTotales
    {
        
        //public event EventHandler<Totalizar> TotalesOK;
        private decimal _subTotal;


        //VentaTotalizarFrm frmTotalizar;
        //public void Totalizar()
        //{
        //    if (frmTotalizar == null)
        //    {
        //        frmTotalizar = new VentaTotalizarFrm();
        //        frmTotalizar.ProcesarOk += frmTotalizar_ProcesarOk;
        //    }
        //    frmTotalizar.Limpiar();
        //    frmTotalizar.setSubTotalVenta(_subTotal);
        //    frmTotalizar.setFormaPagoIsContado(_isContado);
        //    frmTotalizar.setPermisoDsctoCargoGlobal(_permisoDsctoCargoGlobal);
        //    frmTotalizar.ShowDialog();
        //}

        //private void frmTotalizar_ProcesarOk(object sender, VentaAdministrativa.Totalizar e)
        //{
        //    frmTotalizar.Close();
        //    EventHandler<Totalizar> handler = TotalesOK;
        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}

        public void setSubTotal(decimal monto)
        {
            _subTotal = monto;
        }

    }

}