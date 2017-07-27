using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Document to submit to the Text Analytics API for analysis.
    /// </summary>
    public class Document : IDocument
    {
        #region Properties

        /// <summary>
        /// Gets or sets the document's identifier.
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
        /// Gets the size of the document in bytes.
        /// </summary>
        /// <value>
        /// The size of the document in bytes.
        /// </value>
        [JsonIgnore]
        public int Size
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this.Text))
                {
                    return 0;
                }
                else
                {
                    return Encoding.UTF8.GetByteCount(this.Text);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text of the document.
        /// </summary>
        /// <value>
        /// The text of the document.
        /// </value>
        [JsonProperty("text")]
        public string Text
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            this.Text = this.Text.Replace("\"", "");
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Text;
        }

        #endregion Methods
    }
}
