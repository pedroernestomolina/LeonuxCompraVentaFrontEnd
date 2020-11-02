using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Producto.Data
{
    
    public class Ficha
    {

        public Identificacion identidad { get; set; }


        public string AutoId { get { return identidad.auto; } }
        public string CodigoPrd { get { return identidad.codigo; } }
        public string DescripcionPrd { get { return identidad.descripcion; } }
        public string Departamento { get { return identidad.departamento; } }
        public string Grupo { get { return identidad.grupo; } }
        public string Marca { get { return identidad.marca; } }
        public string Referencia { get { return identidad.referencia; } }
        //public string Empaque { get { return identidad.Empaque; } }
        //public string Impuesto { get { return identidad.Impuesto; } }
        public string Origen { get { return identidad.origen ; } }
        public string Estatus { get { return identidad.estatus.ToString(); } }
        public string Divisa { get { return identidad.AdmPorDivisa.ToString(); } }
        public string Producto { get { return CodigoPrd + Environment.NewLine + DescripcionPrd; } }


        public Ficha()
        {
            identidad = new Identificacion();
        }

    }

}