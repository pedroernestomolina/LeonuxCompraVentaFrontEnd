using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Editar
{
    
    public class Gestion
    {

        private IGestion miGestion;


        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque1 { get { return miGestion.Empaque1; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque2 { get { return miGestion.Empaque2; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque3 { get { return miGestion.Empaque3; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque4 { get { return miGestion.Empaque4; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque5 { get { return miGestion.Empaque5; } }
        public BindingSource SourceEmpaque1 { get { return miGestion.SourceEmpaque1; } }
        public BindingSource SourceEmpaque2 { get { return miGestion.SourceEmpaque2; } }
        public BindingSource SourceEmpaque3 { get { return miGestion.SourceEmpaque3; } }
        public BindingSource SourceEmpaque4 { get { return miGestion.SourceEmpaque4; } }
        public BindingSource SourceEmpaque5 { get { return miGestion.SourceEmpaque5; } }

        public string Producto { get { return miGestion.Producto; } }
        public string CostoUnitario { get { return miGestion.CostoUnitario; } }
        public string AdmDivisa { get { return miGestion.AdmDivisa; } }
        public string TasaIva { get { return miGestion.TasaIva; } }
        public string MetodoCalculoUtilidad { get { return miGestion.MetodoCalculoUtilidad; } }
        public string TasaCambioActual { get { return miGestion.TasaCambioActual; } }
        public string FechaUltActCosto { get { return miGestion.FechaUltActCosto; } }

        public data Precio_1 { get { return miGestion.Precio_1; } }
        public data Precio_2 { get { return miGestion.Precio_2; } }
        public data Precio_3 { get { return miGestion.Precio_3; } }
        public data Precio_4 { get { return miGestion.Precio_4; } }
        public data Precio_5 { get { return miGestion.Precio_5; } }
        public bool Habilitar_ContenidoEmpaque { get { return miGestion.Habilitar_ContenidoEmpaque; } }
        public bool Habilitar_Empaque { get { return miGestion.Habilitar_Empaque; } }


        public Gestion(IGestion gestion)
        {
            miGestion = gestion;
        }


        public void setFicha(string autoprd)
        {
            miGestion.setFicha(autoprd);
        }

        EditarFrm frm ;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new EditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return miGestion.CargarData();
        }

        public void ModoPrecioSw()
        {
            miGestion.ModoPrecioSw();
        }

        public void Procesar()
        {
            miGestion.Procesar();
        }

    }

}