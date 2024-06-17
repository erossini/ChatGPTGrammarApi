using System.Text.Json.Serialization;

namespace ChatGPTGrammarApi.Models.Responses
{
    /// <summary>
    /// Class SentencePayloadResponse.
    /// </summary>
    public class SentencePayloadResponse
    {
        /// <summary>
        /// Gets or sets the fixed sentence.
        /// </summary>
        /// <value>The fixed sentence.</value>
        [JsonPropertyName("fixedSentence")]
        public string? FixedSentence { get; set; }
    }
}