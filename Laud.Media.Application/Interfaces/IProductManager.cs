using Laud.Media.Application.Models;
using Laud.Media.Application.Models.Product;

namespace Laud.Media.Application.Interfaces
{
    public interface IProductManager
    {
        List<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        void Create(ProductModel model);
        ResultModel Update(ProductModel model);
        void Delete(int id);
    }
}
