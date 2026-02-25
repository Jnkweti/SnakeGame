namespace Snake.Entities;
using System;
using System.Collections.Generic;

using System.Linq;



internal sealed class SnakeEntity
{
    public List<Coord> Body { get; } = new();

    public Coord PreviousHead { get; set; }

    public Direction CurrentDirection { get;  set; } = Direction.Right;

    private Direction _nextDirection = Direction.Right;

    public SnakeEntity(Coord startPos, int initialLength = 3)
    {
        for (int i = 0; i < initialLength; i++)
            Body.Add(new Coord(startPos.X - i, startPos.Y));

        PreviousHead = new Coord(Body[0]);
    }

    public void QueueDirection(Direction d)
    {
        if(!IsOpposite(d, CurrentDirection))
            _nextDirection = d;
    }

    public void Tick(bool growing)
    {
        PreviousHead = new Coord(Body[0]);
        CurrentDirection = _nextDirection;

        Coord newHead = new Coord(Body[0]);
        newHead.ApplyMovementDirection(CurrentDirection);
        Body.Insert(0, newHead);

        if (!growing)
            Body.RemoveAt(Body.Count - 1);

    }

    public bool  CollideWithSelf()
    {
        return Body.Skip(1).Any(c => c.Equals(Body[0]));
    }

    private static bool IsOpposite(Direction a, Direction b) =>
      (a == Direction.Left  && b == Direction.Right) ||
      (a == Direction.Right && b == Direction.Left)  ||
      (a == Direction.Up    && b == Direction.Down)  ||
      (a == Direction.Down  && b == Direction.Up);



    
}