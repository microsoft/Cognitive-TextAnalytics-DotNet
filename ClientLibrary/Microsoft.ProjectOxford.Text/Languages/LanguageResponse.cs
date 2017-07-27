using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.ProjectOxford.Text.Language
{
    /// <summary>
    /// Response from the Text Analytics language identification API.
    /// </summary>
    public class LanguageResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageResponse"/> class.
        /// </summary>
        public LanguageResponse()
        {
            this.Documents = new List<LanguageResponseDocument>();
            this.Errors = new List<DocumentError>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        /// <value>
        /// The documents.
        /// </value>
        [JsonProperty("documents")]
        public List<LanguageResponseDocument> Documents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        [JsonProperty("errors")]
        public List<DocumentError> Errors
        {
            get;
            set;
        }

        #endregion Properties
    }
}
