using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace PatternsTask
{
    [DataContract]
    class EndUser: ICounter, IComparable
    {
        [DataMember]
        public string ID { get; private set; }
        [DataMember]
        public float startCount { get; private set; }
        [DataMember]
        public float endCount { get; private set; }

        public EndUser()
        {
            startCount = 0;
            endCount = 0;
        }

        public EndUser(float start, float end, string id)
        {
            startCount = start;
            endCount = end;
            ID = id;
        }

        public void Display()
        {
            Console.WriteLine($"EndUser: {ID} : {startCount} - {endCount}");
        }

        public void Accept(ICounterVisitor visitor)
        {
            visitor.VisitEndUser(this);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            EndUser otherUser = obj as EndUser;
            if (otherUser != null)
                return (this.endCount-this.startCount).CompareTo(otherUser.endCount - otherUser.startCount);
            else
                throw new ArgumentException("Object is not an EndUser");
        }
    }
}
