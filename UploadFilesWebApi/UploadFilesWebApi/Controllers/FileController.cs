using Microsoft.AspNetCore.Mvc;
using UploadFilesWebApi.Files;
using UploadFilesWebApi.Filesmodel;
using UploadFilesWebApi.model;

namespace UploadFilesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileDbContext _context;
        private readonly IHostEnvironment _environment;
        public FileController(FileDbContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }



        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(IFormFile Files)
        {
            ResponseModel responseModel = new ResponseModel();
            long fileSize = Files.Length;
            string FolderPath = Path.Combine(_environment.ContentRootPath, "uploads");
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            string FileName = "+ Files.FileName";
            
            string filePath = Path.Combine(FolderPath, FileName);
         
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var document = new FilesModel
                {
                    FileName = Files.FileName,
                    FileType = Path.GetExtension(Files.FileName),
                    FileSize = fileSize,
                };
                await Files.CopyToAsync(stream);

                _context.FilesDb.Add(document);
                await _context.SaveChangesAsync();
            }
            
            return Ok("File Added successfully");
        }
    }
}


        
