using Microsoft.EntityFrameworkCore;
using UploadFilesWebApi.Filesmodel;

namespace UploadFilesWebApi.Files
{
    public class FileDbContext:DbContext
    {
        public FileDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<FilesModel> FilesDb { get; set; }

    }
}
