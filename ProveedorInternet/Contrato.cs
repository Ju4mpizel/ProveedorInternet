using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedorInternet
{
    public class Contrato
    {
        public int IdContrato { get; set; }

        // Claves Foráneas:
        public int IdUsuarioFK { get; set; }
        public int IdPlanFK { get; set; }

        public DateTime FechaInicio { get; set; } // Usaremos DateTime para la fecha
        public string DireccionInstalacion { get; set; }
        public string EstadoContrato { get; set; }

        // Propiedades de ayuda (NO están en la DB, solo para mostrar en el DataGridView)
        public string NombreUsuario { get; set; }
        public string NombrePlan { get; set; }

        public Contrato() { }
    }
}
