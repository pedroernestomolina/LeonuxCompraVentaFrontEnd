﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IData: ISucursal, IDeposito, IUsuario, IProveedor, IProducto, IEmpresa, 
        IPermiso, IConfiguracion, IDocumento, IConcepto
    {

        OOB.ResultadoEntidad<DateTime> FechaServidor();

    }

}