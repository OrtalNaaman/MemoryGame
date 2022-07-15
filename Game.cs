using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class Game
    {
        public Board Board { get; set; }
        private int Couples { get; set; }
        public User[] User { get; set; }
        private int TotalWins { get; set; }
        public Game(Board board, int players)
        {
            Board = board;
            Couples = Board.Size * Board.Size / 2;
            User = new User[players];
        }
        public bool Success(User user)
        {
            Board.PrintBoard();
            Card card1 = new Card(Board, "first");
            Board.PrintBoard(card1);
            Card card2 = new Card(Board, "second");
            while (card1.SameChoice(card2))
            {
                SetColor("Error! you chose the same place!\n", ConsoleColor.Yellow);
                card2 = new Card(Board, "second");
            }
            Board.PrintBoard(card1, card2);
            if (card1.Value == card2.Value)
            {
                SetColor($"Great {user.Name.ToUpper()}! you earned 1 point!\n", ConsoleColor.Red);
                user.Points++;
                TotalWins++;
                SetColor($"Now your total is {user.Points} points!\n\n", ConsoleColor.Red);
                card1.RemoveCard();
                card2.RemoveCard();
                return true;
            }
            else
            {
                SetColor("Wrong!\n\n", ConsoleColor.Red);
                return false;
            }
        }
        public void Play()
        { 
            if (User.Length == 1)
            {
                Console.WriteLine("Please enter your name: ");
                User[0] = new User(Console.ReadLine());
                SetColor($"\n\nWELCOME {User[0].Name.ToUpper()}! \n", ConsoleColor.Red);
                while (TotalWins < Couples)
                {
                    Success(User[0]);
                }
            }
            else
            {
                for (int i = 0; i < User.Length; i++)
                {
                    Console.WriteLine($"Player number {i + 1} , please enter your name: ");
                    User[i] = new User(Console.ReadLine());
                }
                Console.Clear();
                SetColor("**********WELCOME!!!**********", ConsoleColor.Yellow);
                for (int i = 0; i < User.Length; i++)
                {
                    SetColor($"\nPlayer Number {i + 1}: {User[i].Name.ToUpper()}", ConsoleColor.Yellow);
                }
                Console.WriteLine("\n\n");
                while (TotalWins < Couples)
                {
                    foreach (User user in User)
                    {
                        if (TotalWins < Couples)
                        {
                            SetColor($"{user.Name.ToUpper()} Is Now Play:", ConsoleColor.Red);
                            while (TotalWins < Couples)
                            {
                                while (Success(user) && (TotalWins < Couples))
                                    Console.WriteLine($"{user.Name.ToUpper()} now you can play another round!");
                                break;
                            }
                        }
                    }
                }
            }
            foreach (User user in User)
            {
                SetColor(user.ToString()+"\n", ConsoleColor.Magenta);
            }
        }
        public static void SetColor(string strToColor, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(strToColor);
            Console.ResetColor();
        }
    }
}

