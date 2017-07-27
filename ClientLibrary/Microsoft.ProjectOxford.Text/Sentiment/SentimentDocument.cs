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
    /// Document to submit to the Text Analytics API for sentiment analysis.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.Document" />
    /// /// <seealso cref="Microsoft.ProjectOxford.Text.Core.IDocument" />
    public class SentimentDocument : Document, IDocument
    {
        #region Properties

        /// <summary>
        /// Gets or sets the language the text is in.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [JsonProperty("language")]
        public string Language { get; set; }

        #endregion Properties
    }
}
