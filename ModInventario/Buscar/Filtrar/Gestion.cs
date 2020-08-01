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
        private List<OOB.LibInventario.Producto.Categoria.Ficha> lCategoria;
        private List<OOB.LibInventario.Producto.Origen.Ficha> lOrigen;
        private List<OOB.LibInventario.TasaImpuesto.Ficha> lTasa;
        private BindingSource bsDepart;
        private BindingSource bsGrupo ;
        private BindingSource bsCategoria ;
        private BindingSource bsOrigen ;
        private BindingSource bsTasa ;


        public BindingSource SourceDepart { get { return bsDepart; } }
        public BindingSource SourceGrupo { get { return bsGrupo; } }
        public BindingSource SourceCategoria { get { return bsCategoria; } }
        public BindingSource SourceOrigen { get { return bsOrigen; } }
        public BindingSource SourceTasa { get { return bsTasa ; } }
        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoTasa { get; set; }
        public string IdCategoria { get; set; }
        public string IdOrigen { get; set; }
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

            lCategoria = new List<OOB.LibInventario.Producto.Categoria.Ficha>();
            bsCategoria = new BindingSource();
            bsCategoria .DataSource = lCategoria;

            lOrigen= new List<OOB.LibInventario.Producto.Origen.Ficha>();
            bsOrigen = new BindingSource();
            bsOrigen.DataSource = lOrigen;

            lTasa= new List<OOB.LibInventario.TasaImpuesto.Ficha>();
            bsTasa= new BindingSource();
            bsTasa.DataSource = lTasa;
        }

        private void LimpiarEntradas()
        {
            AutoDepartamento = "";
            AutoGrupo = "";
            AutoTasa = "";
            IdCategoria = "";
            IdOrigen = "";
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

    }

}
