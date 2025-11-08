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
    public class DALUsuarioLog : DALConnection
    {
       // string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public void Alta(BEUsuarioLog pBEUsuarioLog)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("ALTA_UsuarioLog", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO",pBEUsuarioLog.IdUsuario) );
                cmd.Parameters.Add(new SqlParameter("@ACCION", pBEUsuarioLog.Accion) );

                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<BEUsuarioLog> Listar(BEUsuario pBEUsuario)
        {
            List<BEUsuarioLog> tmp = new List<BEUsuarioLog>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_LOGS_USUARIO",conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", pBEUsuario.IdUsuario));

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                { 
                   BEUsuarioLog tmpUsuario = new BEUsuarioLog(reader["IDLOG"].ToString(), reader["IDUSUARIO"].ToString(), reader["FECHAHORA"].ToString(), reader["ACCION"].ToString() );

                    tmp.Add(tmpUsuario);
                }

            }


            return tmp;

        }




        public List<BEUsuarioLog> Listar()
        {
            List<BEUsuarioLog> tmp = new List<BEUsuarioLog>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_LOGS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BEUsuarioLog tmpUsuario = new BEUsuarioLog(reader["IDLOG"].ToString(), reader["IDUSUARIO"].ToString(), reader["FECHAHORA"].ToString(), reader["ACCION"].ToString());

                    tmp.Add(tmpUsuario);
                }

            }


            return tmp;

        }


    }





}