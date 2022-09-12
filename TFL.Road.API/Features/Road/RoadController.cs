using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using TFL.API.Interfaces;
using TFL.API.Model;
using TFL.API.Request;

namespace TFL.API.Features.Road
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadController : ControllerBase
    {
        private readonly IGet<RoadRequest, RoadModel> get;

        public RoadController(IGet<RoadRequest, RoadModel> get)
        {
            Guard.ArgumentNotNull(get, nameof(get));
            this.get = get;
        }

        [HttpGet(Name = "GetStatus")]
        public async Task<IActionResult> Get([FromQuery] RoadRequest request)
        {
            if (request == null) return BadRequest();

            var result = await this.get.Handler(request);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
