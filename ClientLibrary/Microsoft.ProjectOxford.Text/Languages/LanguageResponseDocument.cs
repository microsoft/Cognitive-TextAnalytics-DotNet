using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.ProjectOxford.Text.Language
{
    /// <summary>
    /// Document from the Text Analytics language identification API.
    /// </summary>
    public class LanguageResponseDocument
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageResponseDocument"/> class.
        /// </summary>
        public LanguageResponseDocument()
        {
            this.DetectedLanguages = new List<DetectedLanguage>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the document.
        /// </summary>
        /// <value>
        /// The identifier of the document.
        /// </value>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the detected languages in the document.
        /// </summary>
        /// <value>
        /// The detected languages in the document.
        /// </value>
        [JsonProperty("detectedLanguages")]
        public List<DetectedLanguage> DetectedLanguages
        {
            get;
            set;
        }

        #endregion Properties
    }
}
