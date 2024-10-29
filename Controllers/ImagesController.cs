using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalkz.API.Models.DomainModels;
using NZWalkz.API.Models.DTOs.Images;
using NZWalkz.API.Repo.ImagesRepo;

namespace NZWalkz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImagesRepo imageRepos;

        public ImagesController(IImagesRepo imageRepos)
        {
            this.imageRepos = imageRepos;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] UploadImageReqDto req)
        {
            ValidateUploadImage(req);

            if(ModelState.IsValid)
            {
                //Convert to domain model
                var imageDomainModel = new Images
                {
                    File = req.File,
                    Filename = req.FileName,
                    FileDesc = req.FileDesc,
                    FileExt = Path.GetExtension(req.File.FileName),
                    FileSize = req.File.Length
                };


                await imageRepos.Upload(imageDomainModel);

                return Ok(imageDomainModel);

            }

            return BadRequest(ModelState);
        }

        private void ValidateUploadImage(UploadImageReqDto req) 
        {
            var allowedExtensionFile = new string[] { ".jpg", ".jpeg", ".png" };

            //Cek File Exxtension
            if (!allowedExtensionFile.Contains(Path.GetExtension(req.File.FileName))) 
            {
                ModelState.AddModelError("file", "File extension not supported");
            }

            //Cek file size maks = 10 MB
            if (req.File.Length > 10485760)
            {
                ModelState.AddModelError("filesize", "Filesize more than 10MB, please upload a smaller size file or compress the current file!");
            }


        }
    }
}
