using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Cliente
{
    
    public class Gestion
    {


        private Buscar.Gestion _gestionBuscar;


        public OOB.Cliente.Entidad.Ficha Cliente { get { return _gestionBuscar.Cliente; } }
        public string ClienteData { get { return _gestionBuscar.Cliente != null ? _gestionBuscar.Cliente.Data : ""; } }


        public Gestion() 
        {
            _gestionBuscar = new Buscar.Gestion();
        }


        public void Inicia()
        {
            _gestionBuscar.Inicia();
            if (!_gestionBuscar.ClienteSeleccionadoIsOk)
                _gestionBuscar.Limpiar();
        }

        public void Limpiar()
        {
            _gestionBuscar.Limpiar();
        }

        public void Inicializa()
        {
            _gestionBuscar.Inicializar();
        }

    }

}