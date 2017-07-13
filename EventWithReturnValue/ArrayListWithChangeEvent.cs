using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MyCollection
{
    //Define the custom event which returning count of element in the array
    public class OnListChangedEventArgs : EventArgs
    {
        public int ItemCount { get; set; }
        public  OnListChangedEventArgs(int itemCount)
        {
            ItemCount = itemCount;
        }
    }
    
    public class ArrayListWithChangedEvent : ArrayList
    {
        //Define the event handler
        public event EventHandler<OnListChangedEventArgs> OnListChanged;

        // Invoke the Changed event; called whenever list changes
        protected virtual void OnChanged(int itemCount)
        {
            //if (OnListChanged != null)
            //    OnListChanged(this, new OnListChangedEventArgs(itemCount));

            OnListChanged?.Invoke(this, new OnListChangedEventArgs(itemCount));
        }

        // Override some of the methods that can change the list;
        // invoke event after each:
        public override int Add(object value)
        {
            int i = base.Add(value);
            //raise event
            OnChanged(base.Count);
            return i;
        }

        public override void Clear()
        {
            base.Clear();
            OnChanged(base.Count);
        }

        public override object this[int index]
        {
            set
            {
                base[index] = value;
                OnChanged(base.Count);
            }
        }
    }
}
