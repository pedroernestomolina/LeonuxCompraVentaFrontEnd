using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion.Cliente
{

    public class Buscar
    {

        OOB.LibVenta.PosOffline.Cliente.Ficha _fichaCliente ;


        public OOB.LibVenta.PosOffline.Cliente.Ficha FichaCliente 
        {
            get 
            {
                return _fichaCliente;
            }
        }


        public Buscar()
        {
            _fichaCliente = null;
        }


        public bool BuscarPorCiRif(string data) 
        {
            var rt = false;

            var cirif = data.Trim().ToUpper();
            if (cirif != "")
            {
                var r01 = Sistema.MyData2.Cliente_BuscarPorCiRif(cirif);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }

                _fichaCliente = r01.Entidad;
                rt = true;
            }

            return rt;
        }

        public bool Listar(string buscar)
        {
            var rt = false;

            if (buscar.Trim() == "") 
            {
                return false;
            }

            var frm = new ListaFrm();
            if (frm.CargarData(buscar)) 
            {
                frm.ShowDialog();
                if (frm.IsClienteSelected)
                {
                    var r01 = Sistema.MyData2.Cliente(frm.ClienteSelected.Id);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return false;
                    }

                    _fichaCliente = r01.Entidad;
                    return true;
                }
            }

            return rt;
        }

        public bool AgregarCliente(string cirif, string nombre, string dirFiscal, string telefono) 
        {
            var rt = false;

            if (cirif == "")
            {
                return false;
            }
            if (nombre == "")
            {
                return false;
            }
            if (dirFiscal == "")
            {
                return false;
            }
            var ficha = new OOB.LibVenta.PosOffline.Cliente.Agregar()
            {
                CiRif = cirif,
                NombreRazaonSocial = nombre,
                DirFiscal = dirFiscal,
                Telefono = telefono,
            };
            var r01 = Sistema.MyData2.Cliente_Agregar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData2.Cliente(r01.Id);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            rt = true;
            _fichaCliente = r02.Entidad;
            Helpers.Msg.AgregarOk();

            return rt;
        }

    }

}