using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProveedorInternet
{
    public class PlanDAL
    {
        private ClaseConexion dbConexion = new ClaseConexion();
        public List<Plan> ObtenerPlanes()
        {
            List<Plan> lista = new List<Plan>();

            string sql = "SELECT id_plan, nombre_plan, velocidad, precio, descripcion FROM planes";

            MySqlConnection conexion = dbConexion.AbrirConexion();

            if (conexion == null) return lista;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Plan p = new Plan();

                    p.IdPlan = reader.GetInt32("id_plan");
                    p.NombrePlan = reader.GetString("nombre_plan");
                    p.Velocidad = reader.GetInt32("velocidad");
                    p.Precio = reader.GetDecimal("precio");
                    p.Descripcion = reader.GetString("descripcion");

                    lista.Add(p);
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al leer datos de Planes: " + ex.Message, "Error de SQL");
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return lista;
        }
        public int GuardarPlan(Plan plan)
        {
            int filasAfectadas = 0;
            string sql = "INSERT INTO planes (nombre_plan, velocidad, precio, descripcion) " +
                         "VALUES (@nombre, @velocidad, @precio, @descripcion)";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@nombre", plan.NombrePlan);
                comando.Parameters.AddWithValue("@velocidad", plan.Velocidad);
                comando.Parameters.AddWithValue("@precio", plan.Precio);
                comando.Parameters.AddWithValue("@descripcion", plan.Descripcion);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al guardar el plan: {ex.Message}", "Error de SQL");
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }

        public int ActualizarPlan(Plan plan)
        {
            int filasAfectadas = 0;

            string sql = "UPDATE planes SET nombre_plan = @nombre, velocidad = @velocidad, " +
                         "precio = @precio, descripcion = @descripcion WHERE id_plan = @id";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@nombre", plan.NombrePlan);
                comando.Parameters.AddWithValue("@velocidad", plan.Velocidad);
                comando.Parameters.AddWithValue("@precio", plan.Precio);
                comando.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                comando.Parameters.AddWithValue("@id", plan.IdPlan);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al actualizar el plan: {ex.Message}", "Error de SQL");
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }

        public int EliminarPlan(int idPlan)
        {
            int filasAfectadas = 0;

            string sql = "DELETE FROM planes WHERE id_plan = @id";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                comando.Parameters.AddWithValue("@id", idPlan);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451) 
                {
                    System.Windows.Forms.MessageBox.Show("No se puede eliminar este plan porque está asignado a uno o más contratos (Restricción de Integridad).", "Error de Eliminación");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show($"Error al eliminar el plan: {ex.Message}", "Error de SQL");
                }
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }
    }
}
