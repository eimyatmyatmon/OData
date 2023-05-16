/*using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using ODataTutorial.Models;

namespace ODataTutorial.Controllers
{
    [ApiController]
    [Route("v1/[http]")]
    public class HttpController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        static async Task Test()
        {
            using (var client = new HttpClient())
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("http://localhost:5146/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        [HttpGet]
        [Route("Test")]
        static async Task<Note> Get(String path)
        {
            Note note = null;
            HttpResponseMessage response = await client.GetAsync("http://localhost:5146/v1/Notes");
            if (response.IsSuccessStatusCode)
            {
                note = await response.Content.ReadAsAsync<Note>();
            }
            return note;
        }
    }
}*/