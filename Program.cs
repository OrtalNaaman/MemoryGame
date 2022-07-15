using System;

namespace MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game.SetColor("***********************MEMORY GAME***********************\n", ConsoleColor.Magenta);
            StartNewGame();
        }
        public static void GetValidSize(out int size)
        {
            size = 0;
            while (size == 0)
            {
                try
                {
                    do
                    {
                        Console.WriteLine("\nChoose an even number for the board size, between 2 to 8:");
                        size = int.Parse(Console.ReadLine());
                    }
                    while ((size < 2) | (size > 8) | (size % 2 != 0));
                }
                catch (Exception)
                {
                    Game.SetColor("You didn't entered a valid number.", ConsoleColor.Yellow);
                    GetValidSize(out size);
                }
            }   
        }
        public static void StartNewGame()
        {
            int size;
            GetValidSize(out size);
            Board board = new Board(size);
            Console.WriteLine("Please enter number of players: ");
            int playersNum = 0;
            while (playersNum == 0)
            {
                try
                {
                    playersNum = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Game.SetColor("You didn't entered a valid number. Please enter number of players\n", ConsoleColor.Yellow);
                    playersNum = 0;
                }    
            }
            Console.Clear();
            Game game = new Game(board, playersNum);
            game.Play();

            Game.SetColor("****************GAME OVER!*******************\n\n", ConsoleColor.Magenta);
            Game.SetColor("IF YOU WANT TO PLAY AGAIN PLEASE ENTER Y.\nTO EXIT PRESS ANY OTHER KEY.\n", ConsoleColor.DarkCyan);

            string wantToPlay = Console.ReadLine();
            if (wantToPlay.ToUpper() == "Y")
            {
                Console.Clear();
                StartNewGame();
            }
            else
            {
                Game.SetColor("\nTHANK YOU FOR PLAYING! GOODBY!\n\n", ConsoleColor.Magenta);   
                return;
            }
        }
    }
}


