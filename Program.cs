using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BrowserenV2
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            //Http response
            HttpResponseMessage response = await client.GetAsync("http://www.eb.dk/");
            response.EnsureSuccessStatusCode();

            //Take the content from response and reads it as string
            string responseBody = await response.Content.ReadAsStringAsync();

            //Trims htmltags from the response
            string trimmedStringRegex = Regex.Replace(responseBody, "<.*?>", String.Empty);
            Console.WriteLine(trimmedStringRegex);
            Console.ReadLine();
        }
    }
}
