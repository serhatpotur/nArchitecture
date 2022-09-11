using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynmic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest request)
        {
            GetListModelQuery query = new GetListModelQuery { PageRequest = request };
            ModelListModel result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("GetList/ByDynmic")]
        public async Task<IActionResult> GetListByDynmic([FromQuery] PageRequest request, [FromBody] Dynamic dynamic)
        {
            GetListModelByDynmicQuery dynmicQuery = new GetListModelByDynmicQuery { PageRequest = request, Dynamic = dynamic };
            ModelListModel result = await Mediator.Send(dynmicQuery);
            return Ok(result);
        }
    }
}
