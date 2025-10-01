using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class EventEventArgs:EventArgs
    {
        public string HorseName { get; set; }
        public int Place { get; set; }
        public EventEventArgs(string horseName, int place)
        {
            this.HorseName = horseName;
            this.Place = place;
        }

    }
}
