using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Reportes.Filtro
{
    
    public class general
    {

        public string auto { get; set; }
        public string descripcion { get; set; }


        public general()
        {
            limpiar();
        }

        public general(string id, string desc)
            :this()
        {
            setficha(id, desc);
        }

        public void limpiar()
        {
            this.auto = "";
            this.descripcion = "";
        }

        public  void setficha(string id, string desc)
        {
            this.auto = id;
            this.descripcion = desc;
        }

    }

}
