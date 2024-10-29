using NZWalkz.API.Data;
using NZWalkz.API.Models.DomainModels;

namespace NZWalkz.API.Repo.ImagesRepo
{
    public class LocalImageRepos : IImagesRepo
    {
        private readonly IWebHostEnvironment web;
        private readonly IHttpContextAccessor httpContext;
        private readonly NZWalkzDBContext dbContext;

        public LocalImageRepos(IWebHostEnvironment web, IHttpContextAccessor httpContext, NZWalkzDBContext dbContext)
        {
            this.web = web;
            this.httpContext = httpContext;
            this.dbContext = dbContext;
        }
        public async Task<Images> Upload(Images image)
        {
            var localFilePath = Path.Combine(web.ContentRootPath, "Images", $"{image.Filename}{image.FileExt}");

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var fileFullPath = $"{httpContext.HttpContext.Request.Scheme}://{httpContext.HttpContext.Request.Host}{httpContext.HttpContext.Request.PathBase}/Images/{image.Filename}{image.FileExt}";

            image.FilePath = fileFullPath;

            //Save to Database
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;

        }
    }
}
