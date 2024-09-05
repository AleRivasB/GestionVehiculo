using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVehiculo.Models
{
    
        public class Vehiculo : BaseEntity
        {

            public string Nombre { get; set; }

            public int anio { get; set; }

            public int cantidadPuertas { get; set; }

            [ForeignKey("Marca")]

            public int MarcaId { get; set; }

        }
    
}
