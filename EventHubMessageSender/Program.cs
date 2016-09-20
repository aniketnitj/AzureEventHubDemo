using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace EventHubMessageSender
{
    class Program
    {
        static string eventHubName = "{msg-event-2}";
        static string connectionString = "{Your Connection key here}";

        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl-C to stop the sender process");
            //Console.WriteLine("Press Enter to start now");
            //Console.ReadLine();
            SendingRandomMessages();
        }

        static void SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
            while (true)
            {
                try
                {
                    //var message = Guid.NewGuid().ToString();
                    var message = new Message();
                    message.Id= Guid.NewGuid().ToString();
                    message.timestamp = DateTime.Now;
                    message.messageBody = "This is sample json message !!";
                    var jsonMsg= JsonConvert.SerializeObject(message);

                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, message.Id);
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(jsonMsg)));
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

                Thread.Sleep(200);
            }
        }
    }
}
