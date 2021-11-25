using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Documentos.Generar.BuscarProducto.Items
{
    
    public class data
    {

        private string _id;
        private string _codigo;
        private string _descripcion;
        private bool _isActivo;
        private decimal _exActual;
        private decimal _exDisp;
        private decimal _tasaIva;
        private string _empqCont_1;
        private decimal _pneto_1;
        private string _empqCont_2;
        private decimal _pneto_2;


        public string Id { get { return _id; } }
        public string Codigo { get { return _codigo; } }
        public string Descripcion { get { return _descripcion; } }
        public bool IsActivo { get { return _isActivo; } }
        public string Estatus { get { return IsActivo ? "" : "INACTIVO"; } }
        public decimal ExActual { get { return _exActual; } }
        public decimal ExDisponible { get { return _exDisp; } }
        public decimal TasaIva { get { return _tasaIva; } }
        //
        public string EmpqCont_1 { get { return _empqCont_1; } }
        public decimal PNeto_1 { get { return _pneto_1; } }
        public decimal PFull_1 { get { return calculaFull(_pneto_1); } }
        //
        public string EmpqCont_2 { get { return _empqCont_2; } }
        public decimal PNeto_2 { get { return _pneto_2; } }
        public decimal PFull_2 { get { return calculaFull(_pneto_2); } }


        public data() 
        {
            Limpiar();
        }

        public data(OOB.Producto.Lista.Ficha it)
            :this()
        {
            _id = it.Id;
            _codigo = it.Codigo;
            _descripcion = it.Nombre;
            _isActivo = it.IsActivo;
            _exActual = it.ExFisica;
            _exDisp = it.ExDisponible;
            _tasaIva = it.TasaIva;
            _empqCont_1 = it.Empq_1.Trim() + "/" + it.Cont_1.ToString().Trim();
            _pneto_1 = it.PNeto1;
            _empqCont_2 = it.Empq_2.Trim() + "/" + it.Cont_2.ToString().Trim();
            _pneto_2 = it.PNeto2;
        }
       
        public void Limpiar()
        {
            _id = "";
            _codigo = "";
            _descripcion = "";
            _isActivo = true;
            _exActual = 0m;
            _exDisp = 0m;
            _tasaIva = 0m;
            _empqCont_1 = "";
            _pneto_1 = 0m;
            _empqCont_2 = "";
            _pneto_2 = 0m;
        }

        private decimal calculaFull(decimal pn) 
        {
            var rt = pn;
            var iva= pn * (_tasaIva/100);
            rt += iva;
            return rt;
        }

    }

}