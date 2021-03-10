using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Configuracion.MetodoCalculoUtilidad
{
    
    public class Gestion
    {

        private bool _isOk;
        private BindingSource _bs;
        private List<data> _ldata;
        private data _metCalculoUt;


        public bool IsOk { get { return _isOk; } }
        public data MetCalculoUt { get { return _metCalculoUt; } }
        public BindingSource Source { get { return _bs; } }


        public Gestion()
        {
            _isOk = false;
            _metCalculoUt= null;
            _ldata = new List<data>();
            _bs=new BindingSource();
            _bs.DataSource = _ldata;
        }


        public void Inicializa()
        {
            _isOk = false;
        }

        ConfigurarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ConfigurarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _ldata.Clear();
            _ldata.Add(new data("1", "Lineal"));
            _ldata.Add(new data("2", "Financiero"));
            
            switch (r01.Entidad.ToString().ToUpper()) 
            {
                case "LINEAL":
                    _metCalculoUt = _ldata.FirstOrDefault(f => f.auto == "1");
                    break;
                case "FINANCIERO":
                    _metCalculoUt= _ldata.FirstOrDefault(f => f.auto == "2");
                    break;
            }

            return rt;
        }

        public void Proesar()
        {
            _isOk = false;
            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var fichaOOB = new OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Ficha()
                {
                    Metodo = _metCalculoUt.descripcion,
                };
                var r01 = Sistema.MyData.Configuracion_SetMetodoCalculoUtilidad(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _isOk = true;
                Helpers.Msg.EditarOk();
            }

        }

        public void setMetCalculoUt (string p)
        {
            _metCalculoUt = _ldata.FirstOrDefault(f => f.auto == p);
        }

    }

}