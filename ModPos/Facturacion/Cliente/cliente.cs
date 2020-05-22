using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion.Cliente
{

    public class Ficha
    {

        public int Id { get; set; }
        public string CiRif { get; set; }
        public string NombreRazaonSocial { get; set; }
        public string DirFiscal { get; set; }
        public string Telefono { get; set; }

        public string Data 
        {
            get 
            {
                var rt = "";
                rt = CiRif + Environment.NewLine + NombreRazaonSocial;
                return rt;
            }
        }


        public Ficha()
        {
            Limpiar();
        }


        public void setEntidad(OOB.LibVenta.PosOffline.Cliente.Ficha ent)
        {
            this.Id = ent.Id;
            this.CiRif = ent.CiRif;
            this.NombreRazaonSocial = ent.NombreRazonSocial;
            this.DirFiscal = ent.DirFiscal;
            this.Telefono = ent.Telefono;
        }

        public void Limpiar() 
        {
            Id = -1;
            CiRif = "";
            NombreRazaonSocial = "";
            DirFiscal = "";
            Telefono = "";
        }

    }

}