﻿using DotNetTrainningBatch3.MvcApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace DotNetTrainningBatch3.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex(int pageNo = 1, int pageSize = 10)
        {
            BlogResponseModel responseModel = new();

            var apiResponse = await _httpClient.GetAsync($"/api/blog/{pageNo}/{pageSize}");
            if (apiResponse.IsSuccessStatusCode)
            {
                var jsonString = await apiResponse.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<BlogResponseModel>(jsonString)!;
            }
            return View("BlogIndex", responseModel);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogSave(BlogModel blog)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
            await _httpClient.PostAsync("api/blog", content);

            return Redirect("/Blog");
        }

        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var response = await _httpClient.GetAsync($"api/Blog/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/Blog");
            }

            var jsonStr = await response.Content.ReadAsStringAsync();
            BlogModel model = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
            return View("BlogEdit", model);
        }

        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(blog), Encoding.UTF8, Application.Json);
            await _httpClient.PutAsync($"api/Blog/{id}", content);

            return Redirect("/Blog");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            await _httpClient.DeleteAsync($"api/Blog/{id}");

            return Redirect("/Blog");
        }
    }
}
