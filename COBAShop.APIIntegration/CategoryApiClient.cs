using COBAShop.Utilities.Constants;
using COBAShop.ViewModels.Catalog.Categories;
using COBAShop.ViewModels.Comon;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace COBAShop.APIIntegration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<bool> CreateCategory(CategoryCreateRequest request)
        {
            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var session = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.Status.ToString()), "status");
            requestContent.Add(new StringContent(request.SortOrder.ToString()), "sortOrder");
            requestContent.Add(new StringContent(request.ParentId.ToString()), "parentId");

            requestContent.Add(new StringContent(request.IsShowOnHome.ToString()), "isShowOnHome");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(languageId) ? "" : languageId.ToString()), "languageId");

            var response = await client.PostAsync($"/api/categories/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            return await GetListAsync<CategoryVm>(
                  $"/api/categories?languageId=" + languageId
                );
        }

        public async Task<PagedResult<CategoryVm>> GetAllPagings(GetCategoryPagingRequest request)
        {
            return await GetAsync<PagedResult<CategoryVm>>(
                 $"/api/categories/paging?pageIndex={request.PageIndex}" +
                  $"&pageSize={request.PageSize}" +
                  $"&keyword={request.Keyword}&languageId={request.LanguageId}"
               );
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            return await GetAsync<CategoryVm>($"/api/categories/{id}/{languageId}");
        }

        public async Task<bool> UpdateCategory(CategoryUpdateRequest request)
        {
            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.Status.ToString()), "status");
            requestContent.Add(new StringContent(request.SortOrder.ToString()), "sortOrder");
            requestContent.Add(new StringContent(request.ParentId.ToString()), "parentId");

            requestContent.Add(new StringContent(request.IsShowOnHome.ToString()), "isShowOnHome");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(languageId) ? "" : languageId.ToString()), "languageId");

            var response = await client.PutAsync($"/api/categories/" + request.Id, requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await Delete($"/api/categories/" + id);
        }
    }
}