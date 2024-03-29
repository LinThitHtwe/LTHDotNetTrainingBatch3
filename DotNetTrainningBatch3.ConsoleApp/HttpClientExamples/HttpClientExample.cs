using DotNetTrainningBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
       public async Task Run()
       {
            await Read();
            //await ReadJsonPlaceholder();
       }

       private async Task Read()
       {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7028/api/Blog");
            if(response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<Blog> blogs = JsonConvert.DeserializeObject<List<Blog>>(jsonString)!;
                foreach(Blog blog in blogs)
                {
                    Console.WriteLine("Id : " + blog.Id);
                    Console.WriteLine("Title : " + blog.Title);
                    Console.WriteLine("Author : " + blog.Author);
                }
            
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
       }

        private async Task GetById(string id)
        {
            string url = $"https://localhost:7131/api/Blog/{id}";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                Blog blog = JsonConvert.DeserializeObject<Blog>(jsonString)!;
                Console.WriteLine(blog.Title);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Create(string title,string id,string author)
        {
            Blog blog = new Blog()
            {
                Title = title,
                Author = author,
                Id = id,
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync($"https://localhost:7131/api/Blog", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        
        public async Task Update(string id, string title, string author)
        {
            Blog blog = new Blog()
            {
                Title = title,
                Author = author,
                Id = id,
            };
            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7131/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Delete(int id)
        {
            string url = $"https://localhost:7131/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
