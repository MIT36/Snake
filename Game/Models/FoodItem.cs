using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    public class FoodItem : Item
    {
        public Color Color { get; set; }

        public FoodItem(int x, int y, Color color) : base(x, y)
        {
            this.Color = color;
        }
    }
}
