using Microsoft.AspNetCore.Mvc;
using WavesOfFoodDemo.Server.Dtos;
using WavesOfFoodDemo.Server.Services;

namespace WavesOfFoodDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodInfoController : ControllerBase
    {
        private readonly ILogger<FoodInfoController> _logger;
        private readonly IFoodInfoService _foodInfoService;

        public FoodInfoController(
            ILogger<FoodInfoController> logger,
            IFoodInfoService foodInfoService)
        {
            _logger = logger;
            _foodInfoService = foodInfoService;
        }

        [HttpGet("GetFoodInfos")]
        public async Task<IActionResult> GetFoodInfos()
        {
            try
            {
                var data = await _foodInfoService.GetFoodInfoDtosAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SearchFoodInfos")]
        public async Task<IActionResult> SearchFoodInfos(string foodName)
        {
            try
            {
                var data = await _foodInfoService.SearchFoodInfoDtosAsync(foodName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostFoodInfo")]
        public async Task<IActionResult> PostFoodInfo(FoodInfoCreateDto foodInfoCreateDto)
        {
            try
            {
                var data = await _foodInfoService.AddFoodInfoAsync(foodInfoCreateDto);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutFoodInfo")]
        public async Task<IActionResult> PutFoodInfo(FoodInfoDto foodInfoDto)
        {
            try
            {
                var data = await _foodInfoService.EditFoodInfoAsync(foodInfoDto);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteFoodInfo/{id}")]
        public async Task<IActionResult> DeleteFoodInfo(Guid id)
        {
            try
            {
                var data = await _foodInfoService.RemoveFoodInfoDtosAsync(id);
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}