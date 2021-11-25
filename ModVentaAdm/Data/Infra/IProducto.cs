﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface IProducto
    {
        
        OOB.Resultado.Lista<OOB.Producto.Lista.Ficha> Producto_GetLista(OOB.Producto.Lista.Filtro filtro);
        OOB.Resultado.FichaEntidad<OOB.Producto.Entidad.Ficha> Producto_GetFichaById(string id);

    }

}