using Microsoft.AspNetCore.Mvc;

namespace FruitMarket.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }
}