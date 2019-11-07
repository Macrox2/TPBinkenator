using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TPFINAL.Models
{
    public static class BD
    {
        private static string _connectionString = "Server=.;Database=Akinator;Trusted_Connection=True;";

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
                    string filtro = (lector["Correcta"]).ToString();
                    Filtro miFiltro = new Filtro(filtro);
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
                    bool decisivo= Convert.ToBoolean(lector["esDecisiva"]);
                    Respuesta miRta = new Respuesta(filtro,idPer,rta, decisivo);
                    lstRespuestas.Add(miRta);
                }
            }
            Desconectar(conexion);
            return lstRespuestas;

        }




    }
}