using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebUI.Dtos.FeatureDtos;
using ApiProjeKampi.WebUI.Dtos.CategoryDto;
using ApiProjeKampi.WebUI.Dtos.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKampi.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiProjeContext _apiProjeContext;

        public AdminController(IHttpClientFactory httpClientFactory, ApiProjeContext apiProjeContext)
        {
            _httpClientFactory = httpClientFactory;
            _apiProjeContext = apiProjeContext;
        }

        #region Category

        #region CategoryList
        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Categories");
            if (responsemessage.IsSuccessStatusCode)
            {
                var JsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(JsonData);
                return View(values);
            }
            return View();
        }
        #endregion

        #region CategoryCreate

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7233/api/Categories", stringContent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }

        #endregion

        #region CategoryDelete

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7233/api/Categories?id=" + id);
            return RedirectToAction("CategoryList");
        }

        #endregion

        #region CategoryEditAndUpdate

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Categories/GetCategoryById?id=" + id);
            var jsonData = await responsemessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdCategoryDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://localhost:7233/api/Categories", stringContent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }

        #endregion

        #endregion

        #region Product

        #region ProductList
        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Products/ProductListWithCategory");
            if (responsemessage.IsSuccessStatusCode)
            {
                var JsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductListWithCategoryDto>>(JsonData);
                return View(values);
            }
            return View();
        }

        #endregion

        #region ProductCreate
        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.CategoryList = _apiProjeContext.Categories.Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.Name
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductWithCategoryDto createProductWithCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createProductWithCategoryDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7233/api/Products/CreateProductWithCategory", stringContent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            else
            {
                ViewBag.CategoryList = _apiProjeContext.Categories.Select(x => new SelectListItem
                {
                    Value = x.CategoryId.ToString(),
                    Text = x.Name
                }).ToList();
                return View();
            }
        }

        #endregion

        #region ProductDelete
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync("https://localhost:7233/api/Products?id=" + id);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }

        #endregion

        #region ProductEditAndUpdate
        public async Task<IActionResult> EditProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Products/GetByIdProduct?id=" + id);
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdProductDto>(jsonData);

                var getCategory = await client.GetAsync("https://localhost:7233/api/Categories");
                var CategoryJsonData = await getCategory.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(CategoryJsonData);

                List<SelectListItem> selectListItems = (from x in categories
                                                        select new SelectListItem
                                                        {
                                                            Value = x.CategoryId.ToString(),
                                                            Text = x.Name,
                                                            Selected = x.Name == value.Name
                                                        }).ToList();
                ViewBag.CategoryList = selectListItems;
                return View(value);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductWithCategoryDto updateProductWithCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(updateProductWithCategoryDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://localhost:7233/api/Products/UpdateProductWithCategory", stringContent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }
        #endregion



        #endregion

        #region Feature

        #region FeatureList

        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Features");
            var JsonData = await responsemessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(JsonData);
            return View(values);
        }

        #endregion

        #region FeatureCreate

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7233/api/Features", stringContent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View();
        }

        #endregion

        #region FeatureDelete

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync("https://localhost:7233/api/Features?id=" + id);
            if (responsemessage.IsSuccessStatusCode)
                return RedirectToAction("FeatureList");
            return View();
        }

        #endregion

        #region FeatureEditAndUpdate

        [HttpGet]
        public async Task<IActionResult> EditFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7233/api/Features/GetByIdFeature?id=" + id);
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdFeatureDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://localhost:7233/api/Features", stringContent);

            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View(updateFeatureDto);
        }

        #endregion

        #endregion
    }
}
