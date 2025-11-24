using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms; // Para usar MessageBox

namespace ProveedorInternet
{
    public class PlanDAL
    {
        private ClaseConexion dbConexion = new ClaseConexion();

        // Método para obtener todos los planes y devolverlos como una lista
        public List<Plan> ObtenerPlanes()
        {
            List<Plan> lista = new List<Plan>();
            string sql = "SELECT id_plan, nombre_plan, velocidad, precio, descripcion FROM planes";

            MySqlConnection conexion = dbConexion.AbrirConexion();

            // Si la conexión falló (devuelve null), salimos del método
            if (conexion == null) return lista;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                MySqlDataReader reader = comando.ExecuteReader();

                // 1. Recorrer los resultados: 
                //    El bucle 'while (reader.Read())' pasa por cada fila que devuelve MySQL
                while (reader.Read())
                {
                    Plan p = new Plan();

                    // 2. Mapeo (Llenar el objeto Plan con los datos de la fila)
                    //    Los nombres dentro de Get*() deben coincidir con los nombres de las columnas en MySQL.
                    p.IdPlan = reader.GetInt32("id_plan");
                    p.NombrePlan = reader.GetString("nombre_plan");
                    p.Velocidad = reader.GetInt32("velocidad");
                    p.Precio = reader.GetDecimal("precio");

                    // Aquí asumimos que la descripción no es NULL por simplicidad. 
                    // Si fuese NULL, causaría un error.
                    p.Descripcion = reader.GetString("descripcion");

                    // 3. Agregar a la lista:
                    lista.Add(p);
                }

                reader.Close(); // Es crucial cerrar el lector
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al leer datos de Planes: " + ex.Message, "Error de SQL");
            }
            finally
            {
                // Cerramos la conexión al terminar, haya o no error
                dbConexion.CerrarConexion();
            }

            return lista;
        }
        public int GuardarPlan(Plan plan)
        {
            int filasAfectadas = 0;

            // Consulta SQL. Usamos @parametros (ej: @nombre) para prevenir la inyección SQL.
            string sql = "INSERT INTO planes (nombre_plan, velocidad, precio, descripcion) " +
                         "VALUES (@nombre, @velocidad, @precio, @descripcion)";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                // 1. Asignar Parámetros: Mapeamos el objeto 'Plan' que recibimos a los @parametros de SQL.
                comando.Parameters.AddWithValue("@nombre", plan.NombrePlan);
                comando.Parameters.AddWithValue("@velocidad", plan.Velocidad);
                comando.Parameters.AddWithValue("@precio", plan.Precio);
                comando.Parameters.AddWithValue("@descripcion", plan.Descripcion);

                // 2. Ejecutar: ExecuteNonQuery se usa para INSERT, UPDATE, y DELETE 
                //    ya que no devuelve datos, solo la cantidad de filas modificadas (filasAfectadas).
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

            // La clave es el WHERE id_plan=@id. Usamos el ID para saber qué registro cambiar.
            string sql = "UPDATE planes SET nombre_plan = @nombre, velocidad = @velocidad, " +
                         "precio = @precio, descripcion = @descripcion WHERE id_plan = @id";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                // Asignar Parámetros, incluyendo el ID
                comando.Parameters.AddWithValue("@nombre", plan.NombrePlan);
                comando.Parameters.AddWithValue("@velocidad", plan.Velocidad);
                comando.Parameters.AddWithValue("@precio", plan.Precio);
                comando.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                comando.Parameters.AddWithValue("@id", plan.IdPlan); // ¡El ID es crucial!

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

            // Consulta SQL: Elimina la fila donde el id_plan coincida
            string sql = "DELETE FROM planes WHERE id_plan = @id";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);

                // Asignar Parámetros: Solo necesitamos el ID
                comando.Parameters.AddWithValue("@id", idPlan);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                // ⚠️ IMPORTANTE: Aquí se capturará el error si el plan está en uso
                // debido a la restricción ON DELETE RESTRICT que implementaste.
                if (ex.Number == 1451) // Código de error de MySQL para restricción de clave foránea
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
