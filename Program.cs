// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Snake;

Coord gridDim = new Coord(50, 20);

Coord snakePos = new Coord(10, 1);

Random rand = new Random();

Coord applePos = new Coord(rand.Next(1, gridDim.X -1), rand.Next(1, gridDim.Y -1));

Direction movement = Direction.Down;

int frameDelayMilli = 100;

StringBuilder snake = new StringBuilder("■");

List<Coord> snakePosHis = new List<Coord>();
int tailLength = 1;

int score = 0;

Boolean run = true;

while (run)
{
    Console.Clear();
    Console.WriteLine("Score: " + score);
    snakePos.ApplyMovementDirection(movement);
    for(int y = 0; y < gridDim.Y; y++)
    {
        for(int x = 0; x<gridDim.X; x++)
        {
            Coord currentCo = new Coord(x, y);
            if(snakePos.Equals(currentCo) || snakePosHis.Contains(currentCo))
            {
                Console.Write(snake);
            }
            else if (applePos.Equals(currentCo))
            {
                Console.Write("0");
            }
            else if(x == 0 || y == 0 || x == gridDim.X -1 || y == gridDim.Y - 1)
            {
                Console.Write("#");
                
            }
            else
            {
                Console.Write(" ");
            }
            
        }

        Console.WriteLine();
    }

    if (snakePos.Equals(applePos))
    {
        tailLength++;
        score++;
        applePos = new Coord(rand.Next(1, gridDim.X -1), rand.Next(1, gridDim.Y -1));

    }
    if(snakePos.X >= gridDim.X || snakePos.X < 1 || snakePos.Y >= gridDim.Y || snakePos.Y < 1
    || snakePosHis.Contains(snakePos))
    {
        Console.Clear();
        Console.WriteLine("GAME OVER!");
        Console.WriteLine("Score: " + score);

        askUser:
        Console.WriteLine("Play Again?\n1)Yes\n2)No");
        String choice = Console.ReadLine() ?? "";
        switch (choice.ToLower())
        {
            case "1":
                score = 0;
                tailLength = 1;
                snakePos = new Coord(10, 1);
                snakePosHis.Clear();
                movement = Direction.Down;
                continue;
            case "yes":
                score = 0;
                tailLength = 1;
                snakePos = new Coord(10, 1);
                snakePosHis.Clear();
                movement = Direction.Down;
                continue;
            case "2":
                run = false;
                break;
            case "no":
                run = false;
                break;
            default:
                goto askUser;

        }
    }

    snakePosHis.Add(new Coord(snakePos.X, snakePos.Y));

    if(snakePosHis.Count > tailLength)
    {
        snakePosHis.RemoveAt(0);
    }

    DateTime time = DateTime.Now;

    while((DateTime.Now - time).TotalMilliseconds < frameDelayMilli)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;
        
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                movement = Direction.Left;
                break;
            case ConsoleKey.RightArrow:
                movement = Direction.Right;
                break;
            case ConsoleKey.UpArrow:
                movement = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                movement = Direction.Down;
                break;
        }
    
        }
    }
  
}
// Console.Clear();

Console.WriteLine("GAME OVER!");
Console.WriteLine("Score: " + score);
