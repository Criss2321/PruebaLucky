using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HijosDAO
    {
        private string cnx = string.Empty;

        public HijosDAO(string cnx)
        {
            this.cnx = cnx;
        }

        // Listado de Hijos
        public List<Hijos> ListadoHijos(int idPersonal)
        {
            var listado = new List<Hijos>();

            string query = "EXEC ListarHijosPersonal @IdPersonal";

            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@IdPersonal", idPersonal);

                conexion.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var hijos = new Hijos
                    {
                        IdHijo = dr.GetInt32(0),
                        IdPersonal = dr.GetInt32(1),
                        TipoDoc = dr.GetString(2),
                        NumeroDoc = dr.GetString(3),
                        ApPaterno = dr.GetString(4),
                        ApMaterno = dr.GetString(5),
                        Nombre1 = dr.GetString(6),
                        Nombre2 = dr.GetString(7),
                        NombreCompleto = dr.GetString(8),
                        FechaNac = dr.GetDateTime(9)
                    };
                    listado.Add(hijos);
                }

            }
            return listado;
        }

        // Registrar Hijos
        public bool RegistrarHijos(Hijos hijos)
        {
            var resultado = false;

            string query = "EXEC RegistrarHijosPersonal @IdPersonal, @TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @FechaNac";

            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@IdPersonal", hijos.IdPersonal);
                cmd.Parameters.AddWithValue("@TipoDoc", hijos.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", hijos.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", hijos.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", hijos.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", hijos.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", hijos.Nombre2);
                cmd.Parameters.AddWithValue("@FechaNac", hijos.FechaNac);

                conexion.Open();

                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;
        }

        // Editar Hijos
        public bool EditarHijos(Hijos hijos)
        {
            var resultado = false;

            string query = "EXEC EditarDatosHijo @IdHijo, @TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @FechaNac";

            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@IdHijo", hijos.IdHijo);
                cmd.Parameters.AddWithValue("@TipoDoc", hijos.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", hijos.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", hijos.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", hijos.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", hijos.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", hijos.Nombre2);
                cmd.Parameters.AddWithValue("@FechaNac", hijos.FechaNac);

                conexion.Open();

                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;
        }

        // Eliminar Hijos
        public bool EliminarHijos(int idHijo)
        {
            var resultado = false;

            string query = "EXEC EliminarHijo @IdHijo";

            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@IdHijo", idHijo);

                conexion.Open();

                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;
        }

    }
}
