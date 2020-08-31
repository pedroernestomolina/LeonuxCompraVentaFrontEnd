using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{

    public interface IServConf
    {

        OOB.Resultado Inicializar_BD(OOB.LibSistema.Configuracion.Inicializar.Ficha ficha);

    }

}