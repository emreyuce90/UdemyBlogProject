using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyBlogProject.WebApi.CustomFilters
{
    public class ValidModel:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //bize gelen model doğru değilse
            if (!context.ModelState.IsValid)
            {
                //badrequest dön ve içerisine de girilen modeli bas
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            
        }
    }
}
