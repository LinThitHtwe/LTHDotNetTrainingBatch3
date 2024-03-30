using DotNetTrainningBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample2
    {
        public async Task Run()
        {
            await Read();
            await ReadJsonPlaceholder();
        }

        private async Task Read()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7131/api/Blog");
            //HttpResponseMessage response2 = client.GetAsync("https://localhost:7131/api/Blog").Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject() // C# object to JSON
                //JsonConvert.DeserializeObject() // JSON to C# object

                List<Blog> blogs = JsonConvert.DeserializeObject<List<Blog>>(jsonStr)!;
                //blogs.Add(new BlogModel()
                //{

                //});
                //BlogModel[] blogs2 = JsonConvert.DeserializeObject<BlogModel[]>(jsonStr)!;
                //blogs2[0] = 

                foreach (Blog blog in blogs)
                {
                    Console.WriteLine(blog.Title);
                    Console.WriteLine(blog.Author);
                    Console.WriteLine(blog.Id);
                }

                //foreach (BlogModel blog in blogs2)
                //{
                //    Console.WriteLine(blog.BlogId);
                //    Console.WriteLine(blog.BlogTitle);
                //    Console.WriteLine(blog.BlogAuthor);
                //    Console.WriteLine(blog.BlogContent);
                //}
            }

        }

        private async Task ReadJsonPlaceholder()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject() // C# object to JSON
                //JsonConvert.DeserializeObject() // JSON to C# object

                List<JsonPlaceholderModel> lst = JsonConvert.DeserializeObject<List<JsonPlaceholderModel>>(jsonStr)!;

                foreach (JsonPlaceholderModel item in lst)
                {
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                    Console.WriteLine(item.userId);
                    Console.WriteLine(item.id);
                }
            }
        }
    }
}
