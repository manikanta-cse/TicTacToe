using System.Collections.Generic;

namespace TicTacToe.Game
{
    class Game
    {
        public int Id { get; set; }

        public User.User PlayerOne { get; set; }

        public User.User PlayerTwo { get; set; }

        //kept here to maintain moves, so that undo move can be done easily
        public List<Move.Move> Moves { get; set; }

        private readonly Board.Board _board;

        public User.User CurrentPlayer { get; private set; }

        public User.User Winner { get; private set; }


        public Game(Board.Board board)
        {
            _board = board;
            CurrentPlayer = new User.User();
            Winner = new User.User();
        }


        public User.User MakeMove(Move.Move move)
        {
            SetCurrentPlayer(move);
            SetPlayerId(move);
            SetWinner(move);
            return _board.MakeMove(move);
        }

        public void PrintBoard()
        {
            _board.PrintBoard();
        }

        private void SetCurrentPlayer(Move.Move move)
        {
            CurrentPlayer = move.Player;
        }

        private void SetPlayerId(Move.Move move)
        {
            move.Player.Id = move.Player.Id == 0 ? -1 : +1;
        }

        private void SetWinner(Move.Move move)
        {
            if (_board.IsWinner(move))
            {
                Winner = move.Player;
            }
        }

    }
}
