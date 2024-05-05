using ImageuploadApi.Repository.Abstract;

namespace ImageuploadApi.Repository.Implementation
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment env;
        public FileService(IWebHostEnvironment env)
        {

            this.env = env;

        }
        public Tuple<int, String> SaveImage(IFormFile imageFile)
        {
            try
            {
                var contentPath = this.env.ContentRootPath;
                // path="E:\webapi\ImageuploadApi\Uploads"
                var path = Path.Combine(contentPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };
                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("only {0} extensions are allowed",string.Join(",", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }
                string uniqueString = Guid.NewGuid().ToString();
                var newFilename = uniqueString + ext;
                var FileWithPath = Path.Combine(path, newFilename);
                var stream = new FileStream(FileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFilename);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }
        public bool DeleteImage(string ImageFileName)
        {
            try
            {
                var wwwPath = this.env.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", ImageFileName);
                if(System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }

}

