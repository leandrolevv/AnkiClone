using Anki.Domain.DbContexts;
using Anki.Domain.Entities;
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
            var cards = await context.Cards.AsNoTracking().ToListAsync();

            return Ok(cards);
        }

        [HttpPost("/v1/Card")]
        public async Task<IActionResult> PostAsync([FromServices] AnkiDbContext context, [FromBody] Card model)
        {
            var card = new Card()
            {
                Front = model.Front,
                Back = model.Back,
                Tags = model.Tags
            };

            await context.Cards.AddAsync(card);
            await context.SaveChangesAsync();
            
            return Ok(card);
        }
    }
}
