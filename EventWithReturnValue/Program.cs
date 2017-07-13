using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollection;

namespace EventWithReturnValue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new list:
            ArrayListWithChangedEvent list = new ArrayListWithChangedEvent();

            // Create a class that listens to the list's change event:
            EventListener listener = new EventListener(list);

            // Add and remove items from the list:
            list.Add("item 1");
            list.Clear();
            list.Add("item 2");
            list.Add("item 3");
            listener.Detach();
            //There will be no event after this code
            list.Add("item 4");
            Console.ReadKey();
        }
    }
}
