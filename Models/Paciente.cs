namespace ExamenUnidad3.Models
{
    public class Paciente 
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public float Peso { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}