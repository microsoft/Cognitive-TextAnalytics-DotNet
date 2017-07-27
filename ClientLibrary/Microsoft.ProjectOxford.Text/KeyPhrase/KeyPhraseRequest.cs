using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.KeyPhrase
{
    /// <summary>
    /// Request for interacting with the Text Analytics key phrase detection API.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextRequest" />
    public class KeyPhraseRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPhraseRequest"/> class.
        /// </summary>
        public KeyPhraseRequest()
        {
            this.Documents = new List<IDocument>();
            this.ValidLanguages = new List<string>() { "en", "es", "de", "ja", "fr" };
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

            if (this.ValidLanguages != null && this.ValidLanguages.Count > 0)
            {
                foreach (var document in this.Documents)
                {
                    var keyPhraseDocument = document as KeyPhraseDocument;

                    if (!this.ValidLanguages.Contains(keyPhraseDocument.Language))
                        throw new LanguageNotSupportedException(keyPhraseDocument.Language, this.ValidLanguages);
                }
            }
        }

        #endregion Methods
    }
}
