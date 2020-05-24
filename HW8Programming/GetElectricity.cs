using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    class GetElectricity : ICounterVisitor
    {
        public float result { get; private set; }

        public void VisitDistributor(Distributor element)
        {
            
        }

        public void VisitEndUser(EndUser element)
        {
            result += element.endCount - element.startCount; 
        }
    }
}
