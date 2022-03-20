using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotteryController : ControllerBase
    {
        private readonly IDrawService drawService;

        public LotteryController(IDrawService drawService)
        {
            this.drawService = drawService;
        }

        [HttpGet, Route("getHistoryData")]
        public async Task<ActionResult<IEnumerable<DrawHistory>>> getHistoryData()
        {
            return Ok(await drawService.GetHistoryData());
        }

        [HttpPost, Route("saveDraw")]
        public async Task<ActionResult> saveDraw([FromBody] string numbers)
        {
            try
            {
                var input = numbers.Split(",").Select(x => int.Parse(x));

                numbers = string.Join(",", input.OrderBy(x => x));
            }
            catch (System.Exception)
            {
                return BadRequest("Invalid input.");
            }
            

            await drawService.SaveDraw(numbers);
            return NoContent();
        }
    }
}