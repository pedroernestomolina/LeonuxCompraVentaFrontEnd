using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.AgregarEditar
{


    public class Gestion
    {

        private IGestion miGestion;
        private Maestros.Departamentos.Gestion _gestionMaestroDepartamento;
        private Maestros.Grupos.Gestion _gestionMaestroGrupo;
        private Maestros.Marcas.Gestion _gestionMaestroMarca;


        public bool IsAgregarEditarOk { get { return miGestion.IsAgregarEditarOk; } }
        public string AutoProductoAgregado { get { return miGestion.AutoProductoAgregado; } }

        public bool IsCerrarHabilitado { get { return miGestion.IsCerrarHabilitado; } }
        public BindingSource Departamentos { get { return miGestion.Departamentos; } }
        public BindingSource Grupos { get { return miGestion.Grupos; } }
        public BindingSource Marcas { get { return miGestion.Marcas; } }
        public BindingSource Impuesto { get { return miGestion.Impuesto; } }
        public BindingSource Origen { get { return miGestion.Origen; } }
        public BindingSource EmpCompra { get { return miGestion.EmpCompra; } }
        public BindingSource Divisa { get { return miGestion.Divisa; } }
        public BindingSource Categoria { get { return miGestion.Categoria; } }
        public BindingSource Clasificacion { get { return miGestion.Clasificacion; } }

        public string CodigoProducto { get { return miGestion.CodigoProducto; } set { miGestion.CodigoProducto = value; } }
        public string DescripcionProducto { get { return miGestion.DescripcionProducto; } set { miGestion.DescripcionProducto = value; } }
        public string NombreProducto { get { return miGestion.NombreProducto; } set { miGestion.NombreProducto = value; } }
        public string ModeloProducto { get { return miGestion.ModeloProducto; } set { miGestion.ModeloProducto = value; } }
        public string ReferenciaProducto { get { return miGestion.ReferenciaProducto; } set { miGestion.ReferenciaProducto = value; } }
        public int ContEmpProducto { get { return miGestion.ContEmpProducto; } set { miGestion.ContEmpProducto = value; } } 

        public string AutoDepartamento { get { return miGestion.AutoDepartamento; } set { miGestion.AutoDepartamento = value; } }
        public string AutoGrupo { get { return miGestion.AutoGrupo; } set { miGestion.AutoGrupo = value; } }
        public string AutoMarca { get { return miGestion.AutoMarca; } set { miGestion.AutoMarca = value; } } 
        public string AutoImpuesto { get { return miGestion.AutoImpuesto; } set { miGestion.AutoImpuesto= value; } }
        public string IdOrigen { get { return miGestion.IdOrigen; } set { miGestion.IdOrigen = value; } }
        public string IdCategoria { get { return miGestion.IdCategoria; } set { miGestion.IdCategoria = value; } }
        public string IdClasificacionAbc { get { return miGestion.IdClasificacionAbc; } set { miGestion.IdClasificacionAbc = value; } }
        public string IdDivisa { get { return miGestion.IdDivisa; } set { miGestion.IdDivisa = value; } }
        public string AutoEmpCompra { get { return miGestion.AutoEmpCompra; } set { miGestion.AutoEmpCompra = value; } }


        public Gestion(IGestion gestion)
        {
            miGestion = gestion;
            _gestionMaestroDepartamento = new Maestros.Departamentos.Gestion();
            _gestionMaestroGrupo = new Maestros.Grupos.Gestion();
            _gestionMaestroMarca = new Maestros.Marcas.Gestion();
        }


        public void setFicha(string autoPrd)
        {
            miGestion.SetFicha(autoPrd);
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }

        }

        private void Limpiar()
        {
            miGestion.Limpiar();
        }

        private bool CargarData()
        {
            return miGestion.CargarData();
        }

        public void Procesar()
        {
            miGestion.Procesar();
        }

        public void InicializarIsCerrarHabilitado()
        {
            miGestion.InicializarIsCerrarHabilitado();
        }

        public void MaestroDepartamento()
        {
            _gestionMaestroDepartamento.Inicia();
            miGestion.CargaDepartamentos();
        }

        public void MaestroGrupo()
        {
            _gestionMaestroGrupo.Inicia();
            miGestion.CargaGrupos();
        }

        public void MaestroMarca()
        {
            _gestionMaestroMarca.Inicia();
            miGestion.CargaMarcas();
        }

    }

}