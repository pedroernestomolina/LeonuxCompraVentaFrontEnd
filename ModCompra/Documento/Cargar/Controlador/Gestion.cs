using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class Gestion
    {

        private GestionDocumento gestionDoc;


        public Gestion()
        {
            gestionDoc=new GestionDocumento();
        }

        public void Inicia() 
        {
            var frm = new Formulario.DocumentoFrm();
            frm.ShowDialog();
            gestionDoc.Inicia();
        }

    }

}