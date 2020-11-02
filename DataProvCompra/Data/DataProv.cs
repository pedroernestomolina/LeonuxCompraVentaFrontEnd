using DataProvCompra.InfraEstructura;
using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    
    public partial class DataProv: IData
    {

        public static IService MyData;


        public DataProv(string instancia, string bd)
        {
            MyData = new ServiceCompra.MyService.Service(instancia, bd);
        }

    }

}