﻿namespace Snake;

public enum Direction
{
    Right,
    Left,
    Up,
    Down
}

public enum EventStatus
{
    Success,
    Moved,
    GameOver,
    PreyEaten
}
