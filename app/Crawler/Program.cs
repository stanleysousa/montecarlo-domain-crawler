using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataHandler;
using Microsoft.FSharp.Collections;

namespace Crawler
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        private async static Task<bool> Indicator(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Head, uri);
            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch(HttpRequestException)
            {
                return false;
            }
        }

        private async static Task ProccessDomain(int k, int count, string domain)
        {
            var absX = Base26Word.WordCount(k);
            var n = new int[count];
            var w_n = new double[count];
            var foundList = new List<string>();

            var sumH = 0;
            var words = NumberGenerator.G(count, absX).Select(w => w.FromBase26());

            for (int i = 0; i < words.Count(); i++)
            {
                var uri = "http://www."+words.ElementAt(i)+"."+domain;
                if(await Indicator(uri))
                {
                    foundList.Add(words.ElementAt(i));
                    sumH ++;
                    Console.WriteLine("Found " + words.ElementAt(i) + " on n=" + i.ToString());
                }
                    n[i]=i;
                    w_n[i]=((absX/count)*sumH);
            }
            Plot.line(ListModule.OfSeq(n), ListModule.OfSeq(w_n), "");
            Console.WriteLine("Found: " + sumH.ToString() + " domains");
            foundList.ForEach(f => Console.WriteLine(f));
        }

        static async Task<int> Main(string[] args)
        {
            var k=4;
            var n=50000;
            var domain = "ufrj.br";
            await ProccessDomain(k, n, domain);
            return 0;
        }
    }
}
