using Microsoft.ProjectOxford.Text.Core.Exceptions;
using Microsoft.ProjectOxford.Text.KeyPhrase;
using System;
using Xunit;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the KeyPhraseClient class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.KeyPhrase.KeyPhraseClient" />
    public class KeyPhraseClientTest
    {
        /// <summary>
        /// Unit test of the validate method for language validation.
        /// </summary>
        [Fact]
        [Trait("Category","Key Phrase Detection")]
        public void Validate_InvalidLanguage()
        {
            var text = "I had a wonderful experience! The rooms were wonderful and the staff were helpful.";
            var doc = new KeyPhraseDocument() { Id = "TEST001", Text = text, Language = "it" };
            var request = new KeyPhraseRequest();
            request.Documents.Add(doc);

            Assert.Throws<LanguageNotSupportedException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the GetKeyPhrases method.
        /// </summary>
        [Fact]
        [Trait("Category","Key Phrase Detection")]
        public void GetKeyPhrases()
        {
            var text = "how is the weather? how is the food? how are the people?";

            var doc = new KeyPhraseDocument() { Id = "TEST001", Text = text, Language = "en" };

            var request = new KeyPhraseRequest();
            request.Documents.Add(doc);

            var client = new KeyPhraseClient(AppSettings.Instance.ApiKey);
            var response = client.GetKeyPhrases(request);

            string expected = "";
            string actual = "";

            expected = "weather";
            actual = response.Documents[0].KeyPhrases[0];
            Assert.Equal(expected, actual);

            expected = "food";
            actual = response.Documents[0].KeyPhrases[1];
            Assert.Equal(expected, actual);

            expected = "people";
            actual = response.Documents[0].KeyPhrases[2];
            Assert.Equal(expected, actual);
        }
    }
}
