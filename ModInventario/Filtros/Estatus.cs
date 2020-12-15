using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Filtros
{
    
    public class Estatus
    {

        public string Id { get; set; }
        public string Descripcion { get; set; }


        public Estatus(string id, string desc )
        {
            this.Id = id;
            this.Descripcion = desc;
        }

    }

}