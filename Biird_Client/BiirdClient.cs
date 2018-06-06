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

        public static string fetch(string id){
            Entity currentEntity;
            using (var wb = new WebClient())
            {

                var response = wb.DownloadString(BiirdClient.resourceValueURL+id);
                currentEntity = new Entity(response);
                Console.WriteLine(currentEntity);
                return response;
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
