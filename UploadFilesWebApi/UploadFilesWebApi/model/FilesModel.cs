namespace UploadFilesWebApi.Filesmodel
{
    public class FilesModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
    }
}
