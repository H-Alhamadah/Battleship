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
    public partial class ResumeGame : Form
    {
        Button start = new Button();
        ComboBox saveGames = new ComboBox();
        Label message = new Label();
        List<GridGame.Models.WaterWarsSave> saves = new List<WaterWarsSave>();
        public static GridGame.Models.WaterWarsSave waterWarsResumedGame;
        public ResumeGame()
        {

            InitializeComponent();
            this.FormClosing += ClosingGame;
            styleForm();
        }

        public void styleForm()
        {
            message.Text = "Choose a saved game";
            message.Font= new Font(message.Font.FontFamily, 20);
            message.Location = new System.Drawing.Point(90, 10);
            message.Size = new System.Drawing.Size(400, 50);
            Controls.Add(message);

            start.Text = "Start";
            start.Font = new Font(start.Font.FontFamily, 10);
            start.Location = new System.Drawing.Point(200, 150);
            start.Size = new System.Drawing.Size(100, 25);
            start.Click += new System.EventHandler(this.StartGame);
            Controls.Add(start);


            saveGames.Location= new System.Drawing.Point(50, 70);
            saveGames.Size = new System.Drawing.Size(400, 25);
            populateList();
            Controls.Add(saveGames);
        }

        private void populateList()
        {
            saves = Program.dbContext.WaterWarsSaves.ToList();

            for (int i=0; i<saves.Count; i++)
            {
                saveGames.Items.Add(saves[i].UserName + "   " + saves[i].EndTime.ToString());
            }
            
        }
        private void StartGame(object sender, EventArgs e)
        {
            waterWarsResumedGame = saves[saveGames.SelectedIndex];
            Engine.playerName = saves[saveGames.SelectedIndex].UserName;
            Engine.P1Tries = saves[saveGames.SelectedIndex].Score;
            Engine.P2Tries= saves[saveGames.SelectedIndex].Score;
            Form1.hours =(int) saves[saveGames.SelectedIndex].TimerHour;
            Form1.minutes = (int)saves[saveGames.SelectedIndex].TimerMinute;
            Form1.seconds = (int)saves[saveGames.SelectedIndex].TimerSecond;

            char[,] array= new char[Engine.width, Engine.height];
            int index1 = 0;
            for(int i=0; i<Engine.width; i++)
            {
                for (int j=0; j<Engine.height; j++)
                {
                    array[i,j]= saves[saveGames.SelectedIndex].Board1[index1++];
                    Engine.board1[i,j]=(int)Char.GetNumericValue(array[i, j]);
                }
            }
            int index2 = 0;
            for (int i = 0; i < Engine.width; i++)
            {
                for (int j = 0; j < Engine.height; j++)
                {
                    array[i, j] = saves[saveGames.SelectedIndex].Board2[index2++];
                    Engine.board2[i, j] = (int)Char.GetNumericValue(array[i, j]);
                }
            }
            string[] tops1 = saves[saveGames.SelectedIndex].ShipsTop1.Split();
            string[] lefts1 =saves[saveGames.SelectedIndex].ShipsLeft1.Split();
            string[] widths1 = saves[saveGames.SelectedIndex].ShipsWidth1.Split();
            string[] heights1 =saves[saveGames.SelectedIndex].ShipsHeight1.Split();
            string[] ori1 = saves[saveGames.SelectedIndex].ShipsOrientation1.Split();

            string[] tops2 = saves[saveGames.SelectedIndex].ShipsTop2.Split();
            string[] lefts2 = saves[saveGames.SelectedIndex].ShipsLeft2.Split();
            string[] widths2 = saves[saveGames.SelectedIndex].ShipsWidth2.Split();
            string[] heights2 = saves[saveGames.SelectedIndex].ShipsHeight2.Split();
            string[] ori2 = saves[saveGames.SelectedIndex].ShipsOrientation2.Split();



            if (saves[saveGames.SelectedIndex].NextGuessX != null) { 
            string[] guessX = saves[saveGames.SelectedIndex].NextGuessX.Split();
            string[] guessY = saves[saveGames.SelectedIndex].NextGuessY.Split();
            

                for (int i = guessX.Length - 2; i >= 0; i--)
                {
                    Engine.goodGuessX.Push(int.Parse(guessX[i]));
                    Engine.goodGuessY.Push(int.Parse(guessY[i]));

                }
            }
            for (int i=0; i<Engine.shipsList1.Length; i++)
            {

                if (int.Parse(ori1[i]) == 1)
                {
                    Engine.shipsList1[i] = new Ship(int.Parse(lefts1[i]), int.Parse(tops1[i]), int.Parse(widths1[i]), int.Parse(heights1[i]), true);

                }
                else
                {
                    Engine.shipsList1[i] = new Ship(int.Parse(lefts1[i]), int.Parse(tops1[i]), int.Parse(widths1[i]), int.Parse(heights1[i]), false);
                }

                if (int.Parse(ori2[i]) == 1)
                {
                    Engine.shipsList2[i] = new Ship(int.Parse(lefts2[i]), int.Parse(tops2[i]), int.Parse(widths2[i]), int.Parse(heights2[i]), true);
                }
                else
                {
                    Engine.shipsList2[i] = new Ship(int.Parse(lefts2[i]), int.Parse(tops2[i]), int.Parse(widths2[i]), int.Parse(heights2[i]), false);
                }



            }

            Engine.resumeGame = true;

            this.Close();
        }

        private void ClosingGame(object sender, FormClosingEventArgs e)
        {
            Engine.forceClosed = true;
        }
    }
}
