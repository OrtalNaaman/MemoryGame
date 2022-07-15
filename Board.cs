using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class Board
    {
        public int Size { get; set; }
        public int[,] GameBoard { get; set; }

        public Board(int size)
        {
            Size = size;
            GameBoard = new int[Size, Size];
            CreateRandomBoard();
        }
        public void CreateRandomBoard()
        {          
            for (int i = 1; i < 1 + Size * Size / 2; i++)
            {
                while (true)
                {
                    int rowNum = new Random().Next(0, Size);
                    int colNum = new Random().Next(0, Size);
                    if (GameBoard[rowNum, colNum] == 0)
                    {
                        GameBoard[rowNum, colNum] = i;
                        break;
                    }
                    else continue;
                }
                while (true)
                {
                    int rowNum = new Random().Next(0, Size);
                    int colNum = new Random().Next(0, Size);
                    if (GameBoard[rowNum, colNum] == 0)
                    {
                        GameBoard[rowNum, colNum] = i;
                        break;
                    }
                    else continue;
                }
            }
        }
        public void PrintBoard(params Card[] card)
        {   
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    bool isExposed = false;
                    for (int k = 0; k < card.Length; k++)
                    {
                        if (i == card[k].RowNum && j == card[k].ColNum)
                        {
                            Game.SetColor(GameBoard[i, j] + "\t", ConsoleColor.Green);
                            isExposed = true;
                        }
                    }
                    if (GameBoard[i, j] == 0)
                    {
                        Game.SetColor(GameBoard[i, j] + "\t", ConsoleColor.Cyan);
                    }       
                    else if (GameBoard[i, j] != 0 && !isExposed)
                        Game.SetColor("X" + "\t", ConsoleColor.Blue);  
                }
            }
            Console.WriteLine("\n\n\n");
        }

    }
}
