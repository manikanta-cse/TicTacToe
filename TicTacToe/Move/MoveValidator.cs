using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class MoveValidator
    {
        public static void Validate(MoveValidatorInput moveExceptionInput)
        {
            if (IsMoveOutOfBoundary(moveExceptionInput))
            {
                throw new ArgumentException("Move out of board boundary");
            }
            if (IsSquareOccupied(moveExceptionInput))
            {
                throw new ArgumentException("Square already occupied");
            }
            if (IsInvalidPlayer(moveExceptionInput))
            {
                throw new ArgumentException("Invalid player");
            }
            if (IsBoardDecided(moveExceptionInput))
            {
                throw new ArgumentException("Board is decided");
            }
        }


        private static bool IsMoveOutOfBoundary(MoveValidatorInput moveExceptionInput)
        {
            return (moveExceptionInput.Move.RowNumber < 0 || moveExceptionInput.Move.ColNumber < 0 || moveExceptionInput.Move.RowNumber >= moveExceptionInput.BoardSize || moveExceptionInput.Move.ColNumber >= moveExceptionInput.BoardSize);
        }

        private static bool IsSquareOccupied(MoveValidatorInput moveExceptionInput)
        {
            return (moveExceptionInput.Board[moveExceptionInput.Move.RowNumber, moveExceptionInput.Move.ColNumber] != 0);
        }

        private static bool IsInvalidPlayer(MoveValidatorInput moveExceptionInput)
        {
            return (moveExceptionInput.Move.Player.Id != 0 && moveExceptionInput.Move.Player.Id != 1);
        }

        private static bool IsBoardDecided(MoveValidatorInput moveExceptionInput)
        {
            return (moveExceptionInput.Winner.Id != 0);
        }




    }
}
