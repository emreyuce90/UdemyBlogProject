using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyBlogProject.BusinessLayer.Interfaces;
using UdemyBlogProject.Entities.Interface;

namespace UdemyBlogProject.WebApi.CustomFilters
{
    public class ValidId<Tentity> : IActionFilter where Tentity : class, ITable, new()
    {
        private readonly IGenericService<Tentity> _genericService;
        public ValidId(IGenericService<Tentity> genericService)
        {
            _genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();

            var id = int.Parse(dictionary.Key.ToString());

            var entity=_genericService.GetByIdAsync(id);

            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{id} ile ilgili veritabanında bir kayıt bulunamadı");
            }
        }
    }
}
