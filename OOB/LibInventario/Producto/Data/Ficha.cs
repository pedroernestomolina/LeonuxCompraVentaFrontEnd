using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Ficha
    {

        public Identificacion identidad { get; set; }
        public Precio precio { get; set; }
        public Costo costo { get; set; }
        public Existencia existencia { get; set; }
        public Extra extra { get; set; }


        public string CodigoPrd { get { return identidad.codigo; } }
        public string DescripcionPrd { get { return identidad.descripcion; } }
        public string Departamento { get { return identidad.departamento; } }
        public string Grupo { get { return identidad.grupo; } }
        public string Producto { get { return CodigoPrd + Environment.NewLine + DescripcionPrd; } }


        public Ficha()
        {
            identidad = new Identificacion();
            precio = new Precio();
            costo = new Costo();
            existencia = new Existencia();
            extra = new Extra();
        }


    }

}
