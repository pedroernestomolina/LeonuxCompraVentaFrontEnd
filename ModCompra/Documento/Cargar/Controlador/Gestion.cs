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
        public DateTime FechaEmision { get { return _gestionDoc.FechaEmision; } }
        public string DocumentoNro { get { return _gestionDoc.DocumentoNro; } }
        public string ControlNro { get { return _gestionDoc.ControlNro; } }
        public DateTime FechaVencimiento { get { return _gestionDoc.FechaVencimiento; } }
        public decimal FactorDivisa { get { return _gestionDoc.FactorDivisa; } }
        public string Deposito { get { return _gestionDoc.DepositoNombre; } }
        public string Sucursal { get { return _gestionDoc.SucursalNombre; } }


        public string TituloDocumento { get { return _gestion.TituloDocumento; } }
        public decimal Total { get { return 0.0m; } }
        public decimal MontoIva { get { return 0.0m; } }
        public decimal MontoDivisa { get { return 0.0m; } }


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