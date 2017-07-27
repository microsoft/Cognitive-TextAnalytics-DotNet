using System;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Exception thrown the maximum size of a document is exceeded.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentMaxSizeException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentMaxSizeException"/> class.
        /// </summary>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="documentSize">Size of the document.</param>
        /// <param name="maximumDocumentSize">Maximum size of the document.</param>
        public DocumentMaxSizeException(string documentId, int documentSize, int maximumDocumentSize)
        {
            this.DocumentId = documentId;
            this.DocumentSize = documentSize;
            this.MaximumDocumentSize = maximumDocumentSize;
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
        /// Gets or sets the maximum size of the document.
        /// </summary>
        /// <value>
        /// The maximum size of the document.
        /// </value>
        public int MaximumDocumentSize
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
                return string.Format("Document {0} is {1} bytes. Documents have a maximum size of {2} bytes.", DocumentId, DocumentSize, MaximumDocumentSize);
            }
        }

        #endregion Properties
    }
}
