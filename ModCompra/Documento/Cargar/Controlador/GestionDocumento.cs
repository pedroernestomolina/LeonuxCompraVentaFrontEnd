using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class GestionDocumento
    {

        Formulario.DatosDocumentoFrm frm;
        public void Inicia()
        {
            if (frm == null) 
            {
                frm = new Formulario.DatosDocumentoFrm();
            }
            frm.ShowDialog();
        }

    }

}
