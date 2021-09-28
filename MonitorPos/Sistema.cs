using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MonitorPos
{
    
    public class Sistema
    {

        static public IPosOffLine.IProvider MyData;
        public static bool ActivarMonitorCierreResumen =false;
        public static int TiempoMonitorCierreResumen = 0;
        public static string IdEquipo = "";

    }

}