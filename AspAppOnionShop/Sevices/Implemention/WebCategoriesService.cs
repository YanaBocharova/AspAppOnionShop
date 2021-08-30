using AspAppOnionShop.Models.Categories;
using AspAppOnionShop.Sevices.Abstraction;
using AutoMapper;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspAppOnionShop.Sevices.Implemention
{
    public class WebCategoriesService : IWebCategoriesService
    {
        readonly IServiceManager serviceManager;
        private readonly IMapper mapper;
        public WebCategoriesService(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public WebCategoriesService(IServiceManager serviceManager, IMapper _mapper)
        {
            this.serviceManager = serviceManager;
            mapper = _mapper;
        }
        public void CreateNewCategory(CategoryViewModel cat)
        {
            if (cat != null)
            {
                var createdCat = mapper.Map<CategoryDto>(cat);
                serviceManager.CategoriesService.CreateCategory(createdCat);
            }
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = serviceManager.CategoriesService.GetAllCategories();
            return categories.Select((c) => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public CategoryViewModel GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryViewModel person)
        {
            throw new NotImplementedException();
        }
    }
}
