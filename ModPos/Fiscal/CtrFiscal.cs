using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Fiscal
{
 
    public class CtrFiscal
    {

        public CtrFiscal()
        {
        }


        public void Activar() 
        {
            var frm = new FiscalFrm();
            frm.ShowDialog();
        }

    }

}
