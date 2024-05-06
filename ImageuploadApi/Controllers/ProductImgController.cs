using ImageuploadApi.Models.Domain;
using ImageuploadApi.Models.DTO;
using ImageuploadApi.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageuploadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImgController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productrepo;
        public ProductImgController(IFileService fs, IProductRepository productrepo)
        {
            this._fileService = fs;
            _productrepo = productrepo;

        }
        [HttpPost]
        public IActionResult Add([FromForm]Productsimg model)
        {
            var status = new Status();
            if(!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if(model.Imagefile != null)
            {
                var fileresult = _fileService.SaveImage(model.Imagefile);
                if(fileresult.Item1==1)
                {
                    //getting name of image
                    model.ProductImage = fileresult.Item2;
                }
                var productresult = _productrepo.Add(model);
                if(productresult)
                {
                    status.StatusCode = 1;
                    status.Message = "Added Successfully";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Not Added Successfully";
                }
                
            }
            return Ok(status);
        }

    }
}
