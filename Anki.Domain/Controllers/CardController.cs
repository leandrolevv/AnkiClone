using Anki.Domain.ActionFilter;
using Anki.Domain.DbContexts;
using Anki.Domain.Entities;
using Anki.Domain.Extensions;
//using Anki.Domain.Extensions;
using Anki.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Anki.Domain.Controllers
{
    [ApiController]
    [Route("v1/Card")]
    public class CardController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] AnkiDbContext context) => Ok(new ResultViewModel<List<Card>>(await context.Cards.Include(x => x.Tags).AsNoTracking()
                .ToListAsync()));

        [HttpPost]
        [ValidateModelFilter]
        public async Task<IActionResult> PostAsync([FromServices] AnkiDbContext context, [FromBody] CardEditorViewModel model)
        {
            var deck = await context.Decks.FirstOrDefaultAsync(x => x.Title == model.DeckTitle);

            if (deck == null)
            {
                return NotFound(new ResultViewModel<string>("Deck não encontrado"));
            }

            var card = new Card()
            {
                Front = model.Front,
                Back = model.Back,
                Deck = deck
            };

            var tags = await context.Tags.Where(x => model.Tags.Contains(x.Text)).ToListAsync();
            card.AddTags(tags, model.Tags);

            await context.Cards.AddAsync(card);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Card>(card));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AnkiDbContext context, [FromRoute] int id)
        {
            var card = context.Cards.FirstOrDefault(x => x.Id == id);

            if (card == null)
                return NotFound(new ResultViewModel<string>("Não foi encontrado o conteúdo"));

            context.Cards.Remove(card);
            await context.SaveChangesAsync();
            return Ok(new ResultViewModel<string>(data: "Excluído com sucesso"));
        }
    }
}
