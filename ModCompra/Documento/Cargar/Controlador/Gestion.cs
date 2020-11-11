using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class Gestion
    {

        private IGestion _gestion;
        private GestionDocumento _gestionDoc;


        public string Proveedor { get { return _gestionDoc.Proveedor; } }
        public string TituloDocumento { get { return _gestion.TituloDocumento; } }



        public Gestion()
        {
            _gestionDoc = new GestionDocumento();
        }


        public void setGestion(IGestion gestion) 
        {
            _gestion = gestion;
            _gestionDoc.setGestion(_gestion.GestionDoc);
        }

        Formulario.DocumentoFrm frm;
        public void Inicia() 
        {
            frm = new Formulario.DocumentoFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void NuevoDocumento()
        {
            _gestionDoc.Inicia();
        }

    }

}