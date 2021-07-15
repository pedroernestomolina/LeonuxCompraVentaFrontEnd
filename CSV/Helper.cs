using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSV
{

    public class Helper
    {

        public Resultado ExportarData(List<data> list,string path) 
        {
            var result = new Resultado();
            try
            {
                var pathfile = path + @"\clientes.csv";
                using (var writer = new StreamWriter(pathfile))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(list);
                }
            }
            catch (Exception e)
            {
                result.isError = true;
                result.mensaje = e.Message;
            }
            return result;
        }

    }

}