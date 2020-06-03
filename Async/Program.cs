using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Async.Models;
/// <summary>
/// https://www.youtube.com/watch?v=2moh18sh5p4&t=1503s
/// </summary>
namespace Async
{
    class Program
    {
        private static long timeElapsed;

        static async Task Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            // syncronous
            Console.WriteLine("Downloading 10 websites syncronously");
            stopwatch.Start();
            RunDownloadSync();
            Console.WriteLine($"Sync: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Reset();


            // asyncronous
            Console.WriteLine("\nDownloading 10 websites asyncronously");
            stopwatch.Start();
            await RunDownloadParallelAsync();
            Console.WriteLine($"Async: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Stop();

            Console.Read();
        }

        private static List<string> PrepData()
        {
            return new List<string>()
            {
                "http://www.google.com",
                "http://www.yahoo.com",
                "http://www.wikipedia.org",
                "http://www.bing.com"
            };
        }

        private static void RunDownloadSync()
        {
            List<string> sites = PrepData();

            foreach (var site in sites)
            {
                var website = DownloadWebsite(site);
                Console.WriteLine($"{website.WebsiteUrl} - {website.WebsiteContent.Length}");
            }
        }

        private static async Task RunDownloadParallelAsync()
        {
            List<string> sites = PrepData();

            List<Task<WebsiteModel>> tasks = new List<Task<WebsiteModel>>();

            foreach (var site in sites)
            {
                tasks.Add(Task.Run(() => DownloadWebsite(site)));
            }

            var websiteModels = await Task.WhenAll(tasks);

            foreach (var website in websiteModels)
            {
                Console.WriteLine($"{website.WebsiteUrl} - {website.WebsiteContent.Length}");
            }
        }


        private static WebsiteModel DownloadWebsite(string siteAddress)
        {
            WebClient webClient = new WebClient();

            return new WebsiteModel()
            {
                WebsiteUrl = siteAddress,
                WebsiteContent = webClient.DownloadString(siteAddress)
            };
        }
    }
}