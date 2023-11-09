using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class Item
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Item()
        {
            X = 0;
            Y = 0;
        }

        public Item(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
