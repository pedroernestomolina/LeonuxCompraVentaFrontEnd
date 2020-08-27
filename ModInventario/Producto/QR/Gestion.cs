using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.QR
{
    
    public class Gestion
    {


        private string _autoPrd;
        public string AutoPrd { get { return _autoPrd; } }
        public string Url 
        { 
            get 
            {
                var rt = @"http://"+Sistema._Instancia+"/info.php?auto="+AutoPrd;
                return rt; 
            } 
        }


        public void setFicha(string p)
        {
            _autoPrd = p;
        }

        QRFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new QRFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            //var r01 = Sistema.MyData.Producto_GetCosto(_autoPrd);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return false;
            //}
            //_data.setFicha(r01.Entidad);

            return rt;
        }

        private void Limpiar()
        {
        }

    }

}