using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedorInternet
{
    internal class ContratoDAL
    {
        private ClaseConexion dbConexion = new ClaseConexion();

        public List<Contrato> ObtenerContratos()
        {
            List<Contrato> lista = new List<Contrato>();
            string sql = @"
                SELECT 
                    C.id_contrato, C.id_usuariofk, C.id_planfk, 
                    C.fecha_inicio, C.direccion_instalacion, C.estado_contrato,
                    U.nombre AS NombreUsuario, P.nombre_plan AS NombrePlan 
                FROM 
                    contratos C
                JOIN 
                    usuarios U ON C.id_usuariofk = U.id_usuario
                JOIN 
                    planes P ON C.id_planfk = P.id_plan
                ORDER BY 
                    C.id_contrato DESC";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return lista;

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader reader = null;

            try
            {
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Contrato c = new Contrato
                    {
                        IdContrato = reader.GetInt32("id_contrato"),
                        IdUsuarioFK = reader.GetInt32("id_usuariofk"),
                        IdPlanFK = reader.GetInt32("id_planfk"),
                        FechaInicio = reader.GetDateTime("fecha_inicio"), // Usa GetDateTime
                        DireccionInstalacion = reader.GetString("direccion_instalacion"),
                        EstadoContrato = reader.GetString("estado_contrato"),

                        // Propiedades de ayuda (las que vienen del JOIN)
                        NombreUsuario = reader.GetString("NombreUsuario"),
                        NombrePlan = reader.GetString("NombrePlan")
                    };
                    lista.Add(c);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al obtener contratos: {ex.Message}", "Error de Consulta");
            }
            finally
            {
                if (reader != null) reader.Close();
                dbConexion.CerrarConexion();
            }
            return lista;
        }
        public int GuardarContrato(Contrato contrato)
        {
            int filasAfectadas = 0;
            string sql = "INSERT INTO contratos (id_usuariofk, id_planfk, fecha_inicio, direccion_instalacion, estado_contrato) " +
                         "VALUES (@idUsuario, @idPlan, @fechaInicio, @direccionInst, @estado)";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                // Asignación de Parámetros
                comando.Parameters.AddWithValue("@idUsuario", contrato.IdUsuarioFK); 
                comando.Parameters.AddWithValue("@idPlan", contrato.IdPlanFK);
                comando.Parameters.AddWithValue("@fechaInicio", contrato.FechaInicio);
                comando.Parameters.AddWithValue("@direccionInst", contrato.DireccionInstalacion);
                comando.Parameters.AddWithValue("@estado", contrato.EstadoContrato);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al guardar el contrato: {ex.Message}", "Error de SQL");
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }

        public int ActualizarContrato(Contrato contrato)
        {
            int filasAfectadas = 0;

            string sql = "UPDATE contratos SET id_usuariofk = @idUsuario, id_planfk = @idPlan, " +
                         "fecha_inicio = @fechaInicio, direccion_instalacion = @direccionInst, " +
                         "estado_contrato = @estado WHERE id_contrato = @idContrato";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@idUsuario", contrato.IdUsuarioFK);
                comando.Parameters.AddWithValue("@idPlan", contrato.IdPlanFK);
                comando.Parameters.AddWithValue("@fechaInicio", contrato.FechaInicio);
                comando.Parameters.AddWithValue("@direccionInst", contrato.DireccionInstalacion);
                comando.Parameters.AddWithValue("@estado", contrato.EstadoContrato);
                comando.Parameters.AddWithValue("@idContrato", contrato.IdContrato);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al actualizar el contrato: {ex.Message}", "Error de SQL");
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }

        public int EliminarContrato(int idContrato)
        {
            int filasAfectadas = 0;

            string sql = "DELETE FROM contratos WHERE id_contrato = @id";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", idContrato);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al eliminar el contrato: {ex.Message}", "Error de SQL");
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }
    }
}
