using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Permisos
{
    
    public class permiso
    {

        public int Id { get; set; }
        public int Modulo { get; set; }
        public string Descripcion { get; set; }
        public string ModuloDescripcion { get; set; }
        public bool RequiereClave { get; set; }
        public string CodigoFuncion { get; set; }


        public permiso()
        {
            Limpiar();
        }

        public permiso(OOB.LibVenta.PosOffline.Permiso.Actual.Permiso ficha)
            : this()
        {
            Id = ficha.Id;
            Modulo = ficha.Modulo;
            Descripcion = ficha.Descripcion;
            RequiereClave = ficha.RequiereClave;
            CodigoFuncion = ficha.CodigoFuncion;
            switch (ficha.Modulo) 
            {
                case 1:
                    ModuloDescripcion = "Principal";
                    break;
                case 2:
                    ModuloDescripcion = "POS";
                    break;
                case 3:
                    ModuloDescripcion = "Adm/Documentos";
                    break;
            }
        }


        private void Limpiar()
        {
            Id = -1;
            Modulo = 0;
            Descripcion = "";
            CodigoFuncion = "";
            RequiereClave = false;
            ModuloDescripcion = "";
        }

    }

}
