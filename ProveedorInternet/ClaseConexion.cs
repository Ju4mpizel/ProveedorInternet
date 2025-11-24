using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProveedorInternet
{
    public class ClaseConexion
    {
        private MySqlConnection conexion;

        private readonly string servidor = "localhost";
        private readonly string usuario = "root";
        private readonly string password = "12345"; 
        private readonly string baseDatos = "proveedorinternet";

        public ClaseConexion()
        {
            // Construye la cadena de conexión
            string cadenaConexion = $"server={servidor};port=3306;user id={usuario};password={password};database={baseDatos}";
            conexion = new MySqlConnection(cadenaConexion);
        }

        // -----------------------------------------------------------------
        // Método para ABRIR la conexión
        // -----------------------------------------------------------------
        public MySqlConnection AbrirConexion()
        {
            try
            {
                // Solo abre si la conexión está cerrada
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                return conexion;
            }
            catch (MySqlException ex)
            {
                // Muestra un mensaje amigable si hay un error (ej: contraseña errónea)
                MessageBox.Show($"Error de conexión a la Base de Datos: {ex.Message}", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // -----------------------------------------------------------------
        // Método para CERRAR la conexión
        // -----------------------------------------------------------------
        public void CerrarConexion()
        {
            // Solo cierra si la conexión está abierta
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
