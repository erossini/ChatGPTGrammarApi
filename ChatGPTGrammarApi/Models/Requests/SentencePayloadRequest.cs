using System.Text.Json.Serialization;

namespace ChatGPTGrammarApi.Models.Requests
{
    /// <summary>
    /// Class SentencePayloadRequest.
    /// </summary>
    public class SentencePayloadRequest
    {
        /// <summary>
        /// Gets or sets the raw sentence.
        /// </summary>
        /// <value>The raw sentence.</value>
        [JsonPropertyName("rawSentence")]
        public string? RawSentence { get; set; }
    }
}