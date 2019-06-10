using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        public int[,] Blocks { get; private set; }

        public User Winner { get; private set; }

        public int BoardSize { get; private set; }

        private int[] RowSum { get; set; }

        private int[] ColSum { get; set; }

        private int DiagnolSum { get; set; }

        private int RevDiagnolSum { get; set; }

        private IWriter _writer { get; set; }

        public Board(IWriter writer)
        {
            Blocks = new int[3, 3]; // 2d matrix
            BoardSize = 2;
            RowSum = new int[3];
            ColSum = new int[3];
            _writer = writer;
            Winner = new User();
        }


        public User MakeMove(Move move)
        {

            MoveValidator.Validate(BuildInput(move));

            SetPlayerOnBoard(move);

            DoRowSum(move);

            DoColoumnSum(move);

            SetDiagnolMove(move);

            SetReverseDiagnolMove(move);

            //SetWinner(move);

            return Winner;

        }

        private MoveValidatorInput BuildInput(Move move)
        {
            return new MoveValidatorInput { Board = Blocks, Move = move, BoardSize = BoardSize, Winner = Winner };
        }

        private void SetPlayerId(Move move)
        {
            move.Player.Id = move.Player.Id == 0 ? -1 : +1;
        }

        public void PrintBoard()
        {
            Console.WriteLine("-------Board--------");
            _writer.Write(this);
            Console.WriteLine("--------------------");
        }

        private void SetDiagnolMove(Move move)
        {
            if (IsDiagnolMove(move))
            {
                DiagnolSum += move.Player.Id;
            }
        }

        private void SetReverseDiagnolMove(Move move)
        {
            if (IsReverseDiagnolMove(move))
            {
                RevDiagnolSum += move.Player.Id;

            }
        }

        //private void SetWinner(Move move)
        //{
        //    if (IsWinner(move))
        //    {
        //        Winner = move.Player;
        //    }
        //}

        public bool IsWinner(Move move)
        {
            return RowSum[move.RowNumber] == Math.Abs(BoardSize) || ColSum[move.ColNumber] == Math.Abs(BoardSize) || DiagnolSum == Math.Abs(BoardSize) || RevDiagnolSum == Math.Abs(BoardSize);
        }

        private void SetPlayerOnBoard(Move move)
        {
            Blocks[move.RowNumber, move.ColNumber] = move.Player.Id;
        }

        private void DoRowSum(Move move)
        {
            RowSum[move.RowNumber] += move.Player.Id;
        }

        private void DoColoumnSum(Move move)
        {
            ColSum[move.ColNumber] += move.Player.Id;
        }

        private bool IsDiagnolMove(Move move)
        {
            return move.RowNumber == move.ColNumber;
        }

        private bool IsReverseDiagnolMove(Move move)
        {
            return move.RowNumber == BoardSize - 1 - move.ColNumber;
        }



    }
}

