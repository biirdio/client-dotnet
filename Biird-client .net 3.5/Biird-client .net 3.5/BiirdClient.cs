using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
namespace Biird_CSharp_Client
{
    public class BiirdClient
    {
        const string BaseUrl = "https://api.biird.io";
        const string resourceValueURL = "https://api.biird.io/resourceValue/";
        const string biirdOutletSelector = ".biird";
        const string dimensionsAttributeSelector = "data-biird-dimensions";
        const string scriptSelector = "script[data-biird-dimensions]";


        public static void RetrieveBiirdContent(string url, ref string res)
        {
            var xhr = (HttpWebRequest)WebRequest.Create(url);
            
        }
    }
}
