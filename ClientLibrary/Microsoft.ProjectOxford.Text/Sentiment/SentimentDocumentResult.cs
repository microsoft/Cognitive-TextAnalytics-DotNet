using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Sentiment
{
    /// <summary>
    /// Sentiment detected by the Text Analytics API.
    /// </summary>
    public class SentimentDocumentResult
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the document.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the score (0 = negative; 1 = positive).
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        [JsonProperty("score")]
        public float Score { get; set; }

        #endregion Properties
    }
}
