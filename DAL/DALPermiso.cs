using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BE;


namespace DAL
{
    public class DALPermiso
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public List<Permiso> ObtenerPermisosRol(Rol pRol)
        {
            List<Permiso> tmp = new List<Permiso>();

            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("OBTENER_PERMISOS_ROL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdRol", pRol.Id));

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    tmp.Add(new Permiso(reader["ID_PERMISO"].ToString(), reader["NOMBRE"].ToString(), reader["DESCRIPCION"].ToString() ) );
                }


            }


            return tmp;

        }

        public void Alta()
        {
            throw new System.NotImplementedException();
        }

        public void Baja()
        {
            throw new System.NotImplementedException();
        }

        public void Modificar()
        {
            throw new System.NotImplementedException();
        }

        public List<Permiso> Listar()
        {
            List<Permiso> tmp = new List<Permiso>();


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_PERMISOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tmp.Add(new Permiso(reader["ID_PERMISO"].ToString(), reader["NOMBRE"].ToString(), reader["DESCRIPCION"].ToString()));
                }


            }


            return tmp;
        }
    }
}