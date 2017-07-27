using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when an unspported language is encountered.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class LanguageNotSupportedException : Exception
    { 
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageNotSupportedException"/> class.
        /// </summary>
        /// <param name="invalidLanguage">The invalid language.</param>
        /// <param name="validLanguages">The valid languages.</param>
        public LanguageNotSupportedException(string invalidLanguage, List<string> validLanguages)
        {
            if (validLanguages == null || validLanguages.Count == 0)
                throw new ArgumentNullException("A list of valid languages must be supplied.");

            this.InvalidLanguage = invalidLanguage;
            this.ValidLanguages = validLanguages;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the invalid language.
        /// </summary>
        /// <value>
        /// The invalid language.
        /// </value>
        public string InvalidLanguage
        {
            get;
            set;
        }

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

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Format("Language {0} is not supported. Supported languages are:"));

                foreach (var language in this.ValidLanguages)
                    sb.AppendLine(language);

                return sb.ToString();
            }
        }

        #endregion Properties
    }
}
