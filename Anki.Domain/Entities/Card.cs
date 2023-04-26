using Anki.Shared.Entities;

namespace Anki.Domain.Entities
{
    public class Card : Entity
    {
        public string Front { get; set; }
        public string Back { get; set; }
        public IList<Tag> Tags { get; set; } = new List<Tag>();
    }
}
