namespace Snake.Entities;
using System;
using System.Collections.Generic;

using System.Linq;

internal sealed class SnakeEntity
{
    public List<Coord> Body { get; } = new();

    public Direction CurrentDirection { get; private set; } = Direction.Right;

    private Direction _nextDirection = Direction.Right;

    
}