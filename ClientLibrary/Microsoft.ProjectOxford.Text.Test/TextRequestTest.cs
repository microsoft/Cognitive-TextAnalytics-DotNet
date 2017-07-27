using Microsoft.ProjectOxford.Text.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the TextRequest class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextRequest" />
    [TestClass]
    public class TextRequestTest
    {
        #region Test Methods

        /// <summary>
        /// Unit test of the Validate method for the minimum number of documents in a collection.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMinDocumentException))]
        public void ValidateTest_MinDocumentCollectionCount()
        {
            var request = new MockRequest();
            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum number of documents in a collection.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMaxDocumentException))]
        public void ValidateTest_MaxDocumentCollectionCount()
        {
            var request = new MockRequest();

            for (int i = 1; i <= 1001; i++)
            {
                request.Documents.Add(new Document() { Id = i.ToString(), Text = "test test test" });
            }

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum size of a document collections.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMaxSizeException))]
        public void ValidateTest_MaxDocumentCollectionSize()
        {
            var text = new string('*', 10240);

            var request = new MockRequest();

            for (int i = 1; i <= 1000; i++)
            {
                request.Documents.Add(new Document() { Id = i.ToString(), Text = text });
            }

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for document identifier.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentIdRequiredException))]
        public void ValidateTest_DocumentIdRequired()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Text = "doc1" });

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for duplicate document identifiers.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionDuplicateIdException))]
        public void ValidateTest_DuplicateDocumentId()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "01", Text = "doc1" });
            request.Documents.Add(new Document() { Id = "01", Text = "doc2" });

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for the minimum document size.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentMinSizeException))]
        public void ValidateTest_MinDocumentSize()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "001" });

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum document size.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentMaxSizeException))]
        public void ValidateTest_MaxDocumentSize()
        {
            var text = new string('*', 10241);

            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "001", Text = text });

            request.Validate();
        }

        #endregion Test Methods
    }

    internal class MockRequest : TextRequest { }
}
