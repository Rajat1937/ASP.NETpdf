using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Appenders
{
    using System.IO;
    using global::Logger.Interfaces;

    public class FileAppender : IAppender
    {

        public FileAppender(ILayout layout, string path = "../../log.txt")
        {
            this.Layout = layout;
            this.Path = path;
            this.Threshold = 3;
        }

        public string Path { get; set; }

        public ILayout Layout { get; set; }

        public int Threshold { get; set; }

        public void Append(ILogable message)
        {
            if ((int)message.Type >= this.Threshold)
            {
                string messageToLog = String.Empty;
                if (this.Layout != null)
                {
                    messageToLog = this.Layout.Format(message);
                }
                else
                {
                    messageToLog = message.TextMessage;
                }

                using (StreamWriter sw = File.AppendText(this.Path))
                {
                    sw.WriteLine(messageToLog);
                }
            }           
        }     
    }
}
