using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace Biird_Client
{
    public class BiirdClient
    {
        private static readonly string URL = "https://api.biird.io/";
        private static readonly string resourceValueURL  = "https://api.biird.io/resourceValue/0";

        public static void Main(strings[] args){
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(resourceValueURL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }  
        }
    }

    class Entity
    {
        public string Data;
        public Entity(string data)
        {
            Data = data;
        }
        //todo check encoding and transfer to utf8
    }

    class Biird
    {
        public static Biird Shared = new Biird();
        private string _languageCode;
        private string _countryCode;
        public Biird()
        {
            string[] code = CultureInfo.CurrentCulture.Name.Split('-');
            if(code.Length == 2)
            {
                _languageCode = code[0];
                _countryCode = code[1];
            }
            else
            {
                _languageCode = code[0];
            }
        }

        public string DefaultLanguageDimentions()
        {
            return _languageCode;
        }

    }
}
