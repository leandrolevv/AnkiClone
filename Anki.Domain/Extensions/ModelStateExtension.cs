using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Anki.Domain.Extensions
{
    public static class ModelStateExtension
    {
        public static IList<string> GetErrors(this ModelStateDictionary modelState)
        {
            var errors = new List<string>();
            
            foreach (var modelErrors in modelState.Values.Select(x => x.Errors))
                errors.AddRange(modelErrors.Select(x => x.ErrorMessage));

            return errors;
        }
    }
}
