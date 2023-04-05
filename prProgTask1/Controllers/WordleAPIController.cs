using Microsoft.AspNetCore.Mvc;
using prProgTask1.Models;

namespace prProgTask1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordleAPIController : ControllerBase
    {
        private readonly ILogger<WordleAPIController> _logger;
        public WordleAPIController(ILogger<WordleAPIController> logger)
        {
            _logger = logger;
        }
        [HttpPost("GetDBUsers")]
        public void GetDBUsers()
            {
            APIModel.LoadUsers();
            }
        [HttpGet("GetWords")]
        public Task<List<string>> GetWord(string word)
        {
            return APIModel.GetWords(word);
        }     
    }
}