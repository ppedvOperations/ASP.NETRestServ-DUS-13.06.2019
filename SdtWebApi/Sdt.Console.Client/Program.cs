using Sdt.Web.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Sdt.Bo.Entities;

namespace Sdt.Console.Client
{
    class Program
    {
        private const string BASEADRESS = "http://localhost:18029/api/";
        private static HttpClient client = new HttpClient() { BaseAddress = new Uri(BASEADRESS)};

        static void Main(string[] args)
        {
            //GetSpruchDesTages().Wait();
            CreateAutor().Wait();

            System.Console.ReadLine();
        }

        private static async Task GetSpruchDesTages()
        {
            try
            {
                var response = await client.GetAsync("sprueche/spruchdestages");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Anfrage erfolgreich...");
                    var sdt = await response.Content.ReadAsAsync<SpruchDesTagesDto>();

                    System.Console.WriteLine($"Spruch Rückgabe: -> Name: {sdt.AutorName} -- Beschreibung: {sdt.AutorBeschreibung} -- Spruch: {sdt.SpruchText}");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }

        private static async Task CreateAutor()
        {
            try
            {
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var autor = new Autor()
                {
                    Name = "Willy Wuff",
                    Beschreibung = "Hund",
                    Geburtsdatum = new DateTime(2017, 01, 01)
                };

                var response = await client.PostAsJsonAsync("autors", autor);

                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    System.Console.WriteLine(response.Headers.Location);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }
    }
}
