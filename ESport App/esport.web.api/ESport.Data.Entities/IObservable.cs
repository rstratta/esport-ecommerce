using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Entities
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void notifyObservers(string message);
    }
}
