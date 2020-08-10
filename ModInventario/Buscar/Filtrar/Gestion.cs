using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Buscar.Filtrar
{

    public class Gestion
    {

        private List<OOB.LibInventario.Departamento.Ficha> lDepart;
        private List<OOB.LibInventario.Grupo.Ficha> lGrupo;
        private List<OOB.LibInventario.Marca.Ficha> lMarca;
        private List<OOB.LibInventario.Deposito.Ficha> lDeposito;
        private List<OOB.LibInventario.Producto.Categoria.Ficha> lCategoria;
        private List<OOB.LibInventario.Producto.Origen.Ficha> lOrigen;
        private List<OOB.LibInventario.TasaImpuesto.Ficha> lTasa;
        private List<OOB.LibInventario.Producto.Estatus.Ficha> lEstatus;
        private List<OOB.LibInventario.Producto.AdmDivisa.Ficha> lAdmDivisa;
        private List<OOB.LibInventario.Producto.Pesado.Ficha> lPesado;
        private List<OOB.LibInventario.Producto.Oferta.Ficha> lOferta;
        private BindingSource bsDepart;
        private BindingSource bsGrupo ;
        private BindingSource bsMarca;
        private BindingSource bsDeposito;
        private BindingSource bsCategoria;
        private BindingSource bsOrigen ;
        private BindingSource bsTasa ;
        private BindingSource bsEstatus;
        private BindingSource bsAdmDivisa;
        private BindingSource bsPesado;
        private BindingSource bsOferta;


        public BindingSource SourceDepart { get { return bsDepart; } }
        public BindingSource SourceGrupo { get { return bsGrupo; } }
        public BindingSource SourceMarca{ get { return bsMarca; } }
        public BindingSource SourceDeposito { get { return bsDeposito; } }
        public BindingSource SourceCategoria { get { return bsCategoria; } }
        public BindingSource SourceOrigen { get { return bsOrigen; } }
        public BindingSource SourceTasa { get { return bsTasa ; } }
        public BindingSource SourceEstatus{ get { return bsEstatus; } }
        public BindingSource SourceAdmDivisa { get { return bsAdmDivisa; } }
        public BindingSource SourcePesado { get { return bsPesado; } }
        public BindingSource SourceOferta { get { return bsOferta; } }

        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoMarca { get; set; }
        public string AutoDeposito { get; set; }
        public string AutoTasa { get; set; }
        public string IdCategoria { get; set; }
        public string IdOrigen { get; set; }
        public string IdEstatus { get; set; }
        public string IdAdmDivisa{ get; set; }
        public string IdPesado { get; set; }
        public string IdOferta { get; set; }

        public bool IsFiltrarOk { get; set; }
        public bool IsLimpiarOK { get; set; }


        public Gestion()
        {
            LimpiarEntradas();

            lDepart = new List<OOB.LibInventario.Departamento.Ficha>();
            bsDepart = new BindingSource();
            bsDepart.DataSource = lDepart;

            lGrupo= new List<OOB.LibInventario.Grupo.Ficha>();
            bsGrupo = new BindingSource();
            bsGrupo.DataSource = lGrupo;

            lMarca = new List<OOB.LibInventario.Marca.Ficha>();
            bsMarca = new BindingSource();
            bsMarca.DataSource = lMarca;

            lDeposito = new List<OOB.LibInventario.Deposito.Ficha>();
            bsDeposito = new BindingSource();
            bsDeposito.DataSource = lDeposito;

            lCategoria = new List<OOB.LibInventario.Producto.Categoria.Ficha>();
            bsCategoria = new BindingSource();
            bsCategoria .DataSource = lCategoria;

            lOrigen= new List<OOB.LibInventario.Producto.Origen.Ficha>();
            bsOrigen = new BindingSource();
            bsOrigen.DataSource = lOrigen;

            lTasa= new List<OOB.LibInventario.TasaImpuesto.Ficha>();
            bsTasa= new BindingSource();
            bsTasa.DataSource = lTasa;

            lEstatus = new List<OOB.LibInventario.Producto.Estatus.Ficha>();
            bsEstatus= new BindingSource();
            bsEstatus.DataSource = lEstatus;

            lAdmDivisa = new List<OOB.LibInventario.Producto.AdmDivisa.Ficha>();
            bsAdmDivisa = new BindingSource();
            bsAdmDivisa.DataSource = lAdmDivisa;

            lPesado = new List<OOB.LibInventario.Producto.Pesado.Ficha>();
            bsPesado = new BindingSource();
            bsPesado.DataSource = lPesado;

            lOferta = new List<OOB.LibInventario.Producto.Oferta.Ficha>();
            bsOferta = new BindingSource();
            bsOferta.DataSource = lOferta;
        }

        private void LimpiarEntradas()
        {
            AutoDepartamento = "";
            AutoGrupo = "";
            AutoTasa = "";
            AutoMarca = "";
            AutoDeposito = "";
            IdCategoria = "";
            IdOrigen = "";
            IdEstatus = "";
            IdAdmDivisa = "";
            IdPesado = "";
            IdOferta = "";
            IsFiltrarOk=false;
        }


        public void Inicia()
        {
            LimpiarEntradas();
            if (CargarData()) 
            {
                var frm = new FiltrosFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
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

            var r02 = Sistema.MyData.Grupo_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            lGrupo.Clear();
            lGrupo.AddRange(r02.Lista.OrderBy(o => o.nombre));

            var r03 = Sistema.MyData.Producto_Categoria_Lista();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            lCategoria.Clear();
            lCategoria.AddRange(r03.Lista.OrderBy(o => o.Descripcion));

            var r04 = Sistema.MyData.Producto_Origen_Lista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            lOrigen.Clear();
            lOrigen.AddRange(r04.Lista.OrderBy(o => o.Descripcion));

            var r05 = Sistema.MyData.TasaImpuesto_GetLista();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            lTasa.Clear();
            lTasa.AddRange(r05.Lista.OrderBy(o => o.tasa));

            var r06 = Sistema.MyData.Marca_GetLista ();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            lMarca.Clear();
            lMarca.AddRange(r06.Lista.OrderBy(o => o.nombre));

            var r07 = Sistema.MyData.Deposito_GetLista();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            lDeposito.Clear();
            lDeposito.AddRange(r07.Lista.OrderBy(o => o.nombre));

            var r08 = Sistema.MyData.Producto_Estatus_Lista ();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return false;
            }
            lEstatus.Clear();
            lEstatus.AddRange(r08.Lista.OrderBy(o => o.Descripcion));

            var r09 = Sistema.MyData.Producto_AdmDivisa_Lista ();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            lAdmDivisa.Clear();
            lAdmDivisa.AddRange(r09.Lista.OrderBy(o => o.Descripcion));

            var r0A = Sistema.MyData.Producto_Pesado_Lista ();
            if (r0A.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0A.Mensaje);
                return false;
            }
            lPesado.Clear();
            lPesado.AddRange(r0A.Lista.OrderBy(o => o.Descripcion));

            var r0B = Sistema.MyData.Producto_Oferta_Lista ();
            if (r0B.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0B.Mensaje);
                return false;
            }
            lOferta.Clear();
            lOferta.AddRange(r0B.Lista.OrderBy(o => o.Descripcion));


            return rt;
        }

        public void Filtrar()
        {
            if (AutoDepartamento != "") 
            {
                IsFiltrarOk = true;
                return;
            }
            if (AutoGrupo != "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (AutoTasa != "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (AutoMarca!= "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (AutoDeposito != "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (IdCategoria != "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (IdOrigen != "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (IdEstatus!= "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (IdAdmDivisa!= "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (IdPesado!= "")
            {
                IsFiltrarOk = true;
                return;
            }
            if (IdOferta != "")
            {
                IsFiltrarOk = true;
                return;
            }
        }

        public void LimpiarSelecciones()
        {
            IsLimpiarOK = false;
            var msg = MessageBox.Show("Limpiar Selecciones ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                IsLimpiarOK = true;
            }
        }

        public void Limpiar()
        {
            LimpiarEntradas();
        }

        public void setFiltroEstatusActivo() 
        {
            IdEstatus = "1";
            IsFiltrarOk = true;
        }

    }

}