namespace TicTacToe.Move
{
    class MoveValidatorInput
    {
        public Move Move { get; set; }

        public int BoardSize { get; set; }

        public int[,] Board { get; set; }

        public User.User Winner { get; set; }


    }
}
