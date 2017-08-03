using Microsoft.ProjectOxford.Text.Core.Exceptions;
using Microsoft.ProjectOxford.Text.Sentiment;
using System;
using Xunit;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the SentimentClient class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Sentiment.SentimentClient" />
    public class SentimentClientTest
    {
        /// <summary>
        /// Unit test of the validate method for language validation.
        /// </summary>
        [Fact]
        [Trait("Category","Sentiment Analysis")]
        public void Validate_InvalidLanguage()
        {
            var text = "I had a wonderful experience! The rooms were wonderful and the staff were helpful.";
            var doc = new SentimentDocument() { Id = "TEST001", Text = text, Language = "ja" };
            var request = new SentimentRequest();
            request.Documents.Add(doc);

            Assert.Throws<LanguageNotSupportedException>(() => request.Validate());
        }

        /// <summary>
        /// Unit test of the GetSentiment method using positive text.
        /// </summary>
        [Fact]
        [Trait("Category","Sentiment Analysis")]
        public void GetSentiment_Positive()
        {
            var text = "I had a wonderful experience! The rooms were wonderful and the staff were helpful.";
            var doc = new SentimentDocument() { Id = "TEST001", Text = text, Language = "en" };

            var request = new SentimentRequest();
            request.Documents.Add(doc);

            var client = new SentimentClient(AppSettings.Instance.ApiKey);
            var response = client.GetSentiment(request);

            var score = response.Documents[0].Score;

            Assert.True(score > 0.5);
        }

        /// <summary>
        /// Unit test of the GetSentiment method using negative text.
        /// </summary>
        [Fact]
        [Trait("Category","Sentiment Analysis")]
        public void GetSentiment_Negative()
        {
            var text = "I had a terrible time at the hotel. The staff were rude and the food was awful.";

            var doc = new SentimentDocument() { Id = "TEST001", Text = text, Language = "en" };

            var request = new SentimentRequest();
            request.Documents.Add(doc);

            var client = new SentimentClient(AppSettings.Instance.ApiKey);
            var response = client.GetSentiment(request);

            var score = response.Documents[0].Score;

            Assert.True(score < 0.5);
        }
    }
}
