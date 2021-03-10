﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.ArticulosCompra
{
    
    public class Filtro
    {

        private DateTime _desde;
        private DateTime _hasta;
        private string _autoProv;


        public DateTime desde { get { return _desde; } }
        public DateTime hasta { get { return _hasta; } }
        public string autoProveedor { get { return _autoProv; } }
        

        public Filtro()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _autoProv = "";
        }

        public void setDesde(DateTime fecha)
        {
            _desde = fecha;
        }

        public void setHasta(DateTime fecha)
        {
            _hasta = fecha;
        }

        public void setProveedor(string idPrv)
        {
            _autoProv = idPrv;
        }

        public bool IsOk()
        {
            var rt = true;

            if (_desde > _hasta) 
            {
                Helpers.Msg.Error("FECHA INCORRECTAS, VERIFIQUE POR FAVOR");
                return false;
            }
            if (_autoProv=="")
            {
                Helpers.Msg.Error("PROVEEDOR INCORRECTO, VERIFIQUE POR FAVOR");
                return false;
            }

            return rt;
        }

    }

}