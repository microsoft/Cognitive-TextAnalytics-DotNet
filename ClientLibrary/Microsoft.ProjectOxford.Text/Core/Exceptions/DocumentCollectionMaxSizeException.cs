using System;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Exception thrown when the maximum size of a document collection is exceeded.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class DocumentCollectionMaxSizeException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentCollectionMaxSizeException"/> class.
        /// </summary>
        /// <param name="collectionSize">Size of the document collection.</param>
        /// <param name="maximumCollectionSize">Maximum size of the document collection.</param>
        public DocumentCollectionMaxSizeException(int collectionSize, int maximumCollectionSize)
        {
            this.CollectionSize = collectionSize;
            this.MaximumCollectionSize = maximumCollectionSize;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the size of the document collection.
        /// </summary>
        /// <value>
        /// The size of the document collection.
        /// </value>
        public int CollectionSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum size of the document collection.
        /// </summary>
        /// <value>
        /// The maximum size of the collection.
        /// </value>
        public int MaximumCollectionSize
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
                return string.Format("Document collection is {0} bytes. Document collections have a maximum size of {1} bytes.", CollectionSize, MaximumCollectionSize);
            }
        }

        #endregion Properties
    }
}
