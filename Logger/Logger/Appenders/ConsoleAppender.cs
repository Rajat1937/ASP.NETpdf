namespace Logger
{
    using System;

    using global::Logger.Interfaces;

    public class ConsoleAppender : IAppender
    {        

        public ConsoleAppender(ILayout layout)
        {
            this.Threshold = 1;
            this.Layout = layout;
        }

        public int Threshold { get; set; }

        public ILayout Layout { get; set; }

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

                Console.WriteLine(messageToLog);
            }
            
        }

       
    }
}
