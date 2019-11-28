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




    }
}