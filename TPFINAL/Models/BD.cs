using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TPFINAL.Models
{
    public static class BD
    {
        private static string _connectionString = "Server=.;Database=Akinator;User ID=alumno;Password=alumno1;";

        public static string connectionString
        {
            get
            {
                return _connectionString;
            }
        }

        private static SqlConnection Conectar()
        {
            SqlConnection conexion;
            conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }

        private static void Desconectar(SqlConnection conexion)
        {
            conexion.Close();
        }

        public static List<Filtro> TraerFiltros()
        {

            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_traerFiltros";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            List<Filtro> filtros = new List<Filtro>();
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string filtro = (lector["filtro"]).ToString();
                    int idecisivo = Convert.ToInt32(lector["esDecisiva"]);
                    bool decisivo=true;
                    if (idecisivo == 0)
                    {
                        decisivo = false;
                    }                    
                    Filtro miFiltro = new Filtro(filtro,decisivo);
                    filtros.Add(miFiltro);
                }
            }
            Desconectar(conexion);
            return filtros;

        }
        public static List<Respuesta> TraerRespuestas()
        {

            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_traerRespuestas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            List<Respuesta> lstRespuestas = new List<Respuesta>();
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string filtro = (lector["filtro"]).ToString();
                    int idPer = Convert.ToInt32(lector["id_Personaje"]);
                    string rta = (lector["respuesta"]).ToString();
                    Respuesta miRta = new Respuesta(filtro,idPer,rta);
                    lstRespuestas.Add(miRta);
                }
            }
            Desconectar(conexion);
            return lstRespuestas;

        }


        public static Personaje TraerPersonajeXid(int id)
        {
            Personaje persona = new Personaje();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "SP_TraerPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.Add(id);
       
            SqlDataReader lector = consulta.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    string nombre = (lector["filtro"]).ToString();
                    string foto = (lector["filtro"]).ToString();

                    persona = new Personaje(id, nombre, foto);
                }
                
            }
            Desconectar(conexion);

            return persona;

        }
        public static void AgregarPersonaje(Personaje person)
        {
            Personaje persona = new Personaje();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "SP_AgregarPersonaje";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@nombre", person.Nombre_Personaje);
            consulta.Parameters.AddWithValue("@foto", person.Ruta_Imagen);

            SqlDataReader lector = consulta.ExecuteReader();
            
            Desconectar(conexion);
        }
        public static void InsertarFiltros(string profesion, string sexo, string nombre, string pelo, string hobbie)
        {
            Personaje persona = new Personaje();
            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "SP_InsertarFiltros";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@profesion", profesion);
            consulta.Parameters.AddWithValue("@sexo", sexo);
            consulta.Parameters.AddWithValue("@nombre", nombre);
            consulta.Parameters.AddWithValue("@pelo", pelo);
            consulta.Parameters.AddWithValue("@hobbie", hobbie);

            SqlDataReader lector = consulta.ExecuteReader();

            Desconectar(conexion);
        }
    }
}