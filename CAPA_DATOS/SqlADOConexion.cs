﻿using System;

namespace CAPA_DATOS
{
    public class SqlADOConexion
    {
        private static string UserSQLConexion = "";
        public static SqlServerGDatos SQLM;
        public static string DataBaseName = "Poyecto";
        //static string SQLServer = "GEMELEK";
        static string SQLServer = "."; // para que supuestamente jale en cualquier server

        //edicion de linea en prueba git
        static public bool IniciarConexion(string user, string password)
        {
            try
            {
                UserSQLConexion = "Data Source=" + SQLServer +
                    "; Initial Catalog= " + DataBaseName + "; " + "Trusted_Connection = True;";
                SQLM = new SqlServerGDatos(UserSQLConexion);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
