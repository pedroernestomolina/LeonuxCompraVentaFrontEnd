using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Configuracion
{
    
    public class configurar
    {

        public void Configura() 
        {
            var frm = new Configuracion.ConfigurarFrm();
            if (frm.CargarData()) 
            {
                frm.ShowDialog();
            }
        }

    }

}
