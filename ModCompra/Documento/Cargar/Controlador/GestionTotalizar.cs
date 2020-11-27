using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{

    public class GestionTotalizar
    {

        private IGestionTotalizar _gestion;


        public bool IsOk { get { return _gestion.IsOk; } }
        public decimal Dscto { get { return _gestion.Dscto; } }
        public decimal Cargo { get { return _gestion.Cargo; } }


        public void setGestion(IGestionTotalizar gestion)
        {
            _gestion = gestion;
        }

        Formulario.TotalizarFrm totalizarFrm;
        public void Inicia()
        {
            _gestion.Inicializar();
            totalizarFrm = new Formulario.TotalizarFrm();
            totalizarFrm.setControlador(this);
            totalizarFrm.ShowDialog();
        }


        public void Guardar()
        {
            _gestion.Guardar();
        }

    }

}