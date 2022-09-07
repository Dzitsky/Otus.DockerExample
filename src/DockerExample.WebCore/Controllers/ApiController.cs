using DockerExample.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DockerExample.WebCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly IUserAppService _userAppService;

        public ApiController(IUserAppService userAppService)
        {
            this._userAppService = userAppService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public JsonResult GetUsers(long id)
        {
            var user = this._userAppService.GetById(id);

            return this.Json(user);
        }
    }
}
