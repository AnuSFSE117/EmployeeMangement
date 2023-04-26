using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace UploadFiles.Controllers
{
    public class uploadController : Controller
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
       
        private async Task<bool> WriteFile(IFormFile file)
        {
            bool IsSaveSuccess = false;
            String filename;
            var extension = "." + file.FileName.ToString();
            filename = DateTime.Now.Ticks + extension;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\Files");
            if (Directory.Exists(path))
            {
                throw new Exception();

            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }

    }
}
