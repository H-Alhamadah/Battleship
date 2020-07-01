using GridGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridGame
{

     
    static class Program
    {
         public static UltimateExoticSharedDatabaseEntities dbContext = new UltimateExoticSharedDatabaseEntities();


        public class PlayerData
        {
            public int score = 0;
            public int roundsPlayed = 0;
            public string playerName = "";

            public PlayerData()
            {

            }
        }



        static User GetUser(UltimateExoticSharedDatabaseEntities dbContext, string username)
        {
            var user = dbContext.Users.Where(x => x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                user = new User();
                user.UserName = username;
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return dbContext.Users.Where(x => x.UserName == username).First();
            }
            return user;
        }


        static void AddGameRecord(UltimateExoticSharedDatabaseEntities dbContext, WaterWar WWdata)
        {
            dbContext.WaterWars.Add(WWdata);
            dbContext.SaveChanges();
        }
        [STAThread]
        static void Main(string[] args)
        {


            var newData = new PlayerData();
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Title());


            if (Title.dialogResult == DialogResult.Yes)
            {
                Application.Run(new ResumeGame());
            }
            else if(Title.dialogResult == DialogResult.No)
            {
                Application.Run(new NewGame());
            }

        if (Engine.forceClosed)
         {
          Application.Run(new Form1());
          }


            newData.playerName = Engine.playerName;
            newData.score = Engine.P1Tries;
            newData.roundsPlayed = 1;
            




            var user = GetUser(dbContext, newData.playerName);
            var waterWarsData = ResumeGame.waterWarsResumedGame != null ? dbContext.WaterWars.First(x => x.ID == ResumeGame.waterWarsResumedGame.ID) : new WaterWar();

            waterWarsData.User = user;
            waterWarsData.Win = Engine.win;
            waterWarsData.Score = newData.score;
            waterWarsData.StartTime = Form1.startTime;
            waterWarsData.EndTime = Form1.endTime;
            if (Engine.save)
            {
                waterWarsData.Saved = true;
                waterWarsData.TimerHour = Form1.hours;
                waterWarsData.TimerMinute = Form1.minutes;
                waterWarsData.TimerSecond = Form1.seconds;
                waterWarsData.Board1 = Engine.board1String;
                waterWarsData.Board2 = Engine.board2String;

                waterWarsData.ShipsTop1 = Engine.P1ShipTop;
                waterWarsData.ShipsLeft1 = Engine.P1ShipLeft;
                waterWarsData.ShipsWidth1 = Engine.P1ShipWidth;
                waterWarsData.ShipsHeight1 = Engine.P1ShipHeight;
                waterWarsData.ShipsOrientation1 = Engine.P1ShipOr;
                waterWarsData.ShipsTop2 = Engine.P2ShipTop;
                waterWarsData.ShipsLeft2 = Engine.P2ShipLeft;
                waterWarsData.ShipsWidth2 = Engine.P2ShipWidth;
                waterWarsData.ShipsHeight2 = Engine.P2ShipHeight;
                waterWarsData.ShipsOrientation2 = Engine.P2ShipOr;
                waterWarsData.NextGuessX = Engine.GuessX;
                waterWarsData.NextGuessY = Engine.GuessY;

                
            }

            if (ResumeGame.waterWarsResumedGame == null)
                AddGameRecord(dbContext, waterWarsData);
            else
                dbContext.SaveChanges();
        }


    }
}
