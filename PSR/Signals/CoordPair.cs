using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainModule.Signals
{
    public class CoordPair
    {
        public CoordPair(List<double> x, List<double> y)
        {
            this.X = x;
            this.Y = y;
        }

        public List<double> X { get; set; }
        public List<double> Y { get; set; }
    }
}
