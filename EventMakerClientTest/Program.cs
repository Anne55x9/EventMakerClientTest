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
            const string serverUrl = "http://eventmakerws20170324112930.azurewebsites.net/";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();

                var myNewEvent = new Event()
                {
                   
                    Name = "Abba",
                    Description = "Svensk lækkerhed",
                    Place = "EASJ",
                    Date = new DateTime(2017, 10, 05, 12, 00, 00 )
                };

                try
                {
                    var response = client.PostAsJsonAsync<Event>("api/EventsFINALs", myNewEvent).Result;
                    Console.WriteLine("hotel : " + myNewEvent.Name + " hoteladresse : " + myNewEvent.Description);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har indsat en ny event");
                        Console.WriteLine("Post Content: " + response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine("Fejl, eventen blev ikke indsat");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }


            using (var client1 = new HttpClient())
            {
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client1.BaseAddress = new Uri(serverUrl);
                client1.DefaultRequestHeaders.Clear();
                string urlString8 = "api/eventsfinals/2";

                try
                {
                    HttpResponseMessage response = client1.DeleteAsync(urlString8).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Du har slettet et event");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                    else
                    {
                        Console.WriteLine("Fejl, eventet blev ikke slettet");
                        Console.WriteLine("Statuskode : " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }



            using (var client2 = new HttpClient())
            {
                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client2.BaseAddress = new Uri(serverUrl);
                client2.DefaultRequestHeaders.Clear();
                string urlString2 = "api/eventsfinals";

                try
                {
                    HttpResponseMessage response2 = client2.GetAsync(urlString2).Result;
                    if (response2.IsSuccessStatusCode)
                    {
                        var eventlist = response2.Content.ReadAsAsync<List<Event>>().Result;

                        foreach (var events in eventlist)
                        {
                            Console.WriteLine("Event : " + events.Name + "Eventbeskrivelse : " + events.Description + "Sted: " + events.Place + "Dato&tid: " + events.Date);
                        }
                        //var hotelRoskilde = from h in hotelList
                        //                    where h.Address.Contains("Roskilde")
                        //                    select h;
                        //Console.WriteLine("Hoteller i Roskilde:");

                        ///Lamda sætning. 
                        // var hotellistRoskildeRum = response3.Content.ReadAsAsync<List<Hotel>>().Result.Where(x => x.Address.Contains("Roskilde");


                        //foreach (var item in hotelRoskilde)
                        //{
                        //    Console.WriteLine("hotel : " + item.Name + "hoteladresse : " + item.Address);
                        //}

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }


            using (var client3 = new HttpClient() )
            {
                client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("apllication/json"));
                client3.BaseAddress = new Uri(serverUrl);
                client3.DefaultRequestHeaders.Clear();

                string Urlstring3 = "api/eventsfinals/2";

                try
                {
                    HttpResponseMessage response3 = client3.GetAsync(Urlstring3).Result;
                    if (response3.IsSuccessStatusCode)
                    {
                        var event1 = response3.Content.ReadAsAsync<Event>().Result;
                        Console.WriteLine(event1.ToString());
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("Der er sket en fejl : " + e.Message);
                }
            }


            Console.ReadLine();

        }
    }
}
