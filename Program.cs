using System;
using System.Collections.Generic; //Access the List Class
using System.Linq;


namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = NextPlayer ("");
            Console.WriteLine(player);
            List<string> board = CreateBoard();

            while (! (HasWinner(board) || IsDraw(board)))
            {
                Display_Board(board);
                Make_Move(player, board);
                player = NextPlayer(player);
            }
            Display_Board(board);
            Console.WriteLine("Thanks for playing!");


        }
        static string NextPlayer(string current)
        {
            if(current == "" || current == "o")
            {
                return "x";
            }
            else if(current == "x")
            {
                return "o";
            }
        return current;

        }

        static List<string> CreateBoard()
        {
            //Creates a new list
            //It's a string list because the inputs will be x and o
            //The numbers in board will just be the position
            List<string> board = new List<string>();
            foreach (int square in Enumerable.Range(1,9))
            {
                board.Add(square.ToString());
                Console.WriteLine(square);
            }
            return board;
        }
        static bool HasWinner(List<string> board)
        //A==B && B==C
        {
            return (board[0] == board[1] && board[1]==board[2] ||
                    board[3] == board[4] && board[4]==board[5] ||
                    board[6] == board[7] && board[7]==board[8] ||
                    board[0] == board[3] && board[3]==board[6] ||
                    board[1] == board[4] && board[4]==board[7] ||
                    board[2] == board[5] && board[5]==board[8] ||
                    board[0] == board[4] && board[4]==board[8] ||
                    board[2] == board[4] && board[4]==board[6]);
        }

        static bool IsDraw(List<string> board)
        {
            foreach(int square in Enumerable.Range(1,9))
            {
                if(board[square] != "x" && board[square] != "o")
                {
                return false;
                }
            }
            //Only true after it checks the WHOLE board
            return true;
        }
        static void Display_Board(List<string> board)
        {
            Console.WriteLine("");
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
            Console.WriteLine("-+-+-");
        }
        static void Make_Move(string player, List<string> board)
        {
            Console.Write($"{player}'s turn to choose a square (1-9): ");
            int square = Convert.ToInt32(Console.ReadLine());
            board[square-1] = player;
        }
    }
}
