using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Helpers
{

    public class FormatoPreEmpaque
    {

        public int LargoItemCod;
        public int LargoPeso;
        public int LargoPrecio;
        public int LargoControl;
        public bool IsModoPeso;
        public string IdCabecera;


        public int LargoCabecera { get { return IdCabecera.Length; } }
        public int Largo { get { return LargoCabecera + LargoItemCod + LargoPeso + LargoPrecio + LargoControl; } }


        public FormatoPreEmpaque() 
        {
            IdCabecera = "28";
            LargoItemCod = 5;
            LargoPeso = 5;
            LargoPrecio = 0;
            LargoControl = 1;
            IsModoPeso = true;
        }

    }

}