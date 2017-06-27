using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Interfaces
{
    public interface ILogable
    {
        string TextMessage { get; }

        Type Type { get; }
    }
}
