using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.KeyPhrase
{
    /// <summary>
    /// Document to submit to the Text Analytics API for key phrase detection.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.Document" />
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.IDocument" />
    public class KeyPhraseDocument : Document, IDocument
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
