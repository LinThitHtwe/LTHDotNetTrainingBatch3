using DotNetTrainningBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainningBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
       public async Task Run()
       {
            await Read();
            await ReadJsonPlaceholder();
       }

       private async Task Read()
       {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7028/api/Blog");
            if(response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonString);
                Console.WriteLine("-----------");

                //JsonConvert.SerializeObject() // C# object to JSON
                //JsonConvert.DeserializeObject() // JSON to C# object

                List<Blog> blogs = JsonConvert.DeserializeObject<List<Blog>>(jsonString)!;
                foreach(Blog blog in blogs)
                {
                    Console.WriteLine("Id : " + blog.Id);
                    Console.WriteLine("Title : " + blog.Title);
                    Console.WriteLine("Author : " + blog.Author);
                }
            
            }
            //Console.WriteLine(response.IsSuccessStatusCode);
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
