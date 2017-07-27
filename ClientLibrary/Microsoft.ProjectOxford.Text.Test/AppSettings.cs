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
                var apiKey = ConfigurationManager.AppSettings["apiKey"];

                if (string.IsNullOrEmpty(apiKey))
                    throw new Exception("API key not found appsettings.json");

                return apiKey;
            }
        }
    }
}
