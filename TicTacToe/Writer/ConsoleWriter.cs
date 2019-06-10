using System;

namespace TicTacToe.Writer
{
    class ConsoleWriter : IWriter
    {
        public void Write(Board.Board board)
        {
            int rowLength = board.Blocks.GetLength(0);
            int colLength = board.Blocks.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", board.Blocks[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
