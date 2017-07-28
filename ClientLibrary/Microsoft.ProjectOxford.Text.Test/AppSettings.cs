using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Microsoft.ProjectOxford.Text.Test
{
    public class AppSettings
    {
        private static AppSettings _instance;

        public static AppSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSettings();

                return _instance;
            }
        }

        public string ApiKey
        {
            get
            {
                var apiKey = Environment.GetEnvironmentVariable("COG_API_KEY_TEXTANALYTICS");

                if (string.IsNullOrEmpty(apiKey))
                    throw new Exception("Environment variable COG_API_KEY_TEXTANALYTICS not found.");

                return apiKey;
            }
        }
    }
}
