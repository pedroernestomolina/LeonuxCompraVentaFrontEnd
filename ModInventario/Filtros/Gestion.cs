﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Filtros
{
    
    public class Gestion
    {

        private IFiltros filtros;
        private List<OOB.LibInventario.Deposito.Ficha> lDepOrigen;
        private List<OOB.LibInventario.Deposito.Ficha> lDepDestino;
        private List<OOB.LibInventario.Concepto.Ficha> lConcepto;
        private List<Estatus> lEstatus;
        private BindingSource bsDepOrigen;
        private BindingSource bsDepDestino ;
        private BindingSource bsEstatus;
        private BindingSource bsConcepto;
        private data dataFiltro;


        public bool ActivarDepOrigen { get { return filtros.ActivarDepOrigen; } }
        public bool ActivarDepDestino { get { return filtros.ActivarDepDestino; } }
        public bool ActivarEstatus { get { return filtros.ActivarEstatus; } }
        public BindingSource SourceDepOrigen { get { return bsDepOrigen; } }
        public BindingSource SourceDepDestino { get { return bsDepDestino; } }
        public BindingSource SourceEstatus { get { return bsEstatus; } }
        public BindingSource SourceConcepto { get { return bsConcepto; } }
        public data DataFiltrar { get { return dataFiltro; } }
        public bool FiltrosIsOk { get; set; }


        public Gestion()
        {
            dataFiltro = new data();
            lDepOrigen = new List<OOB.LibInventario.Deposito.Ficha>();
            lDepDestino= new List<OOB.LibInventario.Deposito.Ficha>();
            lConcepto = new List<OOB.LibInventario.Concepto.Ficha>();
            lEstatus = new List<Estatus>();
            bsDepOrigen = new BindingSource();
            bsDepDestino = new BindingSource();
            bsEstatus = new BindingSource();
            bsConcepto = new BindingSource();
            bsDepOrigen.DataSource = lDepOrigen;
            bsDepDestino.DataSource =lDepDestino ;
            bsEstatus.DataSource = lEstatus;
            bsConcepto.DataSource = lConcepto;
            FiltrosIsOk = false;
        }


        public void Inicia() 
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new FiltroFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var xr1 = Sistema.MyData.Deposito_GetLista();
            if (xr1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return false;
            }

            var xr2 = Sistema.MyData.Concepto_GetLista();
            if (xr2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr2.Mensaje);
                return false;
            }

            lConcepto.Clear();
            lDepOrigen.Clear();
            lDepDestino.Clear();
            lEstatus.Clear();
            foreach (var it in xr1.Lista.OrderBy(o=>o.nombre).ToList())
            {
                lDepOrigen.Add(new OOB.LibInventario.Deposito.Ficha(it));
                lDepDestino.Add(new OOB.LibInventario.Deposito.Ficha(it));
            }
            lEstatus.Add(new Estatus("01", "ACTIVO"));
            lEstatus.Add(new Estatus("02", "ANULADO"));
            foreach (var it in xr2.Lista.OrderBy(o => o.nombre).ToList())
            {
                lConcepto.Add(new OOB.LibInventario.Concepto.Ficha(it));
            }

            return rt;
        }

        private void Limpiar()
        {
            FiltrosIsOk = false;
            dataFiltro.Limpiar();
        }

        public void setGestion(IFiltros filtros)
        {
            this.filtros = filtros;
        }

        public void setDepOrigen(string autoId)
        {
            dataFiltro.depOrigen = lDepOrigen.FirstOrDefault(f => f.auto == autoId);
        }

        public void setDepDestino(string autoId)
        {
            dataFiltro.depDestino = lDepDestino.FirstOrDefault(f => f.auto == autoId);
        }

        public void setEstatus(string autoId)
        {
            dataFiltro.estatus = lEstatus.FirstOrDefault(f => f.Id == autoId);
        }

        public void Filtrar()
        {
            FiltrosIsOk = true;
        }

        public void LimpiarFiltros()
        {
            Limpiar();
        }

        public void setConcepto(string autoId)
        {
            dataFiltro.concepto = lConcepto.FirstOrDefault(f => f.auto == autoId);
        }

    }

}