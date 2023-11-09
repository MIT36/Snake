namespace Snake.Models;

public class Settings
{
    private const int MIN_WIDTH = 300;
    private const int MAX_WIDTH = 1200;

    private const int MIN_HEIGHT = 300;
    private const int MAX_HEIGHT = 800;

    private int _width;
    private int _height;
    private int _sizeItem;


    public int SizeItem
    {
        get => _sizeItem;
        set
        {
            if (value < 10)
            {
                _sizeItem = 10;
                return;
            }
            if (value > 20)
            {
                _sizeItem = 20;
                return;
            }

            var tmp = value % 5;
            _sizeItem = tmp != 0 ? value - tmp : value;
        }
    }

    public int Width 
    {
        get => _width;
        set => _width = value < MIN_WIDTH ? MIN_WIDTH : value > MAX_WIDTH ? MAX_WIDTH : value;
    }

    public int Height
    {
        get => _height;
        set => _height = value < MIN_HEIGHT ? MIN_HEIGHT : value > MAX_HEIGHT ? MAX_HEIGHT : value;
    }



    public List<Level> Levels { get; set; } = new();
}
