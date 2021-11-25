using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Documentos.Generar.AgregarEditarItem
{
    
    public class Gestion
    {

        private string _modoFicha;


        public string ModoFicha { get { return _modoFicha; } }
        private OOB.Producto.Entidad.Ficha _prd;


        public Gestion() 
        {
            _modoFicha = "";
            _prd = null;
        }


        public void Inicializa() 
        {
            _modoFicha = "";
            _prd = null;
        }

        AgregarEditarItemFrm _frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (_frm == null) 
                {
                    _frm = new AgregarEditarItemFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setAgregar(OOB.Producto.Entidad.Ficha ficha)
        {
            _modoFicha = "Agregar Item";
            _prd = ficha;
        }

    }

}