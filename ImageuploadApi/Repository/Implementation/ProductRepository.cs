using ImageuploadApi.Models.Domain;
using ImageuploadApi.Repository.Abstract;

namespace ImageuploadApi.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ProductRepository(DatabaseContext context)
        {
                this._databaseContext = context;
        }
        public bool Add(Productsimg model)
        {
            try
            {
                _databaseContext.productsimg.Add(model);
                _databaseContext.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
