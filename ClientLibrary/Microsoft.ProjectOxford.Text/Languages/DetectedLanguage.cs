using Newtonsoft.Json;

namespace Microsoft.ProjectOxford.Text.Language
{
    /// <summary>
    /// Language detected by the Text Analytics API.
    /// </summary>
    public class DetectedLanguage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the language.
        /// </summary>
        /// <value>
        /// The name of the lanuage.
        /// </value>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ISO 639-1 name of the language.
        /// </summary>
        /// <value>
        /// The ISO 639-1 name of the language.
        /// </value>
        [JsonProperty("iso6391Name")]
        public string Iso639Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the confidence score of the identified language.
        /// </summary>
        /// <value>
        /// The confidence score of the identified language..
        /// </value>
        [JsonProperty("score")]
        public float Score
        {
            get;
            set;
        }

        #endregion Properties
    }
}
