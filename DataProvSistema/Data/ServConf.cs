using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.Resultado Inicializar_BD(OOB.LibSistema.Configuracion.Inicializar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Configuracion.InicializarBD.Ficha()
            {
                CodSucursal = ficha.CodSucursal,
                IdEquipo = ficha.IdEquipo,
            };

            var r01 = MyData.Inicializar_BD(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}
