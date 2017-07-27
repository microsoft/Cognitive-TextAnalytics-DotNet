using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core.Exceptions;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the SentimentClient class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Sentiment.SentimentClient" />
    [TestClass]
    public class SentimentClientTest
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
        /// Unit test of the validate method for language validation.
        /// </summary>
        [TestMethod]
        [TestCategory("Sentiment Analysis")]
        [ExpectedException(typeof(LanguageNotSupportedException))]
        public void Validate_InvalidLanguage()
        {
            var text = "I had a wonderful experience! The rooms were wonderful and the staff were helpful.";
            var doc = new SentimentDocument() { Id = "TEST001", Text = text, Language = "ja" };
            var request = new SentimentRequest();
            request.Documents.Add(doc);
            request.Validate();
        }

        /// <summary>
        /// Unit test of the GetSentiment method using positive text.
        /// </summary>
        [TestMethod]
        [TestCategory("Sentiment Analysis")]
        public void GetSentiment_Positive()
        {
            var text = "I had a wonderful experience! The rooms were wonderful and the staff were helpful.";
            var doc = new SentimentDocument() { Id = "TEST001", Text = text, Language = "en" };

            var request = new SentimentRequest();
            request.Documents.Add(doc);

            var client = new SentimentClient(this.apiKey);
            var response = client.GetSentiment(request);

            var score = response.Documents[0].Score;

            Assert.IsTrue(score > 0.5);
        }

        /// <summary>
        /// Unit test of the GetSentiment method using negative text.
        /// </summary>
        [TestMethod]
        [TestCategory("Sentiment Analysis")]
        public void GetSentiment_Negative()
        {
            var text = "I had a terrible time at the hotel. The staff were rude and the food was awful.";

            var doc = new SentimentDocument() { Id = "TEST001", Text = text, Language = "en" };

            var request = new SentimentRequest();
            request.Documents.Add(doc);

            var client = new SentimentClient(this.apiKey);
            var response = client.GetSentiment(request);

            var score = response.Documents[0].Score;

            Assert.IsTrue(score < 0.5);
        }

        #endregion Test Methods
    }
}
