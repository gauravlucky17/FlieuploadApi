﻿namespace ImageuploadApi.Repository.Abstract
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string ImageFileName);
    }
}
