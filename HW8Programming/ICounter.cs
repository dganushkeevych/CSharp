using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    interface ICounter
    {
        string ID { get; }
        void Accept(ICounterVisitor visitor);
        void Display();
    }
}
