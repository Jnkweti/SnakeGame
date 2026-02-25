using System.Diagnostics;
using Snake;
using Snake.Entities;


Coord gridDim = new Coord(50,20);
Random rand = new Random();

SnakeEntity snake = new SnakeEntity(new Coord(10, 5));
Coord applePos = new Coord(rand.Next(1, gridDim.X -1),  rand.Next(1, gridDim.Y));

GameState gameState;

int score = 0;
int frameDelayMilli = 100;
bool run = true;


while (run)
{
    //check to see if snake eats apple
    bool ate = snake.Body[0].Equals(applePos);
    snake.Tick(ate);
    if (ate) { score++; applePos = new Coord(rand.Next(1, gridDim.X - 1), rand.Next(1, gridDim.Y - 1)); }
    Console.Clear();
    for (int y = 0; y <= gridDim.Y; y++)
    {
        for (int x = 0; x <= gridDim.X; x++)
        {
            if(snake.Body.Contains(new Coord(x, y)))
            {
                        Console.Write("■");
            }
            else if (applePos.X == x && applePos.Y == y)
            {
                Console.Write("0");
            }
            else if (y == gridDim.Y - 1 || y == 0)
            {
                Console.Write("#");
            }
            else if(x == gridDim.X - 1 || x == 0)
            {
                Console.Write("||");
            }
            else
            {
                Console.Write(" ");
            }
            
        }
        Console.WriteLine();
    }
    //Checks for Snake out of bounds of self collision
    if ( snake.Body[0].X <= 0 || snake.Body[0].X >= gridDim.X || 
         snake.Body[0].Y <= 0 || snake.Body[0].Y >= gridDim.Y || 
         snake.CollideWithSelf())
    {
        gameState = GameState.GameOver;
        Console.Write("Game Over");
        run = false;
    }
    DateTime time = DateTime.Now;

    while ((DateTime.Now - time).TotalMilliseconds < frameDelayMilli)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;
            
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    snake.QueueDirection(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    snake.QueueDirection(Direction.Right);
                    break;
                case ConsoleKey.UpArrow:
                    snake.QueueDirection(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    snake.QueueDirection(Direction.Down);
                    break;
            }
            
        }
    }
    



}