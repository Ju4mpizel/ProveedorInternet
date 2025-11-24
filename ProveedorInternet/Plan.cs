using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProveedorInternet
{
    public class Plan
    {
        public int IdPlan { get; set; }
        public string NombrePlan { get; set; }
        public int Velocidad { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }

        public Plan()
        {

        }
    }
}
