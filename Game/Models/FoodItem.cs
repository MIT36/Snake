using System.Drawing;

namespace Snake.Models;

public class FoodItem : Item
{
    public Color Color { get; set; }

    public FoodItem(int x, int y, Color color) : base(x, y)
    {
        this.Color = color;
    }
}
