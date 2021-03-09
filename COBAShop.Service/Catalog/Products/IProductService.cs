using COBAShop.ViewModels.Catalog.ProductImages;
using COBAShop.ViewModels.Catalog.Products;
using COBAShop.ViewModels.Comon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.Service.Catalog.Products
{
    internal partial interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductVm> GetById(int productId, string languageId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int quantity);

        Task AddViewCount(int productId);

        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageVm> GetImageById(int imageId);

        Task<List<ProductImageVm>> GetListImages(int productId);

        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
    }
}