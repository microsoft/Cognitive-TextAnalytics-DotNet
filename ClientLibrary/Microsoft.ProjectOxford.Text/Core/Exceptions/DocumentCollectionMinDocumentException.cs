using System;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Exception thrown when a collection does not have the minimum number of documents.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentCollectionMinDocumentException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentCollectionMinDocumentException"/> class.
        /// </summary>
        /// <param name="documentCount">The dcount of documents in the collection.</param>
        /// <param name="MinimumDocumentCount">The minimum number of documents in a collection.</param>
        public DocumentCollectionMinDocumentException(int documentCount, int MinimumDocumentCount)
        {
            this.DocumentCount = documentCount;
            this.MinimumDocumentCount = MinimumDocumentCount;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the count of documents in the collection.
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
        /// Gets or sets the minimum number of documents in a collection.
        /// </summary>
        /// <value>
        /// The minimum document count.
        /// </value>
        public int MinimumDocumentCount { get; set; }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("Document collection has [0} documents. The minimum number of documents for a collection is {1}.", DocumentCount, MinimumDocumentCount);
            }
        }

        #endregion Properties
    }
}
