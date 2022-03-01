using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Configuracion.Modulo
{
    
    public class data
    {

        private string _max;
        private string _med;
        private string _min;
        private decimal _cnt;


        public string ClaveMaxima { get { return _max; } }
        public string ClaveMedia { get { return _med; } }
        public string ClaveMinima { get { return _min; } }
        public decimal CntDocVisualizar { get { return _cnt; } }


        public data() 
        {
            limpiar();
        }

        public void Limpiar()
        {
            limpiar();
        }

        private void limpiar()
        {
            _max = "";
            _med = "";
            _min = "";
            _cnt = 0m;
        }


        public void setClaveMaxima(string p)
        {
            _max = p;
        }
        public void setClaveMedia(string p)
        {
            _med = p;
        }
        public void setClaveMinima(string p)
        {
            _min = p;
        }
        public void setCntDocVisualizar(decimal p)
        {
            _cnt = p;
        }

    }

}