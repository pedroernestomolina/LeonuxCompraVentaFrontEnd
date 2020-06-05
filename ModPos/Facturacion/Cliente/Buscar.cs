using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion.Cliente
{

    public class Buscar
    {


        public Cliente.Ficha FichaCliente {get;set;}


        public Buscar()
        {
            FichaCliente = new Ficha();
        }

        public void BuscarPorId(int idCliente) 
        {
            var r01 = Sistema.MyData2.Cliente(idCliente);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            FichaCliente.setEntidad(r01.Entidad);
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

                FichaCliente.setEntidad(r01.Entidad);
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

                    FichaCliente.setEntidad(r01.Entidad);
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
            FichaCliente.setEntidad(r02.Entidad);
            Helpers.Msg.AgregarOk();

            return rt;
        }

        public void Busqueda() 
        {
            var frm = new Cliente.BuscarAgregarFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void Limpiar() 
        {
           FichaCliente.Limpiar();
        }

        public void setCliente(int id, string cirif, string nombre, string dirfiscal, string telefono) 
        {
            FichaCliente.Id = id;
            FichaCliente.NombreRazaonSocial = nombre;
            FichaCliente.CiRif = cirif;
            FichaCliente.DirFiscal = dirfiscal;
            FichaCliente.Telefono = telefono;
        }

    }

}