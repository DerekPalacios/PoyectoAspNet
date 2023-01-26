using CAPA_DATOS;
using CAPA_NEGOCIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.Security
{
    public class AuthNetCore
    {
        static public UserModel User;
        static public bool VerifyAuthenticate()
        {
            if (SqlADOConexion.SQLM == null)
            {
                SqlADOConexion.SQLM = null;
                return false;
            }
            return true;
        }
        static public bool loginIN(string user, string password)
        {
            try
            {
                if (SqlADOConexion.IniciarConexion(user, password))
                {
                    
                    User = new UserModel(
                        new TblUsuario().Get<TblUsuario>($" NombreUsuario = '{user}' and ContraseñaSesion = '{password}'").First()
                    ) ;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public class UserModel
    {
        public UserModel(TblUsuario usuario)
        {
            this.user = usuario.NombreUsuario;
            this.success = true;
            this.UserId = usuario.IdUsuario;
            this.Roles = usuario.IdCargo;
        }
        public string user { get; set; }
        public int? UserId { get; set; }
        public bool success { get; set; }
        public int Roles { get; set; }
    }
}
