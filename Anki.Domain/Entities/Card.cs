using Anki.Shared.Entities;

namespace Anki.Domain.Entities
{
    public class Card : Entity
    {
        public string Front { get; set; }
        public string Back { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
