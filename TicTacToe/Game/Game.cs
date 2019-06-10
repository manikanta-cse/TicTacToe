using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        public int Id { get; set; }

        public User PlayerOne { get; set; }

        public User PlayerTwo { get; set; }

        //kept here to maintain moves, so that undo move can be done easily
        public List<Move> Moves { get; set; }

        private readonly Board _board;

        public User CurrentPlayer { get; private set; }

        public User Winner { get; private set; }


        public Game(Board board)
        {
            _board = board;
            CurrentPlayer = new User();
            Winner = new User();
        }


        public User MakeMove(Move move)
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

        private void SetCurrentPlayer(Move move)
        {
            CurrentPlayer = move.Player;
        }

        private void SetPlayerId(Move move)
        {
            move.Player.Id = move.Player.Id == 0 ? -1 : +1;
        }

        private void SetWinner(Move move)
        {
            if (_board.IsWinner(move))
            {
                Winner = move.Player;
            }
        }

    }
}
