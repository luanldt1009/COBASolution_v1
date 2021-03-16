using COBAShop.ViewModels.Catalog.Categories;
using COBAShop.ViewModels.Comon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.Catalog.Catelogies
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<PagedResult<CategoryVm>> GetAllPaging(GetCategoryPagingRequest request);

        Task<CategoryVm> GetById(string languageId, int id);

        Task<int> Create(CategoryCreateRequest request);

        Task<int> Update(CategoryUpdateRequest request);

        Task<int> Delete(int categoryId);
    }
}