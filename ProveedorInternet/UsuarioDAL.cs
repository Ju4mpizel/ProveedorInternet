using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedorInternet
{
    public class UsuarioDAL
    {
        private ClaseConexion dbConexion = new ClaseConexion();
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            string sql = "SELECT id_usuario, nombre, apellido, carnet, telefono, email, direccion FROM usuarios";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return lista;

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            MySqlDataReader reader = null;

            try
            {
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Usuario u = new Usuario
                    {
                        IdUsuario = reader.GetInt32("id_usuario"),
                        Nombre = reader.GetString("nombre"),
                        Apellido = reader.GetString("apellido"),
                        Carnet = reader.GetString("carnet"),
                        Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? string.Empty : reader.GetString("telefono"),
                        Email = reader.IsDBNull(reader.GetOrdinal("email")) ? string.Empty : reader.GetString("email"),
                        Direccion = reader.IsDBNull(reader.GetOrdinal("direccion")) ? string.Empty : reader.GetString("direccion")
                    };
                    lista.Add(u);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener usuarios: " + ex.Message, "Error de Consulta");
            }
            finally
            {
                if (reader != null) reader.Close();
                dbConexion.CerrarConexion();
            }
            return lista;
        }
        public int GuardarUsuario(Usuario usuario)
        {
            int filasAfectadas = 0;

            string sql = "INSERT INTO usuarios (nombre, apellido, carnet, telefono, email, direccion) " +
                         "VALUES (@nombre, @apellido, @carnet, @telefono, @email, @direccion)";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@carnet", usuario.Carnet);
                comando.Parameters.AddWithValue("@telefono", usuario.Telefono);
                comando.Parameters.AddWithValue("@email", usuario.Email);
                comando.Parameters.AddWithValue("@direccion", usuario.Direccion);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Error: El Carnet o el Email ingresado ya existe en la base de datos.", "Dato Duplicado");
                }
                else
                {
                    MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error de SQL");
                }
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }

        public int ActualizarUsuario(Usuario usuario)
        {
            int filasAfectadas = 0;

            string sql = "UPDATE usuarios SET nombre = @nombre, apellido = @apellido, carnet = @carnet, " +
                         "telefono = @telefono, email = @email, direccion = @direccion WHERE id_usuario = @id";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@carnet", usuario.Carnet);
                comando.Parameters.AddWithValue("@telefono", usuario.Telefono);
                comando.Parameters.AddWithValue("@email", usuario.Email);
                comando.Parameters.AddWithValue("@direccion", usuario.Direccion);
                comando.Parameters.AddWithValue("@id", usuario.IdUsuario);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Error: El Carnet o el Email ya existen para otro usuario.", "Dato Duplicado");
                }
                else
                {
                    MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error de SQL");
                }
            }
            finally
            {
                dbConexion.CerrarConexion();
            }

            return filasAfectadas;
        }

        public int EliminarUsuario(int idUsuario)
        {
            int filasAfectadas = 0;

            string sql = "DELETE FROM usuarios WHERE id_usuario = @id";

            MySqlConnection conexion = dbConexion.AbrirConexion();
            if (conexion == null) return 0;

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", idUsuario);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("No se puede eliminar este usuario porque tiene contratos activos o históricos registrados.", "Restricción de Integridad");
                }
                else
                {
                    MessageBox.Show($"Error al eliminar el usuario: {ex.Message}", "Error de SQL");
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
