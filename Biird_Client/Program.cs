using System;
using System.Collections.Generic;
using System.Net;


namespace Biird_Client
{
    class Program
    {
        public static void Main(string[] args){
            
            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(BiirdClient.resourceValueURL);
                Console.WriteLine(response);
            }
        }
    }
}
