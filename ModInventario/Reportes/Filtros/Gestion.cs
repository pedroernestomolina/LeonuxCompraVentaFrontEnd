using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Reportes.Filtros
{
    
    public class Gestion
    {

        private List<OOB.LibInventario.Departamento.Ficha> lDepart;
        private List<OOB.LibInventario.Deposito.Ficha> lDeposito;
        private List<OOB.LibInventario.Producto.AdmDivisa.Ficha> lAdmDivisa;
        private List<OOB.LibInventario.Sucursal.Ficha > lSucursal;
        private List<OOB.LibInventario.Producto.Categoria.Ficha> lCategoria;
        private List<OOB.LibInventario.Producto.Origen.Ficha> lOrigen;
        private List<OOB.LibInventario.TasaImpuesto.Ficha> lTasa;
        private List<OOB.LibInventario.Producto.Estatus.Lista.Ficha> lEstatus;
        private List<OOB.LibInventario.Marca.Ficha> lMarca;
        private List<OOB.LibInventario.Grupo.Ficha> lGrupo;
        private BindingSource bsDepart;
        private BindingSource bsDeposito;
        private BindingSource bsAdmDivisa;
        private BindingSource bsSucursal;
        private BindingSource bsCategoria;
        private BindingSource bsOrigen;
        private BindingSource bsTasa;
        private BindingSource bsEstatus;
        private BindingSource bsMarca;
        private BindingSource bsGrupo;
        private data dataFiltro;
        private Filtros.IFiltros filtros;


        public BindingSource SourceDepart { get { return bsDepart; } }
        public BindingSource SourceDeposito { get { return bsDeposito; } }
        public BindingSource SourceAdmDivisa { get { return bsAdmDivisa; } }
        public BindingSource SourceSucursal { get { return bsSucursal; } }
        public BindingSource SourceCategoria { get { return bsCategoria; } }
        public BindingSource SourceOrigen { get { return bsOrigen; } }
        public BindingSource SourceTasa { get { return bsTasa; } }
        public BindingSource SourceEstatus { get { return bsEstatus; } }
        public BindingSource SourceMarca { get { return bsMarca; } }
        public BindingSource SourceGrupo { get { return bsGrupo; } }
        public Filtros.IFiltros Filtros { get { return filtros; } }
        public data  DataFiltros { get { return dataFiltro; } }


        public bool LimpiarFiltros_IsOK { get; set; }
        public bool ActivarFiltros_IsOK { get; set; }


        public string AutoGrupo { get { return dataFiltro.AutoGrupo; } set { dataFiltro.AutoGrupo= value; } } 
        public string AutoMarca { get { return dataFiltro.AutoMarca; } set { dataFiltro.AutoMarca= value; } } 
        public string AutoDepartamento { get { return dataFiltro.AutoDepartamento; } set { dataFiltro.AutoDepartamento = value; } }
        public string AutoDeposito { get { return dataFiltro.AutoDeposito; } set { dataFiltro.AutoDeposito = value; setNombreDeposito(); } }
        public string AutoTasa { get { return dataFiltro.AutoTasa; } set { dataFiltro.AutoTasa = value; } }
        public string IdAdmDivisa { get { return dataFiltro.IdAdmDivisa; } set { dataFiltro.IdAdmDivisa = value; } }
        public string IdEstatus { get { return dataFiltro.IdEstatus; } set { dataFiltro.IdEstatus= value; } }
        public string IdOrigen  { get { return dataFiltro.IdOrigen; } set { dataFiltro.IdOrigen= value; } }
        public string IdCategoria { get { return dataFiltro.IdCategoria; } set { dataFiltro.IdCategoria = value; } } 
        public string CodigoSucursal { get { return dataFiltro.CodigoSucursal; } set { dataFiltro.CodigoSucursal= value; } }
        public DateTime Desde { get { return dataFiltro.Desde; } set { dataFiltro.Desde= value; } } 
        public DateTime Hasta { get { return dataFiltro.Hasta; } set { dataFiltro.Hasta= value; } } 


        public Gestion()
        {
            dataFiltro = new data();

            lDepart = new List<OOB.LibInventario.Departamento.Ficha>();
            bsDepart = new BindingSource();
            bsDepart.DataSource = lDepart;

            lDeposito = new List<OOB.LibInventario.Deposito.Ficha>();
            bsDeposito = new BindingSource();
            bsDeposito.DataSource = lDeposito;

            lAdmDivisa = new List<OOB.LibInventario.Producto.AdmDivisa.Ficha>();
            bsAdmDivisa = new BindingSource();
            bsAdmDivisa.DataSource = lAdmDivisa;

            lSucursal= new List<OOB.LibInventario.Sucursal.Ficha>();
            bsSucursal = new BindingSource();
            bsSucursal .DataSource = lSucursal;

            lCategoria = new List<OOB.LibInventario.Producto.Categoria.Ficha>();
            bsCategoria = new BindingSource();
            bsCategoria.DataSource = lCategoria;

            lOrigen = new List<OOB.LibInventario.Producto.Origen.Ficha>();
            bsOrigen = new BindingSource();
            bsOrigen.DataSource = lOrigen;

            lTasa = new List<OOB.LibInventario.TasaImpuesto.Ficha>();
            bsTasa = new BindingSource();
            bsTasa.DataSource = lTasa;

            lEstatus = new List<OOB.LibInventario.Producto.Estatus.Lista.Ficha>();
            bsEstatus = new BindingSource();
            bsEstatus.DataSource = lEstatus;

            lMarca= new List<OOB.LibInventario.Marca.Ficha>();
            bsMarca= new BindingSource();
            bsMarca.DataSource = lMarca;

            lGrupo= new List<OOB.LibInventario.Grupo.Ficha>();
            bsGrupo= new BindingSource();
            bsGrupo.DataSource = lGrupo;
        }


        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new FiltrosFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            dataFiltro.Limpiar();
            ActivarFiltros_IsOK = false;
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Departamento_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            lDepart.Clear();
            lDepart.AddRange(r01.Lista.OrderBy(o => o.nombre));

            var r02 = Sistema.MyData.Deposito_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            lDeposito.Clear();
            lDeposito.AddRange(r02.Lista.OrderBy(o => o.nombre));

            var r03 = Sistema.MyData.Producto_AdmDivisa_Lista();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            lAdmDivisa.Clear();
            lAdmDivisa.AddRange(r03.Lista.OrderBy(o => o.Descripcion));

            var r04 = Sistema.MyData.Sucursal_GetLista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            lSucursal.Clear();
            lSucursal.AddRange(r04.Lista.OrderBy(o => o.nombre));

            var r05 = Sistema.MyData.Producto_Categoria_Lista();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            lCategoria.Clear();
            lCategoria.AddRange(r05.Lista.OrderBy(o => o.Descripcion));

            var r06 = Sistema.MyData.Producto_Origen_Lista();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            lOrigen.Clear();
            lOrigen.AddRange(r06.Lista.OrderBy(o => o.Descripcion));

            var r07 = Sistema.MyData.TasaImpuesto_GetLista();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            lTasa.Clear();
            lTasa.AddRange(r07.Lista.OrderBy(o => o.tasa));

            var r08 = Sistema.MyData.Grupo_GetLista ();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return false;
            }
            lGrupo.Clear();
            lGrupo.AddRange(r08.Lista.OrderBy(o => o.nombre));

            var r09 = Sistema.MyData.Marca_GetLista();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            lMarca.Clear();
            lMarca.AddRange(r09.Lista.OrderBy(o => o.nombre));

            lEstatus.Clear();
            lEstatus.Add(new OOB.LibInventario.Producto.Estatus.Lista.Ficha() { Id = "1", Descripcion = "Activo" });
            lEstatus.Add(new OOB.LibInventario.Producto.Estatus.Lista.Ficha() { Id = "3", Descripcion = "Inactivo" });

            return rt;
        }

        public void LimpiarFiltros()
        {
            LimpiarFiltros_IsOK = false;
            var msg = MessageBox.Show("Limpiar Filtros ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                dataFiltro.Limpiar();
                LimpiarFiltros_IsOK = true;
            }
        }

        public void setGestion(IFiltros filtros)
        {
            this.filtros = filtros;
        }

        public void ActivarFiltros()
        {
            ActivarFiltros_IsOK = true;
        }

        private void setNombreDeposito()
        {
            var dp =lDeposito.FirstOrDefault(f=>f.auto==dataFiltro.AutoDeposito);
            if (dp != null)
                dataFiltro.NombreDeposito = dp.nombre;
        }

        private void setNombreDepartamento ()
        {
            var dp = lDepart.FirstOrDefault(f => f.auto == dataFiltro.AutoDepartamento);
            if (dp != null)
                dataFiltro.NombreDepartamento = dp.nombre;
        }

    }

}