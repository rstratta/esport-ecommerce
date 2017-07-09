using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Service
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void NotifyObservers(string message);
    }
}
