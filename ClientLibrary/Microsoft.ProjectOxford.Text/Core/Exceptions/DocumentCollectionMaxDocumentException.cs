using System;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Exception thrown when the maximum number of documents in a collection is exceeded.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentCollectionMaxDocumentException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentCollectionMaxDocumentException"/> class.
        /// </summary>
        /// <param name="documentCount">The document count.</param>
        /// <param name="maximumDocumentCount">The maximum document count allowed.</param>
        public DocumentCollectionMaxDocumentException(int documentCount, int maximumDocumentCount)
        {
            this.DocumentCount = documentCount;
            this.MaximumDocumentCount = maximumDocumentCount;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the document count.
        /// </summary>
        /// <value>
        /// The document count.
        /// </value>
        public int DocumentCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum document count.
        /// </summary>
        /// <value>
        /// The maximum document count.
        /// </value>
        public int MaximumDocumentCount
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
                return string.Format("Document collection has [0} documents. The maximum number of documents for a collection is {1}.", DocumentCount, MaximumDocumentCount);
            }
        }

        #endregion Properties
    }
}
