using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COBAShop.APIIntegration;
using COBAShop.Utilities.Constants;
using COBAShop.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COBAShop.AdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryController(ICategoryApiClient categoryApiClient)
        {
            this._categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetCategoryPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
            };

            var data = await _categoryApiClient.GetAllPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _categoryApiClient.CreateCategory(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            if (string.IsNullOrEmpty(languageId))
                languageId = "vi";
            var category = await _categoryApiClient.GetById(languageId, id);
            var categoryUpdate = new CategoryUpdateRequest();
            if (category != null)
            {
                categoryUpdate.Id = category.Id;
                categoryUpdate.IsShowOnHome = category.IsShowOnHome;
                categoryUpdate.LanguageId = category.LanguageId;
                categoryUpdate.Name = category.Name;
                categoryUpdate.SeoDescription = category.SeoDescription;
                categoryUpdate.SeoTitle = category.SeoTitle;
                categoryUpdate.SortOrder = category.SortOrder;
                categoryUpdate.Status = category.Status;
                categoryUpdate.ParentId = category.ParentId;
            }
            return View(categoryUpdate);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _categoryApiClient.UpdateCategory(request);
            if (result)
            {
                TempData["result"] = "Cập nhập thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhập thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            if (string.IsNullOrEmpty(languageId))
                languageId = "vi";
            var category = await _categoryApiClient.GetById(languageId, id);
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryApiClient.DeleteCategory(id);
            if (result)
            {
                TempData["result"] = "Xóa  thành công";
                return Json(new
                {
                    status = true,
                    message = "Xóa thành công"
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message = "Xóa thất bại"
                }); ;
            }
        }
    }
}