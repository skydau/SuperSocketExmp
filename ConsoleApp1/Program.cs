using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new EasyClient();

            // Initialize the client with the receive filter and request handler
            client.Initialize(new MyReceiveFilter(), (request) =>
            {
                // handle the received request
                Console.WriteLine($"{request.Key}, {request.Body}");
            });

            // Connect to the server
            var connected = client.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2020)).Result;

            if (connected)
            {
                Random r = new Random(100);
                // Send data to the server
                for (int i = 0; i < 100; i++)
                {
                    client.Send(Encoding.ASCII.GetBytes($"ADD {r.Next(100)} {r.Next(100)}{Environment.NewLine}"));
                    //Thread.Sleep(1000);
                }

            }

            client.Error += Client_Error;


            Console.ReadLine();
        }

        private static void Client_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}
