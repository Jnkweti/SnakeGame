namespace Snake
{
    internal static class GameSetting
    {
        public static int GridCols { get; set; } = 40;
        public static int GridRows { get; set; } = 30;

        public static int cellSize { get; set; } = 20;

        public static int HeaderHeight { get; set; } = 40;

        public static int WindowWidth => GridCols * cellSize;
        public static int WindowHeight => GridRows * cellSize + HeaderHeight;

        public static readonly Dictionary<Difficulty, float> TicksPerSecond = new Dictionary<Difficulty, float>
        {
            { Difficulty.Easy, 5f },
            { Difficulty.Medium, 10f },
            { Difficulty.Hard, 15f }
        };

        
    }
    internal enum Difficulty
    {
        Easy, Medium, Hard
    }


}