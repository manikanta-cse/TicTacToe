namespace TicTacToe.Move
{
    public class Move
    {
        public int RowNumber { get; set; }

        public int ColNumber { get; set; }

        public User.User Player { get; set; }
    }
}