using ImageuploadApi.Models.Domain;
namespace ImageuploadApi.Repository.Abstract
{
    public interface IProductRepository
    {
        bool Add(Productsimg model);
    }
}
