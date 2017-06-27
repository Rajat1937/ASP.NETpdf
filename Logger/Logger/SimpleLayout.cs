using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    using global::Logger.Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(ILogable messageToFormat)
        {
            string message = string.Format(
                "{0} - {1} - {2}",
                DateTime.Now,
                messageToFormat.Type.ToString(),
                messageToFormat.TextMessage);

            return message;
        }
    }
}
