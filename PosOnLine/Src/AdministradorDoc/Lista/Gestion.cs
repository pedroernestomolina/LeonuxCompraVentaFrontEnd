using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Lista
{
    
    public class Gestion
    {


        private List<data> _l;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private data _docAplicarNotaCredito;
        private data _docAplicaParaAnulacion;

        public string TotItems { get { return _bs.Count.ToString().Trim(); } }
        public data DocAplicarNotaCredito { get { return _docAplicarNotaCredito; } }
        public data DocAplicaParaAulacion { get { return _docAplicaParaAnulacion; } }
        public BindingSource Source { get { return _bs; } }


        public Gestion()
        {
            _docAplicarNotaCredito = null;
            _docAplicaParaAnulacion = null;
            _l= new List<data>();
            _bl = new BindingList<data>(_l);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa() 
        {
            _docAplicarNotaCredito = null;
            _docAplicaParaAnulacion = null;
        }

        public void BajarItem()
        {
            _bs.Position += 1;
        }

        public void SubirItem()
        {
            _bs.Position -= 1;
        }

        public void setData(List<OOB.Documento.Lista.Ficha> list)
        {
            _bl.Clear();
            foreach (var it in list.OrderByDescending(o=>o.Id).ToList()) 
            {
                _bl.Add(new data(it));
            }
        }

        public bool AplicaParaNotaCredito()
        {
            var rt = false;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                if (it.DocCodigo == "01") 
                {
                    if (!it.IsAnulado) 
                    {
                        _docAplicarNotaCredito = it;
                        return true;
                    }
                }
            }

            return rt;
        }

        public bool AplicaParaAnular()
        {
            var rt = false;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                if (!it.IsAnulado)
                {
                    _docAplicaParaAnulacion = it;
                    return true;
                }
                else 
                {
                    Helpers.Msg.Error("Documento Se Encuentra Ya Anulado");
                    return false;
                }
            }

            return rt;
        }

        public void setAnularDoc()
        {
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                it.setAnularDoc();
            }
            _bs.CurrencyManager.Refresh();
        }

    }

}