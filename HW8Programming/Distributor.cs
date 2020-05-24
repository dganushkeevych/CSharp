using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    [DataContract]
    class Distributor : ICounter
    {
        [DataMember]
        public string ID { get; private set; }
        [DataMember]
        public List<ICounter> devices { get; private set; }

        public void Display()
        {
            Console.WriteLine($"Distributor: {ID}. " );
            foreach (ICounter i in devices)
            {
                i.Display();
            }
        }

        public Distributor()
        {
            ID = "";
            devices = new List<ICounter>();
        }

        public Distributor(string i)
        {
            ID = i;
            devices = new List<ICounter>();
        }

        public Distributor(string id, List<ICounter> dev)
        {
            ID = id;
            devices = dev;
        }

        public void AddDevice(ICounter a)
        {
            devices.Add(a);
        }

        public void Accept(ICounterVisitor visitor)
        {
            foreach(ICounter i in devices)
            {
                i.Accept(visitor);
            }
            visitor.VisitDistributor(this);
        }

        public IEnumerable<ICounter> GetEndUsers(List<ICounter> res)
        {
            var usersE =
                from device in devices
                where device.GetType() == typeof(EndUser)
                select device;

            var usersD =
                from device in devices
                where device.GetType() == typeof(Distributor)
                select device;

            usersE.ToList();
            foreach (var i in usersE)
            {
                res.Add(i);
            }

            foreach (Distributor i in usersD)
            {
                i.GetEndUsers(res);
            }
            return res;
        }

    }
}
