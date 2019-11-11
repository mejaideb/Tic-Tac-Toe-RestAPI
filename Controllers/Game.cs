using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_Tac_Toe.Controllers
{
    public class Game
    {
        public static string[,] arr1 = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        HttpResponse Response;
        static bool player = false;
        
        public bool RowCrossed(string[,] board, string v)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] &&
                    board[i, 1] == board[i, 2] &&
                    board[i, 0] == v)
                    return (true);
            }
            return (false);
        }
        public bool ColumnCrossed(string[,] board, string v)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] &&
                    board[1, i] == board[2, i] &&
                    board[0, i] == v)
                    return (true);
            }
            return (false);
        }
        public bool DiagonalCrossed(string[,] board, string v)
        {
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] == v)
                return (true);
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] == v)
                return (true);
            return (false);
        }

        public bool GameOver(string[,] board ,string v)
        {
            return (RowCrossed(board, v) || ColumnCrossed(board, v) || DiagonalCrossed(board, v));

        }

        public bool GameDraw()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (!arr1[i, j].Contains("X") && !arr1[i, j].Contains("O"))
                        return false;
               
                }
                
            }
            return true;
        }

        public void CheckWinStatus()
        {
            if (RowCrossed(arr1, "X"))
            {

                Response.WriteAsync("\n X Wins\n \n");
                GameAgain();
            }

            if (RowCrossed(arr1, "O"))
            {
                Response.WriteAsync("\n O Wins\n \n");
                GameAgain();
            }
            if (ColumnCrossed(arr1, "X"))
            {
                Response.WriteAsync("\n X Wins\n \n");
                GameAgain();
            }
            if (ColumnCrossed(arr1, "O"))
            {
                Response.WriteAsync("\n O Wins");
                GameAgain();
            }
            if (DiagonalCrossed(arr1, "X"))
            {
                Response.WriteAsync("\n X Wins\n \n");
               GameAgain();
            }
            if (DiagonalCrossed(arr1, "O"))
            {
                Response.WriteAsync("\n O Wins");
                GameAgain();
            }

        }
        public void DisplayBoard()
        {
            Response.WriteAsync("Make Your Choice ..\n");
            Response.WriteAsync("------------------------------------------------------\n");
            Response.WriteAsync("\nThe matrix is : \n");
            for (int i = 0; i < 3; i++)
            {
                Response.WriteAsync("\n");
                for (int j = 0; j < 3; j++)
                {

                    Response.WriteAsync("\t" + arr1[i, j]);
                }
            }
            Response.WriteAsync("\n\n");
        }
        public void GameAgain()
        {
            int k = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr1[i, j] = (k++).ToString();
                }
            }
        }
        public bool ChangePlayer()
        {
            //bool player = false;
            player = !player;
            return player;
        }
        public int UpdateBoard(int id)
        {
            int position = 0;
            foreach (int element in list)
            {
                if (id == element)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            position++;

                            if (arr1[i, j].Equals("X") || arr1[i, j].Equals("O"))
                            {
                                continue;
                            }
                            if (position == id)
                            {
                                if (ChangePlayer())
                                    arr1[i, j] = "X";
                                else
                                    arr1[i, j] = "O";
                            }
                        }
                    }
                    CheckWinStatus();
                }
            }

            return position;
        }
        
    }

}