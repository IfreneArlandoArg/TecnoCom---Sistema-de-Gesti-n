using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DALComponente : DALConnection
    {
       // string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";


        public void PopularHijosFamilia(Familia pFamilia)
        {
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_PopularHijosFamilia", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_familia", pFamilia.Id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string nombre = reader["nombre"].ToString();
                    bool esPatente = (bool)reader["es_patente"];

                    Componente nuevo;
                    if (esPatente)
                    { 
                        nuevo = new Patente(id, nombre); 
                    }
                    else
                    { 
                        nuevo = new Familia(id, nombre);
                        PopularHijosFamilia(nuevo as Familia);
                    }

                    pFamilia.AgregarHijo(nuevo);
                }
            }

            


        }

        public List<Componente> Listar() 
        {
            List<Componente> componentes = new List<Componente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_listarPermisos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string nombre = reader["nombre"].ToString();
                    bool esPatente = (bool)reader["es_patente"];

                    Componente nuevo;
                    if (esPatente)
                        nuevo = new Patente(id, nombre);
                    else
                        nuevo = new Familia(id, nombre);

                    componentes.Add(nuevo);
                }
            }

            return componentes;
        
        
        }

        public List<Componente> ObtenerJerarquia()
        {
            List<Componente> resultado = new List<Componente>();
            Dictionary<int, Componente> componentes = new Dictionary<int, Componente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_obtenerJerarquiaPermisos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string nombre = reader["nombre"].ToString();
                    bool esPatente = (bool)reader["es_patente"];

                    if (!componentes.ContainsKey(id))
                    {
                        Componente nuevo;
                        if (esPatente)
                            nuevo = new Patente(id, nombre);
                        else
                            nuevo = new Familia(id, nombre);

                        componentes[id] = nuevo;
                    }
                }

                
                reader.Close();
                SqlDataReader reader2 = cmd.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2["id_permiso_padre"] != DBNull.Value)
                    {
                        int idPadre = (int)reader2["id_permiso_padre"];
                        int idHijo = (int)reader2["id"];

                        Componente padre = componentes[idPadre];
                        Componente hijo = componentes[idHijo];
                        
                        padre.AgregarHijo(hijo);

                    }
                }
                reader2.Close();
            }

            
            foreach (var comp in componentes.Values)
            {
                bool tienePadre = false;
                foreach (var otro in componentes.Values)
                {
                    if (otro.Hijos != null && otro.Hijos.Contains(comp))
                    {
                        tienePadre = true;
                        break;
                    }
                }

                if (!tienePadre)
                {
                    resultado.Add(comp);
                }
            }

            
            return resultado;



        }





        public void AltaComponente(Componente componente, int? idPadre)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ALTA_PERMISO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", componente.Nombre);
                cmd.Parameters.AddWithValue("@es_patente", componente is Patente);
                cmd.Parameters.AddWithValue("@id_padre", (object)idPadre ?? DBNull.Value);

                conn.Open();
                componente.Id = Convert.ToInt32(cmd.ExecuteScalar()); // si querés recuperar el ID
            }
        }

        public void Baja(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BAJA_PERMISO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Componente componente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_MODIFICAR_PERMISO", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", componente.Id);
                cmd.Parameters.AddWithValue("@nombre", componente.Nombre);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void AsignarHijo(int idPadre, int idHijo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ASIGNAR_HIJO_A_PADRE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_padre", idPadre);
                cmd.Parameters.AddWithValue("@id_hijo", idHijo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DesasignarHijo(int idPadre, int idHijo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DESASIGNAR_HIJO_DE_PADRE", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_padre", idPadre);
                cmd.Parameters.AddWithValue("@id_hijo", idHijo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

       


    }
}