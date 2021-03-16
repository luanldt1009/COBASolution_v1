using COBAShop.ViewModels.Catalog.Categories;
using COBAShop.ViewModels.Comon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.APIIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<PagedResult<CategoryVm>> GetAllPagings(GetCategoryPagingRequest request);

        Task<CategoryVm> GetById(string languageId, int id);

        Task<bool> CreateCategory(CategoryCreateRequest request);

        Task<bool> UpdateCategory(CategoryUpdateRequest request);

        Task<bool> DeleteCategory(int id);
    }
}