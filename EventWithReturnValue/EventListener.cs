using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollection;

namespace EventWithReturnValue
{
    public class EventListener
    {
        private ArrayListWithChangedEvent MyList;

        public EventListener(ArrayListWithChangedEvent list)
        {
            MyList = list;
            // Add "ListChanged" to the Changed event on "List":
            MyList.OnListChanged += MyList_OnListChanged;
        }

        void MyList_OnListChanged(object sender, OnListChangedEventArgs e)
        {
            Console.WriteLine("The list is changed and the count of the list is {0}.", e.ItemCount);
        }

        public void Detach()
        {
            // Detach the event and delete the list:
            MyList.OnListChanged -= MyList_OnListChanged;
            MyList = null;
        }
    }
}
