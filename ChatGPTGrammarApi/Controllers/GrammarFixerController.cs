using ChatGPTGrammarApi.Models.Requests;
using ChatGPTGrammarApi.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSC.CSharp.Library.ChatGPT;

namespace ChatGPTGrammarApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrammarFixerController : ControllerBase
    {
        private readonly ILogger<GrammarFixerController> _logger;
        private IConfiguration _configuration;

        public GrammarFixerController(ILogger<GrammarFixerController> logger, 
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// Versions this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        [HttpGet("version")]
        public string Version()
        {
            return _configuration["VERSION"];
        }

        /// <summary>
        /// Fixes the grammar.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        [HttpPost("fixGrammar")]
        public async Task<IActionResult> FixGrammar([FromBody] SentencePayloadRequest request)
        {
            // retrieve ai key from configuration
            var openAiKey = _configuration["OPENAI_API_KEY"];

            if (openAiKey == null)
                return NotFound("key not found");

            var openai = new ChatGpt(openAiKey);

            var fixedSentence = await openai.Ask(
                $"Fix the following sentence for spelling and grammar: {request.RawSentence}");
            if (fixedSentence == null)
                return NotFound("Unable to call ChatGPT.");

            return Ok(new SentencePayloadResponse() { FixedSentence = fixedSentence });
        }
    }
}