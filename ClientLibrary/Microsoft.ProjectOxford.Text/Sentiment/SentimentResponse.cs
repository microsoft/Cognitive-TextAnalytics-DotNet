using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;

namespace Microsoft.ProjectOxford.Text.Sentiment
{
    /// <summary>
    /// Response from the Text Analytics sentiment analysis API.
    /// </summary>
    public class SentimentResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentResponse"/> class.
        /// </summary>
        public SentimentResponse()
        {
            this.Documents = new List<SentimentDocumentResult>();
            this.Errors = new List<DocumentError>();
        }

        #endregion  Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>
        /// The documents.
        /// </value>
        [JsonProperty("documents")]
        public List<SentimentDocumentResult> Documents { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        [JsonProperty("errors")]
        public List<DocumentError> Errors { get; set; }

        #endregion Properties
    }
}
