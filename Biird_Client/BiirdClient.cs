using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Net;

namespace Biird_Client
{
    public class BiirdClient
    {
        public static readonly string URL = "https://api.biird.io/";
        public static readonly string resourceValueURL  = "https://api.biird.io/resourceValue/";
    
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

        /// <summary>
        ///  Dictionary of Dimensions.
        /// </summary>
        /// <param name="key"> Language Code. </param>
        /// <param name="value"> Attribute, example: language </param>
        private Dictionary<string, string> biirdBaseDimensions = new Dictionary<string, string>();
        public Biird()
        {
            string[] code = CultureInfo.CurrentCulture.Name.Split('-');
            // TO DO :
            //       - call the default dimensions
            Biird.Shared.DefaultLanguageDimentions();

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
            biirdBaseDimensions.Add("de","language"); // for test purposes
            return _languageCode;
        }
        
        /// <summary>
        ///  Call fetch to connect to the API
        /// </summary>
        /// <param name="id"> Id for the current item.</param>
        public static string fetch(string id){
            Entity currentEntity;
            
            using (var wb = new WebClient())
            {
                
                string parameters = "?";
                int i = 0;

                // add all attributes and its values to the parameters
                foreach(string key in Shared.biirdBaseDimensions.Keys){
                    parameters += Shared.biirdBaseDimensions[key] + "=" + key;
                    if( i < Shared.biirdBaseDimensions.Keys.Count-1){
                        parameters += "&";
                    }
                    i++;
                }

                // Console.WriteLine(BiirdClient.resourceValueURL + id + parameters);
                // string finalString = "https://api.biird.io/resourceValue/b9fb0f44-31d5-45df-9ec3-776568802c31?language=en";
                var response = wb.DownloadString(BiirdClient.resourceValueURL + id + parameters);
                currentEntity = new Entity(response);
                Console.WriteLine(currentEntity.Data);
                return response;
            }
          
           

        }

    }
}
