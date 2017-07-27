using System;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Exception thrown when the minimum document size is not met.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentMinSizeException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentMinSizeException"/> class.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="documentSize">Size of the document.</param>
        /// <param name="minimumDocumentSize">Minimum size of the document.</param>
        public DocumentMinSizeException(string documentId, int documentSize, int minimumDocumentSize)
        {
            this.DocumentId = documentId;
            this.DocumentSize = documentSize;
            this.MinimumDocumentSize = minimumDocumentSize;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        public string DocumentId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the size of the document.
        /// </summary>
        /// <value>
        /// The size of the document.
        /// </value>
        public int DocumentSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the minimum size of the document.
        /// </summary>
        /// <value>
        /// The minimum size of the document.
        /// </value>
        public int MinimumDocumentSize
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
                return string.Format("Document {0} is {1} bytes. Documents have a minimum size of {2} bytes.", DocumentId, DocumentSize, MinimumDocumentSize);
            }
        }

        #endregion Properties
    }
}
