﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPos.Facturacion.Pago.ValidarCambio
{

    public class Gestion
    {


        private decimal _montoValidar;
        private decimal _montoCapturado;


        public bool ValidarIsOk { get { return (_montoValidar-_montoCapturado)==0.0m; } }


        public Gestion() 
        {
        }


        public void Inicializa()
        {
            _montoValidar = 0.0m;
            _montoCapturado = 0.0m;
        }

        public void setMontoValidar(decimal monto)
        {
            _montoValidar = monto;
        }

        ValidarCambioFrm _frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (_frm==null)
                {
                    _frm=new ValidarCambioFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void setMontoCapturado(decimal monto)
        {
            _montoCapturado = monto;
        }

    }

}