using BE_ImageManagement.Interfaces;
using BE_ImageManagement.Models.RRModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_ImageManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IImageService service) : ControllerBase
    {
        [HttpPost]
        public ActionResult POST([FromBody]ImageRequest image)
        {
            var result = service.AddImage(image);

            if(result.IsSuccess)
            {
                return Created("",result);
            }
            return StatusCode(500);
        }

        [HttpPut]
        public ActionResult PUT([FromBody] ImageUpdateRequest image)
        {
            var result = service.UpdateImage(image);

            if(result.IsSuccess)
            {
                return Created("", result);
            }
            return StatusCode(500);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DELETE([FromRoute] int id)
        {
            var result = service.DeleteImage(id);

            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return StatusCode(500);
        }


        [HttpGet]
        public ActionResult GET()
        {
            var result = service.GetImages();
            if(result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult GET([FromRoute]int id)
        {
            var result = service.GetImage(id);
            if(result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

    }
}
