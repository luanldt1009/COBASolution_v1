using COBAShop.Data.EF;
using COBAShop.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using COBAShop.Data.Entities;
using COBAShop.Data.Enums;
using COBAShop.Utilities.Exceptions;
using COBAShop.ViewModels.Comon;

namespace COBAShop.Service.Catalog.Catelogies
{
    public class CategoryService : ICategoryService
    {
        public readonly COBAShopDbContext _context;

        public CategoryService(COBAShopDbContext context)
        {
            this._context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<CategoryTranslation>();

            translations.Add(new CategoryTranslation()
            {
                Name = request.Name,
                SeoDescription = request.SeoDescription,
                SeoTitle = request.SeoTitle,
                LanguageId = request.LanguageId
            });

            var category = new Category()
            {
                SortOrder = request.SortOrder,
                IsShowOnHome = request.IsShowOnHome,
                ParentId = request.ParentId,
                Status = (Status)request.Status,
                CategoryTranslations = translations,
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        //where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
                Status = (int)x.c.Status,
                IsShowOnHome = x.c.IsShowOnHome,
                SortOrder = x.c.SortOrder,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
            }).ToListAsync();
        }

        public async Task<PagedResult<CategoryVm>> GetAllPaging(GetCategoryPagingRequest request)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        select new { c, ct };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.ct.Name.Contains(request.Keyword));
            var data = await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
                Status = (int)x.c.Status,
                IsShowOnHome = x.c.IsShowOnHome,
                SortOrder = x.c.SortOrder,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
            }).OrderBy(x => x.SortOrder).ToListAsync();
            //3. Paging
            int totalRow = await query.CountAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<CategoryVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where /*ct.LanguageId == languageId &&*/ c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
                Status = (int)x.c.Status,
                IsShowOnHome = x.c.IsShowOnHome,
                SortOrder = x.c.SortOrder,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(CategoryUpdateRequest request)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            var categoryTranslations = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.Id);

            if (category == null || categoryTranslations == null) throw new COBAShopException($"Cannot find a Category with id: {request.Id}");

            categoryTranslations.Name = request.Name;
            categoryTranslations.SeoDescription = request.SeoDescription;
            categoryTranslations.SeoTitle = request.SeoTitle;

            category.Status = (Status)request.Status;
            category.SortOrder = request.SortOrder;
            category.IsShowOnHome = request.IsShowOnHome;
            category.ParentId = request.ParentId;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category == null)
            {
                throw new COBAShopException($"Không tìm thấy danh mục: {categoryId}");
            }
            //  var images = _context.ProductImages.Where(x => x.ProductId == productId);
            //foreach (var item in images)
            //{
            //    await _storageService.DeteleFileAsync(item.ImagePath);
            //}
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }
    }
}