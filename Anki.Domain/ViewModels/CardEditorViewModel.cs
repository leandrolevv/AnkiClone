using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Anki.Domain.Entities;

namespace Anki.Domain.ViewModels
{
    public class CardEditorViewModel
    {
        [Required(ErrorMessage = "O campo Frente é obrigatório")]
        [MaxLength(1000, ErrorMessage = "O tamanho máximo do campo Frente é 1000 caracteres")]
        [MinLength(5)]
        public string Front { get; set; }
        [Required(ErrorMessage = "O campo Costas é obrigatório")]
        [MaxLength(1000, ErrorMessage = "O tamanho máximo do campo Costas é 1000 caracteres")]
        public string Back { get; set; }
        [Required(ErrorMessage = "A carta deve estar vinculada a algum baralho")]
        public string DeckTitle { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
    }
}
