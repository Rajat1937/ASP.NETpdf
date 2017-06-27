using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    using global::Logger.Interfaces;

    public interface ILogger
    {
        void Error(string message);

        void Critical(string message);

        void Fatal(string message);

        void Warn(string message);

        void Info(string message);        
    }
}
