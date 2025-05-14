using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALUsuarioLog
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public void Alta(BEUsuarioLog pBEUsuarioLog)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("ALTA_UsuarioLog", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO",pBEUsuarioLog.IdUsuario));
            
            }
        }

        public List<BEUsuarioLog> Listar(BEUsuario pBEUsuario)
        {
            throw new System.NotImplementedException();
        }
    }
}