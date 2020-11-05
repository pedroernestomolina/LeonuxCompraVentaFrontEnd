using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionFac : Controlador.IGestion
    {

        private Controlador.IGestionDocumento gestionDoc;


        public Controlador.IGestionDocumento GestionDoc { get { return gestionDoc; } }


        public string TituloDocumento
        {
            get { return "Entrada Documento: ( FACTURA )"; }
        }


        public GestionFac()
        {
            gestionDoc= new GestionDocumentoFac();
        }

    }

}