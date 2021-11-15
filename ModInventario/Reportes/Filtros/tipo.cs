using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ModInventario.Reportes.Filtros
{
    
    public class tipo
    {

        private string _id;
        private string _codigo;
        private string _desc;


        public string Id { get { return _id; } }
        public string Codigo { get { return _codigo; } }
        public string Descripcion { get { return _desc; } }
        public string Filtro 
        { 
            get 
            { 
                var x="";
                if (_id !="")
                    x+=_desc.Trim()+"("+_codigo.Trim()+")";
                return x;
            }
        }


        public tipo() 
        {
            limpiar();
        }

        public tipo(string _id, string _cod, string _desc)
            : this()
        {
            this._id = _id;
            this._codigo = _cod;
            this._desc= _desc;
        }


        private void limpiar()
        {
            _id = "";
            _codigo = "";
            _desc= "";
        }

        public void Limpiar()
        {
            limpiar();
        }

    }

}