using Anki.Domain.DbContexts;
using Anki.Domain.Entities;
using Anki.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anki.Domain.Controllers
{
    [ApiController]
    public class CardController: ControllerBase
    {
        [HttpGet("/v1/Card")]
        public async Task<IActionResult> GetAsync([FromServices] AnkiDbContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Erro na validação dos dados");
            }

            var cards = await context.Cards.Include(x => x.Tags).AsNoTracking().ToListAsync();

            if (cards.Count == 0)
            {
                return NotFound(new ResultViewModel<string>("Não foi possível encontrar nenhum card"));
            }

            return Ok(new ResultViewModel<List<Card>>(cards));
        }

        [HttpPost("/v1/Card")]
        public async Task<IActionResult> PostAsync([FromServices] AnkiDbContext context, [FromBody] CardEditorViewModel model)
        {
            var tags = new List<Tag>(model.Tags.Select(x => new Tag() { Text = x }));

            if (!ModelState.IsValid)
            {
                return BadRequest("Erro na validação dos dados");
            }
            var card = new Card()
             {
                 Front = model.Front,
                 Back = model.Back,
                 Tags = tags
            };
 
             await context.Cards.AddAsync(card);
             await context.SaveChangesAsync();
            
             return Ok(card);
        }
    }
}
