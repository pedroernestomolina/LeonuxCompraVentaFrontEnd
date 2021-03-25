﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.OOB.Producto.Entidad
{
    
    public class Ficha
    {

        public string Auto { get; set; }
        public string AutoDepartamento { get; set; }
        public string AutoGrupo { get; set; }
        public string AutoSubGrupo { get; set; }
        public string AutoTasaIva { get; set; }
        public string AutoMarca { get; set; }
        public string AutoMedidaEmpaque_1 { get; set; }
        public string AutoMedidaEmpaque_2 { get; set; }
        public string AutoMedidaEmpaque_3 { get; set; }
        public string AutoMedidaEmpaque_4 { get; set; }
        public string AutoMedidaEmpaque_5 { get; set; }

        public string CodigoPrd { get; set; }
        public string CodigoPLU { get; set; }
        public string NombrePrd { get; set; }
        public string Referencia { get; set; }
        public string Categoria { get; set; }

        public string CodDepartamento { get; set; }
        public string NombreDepartamento { get; set; }

        public string CodGrupo { get; set; }
        public string NombreGrupo { get; set; }

        public string NombreTasa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Pasillo { get; set; }
        public decimal TasaImpuesto { get; set; }

        public string Estatus { get; set; }
        public string EstatusPesado { get; set; }
        public string EstatusDivisa { get; set; }
        public string EstatusOferta { get; set; }

        public decimal pneto_1 { get; set; }
        public decimal pneto_2 { get; set; }
        public decimal pneto_3 { get; set; }
        public decimal pneto_4 { get; set; }
        public decimal pneto_5 { get; set; }
        public decimal pdf_1 { get; set; }
        public decimal pdf_2 { get; set; }
        public decimal pdf_3 { get; set; }
        public decimal pdf_4 { get; set; }
        public decimal pdf_5 { get; set; }
        public int contenido_1 { get; set; }
        public int contenido_2 { get; set; }
        public int contenido_3 { get; set; }
        public int contenido_4 { get; set; }
        public int contenido_5 { get; set; }
        public string empaque_1 { get; set; }
        public string empaque_2 { get; set; }
        public string empaque_3 { get; set; }
        public string empaque_4 { get; set; }
        public string empaque_5 { get; set; }
        public string decimales_1 { get; set; }
        public string decimales_2 { get; set; }
        public string decimales_3 { get; set; }
        public string decimales_4 { get; set; }
        public string decimales_5 { get; set; }

        public bool IsActivo { get { return Estatus.Trim().ToUpper() == "ACTIVO"; } }
        public bool IsDivisa { get { return EstatusDivisa.Trim().ToUpper() == "1"; } }
        public bool IsPesado { get { return EstatusPesado.Trim().ToUpper() == "1"; } }
        public bool IsOferta { get { return EstatusOferta.Trim().ToUpper() == "1"; } }


        public Ficha()
        {
            Auto = "";
            AutoDepartamento = "";
            AutoGrupo = "";
            AutoMarca = "";
            AutoSubGrupo = "";
            AutoTasaIva = "";
            AutoMedidaEmpaque_1 = "";
            AutoMedidaEmpaque_2 = "";
            AutoMedidaEmpaque_3 = "";
            AutoMedidaEmpaque_4 = "";
            AutoMedidaEmpaque_5 = "";

            CodigoPLU = "";
            CodigoPrd = "";
            NombrePrd = "";
            Referencia = "";
            Categoria = "";

            CodDepartamento = "";
            NombreDepartamento = "";
            CodGrupo = "";
            NombreGrupo = "";
            Marca = "";
            Modelo = "";
            Pasillo = "";
            NombreTasa = "";
            TasaImpuesto = 0.0m;

            Estatus = "";
            EstatusDivisa = "";
            EstatusPesado = "";
            EstatusOferta = "";

            pneto_1 = 0.0m;
            pneto_2 = 0.0m;
            pneto_3 = 0.0m;
            pneto_4 = 0.0m;
            pneto_5 = 0.0m;
            pdf_1 = 0.0m;
            pdf_2 = 0.0m;
            pdf_3 = 0.0m;
            pdf_4 = 0.0m;
            pdf_5 = 0.0m;
            contenido_1 = 0;
            contenido_2 = 0;
            contenido_3 = 0;
            contenido_4 = 0;
            contenido_5 = 0;
            empaque_1 = "";
            empaque_2 = "";
            empaque_3 = "";
            empaque_4 = "";
            empaque_5 = "";
            decimales_1 = "";
            decimales_2 = "";
            decimales_3 = "";
            decimales_4 = "";
            decimales_5 = "";
        }

    }

}