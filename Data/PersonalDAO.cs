using Entity;
using System.Data.SqlClient;

namespace Data
{
    public class PersonalDAO
    {
        private string cnx = string.Empty;

        public PersonalDAO(string cnx)
        {
            this.cnx = cnx;
        }

        // Listado de Personal
        public List<Personal> ListadoPersonal()
        {
            var listado = new List<Personal>();
            
            string query = "EXEC ListarPersonal";

            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                conexion.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var personal = new Personal
                    {
                        IdPersonal = dr.GetInt32(0),
                        TipoDoc = dr.GetString(1),
                        NumeroDoc = dr.GetString(2),
                        ApPaterno = dr.GetString(3),
                        ApMaterno = dr.GetString(4),
                        Nombre1 = dr.GetString(5),
                        Nombre2 = dr.GetString(6),
                        NombreCompleto = dr.GetString(7),
                        FechaNac = dr.GetDateTime(8),
                        FechaIngreso = dr.GetDateTime(9)
                    };
                    listado.Add(personal);
                }

            }
            return listado;
        }

        // Registrar Personal
        public bool RegistrarPersonal(Personal personal)
        {
            var resultado = false;

            string query = "EXEC RegistrarPersonal @TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @FechaNac, @FechaIngreso";
            
            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@TipoDoc", personal.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", personal.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                cmd.Parameters.AddWithValue("@FechaNac", personal.FechaNac);
                cmd.Parameters.AddWithValue("@FechaIngreso", personal.FechaIngreso);

                conexion.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }

            return resultado;
        }

        // Editar datos del Personal
        public bool EditarDatosPersonal(Personal personal)
        {
            bool resultado = false;

            string query = "EXEC EditarDatosPersonal @IdPersonal, @TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @FechaNac, @FechaIngreso";

            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@IdPersonal", personal.IdPersonal);
                cmd.Parameters.AddWithValue("@TipoDoc", personal.TipoDoc);
                cmd.Parameters.AddWithValue("@NumeroDoc", personal.NumeroDoc);
                cmd.Parameters.AddWithValue("@ApPaterno", personal.ApPaterno);
                cmd.Parameters.AddWithValue("@ApMaterno", personal.ApMaterno);
                cmd.Parameters.AddWithValue("@Nombre1", personal.Nombre1);
                cmd.Parameters.AddWithValue("@Nombre2", personal.Nombre2);
                cmd.Parameters.AddWithValue("@FechaNac", personal.FechaNac);
                cmd.Parameters.AddWithValue("@FechaIngreso", personal.FechaIngreso);

                conexion.Open();

                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;
        }

        // Eliminar Personal
        public bool EliminarPersonal(int idPersonal)
        {
            bool resultado = false;

            string query = "EXEC EliminarPersonal @IdPersonal";

            using (var conexion = new SqlConnection(cnx))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@IdPersonal", idPersonal);

                conexion.Open();

                resultado = cmd.ExecuteNonQuery() > 0;
            }

            return resultado;
        }
    }
}
