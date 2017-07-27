using System;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Exception thrown when duplication document id's are encountered.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentCollectionDuplicateIdException :  Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentCollectionDuplicateIdException"/> class.
        /// </summary>
        /// <param name="documentId">The identifier of the document containing the exception.</param>
        public DocumentCollectionDuplicateIdException(string documentId)
        {
            this.DocumentId = documentId;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier containing the exception.
        /// </value>
        public string DocumentId
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
                return string.Format("Multiple documents with the id {0} were found. Document id's must be unique per document.", this.DocumentId);
            }
        }

        #endregion Properties
    }
}
