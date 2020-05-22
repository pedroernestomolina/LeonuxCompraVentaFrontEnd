using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.Cliente
{
    
    public class Ficha 
    {

        public string Auto { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoVendedor { get; set; }
        public string AutoCobrador { get; set; }
        public string AutoEstado { get; set; }
        public string AutoZona { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CiRif { get; set; }
        public string DireccionFiscal { get; set; }
        public string Contacto { get; set; }
        public Enumerados.enumTarifaPrecio TarifaPrecio { get; set; }
        public decimal PorctDescuento { get; set; }
        public decimal PorctRecargo { get; set; }
        public bool IsCreditoHabilitado { get; set; }
        public int DiasCredito { get; set; }
        public Enumerados.enumCategoria Categoria { get; set; }
        public decimal LimitePorMonto { get; set; }
        public int LimitePorDocumento { get; set; }
        public string Notas{ get; set; }
        public string Aviso { get; set; }
        public bool IsActivo { get; set; }
        public Enumerados.enumDenominacionFiscal DenominacionFiscal { get; set; }

        public string Email { get; set; }
        public string Telefono_1 { get; set; }
        public string Telefono_2 { get; set; }
        public string Celular { get; set; }

        public string GrupoDescripcion { get; set; }
        public string GrupoCodigo { get; set; }

        public string EstadoDescripcion { get; set; }

        public string ZonaDescripcion { get; set; }
        public string ZonaCodigo { get; set; }

        public string CobradorNombre { get; set; }
        public string CobradorCodigo { get; set; }

        public string VendedorNombre { get; set; }
        public string VendedorCodigo { get; set; }

        public List<PorCobrar> DocumentosPendientePorCobrar { get; set; }


        public decimal SaldoDisponible 
        {
            get 
            {
                var rt = 0.0m;
                if (DocumentosPendientePorCobrar != null && DocumentosPendientePorCobrar.Count > 0) 
                {
                    rt = LimitePorMonto - DocumentosPendientePorCobrar.Sum(sm => sm.MontoPendiente);
                }
                return rt;
            }
        }
 
        public string Cliente 
        {
            get 
            {
                var dt = CiRif.Trim()+Environment.NewLine+Nombre.Trim();
                return dt;
            }
        }

        public string CategoriaDescripcion
        {
            get
            {
                var dt = "";
                switch (Categoria)
                {
                    case Enumerados.enumCategoria.Administrativo:
                        dt = "ADMINISTRATIVO";
                        break;
                    case Enumerados.enumCategoria.Eventual:
                        dt = "EVENTUAL";
                        break;
                }
                return dt;
            }
        }

        public string DenominacionFiscalDescripcion
        {
            get
            {
                var dt = "";
                switch (DenominacionFiscal)
                {
                    case Enumerados.enumDenominacionFiscal.NoContribuyente :
                        dt = "No Contribuyente";
                        break;
                    case Enumerados.enumDenominacionFiscal.Contribuyente :
                        dt = "Contribuyente";
                        break;
                }
                return dt;
            }
        }

        public string TarifaPrecioDescripcion
        {
            get
            {
                var dt = "";
                switch (TarifaPrecio)
                {
                    case Enumerados.enumTarifaPrecio.Tarifa_1 :
                        dt = "PRECIO #1";
                        break;
                    case Enumerados.enumTarifaPrecio.Tarifa_2:
                        dt = "PRECIO #2";
                        break;
                    case Enumerados.enumTarifaPrecio.Tarifa_3:
                        dt = "PRECIO #3";
                        break;
                    case Enumerados.enumTarifaPrecio.Tarifa_4:
                        dt = "PRECIO #4";
                        break;
                }
                return dt;
            }
        }

    }

}