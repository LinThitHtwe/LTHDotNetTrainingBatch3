using DotNetTrainningBatch3.BirdWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetTrainningBatch3.BirdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly string _url = "https://burma-project-ideas.vercel.app/birds";

        [HttpGet]
        public async Task<IActionResult> GetBirds()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<BirdData> receivedBirds = JsonConvert.DeserializeObject<List<BirdData>>(json);

                // List<BirdView> responseBirds = receivedBirds.Select(bird => new BirdView
                //{
                //    BirdId = bird.Id,
                //     BirdName = bird.BirdMyanmarName,
                //     Desp = bird.Description,
                //     PhotoUrl = $"https://burma-project-ideas.vercel.app/{bird.ImagePath}"
                // }).ToList();
                List<BirdView> responseBirds = new List<BirdView>();
                foreach(BirdData birdData in receivedBirds)
                {
                    BirdView birdView = ChangeToBirdView(birdData);
                    responseBirds.Add(birdView);
                }
                return Ok(responseBirds);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBridById(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BirdData birdData = JsonConvert.DeserializeObject<BirdData>(json)!;

                //var birdView = new BirdView
                //{
                //    BirdId = birdData.Id,
                //    BirdName = birdData.BirdMyanmarName,
                //    Desp = birdData.Description,
                //    PhotoUrl = $"https://burma-project-ideas.vercel.app/{birdData.ImagePath}"
                //};
                var birdView = ChangeToBirdView(birdData);
                return Ok(birdView);
            }
            else
            {
                return BadRequest();
            }
        }

        private BirdView ChangeToBirdView(BirdData birdData)
        {
            var birdView = new BirdView
            {
                BirdId = birdData.Id,
                BirdName = birdData.BirdMyanmarName,
                Desp = birdData.Description,
                PhotoUrl = $"https://burma-project-ideas.vercel.app/{birdData.ImagePath}"
            };
            return birdView;
        }
    }

}
