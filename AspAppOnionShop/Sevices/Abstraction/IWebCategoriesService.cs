using AspAppOnionShop.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Sevices.Abstraction
{
    public interface IWebCategoriesService
    {
        List<CategoryViewModel> GetAllCategories();
        CategoryViewModel GetCategoryById(Guid id);
        void UpdateCategory(CategoryViewModel category);
        void CreateNewCategory(CategoryViewModel category);
        void RemoveCategoryById(Guid id);
    }
}
