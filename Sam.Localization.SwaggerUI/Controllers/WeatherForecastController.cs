using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Sam.Localization.SwaggerUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            this.localizer = localizer;
        }

        [HttpGet]
        public string Get()
        {
            return localizer["Article"];
        }
    }
}
