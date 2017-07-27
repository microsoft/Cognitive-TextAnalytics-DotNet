using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Request for interacting with the Text Analytics API's. This is an abstract class.
    /// </summary>
    public abstract class TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRequest"/> class.
        /// </summary>
        public TextRequest()
        {
            this.Documents = new List<IDocument>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the documents associated with the request.
        /// </summary>
        /// <value>
        /// The documents associated with the request.
        /// </value>
        [JsonProperty("documents")]
        public virtual List<IDocument> Documents
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <exception cref="DocumentCollectionMinDocumentException">Thrown when the minimum number of documents is not met.</exception>
        /// <exception cref="DocumentCollectionMaxDocumentException">Thrown when the maximum number of documents is exceeded.</exception>
        /// <exception cref="DocumentIdRequiredException">Thrown when a document id is not provided.</exception>
        /// <exception cref="DocumentCollectionDuplicateIdException">Thrown when the same id is used on multiple documents.</exception>
        /// <exception cref="DocumentMinSizeException">Thrown when the minimum size of a document is not met.</exception>
        /// <exception cref="DocumentMaxSizeException">Thrown when the maximum size of a document is exceeded.</exception>
        /// <exception cref="DocumentCollectionMaxSizeException">Thrown when the maximum size of all document is exceeded.</exception>
        public virtual void Validate()
        {
            //must have at least one document
            if (this.Documents == null || this.Documents.Count <= 0)
            {
                throw new DocumentCollectionMinDocumentException(0, 1);
            }

            //must not have more than 1000 documents
            if (this.Documents.Count > 1000)
            {
                throw new DocumentCollectionMaxDocumentException(this.Documents.Count, 1000);
            }

            var collectionSize = 0;
            var documentIds = new List<string>();

            foreach(var document in this.Documents)
            {
                //document must have an id
                if (string.IsNullOrWhiteSpace(document.Id))
                {
                    throw new DocumentIdRequiredException();
                }

                //document id's must be unique
                if (documentIds.Contains(document.Id))
                {
                    throw new DocumentCollectionDuplicateIdException(document.Id);
                }
                else
                {
                    documentIds.Add(document.Id);
                }

                //document size must be greater than 0 and less than or equal to 10KB
                if (document.Size <= 0)
                {
                    throw new DocumentMinSizeException(document.Id, document.Size, 1);
                }

                if (document.Size > 10240)
                {
                    throw new DocumentMaxSizeException(document.Id, document.Size, 10240);
                }

                collectionSize = collectionSize + document.Size;
            }

            //total size of all documents cannot exceed 1MB
            if (collectionSize > 1048576)
            {
                throw new DocumentCollectionMaxSizeException(collectionSize, 1048576);
            }
        }

        #endregion Methods
    }
}
