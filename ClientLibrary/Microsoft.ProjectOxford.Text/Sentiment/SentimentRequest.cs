using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Core.Exceptions;

namespace Microsoft.ProjectOxford.Text.Sentiment
{
    /// <summary>
    /// Request for interacting with the Text Analytics sentiment analysis API.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextRequest" />
    public class SentimentRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentRequest"/> class.
        /// </summary>
        public SentimentRequest()
        {
            this.Documents = new List<IDocument>();
            this.ValidLanguages = new List<string>() { "en", "es", "fr", "pt" };
        }

        #endregion  Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the valid languages.
        /// </summary>
        /// <value>
        /// The valid languages.
        /// </value>
        public List<string> ValidLanguages
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <exception cref="Microsoft.ProjectOxford.Text.Core.Exceptions.LanguageNotSupportedException"></exception>
        public override void Validate()
        {
            base.Validate();

            if(this.ValidLanguages != null && this.ValidLanguages.Count >0)
            {
                foreach(var document in this.Documents)
                {
                    var sentimentDocument = document as SentimentDocument;

                    if (!string.IsNullOrEmpty(sentimentDocument.Language))
                    {
                        if (!this.ValidLanguages.Contains(sentimentDocument.Language))
                            throw new LanguageNotSupportedException(sentimentDocument.Language, this.ValidLanguages);
                    }
                }
            }
        }

        #endregion Methods
    }
}
