﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Administrador
{
    
    public interface IGestionListaDetalle
    {

        BindingSource Source { get; }
        string Items { get; }


        void setLista(List<OOB.LibInventario.Movimiento.Lista.Ficha> list);
        void AnularItem();
        void LimpiarData();

    }

}