using System.ComponentModel.DataAnnotations;
using Anki.Domain.Entities;

namespace Anki.Domain.ViewModels
{
    public class CardEditorViewModel
    {
        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Front { get; set; }
        [Required]
        [StringLength(100)]
        public string Back { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
    }
}
