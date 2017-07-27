using Newtonsoft.Json;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Error returned by the Text Analytics API for a document.
    /// </summary>
    public class DocumentError
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier of the document containing the error.
        /// </summary>
        /// <value>
        /// The identifier of the doucment.
        /// </value>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }

        #endregion Properties
    }
}
