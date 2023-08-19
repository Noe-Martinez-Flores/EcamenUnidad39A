namespace ExamenUnidad3.Models
{
    public class Citas
    {
        public int Id { get; set; }
        public string? MotivoVisita { get; set; }
        public string? NombreVeterinario { get; set; }
        public DateTime FechaReservada { get; set; }
        public DateTime FechaAtencion { get; set; }
        public string? Observaciones { get; set; }
    }
}