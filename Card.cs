namespace MemoryGame
{
    public class Card
    {
        public Board Board { get; set; }
        public int RowNum { get; set; }
        public int ColNum { get; set; }
        public int Value { get; set; }
        public Card(Board board, string choice)
        {
            Board = board;
            SetCard(choice);
        }

        public void SetCard(string choice)
        {
            Console.WriteLine($"Choose {choice} card row:");
            try
            {
                RowNum = int.Parse(Console.ReadLine()) - 1;
                while ((RowNum < 0) || (RowNum >= Board.Size))
                {
                    Game.SetColor($"Row {RowNum + 1} isn't in range, enter a valid row:\n", ConsoleColor.Yellow);
                    RowNum = int.Parse(Console.ReadLine()) - 1;
                }
                Console.WriteLine($"Choose {choice} card column:");
                ColNum = int.Parse(Console.ReadLine()) - 1;
                while ((ColNum < 0) || (ColNum >= Board.Size))
                {
                    Game.SetColor($"Column {ColNum + 1} isn't in range, enter a valid column:\n", ConsoleColor.Yellow);
                    ColNum = int.Parse(Console.ReadLine()) - 1;
                }
                if (Board.GameBoard[RowNum, ColNum] == 0)
                {
                    Game.SetColor("OOPS! this card has allready been taken, try again\n", ConsoleColor.Yellow);
                    SetCard(choice);
                }
                Value = Board.GameBoard[RowNum, ColNum];
            }
            catch (Exception)
            {
                Game.SetColor("Invalid choice!\n", ConsoleColor.Yellow);
                SetCard(choice);
            }

            //Console.WriteLine($"The value of card[{RowNum + 1},{ColNum + 1}] = {Value}");     
        }
        public void RemoveCard()
        {
            Board.GameBoard[RowNum, ColNum] = 0;
        }
        public bool SameChoice(Card card2)
        {
            if ((RowNum==card2.RowNum) && (ColNum==card2.ColNum))
                return true;
            return false;
        }
    }
}