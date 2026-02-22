# Snake Game

A classic Snake game built as a C# console application targeting .NET 10.

## How to Play

Use the **arrow keys** to steer the snake. Eat the apples (`0`) to grow and increase your score. The game ends if the snake hits a wall (`#`) or runs into itself.

When the game is over, you can choose to play again or quit.

## Controls

| Key | Action |
|-----|--------|
| Arrow Up | Move up |
| Arrow Down | Move down |
| Arrow Left | Move left |
| Arrow Right | Move right |

## Running the Game

```bash
dotnet run
```

## Project Structure

| File | Description |
|------|-------------|
| `Program.cs` | Main game loop — rendering, input, collision detection |
| `coord.cs` | `Coord` class for 2D positions and movement |
| `DIrect.cs` | `Direction` enum (Up, Down, Left, Right) |
