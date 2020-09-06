using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Kardex.Movimiento
{
    
    public class detalle
    {

        private OOB.LibInventario.Kardex.Movimiento.Resumen.Data reg;
        public string AutoDeposito { get; set; }
        public string AutoConcepto { get; set; }
        public string Deposito { get; set; }
        public string Concepto { get; set; }
        public int CntMovimiento { get; set; }
        public decimal CntInventario { get; set; }


        public detalle(OOB.LibInventario.Kardex.Movimiento.Resumen.Data reg)
        {
            this.reg = reg;
            AutoDeposito = reg.autoDeposito;
            AutoConcepto = reg.autoConcepto;
            Deposito = reg.nombreDeposito.Trim() + "/" + reg.codigoDeposito;
            Concepto = reg.nombreConcepto.Trim() + "/" + reg.codigoConcepto;
            CntInventario = reg.cntInventario;
            CntMovimiento = reg.cntMovimiento;
        }


    }

}