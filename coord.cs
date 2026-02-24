
namespace Snake
{
    internal class Coord
    {

        public int X { get; set ; }
    
        public int Y { get;  set; }
        
        public Coord(int x, int y)
        {
            this.X = x;
            this.Y = y;

        }

        // Copy constructor — creates an independent clone of another Coord
        public Coord(Coord other) : this(other.X, other.Y) { }

        // Required whenever Equals is overridden — equal objects must have equal hash codes
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override bool Equals(object? obj)
        {
            if(obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Coord other = (Coord)obj;

            return X == other.X && Y == other.Y;
        }

        public void ApplyMovementDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    X--;
                    break;
                case Direction.Right:
                    X++;
                    break;
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Down:
                    Y++;
                    break;
            }
        }
    }
}