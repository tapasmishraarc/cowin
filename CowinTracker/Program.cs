using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using CowinTracker;
using System.Net.Mail;
using System.Net;

namespace HttpClientDemo
{
    class Program
    {
        public static string body = "";
        public static bool sendMail = false;
        static void Main(string[] args)
        {
            for (int i = DateTime.Now.Day; i < 10; i++)
            {
                string address = i.ToString() + "-05-2021";
                result(address);
                if (i == 29)
                    i = DateTime.Now.Day;
            }
            if (sendMail)
            {
                SendMail(body);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        public static void SendMail(string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("devopssimplify@gmail.com", "Jogisarda@23"),
                 EnableSsl = true,
            };

            smtpClient.Send("devopssimplify@gmail.com", "devopssimplify@gmail.com", "CoWin", body);

        }
        public static void result(string addressparam)
        {
            string address = "https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/findByDistrict?district_id=446&date=" + addressparam;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);
                //HTTP GET
                var responseTask = client.GetAsync(address);
                Root root = new Root();
                var result = responseTask.Result;
                //string body = "";
                if (result.IsSuccessStatusCode)
                {

                    var apiResponse = result.Content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<Root>(apiResponse.Result);
                    Console.WriteLine(addressparam);
                    body = body + "\n" + addressparam;
                    Console.WriteLine("======================================");
                    body = body + "\n" + "======================================";
                    foreach (Session session in root.sessions)
                    {
                        
                        if (session.min_age_limit == 18)
                        {

                            body = body + "\n"+session.address;

                            sendMail = true;
                            Console.WriteLine(session.address);


                        }
                        
                    }


                    body = body + "\n" + "======================================";
                    Console.WriteLine("======================================");
                }
            }
           // Console.ReadLine();
        }
    }
}