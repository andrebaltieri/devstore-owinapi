using Microsoft.Owin.Hosting;
using System;

namespace DevStore.Api.Owin
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Serviço rodando...");
                Console.ReadLine();
            }
        }
    }
}
