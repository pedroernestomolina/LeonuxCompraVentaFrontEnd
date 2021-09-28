using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.ReconversionMonetaria
{
    
    public class Gestion
    {
        
        private bool _actualizacionIsOk;
        private decimal _factorReconversion;
        private decimal _tasaDivisa;
        private decimal _tasaRecepcionPos;
        private OOB.LibSistema.ReconversionMonetaria.Data.Ficha _data;
        private string _advertencia;


        public bool ActualizacionIsOk { get { return _actualizacionIsOk; } }
        public decimal FactorReconversion { get { return _factorReconversion; } }
        public string Advertencia { get { return _advertencia; } }


        public Gestion() 
        {
            _actualizacionIsOk = false;
            _factorReconversion = 0.0m;
            _tasaDivisa = 0.0m;
            _tasaRecepcionPos = 0.0m;
            _data = null;
            _advertencia = "";
        }


        public void Inicializa()
        {
            setAdvertencia("PARA EL 1 DE OCTUBRE ENTRA EN VIGENCIA LA NUEVA EXPRESION MONETARIA, LA CUAL DIVIDE LA ESCALA ACTUAL ENTRE 1 MILLON");
            _actualizacionIsOk = false;
            _factorReconversion = 0.0m;
            _tasaDivisa = 0.0m;
            _tasaRecepcionPos = 0.0m;
            _data = null;
        }

        private void setAdvertencia(string p)
        {
            _advertencia=p;
        }

        ReconversionMonFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ReconversionMonFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _tasaDivisa = r01.Entidad;

            var r02 = Sistema.MyData.Configuracion_TasaRecepcionPos();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _tasaRecepcionPos = r02.Entidad;

            var r03 = Sistema.MyData.ReconversionMonetaria_GetData();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _data = r03.Entidad;

            return rt;
        }

        public void Procesar()
        {
            var msg = MessageBox.Show("Estas Seguro De Iniciar El Proceso De Reconversión ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                setAdvertencia("ESTE PROCESO PUEDE DURAR VARIOS MINUTOS"+Environment.NewLine+"POR FAVOR ESPERE....");
                frm.ActualizarMensaje();
                msg = MessageBox.Show("Confirmar Iniciar El Proceso De Reconversión ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    Reconversion();
                }
            }
        }

        private void Reconversion()
        {
            _actualizacionIsOk = false;
            var ficha = new OOB.LibSistema.ReconversionMonetaria.Actualizar.Ficha()
            {
                codUsuario = Sistema.UsuarioP.codigo,
                equipoEstacion = Sistema.EstacionEquipo,
                factorReconverion = _factorReconversion,
                idUsuario = Sistema.UsuarioP.auto,
                tasaDivisa = Math.Round(_tasaDivisa / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                tasaDivisaPos = Math.Round(_tasaRecepcionPos / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                usuario = Sistema.UsuarioP.nombre,
                Producto = _data.Producto.Select(s =>
                {
                    var prd = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemPrd()
                    {
                        autoId = s.autoId,
                        nombre = s.nombre,
                        costo = s.costo > 0 ? Math.Round(s.costo / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        costoProm = s.costoProm > 0 ? Math.Round(s.costoProm / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        costoPrv = s.costoPrv > 0 ? Math.Round(s.costoPrv / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        costoUnd = s.costoUnd > 0 ? Math.Round(s.costoUnd / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        costoPromUnd = s.costoPromUnd > 0 ? Math.Round(s.costoPromUnd / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        costoPrvUnd = s.costoPrvUnd > 0 ? Math.Round(s.costoPrvUnd / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        precio1 = s.precio1 > 0 ? Math.Round(s.precio1 / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        precio2 = s.precio2 > 0 ? Math.Round(s.precio2 / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        precio3 = s.precio3 > 0 ? Math.Round(s.precio3 / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        precio4 = s.precio4 > 0 ? Math.Round(s.precio4 / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        precio5 = s.precio5 > 0 ? Math.Round(s.precio5 / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                    };
                    return prd;
                }).ToList(),
                Proveedor = _data.Proveedor.Select(s =>
                {
                    var prv = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemProv()
                    {
                        autoId = s.autoId,
                        nombre = s.nombre,
                        anticipos = s.anticipos > 0 ? Math.Round(s.anticipos / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        debitos = s.debitos > 0 ? Math.Round(s.debitos / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        creditos = s.creditos > 0 ? Math.Round(s.creditos / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        saldo = s.saldo > 0 ? Math.Round(s.saldo / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        disponible = s.disponible > 0 ? Math.Round(s.disponible / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                    };
                    return prv;
                }).ToList(),
                SaldoPorPagar = _data.SaldoPorPagar.Select(s =>
                {
                    var cxp = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemSaldoPorPagar()
                    {
                        autoDoc = s.autoDoc,
                        docNumero = s.docNumero,
                        importe = s.importe > 0 ? Math.Round(s.importe / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        acumulado = s.acumulado > 0 ? Math.Round(s.acumulado / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        resta = s.resta > 0 ? Math.Round(s.resta / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                    };
                    return cxp;
                }).ToList(),
                HistoricoCosto = _data.Producto.Select(s =>
                {
                    var cost = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemHistCosto()
                    {
                        autoPrd = s.autoId,
                        costo = s.costo > 0 ? Math.Round(s.costo / _factorReconversion, 2, MidpointRounding.AwayFromZero) : 0,
                        costoDivisa = s.costoDivisa,
                        documento = "",
                        estacionEquipo = Sistema.EstacionEquipo,
                        nota = "RECONVERSION MONETARIA AL 01/10/2021",
                        serie = "MAN",
                        tasaDivisa = Math.Round(_tasaDivisa / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                        usuario = Sistema.UsuarioP.nombre,
                    };
                    return cost;
                }).ToList(),
            };
            var lista= new List<OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemHistPrecio>();
            foreach (var rg in _data.Producto)
            {
                if (rg.precio1 > 0)
                {
                    var nr = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemHistPrecio()
                    {
                        autoPrd = rg.autoId,
                        estacionEquipo = Sistema.EstacionEquipo,
                        idPrecio = "1",
                        usuario = Sistema.UsuarioP.nombre,
                        nota = "RECONVERSION MONETARIA AL 01/10/2021",
                        precio = Math.Round(rg.precio1 / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                    };
                    lista.Add(nr);
                }
                if (rg.precio2 > 0)
                {
                    var nr = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemHistPrecio()
                    {
                        autoPrd = rg.autoId,
                        estacionEquipo = Sistema.EstacionEquipo,
                        idPrecio = "2",
                        usuario = Sistema.UsuarioP.nombre,
                        nota = "RECONVERSION MONETARIA AL 01/10/2021",
                        precio = Math.Round(rg.precio2 / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                    };
                    lista.Add(nr);
                }
                if (rg.precio3 > 0)
                {
                    var nr = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemHistPrecio()
                    {
                        autoPrd = rg.autoId,
                        estacionEquipo = Sistema.EstacionEquipo,
                        idPrecio = "3",
                        usuario = Sistema.UsuarioP.nombre,
                        nota = "RECONVERSION MONETARIA AL 01/10/2021",
                        precio = Math.Round(rg.precio3 / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                    };
                    lista.Add(nr);
                }
                if (rg.precio4 > 0)
                {
                    var nr = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemHistPrecio()
                    {
                        autoPrd = rg.autoId,
                        estacionEquipo = Sistema.EstacionEquipo,
                        idPrecio = "4",
                        usuario = Sistema.UsuarioP.nombre,
                        nota = "RECONVERSION MONETARIA AL 01/10/2021",
                        precio = Math.Round(rg.precio4 / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                    };
                    lista.Add(nr);
                }
                if (rg.precio5 > 0)
                {
                    var nr = new OOB.LibSistema.ReconversionMonetaria.Actualizar.ItemHistPrecio()
                    {
                        autoPrd = rg.autoId,
                        estacionEquipo = Sistema.EstacionEquipo,
                        idPrecio = "PTO",
                        usuario = Sistema.UsuarioP.nombre,
                        nota = "RECONVERSION MONETARIA AL 01/10/2021",
                        precio = Math.Round(rg.precio5 / _factorReconversion, 2, MidpointRounding.AwayFromZero),
                    };
                    lista.Add(nr);
                }
            }
            ficha.HistoricoPrecio = lista;

            var r01 = Sistema.MyData.ReconversionMonetaria_Actualizar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _actualizacionIsOk = true;
            Helpers.Msg.OK("PROCESO REALIZADO DE MANERA EXITOSA....... !!!");
        }

        public void setFactorReconversion(decimal factor)
        {
            _factorReconversion = factor;
        }

    }

}