using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using System;
using Xunit;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the LanguageClient class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Language.LanguageClient" />
    public class LanguageClientTest
    {
        /// <summary>
        /// Unit test of the GetLanguage method using a single language.
        /// </summary>
        [Fact]
        [Trait("Category","Language Detection")]
        public void GetLanguagesTest_OneLangage()
        {
            var doc01 = new Document() { Id = "TEST001", Text = "Hello my friend" };

            var request = new LanguageRequest();
            request.Documents.Add(doc01);

            var client = new LanguageClient(AppSettings.Instance.ApiKey);
            var response = client.GetLanguages(request);

            Assert.Equal("en", response.Documents[0].DetectedLanguages[0].Iso639Name);
            Assert.Equal("English", response.Documents[0].DetectedLanguages[0].Name);
            Assert.Equal(1.0, response.Documents[0].DetectedLanguages[0].Score);
        }

        /// <summary>
        /// Unit test of the GetLanguage method using a single language.
        /// </summary>
        [Fact]
        [Trait("Category","Language Detection")]
        public void GetLanguagesTest_TwoLangages()
        {
            var doc01 = new Document() { Id = "TEST001", Text = "Hello my friend." };
            var doc02 = new Document() { Id = "TEST002", Text = "Hola mi amigo" };

            var request = new LanguageRequest();
            request.NumberOfLanguagesToDetect = 2;
            request.Documents.Add(doc01);
            request.Documents.Add(doc02);

            var client = new LanguageClient(AppSettings.Instance.ApiKey);
            var response = client.GetLanguages(request);

            Assert.Equal("en", response.Documents[0].DetectedLanguages[0].Iso639Name);
            Assert.Equal("English", response.Documents[0].DetectedLanguages[0].Name);
            Assert.Equal(1.0, response.Documents[0].DetectedLanguages[0].Score);

            Assert.Equal("es", response.Documents[1].DetectedLanguages[0].Iso639Name);
            Assert.Equal("Spanish", response.Documents[1].DetectedLanguages[0].Name);
            Assert.Equal(1.0, response.Documents[1].DetectedLanguages[0].Score);
        }
    }
}
