using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public class data
    {

        public string IdSucursal { get; set; }
        public string IdConcepto { get; set; }
        public string IdDepOrigen { get; set; }
        public string IdDepDestino { get; set; }
        public string AutorizadoPor { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public dataDetalle detalle { get; set; }


        public data() 
        {
            Limpiar();
        }


        public void Limpiar()
        {
            IdSucursal = "";
            IdConcepto = "";
            IdDepDestino = "";
            IdDepOrigen = "";
            AutorizadoPor = "";
            Motivo = "";
            Fecha = DateTime.Now.Date;
        }

        public bool Verificar()
        {
            var rt = true;

            if (AutorizadoPor.Trim() == "") 
            {
                Helpers.Msg.Error("Campo [ Autorizado ] Falta Por LLenar");
                return false;
            }

            if (Motivo.Trim() == "")
            {
                Helpers.Msg.Error("Campo [ Motivo ] Falta Por LLenar");
                return false;
            }

            if (IdSucursal == "") 
            {
                Helpers.Msg.Error("[ Sucursal ] No Seleccionada");
                return false;
            }

            if (IdConcepto == "")
            {
                Helpers.Msg.Error("[ Concepto ] No Seleccionada");
                return false;
            }

            if (IdDepOrigen == "")
            {
                Helpers.Msg.Error("[ Depósito Origen ] No Seleccionada");
                return false;
            }

            if (detalle.ListaItems.Count == 0) 
            {
                Helpers.Msg.Error("No Hay Items En El Documento ");
                return false;
            }

            return rt;
        }

    }

}