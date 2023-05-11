using Anki.Shared.Entities;

namespace Anki.Domain.Entities
{
    public class Deck : Entity
    {
        public string Title { get; set; }
        public IList<Card> Cards { get; set; }
    }
}
