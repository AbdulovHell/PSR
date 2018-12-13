using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainModule
{
    public class Pair<T, U>
    {
        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    }

    public class ReducedNumber<T, U>
    {
        public ReducedNumber(T number, U order)
        {
            this.Number = number;
            this.Order = order;
        }

        public T Number { get; set; }
        public U Order { get; set; }
    }
}
