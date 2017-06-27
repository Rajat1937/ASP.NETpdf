using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    using System.IO;

    using global::Logger.Appenders;
    using global::Logger.Interfaces;

    class MainLog
    {
        static void Main(string[] args)
        {
            ILayout layout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(layout);
            IAppender fileAppender = new FileAppender(layout);

            ILogger logger = new Logger(consoleAppender, fileAppender);
            try
            {
                logger.Info("The program was finished just now");
                logger.Warn("I am going to test the program now");
                logger.Error("File not found");
            }
            catch (FileNotFoundException)
            {
                Logger currentLogger = logger as Logger;
                if (currentLogger != null)
                {
                    IAppender appender = currentLogger.FindAppender("ConsoleLogger");
                    appender.Append(new Message("Operation failed because the Path of file was not found", Type.Fatal));
                }             
            }           
        }
    }
}
