using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GridGame
{
    class GameData
    {
        public  string username="";
        public  int[,] player1Board=new int[Engine.width, Engine.height];
        public int[,] player2Board= new int[Engine.width, Engine.height];
        public int tries = 0;
        public int seconds = 0;
        public  int minutes=0;
        public  int hours=0;

        public GameData()
        {
            player1Board = Engine.board1;
            player2Board = Engine.board2;
            tries = Engine.P1Tries;
            username = Engine.playerName;
            seconds = Form1.seconds;
            minutes = Form1.minutes;
            hours = Form1.hours;
        }

        public void updateTimer()
        {
            seconds = Form1.seconds;
            minutes = Form1.minutes;
            hours = Form1.hours;
        }
   
        public void updateBoards()
        {
            player1Board = Engine.board1;
            player2Board = Engine.board2;
            
        }

        public void updateTries()
        {
            tries = Engine.P2Tries;
        }
        public void updateUsername()
        {
            username = Engine.playerName;
        }

}

}
