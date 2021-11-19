using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Documentos.Generar.Items
{

    public class data
    {

        private string _codigoPrd;
        private string _descPrd;
        private decimal _cant;
        private decimal _pneto;
        private decimal _dscto1;
        private decimal _dscto2;
        private decimal _dscto3;
        private decimal _dscto;
        private decimal _pimporte;
        private decimal _tasaIva;
        private decimal _mDscto1;
        private decimal _mDscto2;
        private decimal _mDscto3;
        private decimal _mDscto;
        private decimal _mIva;
        private int _id;
        private string _empaque;
        private int _cont;


        public int Id { get { return _id; } }
        public string CodigoPrd { get { return _codigoPrd; } }
        public string DescripcionPrd { get { return _descPrd; } }
        public decimal Cant { get { return _cant; } }
        public decimal PNeto { get {return _pneto;} }
        public decimal Dscto { get {return _mDscto;} }
        public decimal PImporte { get { return _pimporte; } }
        public decimal TasaIva { get { return _tasaIva; } }
        public decimal MIva { get { return _mIva; } }
        public string Empaque { get { return _empaque.Trim() + "/" + _cont.ToString(); } }

        public decimal mTotal 
        {
            get { return _pimporte + MIva; }
        }
        public string TasaIvaDesc 
        {
            get 
            {
                var rt = "Ex";
                if (_tasaIva > 0) rt = _tasaIva.ToString("n2") + "%";
                return rt;
            }
        }


        public data(int id) 
        {
            _mDscto = 0m;
            _mDscto1 = 0m;
            _mDscto1 = 0m;
            _mDscto1 = 0m;
            _pimporte = 0m;
            _mIva = 0m;
            //
            _id = id;
            _codigoPrd = "100200300400";
            _descPrd = "PRODUCTO DE PRUEBA";
            _cant = 5;
            _pneto = 500;
            _dscto1 = 5m;
            _dscto2 = 2m;
            _dscto3 = 0m;
            _tasaIva = 16m;
            _empaque = "BULTO";
            _cont = 12;
            Calcula();
        }

        private void Calcula()
        {
            var m = _pneto*_cant;
            _mDscto1 = m* _dscto1 / 100;
            m -= _mDscto1;
            _mDscto2 = m * _dscto2 / 100;
            m -= _mDscto2;
            _mDscto3 = m * _dscto3 / 100;
            m -= _mDscto3;
            _mDscto = (_pneto * _cant) - m; 
            _pimporte = m;
            _mIva = m * _tasaIva / 100;
        }

    }

}