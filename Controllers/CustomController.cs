/*using Microsoft.AspNetCore.Mvc;
using ODataTutorial.Models;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.OData.Query;

namespace ODataTutorial.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CustomController : ControllerBase
    {
        [Route("CallApi")]
        [HttpGet]

        //Api call with Http Client
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5146"); // Set the base address of the API

                try
                {
                    using (var response = await client.GetAsync("/v1/Notes")) // Make an HTTP GET request to the specified endpoint
                    {
                        response.EnsureSuccessStatusCode(); // Ensure the request was successful

                        var responseContent = await response.Content.ReadAsStringAsync(); // Get the response content

                        return Ok(responseContent); // Return the response content as an HTTP OK result
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle exceptions here
                    return BadRequest();
                }
            }
        }
        [Route("CallApi")]
        [HttpPost]
        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] Note note)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5146"); // Set the base address of the API

                try
                {
                    var content = new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json"); // Create a JSON payload to send with the request

                    using (var response = await client.PostAsync("/v1/Notes", content)) // Make an HTTP POST request to the specified endpoint
                    {
                        response.EnsureSuccessStatusCode(); // Ensure the request was successful

                        var responseContent = await response.Content.ReadAsStringAsync(); // Get the response content

                        return Ok(responseContent); // Return the response content as an HTTP OK result
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle exceptions here
                    return BadRequest();
                }
            }
        }

         [Route("CallApi")]
         [HttpGet]
         //Api call with Bearer Token
         public async Task<IActionResult> Get()
         {
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri("https://api.openweathermap.org"); // Set the base address of the API

                 try
                 {
                     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "your_access_token_here");

                     using (var response = await client.GetAsync("/data/2.5/weather?lat=44.34&lon=10.99")) // Make an HTTP GET request to the specified endpoint
                     {
                         response.EnsureSuccessStatusCode(); // Ensure the request was successful

                         var responseContent = await response.Content.ReadAsStringAsync(); // Get the response content

                         return Ok(responseContent); // Return the response content as an HTTP OK result
                     }
                 }
                 catch (HttpRequestException ex)
                 {
                     // Handle exceptions here
                     return BadRequest();
                 }
             }
         }
          public Task<IActionResult> Post([FromBody] Note note)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             // using (var ctx = new ())
             // {
             using (var client = new HttpClient())
             {
                 client.Notes.Add(new Note()
                 {
                     Id = note.Id,
                     MessageNote = note.MessageNote

                 });

                 client.SaveChanges();
             }

             return Ok(client);
         }


    }
}    [HttpPost]
    public static async void Test()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:5146/v1/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Create a new note
            Note note = new Note
            {
                MessageNote = " ",
                CreatedBy = "emmm",
                UpdatedBy = "emmm"
            };

            string noteUrl = CreateNote(note);
            Console.WriteLine($"New note created at {noteUrl}");
        }
    }

    public static string CreateNote(Note note)
    {
        // Code that creates the note and gets the URL of the newly created note
        string url = "http://localhost:5146/v1/Notes"; // Replace with actual URL
        return url;
    }


    // Get the product
      note = await GetNoteAsync(url.PathAndQuery);
    ShowNote(note);

    // Update the product
    Console.WriteLine("Updating price...");
            note.CreatedBy = "EMMM";
            await UpdateNoteAsync(note);

    // Get the updated product
    note = await GetNoteAsync(url.PathAndQuery);
    ShowNote(note);

    // Delete the product
    var statusCode = await DeleteNoteAsync(note.Id);
    Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            Console.ReadLine();
        }*/