﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha> Usuario_Principal();

    }

}