using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EventMakerClientTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string serverUrl = "http://eventmakerws20170324112930.azurewebsites.net";

            using (var client1 = new HttpClient())
            {
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client1.BaseAddress = new Uri(serverUrl);
                client1.DefaultRequestHeaders.Clear();

                var myNewEvent = new Event()
                {

                    Name = "Abba",
                    Description = "Svensk lækkerhed",
                    Place = "EASJ",
        
        
                    Date = "2017,05,10,12,00,00"
                };

                try
                {
                    var response = client1.PostAsJsonAsync<Event>("API/Hotels", myNewEvent).Result;
                    Console.WriteLine("hotel : " + myNewEvent.Name + " hoteladresse : " + myNewEvent.Description);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har indsat et nyt hotel");
                        Console.WriteLine("Post Content: " + response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine("Fejl, hotellet blev ikke indsat");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }

        }
    }
}
