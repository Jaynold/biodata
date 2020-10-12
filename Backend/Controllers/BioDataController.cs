using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using BioData.Data;
using BioData.DbRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BioData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiodataController : ControllerBase
    {
        private readonly IBioDataRepository _repository;
        private readonly IMapper _mapper;

        public BiodataController(IBioDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private static HttpClient GetHttpClient(string url)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task SetSeedData()
        {
            for (var index = 1; index < 15; index++)
            {
                string baseUrl = $"https://bio.tools/api/tool/?page={index}&format=json&collectionID=vib";
                //Have your using statements within a try/catch block
                try
                {
                    //We will now define your HttpClient with your first using statement which will use a IDisposable.
                    using (HttpClient client = new HttpClient())
                    {
                        //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                        using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                        {
                            //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                            using (HttpContent content = res.Content)
                            {
                                //Now assign your content to your data variable, by converting into a string using the await keyword.
                                var data = await content.ReadAsStringAsync();
                                //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                                if (data != null)
                                {
                                    var results = JObject.Parse(data);
                                    var bios = new List<Biodata>();
                                    var biolist = results["list"];
                                    for (int i = 0; i < ((IList)results["list"]).Count; i++)
                                        _repository.Add<Biodata>(_mapper.Map<Biodata>(biolist[i]));
                                    await _repository.SaveChangesAsync();
                                    Console.WriteLine($"Page {index} done");
                                }
                                else
                                {
                                    Console.WriteLine("NO Data----------");
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception Hit------------");
                    Console.WriteLine(exception);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "All", string property = "none")
        {
            // await SetSeedData();
            var bios = await _repository.GetAllBioDataAsync(search, property);
            if (bios == null)
            {
                return NotFound("Couldn't find any bios!");
            }
            return Ok(bios);
        }

        [HttpGet("{bioid}")]
        public async Task<IActionResult> Get(string bioid)
        {
            var bio = await _repository.GetBioDataAsync(bioid);
            if (bio == null)
            {
                return NotFound($"Couldn't find a bio named \"{bioid}\"");
            }
            return Ok(bio);
        }
    }
}