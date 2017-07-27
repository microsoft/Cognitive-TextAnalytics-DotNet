using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Language
{
    /// <summary>
    /// Client for interacting with the Text Analytics language identification API.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextClient" />
    public class LanguageClient : TextClient
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageClient"/> class.
        /// </summary>
        /// <param name="apiKey">The Text Analytics API key.</param>
        public LanguageClient(string apiKey) : base(apiKey)
        {
            this.Url = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the languages in a collection of documents.
        /// </summary>
        /// <param name="request">The request containing the collection fo documents.</param>
        /// <see cref="Microsoft.ProjectOxford.Text.Language.LanguageResponse"/>
        /// <returns>Returns a LanguageResponse object from the Text Analytics API.</returns>
        public LanguageResponse GetLanguages(LanguageRequest request)
        {
            return GetLanguagesAsync(request).Result;
        }

        /// <summary>
        /// Gets the languages in a collection of documents asynchronously.
        /// </summary>
        /// <param name="request">The request containing the collection fo documents.</param>
        /// <see cref="Microsoft.ProjectOxford.Text.Language.LanguageResponse"/>
        /// <returns>Returns a LanguageResponse object from the Text Analytics API.</returns>
        public async Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request)
        {
            request.Validate();

            var url = this.Url;

            if (request.NumberOfLanguagesToDetect > 1)
            {
                url = string.Format("{0}?numberOfLanguagesToDetect={1}", url, request.NumberOfLanguagesToDetect);
            }

            var json = JsonConvert.SerializeObject(request);
            var responseJson = await this.SendPostAsync(url, json);
            var response = JsonConvert.DeserializeObject<LanguageResponse>(responseJson);

            return response;
        }

        #endregion Methods
    }
}
