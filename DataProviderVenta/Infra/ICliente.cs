using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{

    public interface ICliente
    {

        OOB.ResultadoLista<OOB.LibVenta.Cliente.Ficha> ClienteLista(OOB.LibVenta.Cliente.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibVenta.Cliente.Ficha> ClienteFicha(string autoCliente);
        OOB.ResultadoAuto ClienteAgregarEventual(OOB.LibVenta.Cliente.AgregarEventual ficha);
        OOB.ResultadoLista<OOB.LibVenta.Cliente.PorCobrar> ClienteDocPendientePorCobrar(string auto);

    }

}