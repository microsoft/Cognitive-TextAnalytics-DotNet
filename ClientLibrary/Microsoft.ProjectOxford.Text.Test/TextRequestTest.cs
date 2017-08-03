using Microsoft.ProjectOxford.Text.Core;
using System;
using Xunit;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the TextRequest class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextRequest" />
    public class TextRequestTest
    {
        /// <summary>
        /// Unit test of the Validate method for the minimum number of documents in a collection.
        /// </summary>
        [Fact]
        [Trait("Category", "Request Validation")]
        public void ValidateTest_MinDocumentCollectionCount()
        {
            var request = new MockRequest();
            Assert.Throws<DocumentCollectionMinDocumentException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum number of documents in a collection.
        /// </summary>
        [Fact]
        [Trait("Category", "Request Validation")]
        public void ValidateTest_MaxDocumentCollectionCount()
        {
            var request = new MockRequest();

            for (int i = 1; i <= 1001; i++)
            {
                request.Documents.Add(new Document() { Id = i.ToString(), Text = "test test test" });
            }

            Assert.Throws<DocumentCollectionMaxDocumentException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum size of a document collections.
        /// </summary>
        [Fact]
        [Trait("Category", "Request Validation")]
        public void ValidateTest_MaxDocumentCollectionSize()
        {
            var text = new string('*', 10240);

            var request = new MockRequest();

            for (int i = 1; i <= 1000; i++)
            {
                request.Documents.Add(new Document() { Id = i.ToString(), Text = text });
            }

            Assert.Throws<DocumentCollectionMaxSizeException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the Validate method for document identifier.
        /// </summary>
        [Fact]
        [Trait("Category", "Request Validation")]
        public void ValidateTest_DocumentIdRequired()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Text = "doc1" });

            Assert.Throws<DocumentIdRequiredException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the Validate method for duplicate document identifiers.
        /// </summary>
        [Fact]
        [Trait("Category", "Request Validation")]
        public void ValidateTest_DuplicateDocumentId()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "01", Text = "doc1" });
            request.Documents.Add(new Document() { Id = "01", Text = "doc2" });

            Assert.Throws<DocumentCollectionDuplicateIdException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the Validate method for the minimum document size.
        /// </summary>
        [Fact]
        [Trait("Category", "Request Validation")]
        public void ValidateTest_MinDocumentSize()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "001" });

            Assert.Throws<DocumentMinSizeException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum document size.
        /// </summary>
        [Fact]
        [Trait("Category", "Request Validation")]
        public void ValidateTest_MaxDocumentSize()
        {
            var text = new string('*', 10241);

            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "001", Text = text });

            Assert.Throws<DocumentMaxSizeException>(() => request.Validate());
        }
    }

    internal class MockRequest : TextRequest { }
}
