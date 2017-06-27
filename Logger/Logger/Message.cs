using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    using global::Logger.Interfaces;

    public struct Message : ILogable
    {
        public string TextMessage { get; private set; }

        public Type Type { get; private set; }
        public Message(string message, Type type)
        {
            this.TextMessage = message;
            this.Type = type;
        }

        
    }

}
