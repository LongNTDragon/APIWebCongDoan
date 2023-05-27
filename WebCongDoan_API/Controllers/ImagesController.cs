using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imgRepo;

        public ImagesController(IImageRepository repo)
        {
            _imgRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _imgRepo.GetAllImage());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var img = await _imgRepo.GetImageById(id);
                return img == null ? NotFound() : Ok(img);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ImageVM imgVM)
        {
            try
            {
                await _imgRepo.AddImage(imgVM);
                return StatusCode(StatusCodes.Status201Created, imgVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ImageVM imgVM)
        {
            try
            {
                var img = await _imgRepo.GetImageById(imgVM.ImgId);
                if (img == null)
                    return NotFound();

                await _imgRepo.UpdateImage(imgVM);
                return Ok(imgVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var img = await _imgRepo.GetImageById(id);
                if (img == null)
                    return NotFound();

                await _imgRepo.DeleteImage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
