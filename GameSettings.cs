namespace Snake;

    internal static class GameSettings
    {
        public static int GridCols { get; set; } = 40;
        public static int GridRows { get; set; } = 30;

        public static int CellSize { get; set; } = 20;

        public static int HeaderHeight { get; set; } = 40;

        public static int WindowWidth => GridCols * CellSize;
        public static int WindowHeight => GridRows * CellSize + HeaderHeight;

        public static readonly Dictionary<Difficulty, float> TicksPerSecond = new Dictionary<Difficulty, float>
        {
            { Difficulty.Easy, 5f },
            { Difficulty.Medium, 10f },
            { Difficulty.Hard, 20f }
        };

        
    }
    internal enum Difficulty
    {
        Easy, Medium, Hard
    }


