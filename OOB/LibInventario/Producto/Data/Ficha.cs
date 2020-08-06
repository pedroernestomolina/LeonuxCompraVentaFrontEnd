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
        public string Marca { get { return identidad.marca; } }
        public string Referencia { get { return identidad.referencia; } }
        public string Empaque { get { return identidad.Empaque ; } }
        public string Impuesto { get { return identidad.Impuesto; } }
        public string Categoria { get { return identidad.categoria.ToString() ; } }
        public string Origen { get { return identidad.origen.ToString(); ; } }
        public string Estatus { get { return identidad.estatus.ToString(); } }
        public string EstatusOferta { get { return precio.estatusOferta.ToString(); } }
        public string Divisa { get { return identidad.AdmPorDivisa.ToString(); } }
        public string Pesado { get { return  extra.esPesado.ToString(); } }
        public DateTime FechaAlta { get { return identidad.fechaAlta ; } }
        public string FechaUltimaActualizacion { get { return identidad.fechaUltActualizacion.HasValue ? identidad.fechaUltActualizacion.Value.ToShortDateString() : ""; } }
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
