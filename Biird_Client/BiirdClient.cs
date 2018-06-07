using System.Globalization;
using System.Net;

namespace Biird_Client
{
    public static class Biird
    {
        private const string Url = "https://api.biird.io/resourceValue/";
        private static string _currLangCode;
    
        /// <summary>
        /// Initialize plugin
        /// </summary>
        public static void Init()
        {
            var code = CultureInfo.CurrentCulture.Name.Split('-');
            _currLangCode = code[0]; //get current code
        }

        /// <summary>
        ///  Call fetch to connect to the API
        /// </summary>
        /// <param name="id"> Id for the current item.</param>
        public static string Fetch(string id)
        {
            using (var wb = new WebClient())
            {
                var parameters = "?" + _currLangCode;

                // string finalString = "https://api.biird.io/resourceValue/b9fb0f44-31d5-45df-9ec3-776568802c31?language=en";
                var response = wb.DownloadString(Url + id + parameters);
                return response;
            }
        }

    }
}
