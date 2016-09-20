using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHubMessageSender
{
    class Message
    {
        public string Id { get; set; }
        public string messageBody { get; set; }
        public DateTime timestamp { get; set; }
    }
}
