using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALRol 
    {
        string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
        public List<BERol> Listar() 
        {
            List<BERol> tmp = new List<BERol>();


            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("LISTAR_ROLES",conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    BERol rolTmp = new BERol( reader["IDROL"].ToString(), reader["NOMBRE"].ToString() );
                    
                    tmp.Add(rolTmp);

                }
            
            }



            return tmp;
        }
    }
}