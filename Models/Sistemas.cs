using System.ComponentModel.DataAnnotations;

namespace Registro_de_Prioridades1.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemaId { get; set; }
        [Required (ErrorMessage ="El nombre del sistema es obligatorio")]
        public String? Nombre { get; set; }
    }
}
