using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class MoveValidatorInput
    {
        public Move Move { get; set; }

        public int BoardSize { get; set; }

        public int[,] Board { get; set; }

        public User Winner { get; set; }


    }
}
