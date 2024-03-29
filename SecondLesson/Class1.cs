class Program
{
    static int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

    static void Main(string[] args)
    {
        int[,] chessboard = new int[8, 8];
        int totalSteps = 0;

        Console.WriteLine("Enter coordinates to place the knight (x, y):");
        int x = int.Parse(Console.ReadLine()) - 1;
        int y = int.Parse(Console.ReadLine()) - 1;

        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            FillChessboard(chessboard);

            chessboard[x, y] = -1;

            PrintChessboardWithKnight(chessboard, x, y);

            while (true)
            {
                int minMoves = int.MaxValue;
                int newX = -1, newY = -1;
                for (int i = 0; i < 8; i++)
                {
                    int nextX = x + dx[i];
                    int nextY = y + dy[i];
                    if (IsValidMove(nextX, nextY) && chessboard[nextX, nextY] > 0)
                    {
                        int moves = chessboard[nextX, nextY];
                        if (moves < minMoves)
                        {
                            minMoves = moves;
                            newX = nextX;
                            newY = nextY;
                        }
                    }
                }

                if (newX == -1 && newY == -1)
                    break;

                x = newX;
                y = newY;
                chessboard[x, y] = -1;
                totalSteps++;

                Console.WriteLine("\nThe knight has moved:");
                PrintChessboardWithKnight(chessboard, x, y);
            }

            Console.WriteLine($"\nTotal steps taken by the knight: {totalSteps + 1}");
        }
        else
        {
            Console.WriteLine("Coordinates are outside the chessboard.");
        }
    }

    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }

    static void FillChessboard(int[,] chessboard)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                chessboard[i, j] = CountPossibleMoves(i, j);
            }
        }
    }

    static int CountPossibleMoves(int x, int y)
    {
        int possibleMoves = 0;
        for (int i = 0; i < 8; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];
            if (IsValidMove(newX, newY))
                possibleMoves++;
        }

        return possibleMoves;
    }

    static void PrintChessboardWithKnight(int[,] chessboard, int knightX, int knightY)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (i == knightX && j == knightY)
                {
                    Console.Write("  # ");
                }
                else
                {
                    Console.Write(chessboard[i, j].ToString().PadLeft(3) + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
