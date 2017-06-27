using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    using global::Logger.Interfaces;

    public class Logger : ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();
            foreach (var appender in appenders)
            {
                this.AddAppender(appender);
            }
        }

        public IAppender FindAppender(string name)
        {
            foreach (var appender in this.Appenders)
            {
                if (appender.GetType().ToString().ToLower().Equals(name.ToLower()))
                {
                    return appender;
                }
            }

            return null;
        }

        public List<IAppender> Appenders
        {
            get
            {
                return this.appenders;
            }
        }

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public void Error(string message)
        {
            ILogable messageToLog = new Message(message, Type.Error);
            this.Log(messageToLog);
        }

        public void Critical(string message)
        {
            ILogable messageToLog = new Message(message, Type.Critical);
            this.Log(messageToLog);
        }

        public void Fatal(string message)
        {
            ILogable messageToLog = new Message(message, Type.Fatal);
            this.Log(messageToLog);
        }

        public void Warn(string message)
        {
            ILogable messageToLog = new Message(message, Type.Warn);
            this.Log(messageToLog);
        }

        public void Info(string message)
        {
            ILogable messageToLog = new Message(message, Type.Info);
            this.Log(messageToLog);
        }

        private void Log(ILogable message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(message);
            }
        }
    }
}
