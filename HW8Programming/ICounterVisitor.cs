using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsTask
{
    interface ICounterVisitor
    {
        void VisitDistributor(Distributor element);
        void VisitEndUser(EndUser element);
    }
}
