using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVehiculo.Models
{
    public class Venta : BaseEntity
    {
        public double totalVenta { get; set; }

        public int cantidad { get; set; }

        [ForeignKey("Vehiculo")]

        public int VehiculoId { get; set; }

    }
}
