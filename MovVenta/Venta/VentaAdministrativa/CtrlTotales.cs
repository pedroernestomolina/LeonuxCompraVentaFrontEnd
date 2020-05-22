using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovVenta.Venta.VentaAdministrativa
{

    public class CtrlTotales
    {

        public event EventHandler<Totalizar> TotalesOK;
        private decimal _subTotal;
        private bool _isContado;
        private OOB.LibVenta.Permiso.Ficha _permisoDsctoCargoGlobal;


        VentaTotalizarFrm frmTotalizar;
        public void Totalizar() 
        {
            if (frmTotalizar == null)
            {
                frmTotalizar = new VentaTotalizarFrm();
                frmTotalizar.ProcesarOk += frmTotalizar_ProcesarOk;
            }
            frmTotalizar.Limpiar();
            frmTotalizar.setSubTotalVenta(_subTotal);
            frmTotalizar.setFormaPagoIsContado(_isContado);
            frmTotalizar.setPermisoDsctoCargoGlobal(_permisoDsctoCargoGlobal);
            frmTotalizar.ShowDialog();
        }

        private void frmTotalizar_ProcesarOk(object sender, VentaAdministrativa.Totalizar e)
        {
            frmTotalizar.Close();
            EventHandler<Totalizar> handler = TotalesOK;
            if (handler != null) 
            {
                handler(this, e);
            }
        }

        public void setSubTotal(decimal monto) 
        {
            _subTotal = monto;
        }

        public void setIsContado(bool isContado)
        {
            _isContado = isContado;
        }

        public void setPermisoDsctoCargoGlobal(OOB.LibVenta.Permiso.Ficha permiso)
        {
            _permisoDsctoCargoGlobal = permiso;
        }

    }

}