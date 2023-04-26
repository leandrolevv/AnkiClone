using System.Text.Json.Serialization;
using Anki.Domain.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
}).ConfigureApiBehaviorOptions(
    options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddDbContext<AnkiDbContext>();

var app = builder.Build();
app.MapControllers();

app.Run();
