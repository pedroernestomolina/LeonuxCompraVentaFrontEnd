using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.ExportarData.Cliente
{
    
    public class Gestion: IExportar
    {

        private List<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha> _list;


        public Gestion()
        {
            _list = new List<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha>();
        }


        public void Inicializa()
        {
            _list.Clear();
        }

        public void setLista(List<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha> list)
        {
            _list = list;
        }

        public void Inicia()
        {
            var data = new List<CSV.data>();
            foreach (var it in _list) 
            {
                var rg = new CSV.data()
                {
                    ciRif = it.CiRif,
                    direccion = it.DirFiscal,
                    nombre = it.NombreRazonSocial,
                    telefono = it.Telefono,
                };
                data.Add(rg);
            }

            var expor = new CSV.Helper();
            var path=@"C:\POS\DATA";
            var result= expor.ExportarData(data, path);
            if (result.isError) 
            {
                Helpers.Msg.Error(result.mensaje);
                return;
            }
            Helpers.Msg.OK("!!! PROCESO REALIZADO EXITOSAMENTE !!!");
        }

    }

}