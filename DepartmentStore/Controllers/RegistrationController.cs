using DAL_DepartmentStore;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly DbClass dbContext;
        public RegistrationController(DbClass repoContext) 
        {
            dbContext = repoContext;
        }
        //reference for authenticaton 
        //https://www.c-sharpcorner.com/article/authentication-and-authorization-in-asp-net-core-web-api-with-json-web-tokens/

    }
}
