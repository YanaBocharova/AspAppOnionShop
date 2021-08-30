using AspAppOnionShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Sevices.Abstraction
{
    public interface IWebProductsService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(Guid id);
        void UpdateProduct(ProductViewModel person);
        void CreateNewProduct(ProductViewModel person);
        void RemoveProductById(Guid id);
    }
}
