using Anki.Domain.Extensions;
using Anki.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Anki.Domain.ActionFilter
{
    public class ValidateModelFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ResultViewModel<string>(context.ModelState.GetErrors()));
            }
        }
    }
}
