using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the LanguageClient class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Language.LanguageClient" />
    [TestClass]
    public class LanguageClientTest
    {
        #region Fields

        private string apiKey = "";

        #endregion Fields

        #region Test Inititalization

        /// <summary>
        /// Intializes this instance.
        /// </summary>
        [TestInitialize]
        public void Intialize()
        {
            apiKey = AppSettings.Instance.ApiKey;
        }

        #endregion Test Initialization

        #region Test Methods

        /// <summary>
        /// Unit test of the GetLanguage method using a single language.
        /// </summary>
        [TestMethod]
        [TestCategory("Language Detection")]
        public void GetLanguagesTest_OneLangage()
        {
            var doc01 = new Document() { Id = "TEST001", Text = "Hello my friend" };

            var request = new LanguageRequest();
            request.Documents.Add(doc01);

            var client = new LanguageClient(this.apiKey);
            var response = client.GetLanguages(request);

            Assert.AreEqual("en", response.Documents[0].DetectedLanguages[0].Iso639Name);
            Assert.AreEqual("English", response.Documents[0].DetectedLanguages[0].Name);
            Assert.AreEqual(1.0, response.Documents[0].DetectedLanguages[0].Score);
        }

        /// <summary>
        /// Unit test of the GetLanguage method using a single language.
        /// </summary>
        [TestMethod]
        [TestCategory("Language Detection")]
        public void GetLanguagesTest_TwoLangages()
        {
            var doc01 = new Document() { Id = "TEST001", Text = "Hello my friend." };
            var doc02 = new Document() { Id = "TEST002", Text = "Hola mi amigo" };

            var request = new LanguageRequest();
            request.NumberOfLanguagesToDetect = 2;
            request.Documents.Add(doc01);
            request.Documents.Add(doc02);

            var client = new LanguageClient(this.apiKey);
            var response = client.GetLanguages(request);

            Assert.AreEqual("en", response.Documents[0].DetectedLanguages[0].Iso639Name);
            Assert.AreEqual("English", response.Documents[0].DetectedLanguages[0].Name);
            Assert.AreEqual(1.0, response.Documents[0].DetectedLanguages[0].Score);

            Assert.AreEqual("es", response.Documents[1].DetectedLanguages[0].Iso639Name);
            Assert.AreEqual("Spanish", response.Documents[1].DetectedLanguages[0].Name);
            Assert.AreEqual(1.0, response.Documents[1].DetectedLanguages[0].Score);
        }

        #endregion Test Methods
    }
}
