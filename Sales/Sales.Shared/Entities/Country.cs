using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} el obligatorio")]
        public string Name { get; set; } = null!;

        public ICollection<State>? States { get; set; }

        public int StatesNumbre => States == null ? 0 : States.Count;
    }
}
