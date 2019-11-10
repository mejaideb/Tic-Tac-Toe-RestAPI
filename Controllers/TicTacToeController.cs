using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Tic_Tac_Toe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicTacToeController : ControllerBase
    {
        static string[,] arr1 = new string[3, 3] { {"1","2" ,"3"},{ "4","5","6"},{ "7","8","9"} };
        List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Game game = new Game();
        static bool player = false;
        public bool ChangePlayer()
        {
            //bool player = false;
            player = !player;
            return player;
        }
        // GET: api/TicTacToe
        [HttpGet]
        public void Get()
        {
            DisplayBoard();
        }
        [HttpGet("{id}")]
        public void Get(int id)
        {
            int jaideb = 0;
            jaideb = UpdateBoard(id, jaideb);
            Get();
        }

        private void DisplayBoard()
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

        

        private int UpdateBoard(int id, int jaideb)
        {
          

            foreach (int element in list)
            {
                if (id == element)
                {
                   
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            jaideb++;

                            if (arr1[i,j].Equals("X") || arr1[i, j].Equals("O"))
                            {
                                continue;
                            }
                            
                          
                            if (jaideb == id)
                            {
                                if (ChangePlayer())
                                    arr1[i, j] = "X";
                                else
                                    arr1[i, j] = "O";
                            }
                        }
                    }
                    if (game.RowCrossed(arr1, "X"))
                    {

                        Response.WriteAsync("\n X Wins\n \n");
                        GameAgain();
                    }

                    if (game.RowCrossed(arr1, "O"))
                    {
                        Response.WriteAsync("\n O Wins\n \n");
                        GameAgain();
                    }
                    if (game.ColumnCrossed(arr1, "X"))
                    {
                        Response.WriteAsync("\n X Wins\n \n");
                        GameAgain();
                    }
                    if (game.ColumnCrossed(arr1, "O"))
                    {
                        Response.WriteAsync("\n O Wins");
                        GameAgain();
                    }
                    if (game.DiagonalCrossed(arr1, "X"))
                    {
                        Response.WriteAsync("\n X Wins\n \n");
                        GameAgain();
                    }
                    if (game.DiagonalCrossed(arr1, "O"))
                    {
                        Response.WriteAsync("\n O Wins");
                        GameAgain();
                    }
                    


                }
            }

            return jaideb;
        }
    }
}
