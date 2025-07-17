using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;




namespace DAL
{
    public class DALUsuario 
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";

        DALComponente dalComponente = new DALComponente();

        public void Alta(BEUsuario pBeUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("ALTA_USUARIO",conn);
                cmd.CommandType = CommandType.StoredProcedure;


                
                cmd.Parameters.Add(new SqlParameter("@pNOMBRE", pBeUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@pAPELLIDO", pBeUsuario.Apellido));
                
                cmd.Parameters.Add(new SqlParameter("@pFECHA_NACIMIENTO", pBeUsuario.FechaNacimiento));
                
                cmd.Parameters.Add(new SqlParameter("@pEMAIL", pBeUsuario.Email));
                cmd.Parameters.Add(new SqlParameter("@pPASSWORD_HASH", pBeUsuario.PasswordHash));


                conn.Open();

                cmd.ExecuteNonQuery();



            }
        }

        public List<BEUsuario> Listar()
        {
            List<BEUsuario> tmp = new List<BEUsuario>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LISTAR_USUARIOS", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                  
                    BEUsuario usrTmp = new BEUsuario(reader["IDUSUARIO"].ToString(), reader["NOMBRE"].ToString(), 
                        reader["APELLIDO"].ToString(), reader["FECHA_NACIMIENTO"].ToString(), reader["ACTIVO"].ToString(), 
                        reader["EMAIL"].ToString(), reader["PASSWORD_HASH"].ToString());


                    //Aca agregamos los permisos... 
                    AgregarPermisosUsuario(usrTmp);


                    tmp.Add(usrTmp);

                 
                }

            }


            return tmp;
        }

        public void Modificar(BEUsuario pBeUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("MODIFICAR_USUARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@pIDUSUARIO", pBeUsuario.IdUsuario));
                cmd.Parameters.Add(new SqlParameter("@pNOMBRE", pBeUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@pAPELLIDO", pBeUsuario.Apellido));
               
                
                cmd.Parameters.Add(new SqlParameter("@pEMAIL", pBeUsuario.Email));
                cmd.Parameters.Add(new SqlParameter("@pPASSWORD_HASH", pBeUsuario.PasswordHash));


                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        //Borrado lógico....
        public void Borrar(BEUsuario pBEUsuario)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("BAJA_USUARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@pIDUSUARIO", pBEUsuario.IdUsuario));

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }


        public void AltaPermisoUsuario(int pIdUsuario, int pIdPermiso)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ALTA_PERMISO_USUARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID_USER", pIdUsuario));
                cmd.Parameters.Add(new SqlParameter("@ID_PERMISO", pIdPermiso));

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void BajaPermisoUsuario(int pIdUsuario, int pIdPermiso)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_BAJA_PERMISO_USUARIO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID_USER", pIdUsuario));
                cmd.Parameters.Add(new SqlParameter("@ID_PERMISO", pIdPermiso));

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void AgregarPermisosUsuario(BEUsuario pUsuario) 
        { 
           using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("listar_permisos_usuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID_USER", pUsuario.IdUsuario));

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    Componente componente;

                    if ((bool)reader["es_patente"])
                    {
                        componente = new Patente((int)reader["id"], reader["nombre"].ToString());
                    }
                    else 
                    { 
                       componente = new Familia((int)reader["id"], reader["nombre"].ToString());
                       dalComponente.PopularHijosFamilia(componente as Familia);
                       
                    }

                    pUsuario.AgregarPermiso(componente);



                }

            }
        }


    }
}
