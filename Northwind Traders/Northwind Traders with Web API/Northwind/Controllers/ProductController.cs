using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Northwind.Models;
using NuGet.Packaging.Signing;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Northwind.Controllers;

public class ProductController : Controller
{
    private readonly string baseUrl;
    private readonly string appJson;

    public ProductController(IConfiguration config)
    {
        baseUrl = config.GetValue<string>("BaseUrl");
        appJson = config.GetValue<string>("AppJson");
    }

    [AllowAnonymous]
    // GET: ProductController
    public async Task<ActionResult> Index(int id = 1)
    {
        try
        {
            var categories = await GetCategoriesAsync();
            ViewBag.Category = new SelectList(categories, "categoryId", "categoryName", id);
            ViewBag.categoryName = categories.FirstOrDefault(c => c.categoryId == id).  categoryName;
            
            var products = await GetProductAsync(id);
           
            return View(products);
        }
        catch(Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            return View("Error", new ErrorViewModel());
        }
    }

    private void ConfigClient(HttpClient client)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(appJson));
        client.BaseAddress = new Uri(baseUrl);
    }


    private async Task<List<Category>> GetCategoriesAsync()
    {
        using (var client = new HttpClient())
        {
            ConfigClient(client);

            var response = await client.GetAsync("categories");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Category>>(json);
            }
            else
            {
                throw new Exception($"Failed to retrieve categories. Status code: {response.StatusCode}");
            }
        }
    }
    private async Task<List<Product>> GetProductAsync(int CategoryId)
    {
        using (var client = new HttpClient())
        {
            ConfigClient(client);
            var response = await client.GetAsync($"products?categoryId={CategoryId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
            else
            {
                throw new Exception($"Failed to retrieve products. Status code: {response.StatusCode}");
            }
        }
    }

    [Authorize]
    // GET: ProductController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        try
        {
            var categoryId = 1;
            var products = await GetProductAsync(categoryId);

            var product = products.FirstOrDefault(p => p.productId == id);

            if (product == null)
            {
                ViewBag.ErrorMessage = $"Product id {id} not found";
                return View("Error", new ErrorViewModel());
            }

            var categories = await GetCategoriesAsync();
            ViewBag.CategoryName = categories.FirstOrDefault(c => c.categoryId == product.categoryId)?.categoryName;
            ViewBag.Title = product.productName;
            
            return View(product);
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
            return View("Error", new ErrorViewModel());
        }
    }
}
