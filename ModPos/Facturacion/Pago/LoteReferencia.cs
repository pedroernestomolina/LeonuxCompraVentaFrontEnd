using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion.Pago
{
    
    public class LoteReferencia
    {

        private bool _isOk;


        public string Lote { get; set; }
        public string Referencia { get; set; }
        public bool IsOk { get { return _isOk; } }


        public LoteReferencia()
        {
            Limpiar();
        }


        private void Limpiar()
        {
            _isOk = false;
            Lote = "";
            Referencia = "";
        }

        public void Inicia() 
        {
            Inicia("", "");
        }

        public void Inicia(string p1, string p2)
        {
            Limpiar();

            Lote = p1;
            Referencia = p2;
            var frm = new LoteReferenciaFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void Aceptar()
        {
            if (Lote.Trim() != "" && Referencia.Trim() != "") 
            {
                _isOk = true;
            }
        }

    }

}