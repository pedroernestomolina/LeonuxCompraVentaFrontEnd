﻿using PosOnLine.Data.Prov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosOnLine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            var gestion = new Gestion();
            gestion.Inicia();

            //var r01 = Helpers.Utilitis.CargarXml();
            //if (r01.Result != OOB.Enumerados.EnumResult.isError)
            //{
            //    Sistema.MyData = new DataProvInventario.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos);
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);

            //    var r02 = Sistema.MyData.Empresa_Datos();
            //    if (r02.Result == OOB.Enumerados.EnumResult.isError)
            //    {
            //        Helpers.Msg.Error(r02.Mensaje);
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        Sistema.Negocio = r02.Entidad;

            //        var _gestionId = new Identificacion.Gestion();
            //        _gestionId.Inicia();
            //        if (_gestionId.IsUsuarioOk)
            //        {
            //            var _gestionInv = new GestionInv();
            //            _gestionInv.Inicia();
            //        }
            //    }
            //    //Application.EnableVisualStyles();
            //    //Application.SetCompatibleTextRenderingDefault(false);
            //    //Application.Run(new Form1());
            //}
            //else
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    Application.Exit();
            //}

        }
    }
}
