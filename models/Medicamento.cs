namespace ExamenUnidad3.Models
{
    public class Medicamento 
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int DosisRecomendada { get; set; }
        public string? FormaAdministracion { get; set; }
        public string? Indicaciones { get; set; }
    }
}