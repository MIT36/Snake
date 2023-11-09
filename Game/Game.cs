using System.Drawing;
using Snake.Models;

namespace Snake;

public class Game
{
    private readonly Settings settings = new();

    private readonly System.Timers.Timer timer = new System.Timers.Timer();

    private readonly List<Item> items = new();

    private int indexLevel { get; set; }

    public IReadOnlyCollection<Item> Items => items;

    public Level CurrentLevel { get; private set; }

    public FoodItem RandomFood { get; private set; } = default!;

    public Direction Direction { get; private set; }

    public int TotalScore { get; private set; }

    public event EventHandler<EventStatus> Notification;

    public Game(Settings defaultSettings)
    {
        if (defaultSettings.Levels.Count == 0)
            throw new Exception("No Levels");

        settings = defaultSettings;
        Reset();

        timer.Elapsed += Timer_Elapsed;
    }

    public void Start() => timer.Start();

    public void Stop() => timer.Stop();

    public bool IsRunning() => timer.Enabled;

    public void SetDirection(Direction direction)
    {
        if (!timer.Enabled)
            return;

        if (direction == Direction.Right && Direction != Direction.Left)
            Direction = Direction.Right;
        else if (direction == Direction.Left && Direction != Direction.Right)
            Direction = Direction.Left;
        else if (direction == Direction.Down && Direction != Direction.Up)
            Direction = Direction.Down;
        else if (direction == Direction.Up && Direction != Direction.Down)
            Direction = Direction.Up;
    }

    public void Reset()
    {
        indexLevel = 0;
        CurrentLevel = settings.Levels[0];
        timer.Interval = CurrentLevel.Speed;

        var startY = settings.SizeItem % 20 == 0 ? 20 : settings.SizeItem;

        items.Clear();
        items.Add(new Item(settings.SizeItem * 4, startY));
        items.Add(new Item(settings.SizeItem * 3, startY));
        items.Add(new Item(settings.SizeItem * 2, startY));
        items.Add(new Item(settings.SizeItem, startY));
        items.Add(new Item(0, startY));

        GenerateFood();

        Direction = Direction.Right;
        TotalScore = 0;
    }

    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                switch (Direction)
                {
                    case Direction.Left:
                        items[i].X -= settings.SizeItem;
                        break;
                    case Direction.Right:
                        items[i].X += settings.SizeItem;
                        break;
                    case Direction.Up:
                        items[i].Y -= settings.SizeItem;
                        break;
                    case Direction.Down:
                        items[i].Y += settings.SizeItem;
                        break;

                }

                var currentItem = items[i];

                if (currentItem.X == RandomFood.X && currentItem.Y == RandomFood.Y)
                {
                    TotalScore += 
                        RandomFood.Color == Color.Blue ? CurrentLevel.PointsBlue 
                        : RandomFood.Color == Color.Red ? CurrentLevel.PointsRed : CurrentLevel.PointsSilver;

                    if (TotalScore >= CurrentLevel.MaxScore)
                    {
                        if (indexLevel + 1 == settings.Levels.Count)
                        {
                            timer.Stop();
                            Notification?.Invoke(this, EventStatus.Success);
                            return;
                        }
                        indexLevel++;
                        CurrentLevel = settings.Levels[indexLevel];
                        timer.Interval = CurrentLevel.Speed;
                    }

                    items.Add(new Item(items[items.Count - 1].X, items[items.Count - 1].Y));

                    GenerateFood();
                    Notification?.Invoke(this, EventStatus.PreyEaten);
                }

                if (currentItem.X < 0 || currentItem.X >= settings.Width ||
                    currentItem.Y < 0 || currentItem.Y >= settings.Height || Bump(currentItem.X, currentItem.Y))
                {
                    timer.Stop();
                    Notification?.Invoke(this, EventStatus.GameOver);
                    return;
                }
            }
            else
            {
                items[i].X = items[i - 1].X;
                items[i].Y = items[i - 1].Y;
            }
        }
        Notification?.Invoke(this, EventStatus.Moved);
    }

    private bool Bump(int x, int y)
    {
        for (int j = 1; j < items.Count; j++)
        {
            if (items[j].X == x && items[j].Y == y)
                return true;
        }
        return false;
    }

    private void GenerateFood()
    {
        var rnd = new Random();

        var rndX = rnd.Next(settings.SizeItem, settings.Width - settings.SizeItem * 2);
        var rndY = rnd.Next(settings.SizeItem, settings.Height - settings.SizeItem * 2);

        var color = rnd.Next(0, 3) switch
        {
            0 => Color.Blue,
            1 => Color.Silver,
            _ => Color.Red
        };

        RandomFood = new FoodItem(rndX - rndX % settings.SizeItem, rndY - rndY % settings.SizeItem, color);
    }

}