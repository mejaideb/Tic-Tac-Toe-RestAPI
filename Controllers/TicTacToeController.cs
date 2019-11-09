using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tic_Tac_Toe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicTacToeController : ControllerBase
    {
        int i, j;
        static string[,] arr1 = new string[3, 3] { {"1","2" ,"3"},{ "4","5","6"},{ "7","8","9"} };
        List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

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
            Response.WriteAsync("Make Your Choice ..\n");
            Response.WriteAsync("------------------------------------------------------\n");
            Response.WriteAsync("\nThe matrix is : \n");
            for (i = 0; i < 3; i++)
            {
                Response.WriteAsync("\n");
                for (j = 0; j < 3; j++) {

                    Response.WriteAsync("\t" + arr1[i, j]);
                }
            }
            Response.WriteAsync("\n\n");
        }

        [HttpGet("{id}")]
        public void Get(int id)
        {
            int jaideb = 0;
            jaideb = UpdateBoard(id, jaideb);
            Get();
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
                            if (jaideb == id)
                            {
                                if (ChangePlayer())
                                    arr1[i, j] = "X";
                                else
                                    arr1[i, j] = "O";
                            }


                        }
                    }
                    if (RowCrossed(arr1, "X"))
                        Response.WriteAsync("\n X Wins\n \n");
                }
            }

            return jaideb;
        }


        public bool RowCrossed(string[,] board, string v)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] == board[i,1] &&
                    board[i,1] == board[i,2] &&
                    board[i,0] == v)
                    return (true);
            }
            return (false);
        }





        // POST: api/TicTacToe
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TicTacToe/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
