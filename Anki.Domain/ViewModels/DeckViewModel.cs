using System.ComponentModel.DataAnnotations;

namespace Anki.Domain.ViewModels
{
    public class DeckViewModel
    {
        [Required(ErrorMessage = "O campo Frente é obrigatório")]
        [MaxLength(1000, ErrorMessage = "O tamanho máximo do campo Frente é 1000 caracteres")]
        [MinLength(5)]
        public string Title { get; set; }
    }
}
