using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Test
    {
        public int[,] _board { get; set; }
        public int _n { get; set; }

        public int[] RowSum { get; set; }

        public int[] ColSum { get; set; }

        public int DiagnolSum { get; set; }

        public int RevDiagnolSum { get; set; }

        public int Winner { get; private set; }



        public Test(int n)
        {
            _board = new int[n, n];
            _n = n;
            RowSum = new int[n];
            ColSum = new int[n];

        }

        public int Move(int player, int row, int col)
        {
            if (row < 0 || col < 0 || row >= _n || col >= _n)
            {
                throw new ArgumentException("Move out of board boundary");
            }
            if (_board[row, col] != 0)
            {
                throw new ArgumentException("Square already occupied");
            }
            if (player != 0 && player != 1)
            {
                throw new ArgumentException("Invalid player");
            }
            if (Winner != 0)
            {
                throw new ArgumentException("Board is decided");
            }

            player = player == 0 ? -1 : +1;
            _board[row, col] = player;
            RowSum[row] += player;
            ColSum[col] += player;

            if (row == col)
            {
                DiagnolSum += player;
            }

            if (row == _n - 1 - col)
            {
                RevDiagnolSum += player;

            }

            if (RowSum[row] == Math.Abs(_n) || ColSum[col] == Math.Abs(_n) || DiagnolSum == Math.Abs(_n) || RevDiagnolSum == Math.Abs(_n))
            {

                Winner = player;
            }

            return Winner;

        }




    }
}
