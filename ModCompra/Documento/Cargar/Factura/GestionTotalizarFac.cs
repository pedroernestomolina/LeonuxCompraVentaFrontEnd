using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionTotalizarFac: Controlador.IGestionTotalizar
    {

        public bool IsOk { get; set; }
        public decimal Dscto { get { return dscto; } }
        public decimal Cargo { get { return cargo; } }


        private decimal dscto;
        private decimal cargo;


        public GestionTotalizarFac()
        {
            IsOk = false;
        }


        public void Inicializar()
        {
            IsOk = false;
            dscto = 0.0m;
            cargo = 0.0m;
        }

        public void Guardar()
        {
            var ms = MessageBox.Show("Estas Seguro de Guardar El Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ms == DialogResult.Yes)
            {
                IsOk = true;
                dscto = 0;
                cargo = 0;
            }
        }

    }

}