using GridGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridGame
{
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
            printScores();
        }

        public void printScores()
        {
            var dbContext = new UltimateExoticSharedDatabaseEntities();
            var scores = dbContext.WaterWarsScores.ToList();
                

            System.Windows.Forms.Label List = new System.Windows.Forms.Label();
            System.Windows.Forms.Label List2 = new System.Windows.Forms.Label();
            System.Windows.Forms.Label List3 = new System.Windows.Forms.Label();
            List.Font = new Font(List.Font.FontFamily, 14);
            List.ForeColor = Color.Black;
            List.Location = new Point(10, 10);
            List.Size= new System.Drawing.Size(200, 550);

            List2.Font = new Font(List.Font.FontFamily, 14);
            List2.ForeColor = Color.Black;
            List2.Location = new Point(220, 10);
            List2.Size = new System.Drawing.Size(200, 550);

            List3.Font = new Font(List.Font.FontFamily, 14);
            List3.ForeColor = Color.Black;
            List3.Location = new Point(430, 10);
            List3.Size = new System.Drawing.Size(200, 550);
            string nameList ="";
            string scoreList = "";
            string dateList ="";

            nameList += "PLAYER\n\n";
            scoreList += "SCORE\n\n";
            dateList += "DATE\n\n";



            if (scores.Count > 10)
            {
                foreach (var i in scores)
                {
                    nameList += i.UserName + "\n\n";
                    scoreList += i.Score + "\n\n";
                    dateList += i.EndTime+ "\n\n";
                }

            }
            else
            {
                foreach (var i in scores)
                {
                    nameList += i.UserName + "\n\n";
                    scoreList += i.Score + "\n\n";
                    dateList += i.EndTime+ "\n\n";
                }

            }

            List.Text += nameList;
            List2.Text += scoreList;
            List3.Text += dateList;
            Controls.Add(List);
            Controls.Add(List2);
            Controls.Add(List3);
        }
    }
}
