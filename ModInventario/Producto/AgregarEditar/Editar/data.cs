﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.AgregarEditar.Editar
{
    
    public class data
    {

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string NombreProducto { get; set; }
        public string ReferenciaProducto { get; set; }
        public string ModeloProducto { get; set; }
        public int ContEmpProducto { get; set; }
        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoMarca { get; set; }
        public string AutoImpuesto { get; set; }
        public string AutoEmpCompra { get; set; }
        public string IdOrigen { get; set; }
        public string IdCategoria { get; set; }
        public string IdClasificacionAbc { get; set; }
        public string IdDivisa { get; set; }
        public byte[] Imagen { get; set; }
        public string Plu { get; set; }
        public int DiasEmpaque { get; set; }
        public bool EsPesado { get; set; }


        public data()
        {
            Limpiar();
        }


        public void setFicha(OOB.LibInventario.Producto.Editar.Obtener.Ficha ficha)
        {
            Codigo = ficha.codigo;
            Descripcion = ficha.descripcion;
            NombreProducto = ficha.nombre;
            ModeloProducto = ficha.modelo;
            ReferenciaProducto = ficha.referencia;
            ContEmpProducto = ficha.contenidoCompra;
            AutoDepartamento = ficha.autoDepartamento;
            AutoGrupo = ficha.autoGrupo;
            AutoMarca = ficha.autoMarca;
            AutoImpuesto = ficha.autoTasaImpuesto;
            AutoEmpCompra = ficha.autoEmpCompra;
            IdOrigen = ((int)ficha.origen).ToString();
            IdCategoria = ((int)ficha.categoria).ToString();
            IdClasificacionAbc=((int)ficha.Clasificacion).ToString();
            IdDivisa = ((int)ficha.AdmPorDivisa).ToString();
            Imagen = ficha.imagen;
            EsPesado = ficha.esPesado == OOB.LibInventario.Producto.Enumerados.EnumPesado.Si ? true : false;
            Plu = ficha.plu;
            DiasEmpaque = ficha.diasEmpaque;
        }

        public void Limpiar()
        {
            Codigo = "";
            Descripcion = "";
            NombreProducto = "";
            ModeloProducto = "";
            ReferenciaProducto = "";
            ContEmpProducto = 1;
            AutoDepartamento = "";
            AutoGrupo = "";
            AutoMarca = "";
            AutoImpuesto = "";
            AutoEmpCompra = "";
            IdOrigen = "";
            IdCategoria = "";
            IdClasificacionAbc = "";
            IdDivisa = "";
            Imagen = null;
            EsPesado = false;
            Plu = "";
            DiasEmpaque = 0;
        }

        public string Clasificacion 
        {
            get 
            {
                var rt = "";
                switch (IdClasificacionAbc)
                { 
                    case "1":
                        rt = "A";
                        break;
                    case "2":
                        rt = "B";
                        break;
                    case "3":
                        rt = "C";
                        break;
                    case "4":
                        rt = "D";
                        break;
                }
                return rt;
            }
        }

        public string Categoria 
        {
            get 
            {
                var rt = "";
                switch (IdCategoria)
                {
                    case "1":
                        rt = "Producto Terminado";
                        break;
                    case "2":
                        rt = "Bien de Servicio";
                        break;
                    case "3":
                        rt = "Materia Prima";
                        break;
                    case "4":
                        rt = "Uso Interno";
                        break;
                    case "5":
                        rt = "Sub Producto";
                        break;
                }
                return rt;
            }
        }

        public string Divisa
        { 
            get 
            {
                var rt = "";
                switch (IdDivisa)
                {
                    case "1":
                        rt = "1";
                        break;
                    case "2":
                        rt = "0";
                        break;
                }
                return rt;
            }
        }

        public string Origen
        {
            get
            {
                var rt = "";
                switch (IdOrigen)
                {
                    case "1":
                        rt = "Nacional";
                        break;
                    case "2":
                        rt = "Importado";
                        break;
                }
                return rt;
            }
        }

        public bool IsOk()
        {
            var rt = true;

            //if (Codigo.Trim() == "")
            //{
            //    Helpers.Msg.Error("CAMPO [ CODIGO ] DEBE SER LLENADO");
            //    return false;
            //}

            if (Descripcion.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ DESCRIPCION ] DEBE SER LLENADO");
                return false;
            }

            if (AutoDepartamento.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ DEPARTAMENTO ] DEBE SER LLENADO");
                return false;
            }

            if (AutoGrupo.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ GRUPO ] DEBE SER LLENADO");
                return false;
            }

            if (AutoMarca.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ MARCA ] DEBE SER LLENADO");
                return false;
            }

            if (AutoEmpCompra.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ EMPAQUE COMPRA ] DEBE SER LLENADO");
                return false;
            }

            if (AutoImpuesto.Trim() == "")
            {
                Helpers.Msg.Error("CAMPO [ TASA IMPUESTO ] DEBE SER LLENADO");
                return false;
            }

            if (IdOrigen.Trim() == "" || IdOrigen.Trim() == "-1")
            {
                Helpers.Msg.Error("CAMPO [ ORIGEN ] DEBE SER LLENADO");
                return false;
            }

            if (IdCategoria.Trim() == "" || IdCategoria.Trim() == "-1")
            {
                Helpers.Msg.Error("CAMPO [ CATEGORIA ] DEBE SER LLENADO");
                return false;
            }

            if (IdDivisa.Trim() == "" || IdDivisa.Trim() == "-1")
            {
                Helpers.Msg.Error("CAMPO [ ADMINISTRADO x DIVISA ] DEBE SER LLENADO");
                return false;
            }

            if (IdClasificacionAbc.Trim() == "" || IdClasificacionAbc.Trim() == "-1")
            {
                Helpers.Msg.Error("CAMPO [ CLASIFICACION ] DEBE SER LLENADO");
                return false;
            }

            if (EsPesado)
            {
                if (Plu.Trim() == "")
                {
                    Helpers.Msg.Error("CAMPO [ PLU ] DEBE SER LLENADO");
                    return false;
                }
            }

            return rt;
        }

    }

}