using System.Collections;
using System.Formats.Asn1;
using Anki.Domain.ActionFilter;
using Anki.Domain.DbContexts;
using Anki.Domain.Entities;
using Anki.Domain.Extensions;
using Anki.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anki.Domain.Controllers
{
    [ApiController]
    [Route("v1/Deck")]
    public class DeckController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] AnkiDbContext context) => Ok(new ResultViewModel<IList<Deck>>(await context.Decks.AsNoTracking().ToListAsync()));

        [HttpPost]
        [ValidateModelFilter]
        public async Task<IActionResult> PostAsync([FromServices] AnkiDbContext context, [FromBody] DeckViewModel deckViewModel)
        {
            var deck = new Deck()
            {
                Title = deckViewModel.Title
            };

            await context.Decks.AddAsync(deck);
            await context.SaveChangesAsync();
            return Ok(new ResultViewModel<Deck>(deck));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] AnkiDbContext context, [FromRoute] int id)
        {
            var deck = context.Decks.FirstOrDefault(x => x.Id == id);
            
            if (deck == null)
                return NotFound(new ResultViewModel<string>("Não foi encontrado o conteúdo"));

            context.Decks.Remove(deck);
            await context.SaveChangesAsync();
            return Ok(new ResultViewModel<string>(data: "Excluído com sucesso"));
        }
    }
}
