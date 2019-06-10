using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            var game = new Game(new Board(new ConsoleWriter()));


            Console.WriteLine("Hello Welcome to Tic Tac Toe Game");
            Console.WriteLine("This Game requires 2 players, please enter the player names\n");
            Console.WriteLine("Enter player one name");
            var playerOne = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter player two name");
            var playerTwo = Convert.ToString(Console.ReadLine());

            game.PlayerOne = new User { Name = playerOne,Id=0 };
            game.PlayerTwo = new User { Name = playerTwo,Id=1 };
            Console.WriteLine("\n");
            Console.WriteLine("Board has 3 rows and 3 columns , namely 0,1,2 \n");


            while (game.Winner.Id != +1 || game.Winner.Id != -1)
            {
                var currentplayer = game.CurrentPlayer.Name == playerOne ? playerTwo : playerOne;
                Console.WriteLine("Currently playing by {0} \n", currentplayer);

                Console.WriteLine("Enter row # to which you wanna make move");
                var row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter coloumn # to which you wanna make move");
                var col = Convert.ToInt32(Console.ReadLine());


                game.MakeMove(new Move { ColNumber = col, RowNumber = row, Player = new User { Id = game.CurrentPlayer.Name == playerOne ? 0 : 1, Name = game.CurrentPlayer.Name == playerOne ? playerTwo : playerOne } });

                game.PrintBoard();

            }

        }


    }
}
