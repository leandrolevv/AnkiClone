using Anki.Shared.Entities;

namespace Anki.Domain.Entities
{
    public class Tag : Entity
    {
        public string Text { get; set; }

        public IList<Card> Cards { get; set; }
    }
}
