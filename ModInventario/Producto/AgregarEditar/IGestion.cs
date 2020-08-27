using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.AgregarEditar
{
    
    public interface IGestion
    {


        bool IsCerrarHabilitado { get; }
        System.Windows.Forms.BindingSource Departamentos { get; }
        System.Windows.Forms.BindingSource Grupos { get; }
        System.Windows.Forms.BindingSource Marcas { get; }
        System.Windows.Forms.BindingSource Impuesto { get; }
        System.Windows.Forms.BindingSource Origen { get; }
        System.Windows.Forms.BindingSource EmpCompra { get; }
        System.Windows.Forms.BindingSource Divisa { get; }
        System.Windows.Forms.BindingSource Categoria { get; }
        System.Windows.Forms.BindingSource Clasificacion { get; }

        string CodigoProducto { get; set; }
        string DescripcionProducto { get; set; }
        string NombreProducto { get; set; }
        string ModeloProducto { get; set; }
        string ReferenciaProducto { get; set; }
        int ContEmpProducto { get; set; }
        string AutoDepartamento { get; set; }
        string AutoGrupo { get; set; }
        string AutoMarca { get; set; }
        string AutoImpuesto { get; set; }
        string AutoEmpCompra { get; set; }
        string IdOrigen { get; set; }
        string IdCategoria { get; set; }
        string IdClasificacionAbc { get; set; }
        string IdDivisa { get; set; }

        void SetFicha(string autoPrd);
        void Limpiar();
        bool CargarData();
        void Procesar();
        void InicializarIsCerrarHabilitado();


        bool IsAgregarEditarOk { get; }

        string AutoProductoAgregado { get; }

    }

}