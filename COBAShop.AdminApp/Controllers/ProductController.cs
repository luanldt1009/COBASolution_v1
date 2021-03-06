using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using COBAShop.APIIntegration;
using COBAShop.Utilities.Constants;
using COBAShop.ViewModels.Catalog.Products;
using COBAShop.ViewModels.Comon;
using COBAShop.ViewModels.System.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace COBAShop.AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        private readonly IHostingEnvironment _env;

        public ProductController(IUserApiClient userApiClient, IProductApiClient productApiClient, ICategoryApiClient categoryApiClient, IHostingEnvironment env)
        {
            this._userApiClient = userApiClient;
            this._productApiClient = productApiClient;
            this._categoryApiClient = categoryApiClient;
            this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
                CategoryId = categoryId
            };

            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

            var categories = await _categoryApiClient.GetAll(languageId);
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productApiClient.DeleteProduct(id);
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
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            if (string.IsNullOrEmpty(request.LanguageId))
                request.LanguageId = "vi";
            if (request.IsFeatured == null)
                request.IsFeatured = true;
            var result = await _productApiClient.CreateProduct(request);
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
            try
            {
                var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
                if (string.IsNullOrEmpty(languageId))
                    languageId = "vi";
                var product = await _productApiClient.GetById(id, languageId);
                var productUpdate = new ProductUpdateRequest();
                if (product != null)
                {
                    productUpdate.Id = product.Id;
                    productUpdate.Name = product.Name;
                    productUpdate.Description = product.Description;
                    productUpdate.Details = product.Details;
                    productUpdate.SeoTitle = product.SeoTitle;
                    productUpdate.SeoDescription = product.SeoDescription;
                    productUpdate.Price = product.Price;
                    productUpdate.Stock = product.Stock;
                }
                return View(productUpdate);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(ProductUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                var result = await _productApiClient.UpdateProduct(request);
                if (result)
                {
                    TempData["result"] = "Cập nhập thành công";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Cập nhập thất bại");
                return View(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            if (string.IsNullOrEmpty(languageId))
                languageId = "vi";
            var result = await _productApiClient.GetById(id, languageId);

            //lấy ra danh sách hình
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Image(int id)
        {
            if (id > 0)
            {
                var files = await _productApiClient.GetImages(id);
                if (files.Count > 0)
                {
                    return File(files.FirstOrDefault().FileContent, "image/jpeg");
                }
            }
            string path = Path.Combine(_env.WebRootPath, "css", "images");
            var defaultImage = System.IO.File.ReadAllBytes($"{path}/default.png");
            return File(defaultImage, "image/jpeg");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var roleAssignRequest = await GetCategoryAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetCategoryAssignRequest(request.Id);

            return View(roleAssignRequest);
        }

        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var productObj = await _productApiClient.GetById(id, languageId);
            var categories = await _categoryApiClient.GetAll(languageId);
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var role in categories)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Selected = productObj.Categories.Contains(role.Name)
                });
            }
            return categoryAssignRequest;
        }
    }
}