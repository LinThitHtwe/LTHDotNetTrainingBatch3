using DotNetTrainningBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private readonly string _apiUrl = "https://localhost:7028/api/Blog";

        public async Task Run()
        {
            
            //await GetById("7");
            //await Create("restClient","7","RestClientttt");
            await Read();
            //await Update("5","Updated", "UpdatedByRestClient");
            //await GetById("5");
            //await Delete("7");
        }

        private async Task Read()
        {
            RestRequest request = new RestRequest(_apiUrl,Method.Get);
            RestClient restClient = new RestClient();
            RestResponse restResponse = await restClient.ExecuteAsync(request);
            if (restResponse.IsSuccessStatusCode)
            {
                string json = restResponse.Content!;
                List<Blog> blogs = JsonConvert.DeserializeObject<List<Blog>>(json)!;
                foreach (Blog blog in blogs)
                {
                    Console.WriteLine(blog.Title);
                    Console.WriteLine(blog.Author);
                    Console.WriteLine(blog.Id);
                }
            }
            else
            {
                Console.WriteLine(restResponse.Content);
            }
        }

        private async Task GetById(string id)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest($"{_apiUrl}/{id}",Method.Get);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            if (restResponse.IsSuccessStatusCode)
            {
                string json = restResponse.Content!;
                Blog blog = JsonConvert.DeserializeObject<Blog>(json)!;
                Console.WriteLine(blog.Title);
                Console.WriteLine(blog.Author);
                Console.WriteLine(blog.Id);
            }
            else
            {
                Console.WriteLine(restResponse.Content);
            }

        }

        private async Task Create(string title, string id, string author)
        {
            Blog blog = new Blog()
            {
                Title = title,
                Author = author,
                Id = id
            };

            RestRequest restRequest = new RestRequest(_apiUrl,Method.Post);
            restRequest.AddJsonBody(blog);
            RestClient restClient = new RestClient();
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            if (restResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(restResponse.Content);
            }
            else
            {
                Console.WriteLine(restResponse.Content);
            }
        }

        private async Task Update(string id, string title, string author)
        {
            Blog blog = new Blog()
            {
                //Id = id,
                Title = title,
                Author = author,
            };
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest($"{_apiUrl}/{id}", Method.Put);
            restRequest.AddJsonBody(blog);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            if (restResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(restResponse.Content);
            }
            else
            {
                Console.WriteLine(restResponse.Content);
            }
        }

        private async Task Delete(string id)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest($"{_apiUrl}/{id}", Method.Delete);
            RestResponse restResponse = await restClient.ExecuteAsync(restRequest);
            if (restResponse.IsSuccessStatusCode)
            {
                Console.WriteLine(restResponse.Content);
            }
            else
            {
                Console.WriteLine(restResponse.Content);
            }
        }
    }
}
