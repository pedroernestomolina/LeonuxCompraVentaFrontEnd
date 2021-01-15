using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Deposito.Asignar
{
    
    public class data
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public bool asignado { get; set; }
        public bool asignar { get; set; }
        public bool remover { get; set; }


        public data(OOB.LibInventario.Deposito.Ficha it)
        {
            auto = it.auto;
            codigo = it.codigo;
            nombre = it.nombre;
            asignado = false;
            asignar = false;
            remover = false;
        }

        public void setAsignado()
        {
            asignado = true;
            asignar = true;
        }

    }

}