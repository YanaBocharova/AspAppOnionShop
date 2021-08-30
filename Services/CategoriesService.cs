using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Services.Abstract;
using Services.Abstract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriesService : BaseService,ICategoriesService
    {
        public CategoriesService(IUnitOfWork uow,IMapper _mapper):base(uow, _mapper)
        {
            mapper = _mapper;
            unitOfWork = uow;
        }
        public void CreateCategory(CategoryDto category)
        {
            var categoryNew = mapper.Map<Category>(category);
            unitOfWork.CategoriesRepository.Create(categoryNew);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = unitOfWork.CategoriesRepository.GetAll();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryDto category)
        {
            throw new NotImplementedException();
        }
    }
}
