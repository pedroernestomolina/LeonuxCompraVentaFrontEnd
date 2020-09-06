using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Asignar
{
    
    public class Gestion
    {

        private string autoPrd;
        private List<data> depositos;
        private BindingList<data> bldepositos;
        private BindingSource bs;
        private bool _isCerrarHabilitado;
        private string producto;


        public bool IsCerrarHabilitado { get { return _isCerrarHabilitado; } }
        public string Producto { get { return producto; } }
        public BindingSource Source { get { return bs; } }


        public Gestion()
        {
            autoPrd = "";
            producto = "";
            depositos = new List<data>();
            bldepositos = new BindingList<data>(depositos);
            bs = new BindingSource();
            bs.DataSource = bldepositos;
        }


        public void setFicha(string auto)
        {
            autoPrd=auto;
        }

        AsignarFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AsignarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            producto = "";
            depositos.Clear();
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Deposito_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            foreach (var it in r01.Lista.OrderBy(o=>o.codigo).ToList()) 
            {
                bldepositos.Add(new data(it));
            }

            var r02 = Sistema.MyData.Producto_GetDepositos(autoPrd);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            producto = r02.Entidad.codigoPrd + Environment.NewLine + r02.Entidad.descripcionPrd;
            foreach (var it in r02.Entidad.depositos)
            {
                var dep = depositos.FirstOrDefault(f => f.auto == it.auto);
                if (dep != null) 
                {
                    dep.setAsignado();
                }
            }

            return rt;
        }

        public void Procesar()
        {
            var msg = "Procesar Cambios ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                _isCerrarHabilitado = Guardar();
            }
            else
            {
                _isCerrarHabilitado = false;
            }
        }

        private bool Guardar()
        {
            var rt = true;

            var list = depositos.Where(w => w.asignar && w.asignado == false).Select(s =>
            {
                var nr = new OOB.LibInventario.Producto.Depositos.Asignar.Deposito()
                {
                    autoDeposito = s.auto,
                    averia = 0.0m,
                    disponible = 0.0m,
                    fechaUltConteo = new DateTime(2000, 01, 01),
                    fisica = 0.0m,
                    nivel_minimo = 0.0m,
                    nivel_optimo = 0.0m,
                    pto_pedido = 0.0m,
                    reservada = 0.0m,
                    resultadoUltConteo = 0.0m,
                    ubicacion_1 = "",
                    ubicacion_2 = "",
                    ubicacion_3 = "",
                    ubicacion_4 = "",
                };
                return nr;
            }).ToList();

            if (list.Count > 0)
            {
                var ficha = new OOB.LibInventario.Producto.Depositos.Asignar.Ficha()
                {
                    autoProducto = autoPrd,
                    depositos = list,
                };
                var r01 = Sistema.MyData.Producto_AsignarDepositos(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
            }
            else 
            {
                Helpers.Msg.Error("NO SE HAN ASIGNADOS DEPOSITOS NUEVOS A ESTE PRODUCTO");
                return false;
            }
            
            return rt;
        }

        public void InicializarIsCerrarHabilitado()
        {
            _isCerrarHabilitado = true;
        }

        public void Marcar()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                if (it.asignado) 
                {
                    it.asignar = true;
                }
            }
        }

        public void DesMarcar()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                if (it.asignado)
                {
                    Helpers.Msg.Error("NO PUEDES DESMARCAR ESTE DEPOSITO");
                    it.asignar = true;
                }
            }
        }

    }

}