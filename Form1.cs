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
    public partial class Form1 : Form
    {
        const int refreshRate = 10;
        Graphics graphics = null;
        public const int rectWidth = 1;
        public const int rectHeight = 1;
        public const int drawScale = 20;
        static Brush whiteBrush = new SolidBrush(Color.White);
        static Brush redBrush = new SolidBrush(Color.Red);
        public static Brush blueBrush = new SolidBrush(Color.Blue);
        public static Brush blackBrush = new SolidBrush(Color.Black);
        public static Pen whitePen = new Pen(whiteBrush);
        static Pen redPen = new Pen(redBrush);
        static Pen bluePen = new Pen(blueBrush);
        public static Pen blackPen = new Pen(blackBrush);
        Engine engine = new Engine();
        public System.Windows.Forms.Label Player1 = new Label();
        public System.Windows.Forms.Label Player2 = new Label();
        public System.Windows.Forms.Label timer = new Label();
        public static int seconds;
        public static int minutes;
        public static int hours;
        static bool endGame = false;
        PictureBox p1Ship1 = new PictureBox();
        PictureBox p1Ship2 = new PictureBox();
        PictureBox p1Ship3 = new PictureBox();
        PictureBox p1Ship4 = new PictureBox();
        PictureBox p1Ship5 = new PictureBox();
        PictureBox p1Ship6 = new PictureBox();
        PictureBox p1Ship7 = new PictureBox();
        PictureBox p1Ship8 = new PictureBox();
        PictureBox p1Ship9 = new PictureBox();
        PictureBox p1Ship10 = new PictureBox();
        PictureBox p2Ship1 = new PictureBox();
        PictureBox p2Ship2 = new PictureBox();
        PictureBox p2Ship3 = new PictureBox();
        PictureBox p2Ship4 = new PictureBox();
        PictureBox p2Ship5 = new PictureBox();
        PictureBox p2Ship6 = new PictureBox();
        PictureBox p2Ship7 = new PictureBox();
        PictureBox p2Ship8 = new PictureBox();
        PictureBox p2Ship9 = new PictureBox();
        PictureBox p2Ship10 = new PictureBox();








        Button startGame = new Button();
        Button scoreboard = new Button();
        Button cancel = new Button();
        Timer gameTime = new Timer();
        public static DateTime startTime = new DateTime();
        public static DateTime endTime = new DateTime();
        public Form1()
        {
            engine.generateGame();
            InitializeComponent();

            gameTime.Enabled = true;
            gameTime.Interval = 1000;
            gameTime.Tick += new EventHandler(gameTimer_Tick);

            StyleLabels();
            StyleButtons();
            StyleShips();
            startTime = DateTime.Now;


            this.MouseClick += new MouseEventHandler(mouseClick);
            this.FormClosing += ClosingGame;
            this.Text = "Water Wars";
            graphics = Graphics.FromHwnd(Handle);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!endGame)
            {
                seconds++;
                if (seconds >= 60)
                {
                    seconds = 0;
                    minutes++;
                }
                if (minutes >= 60)
                {
                    minutes = 0;
                    hours++;
                }
                timer.Text = hours.ToString("D" + 3) + ":" + minutes.ToString("D" + 2) + ":" + seconds.ToString("D" + 2);
            }
        }
        public void StyleLabels()
        {
            Player1.BackColor = Color.Blue;
            Player1.ForeColor = Color.White;
            Player1.Location = new Point(0, 0);
            Player1.Text = Engine.playerName + ":     Tries: " + Engine.P1Tries + "      Targets Remaining: " + Engine.P1LiveShips;
            Player1.Width = 500;
            Player1.Font = new Font("Bodoni MT", 16);
            Controls.Add(this.Player1);

            Player2.BackColor = Color.Red;
            Player2.ForeColor = Color.White;
            Player2.Location = new Point(500, 0);
            Player2.Text = "Player 2:     Tries: " + Engine.P1Tries + "      Targets Remaining: " + Engine.P2LiveShips;
            Player2.Width = 500;
            Player2.Font = new Font("Bodoni MT", 16);
            Controls.Add(this.Player2);

            timer.BackColor = Color.Black;
            timer.ForeColor = Color.White;
            timer.Location = new Point(445, 525);
            timer.Width = 120;
            timer.Height = 30;
            timer.Font = new Font("Bodoni MT", 20);
            Controls.Add(this.timer);

        }
        public void StyleShips()

        {
            updateSink();
            if (Engine.shipsList1[0].orientation)
            {
                p1Ship1.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship1.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship1.BackColor = Color.Red;
            p1Ship1.Location = new System.Drawing.Point(Engine.shipsList1[0].shipLocationLeft * drawScale, Engine.shipsList1[0].shipLocationTop * drawScale + 20);
            p1Ship1.Size = new System.Drawing.Size(Engine.shipsList1[0].shipWidth, Engine.shipsList1[0].shipHeight);
            p1Ship1.SizeMode = PictureBoxSizeMode.StretchImage;
            




            if (Engine.shipsList1[1].orientation)
            {
                p1Ship2.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship2.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship2.BackColor = Color.Red;
            p1Ship2.Location = new System.Drawing.Point(Engine.shipsList1[1].shipLocationLeft * drawScale, Engine.shipsList1[1].shipLocationTop * drawScale + 20);
            p1Ship2.Size = new System.Drawing.Size(Engine.shipsList1[1].shipWidth, Engine.shipsList1[1].shipHeight);
            p1Ship2.SizeMode = PictureBoxSizeMode.StretchImage;
            




            if (Engine.shipsList1[2].orientation)
            {
                p1Ship3.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship3.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship3.BackColor = Color.Red;
            p1Ship3.Location = new System.Drawing.Point(Engine.shipsList1[2].shipLocationLeft * drawScale, Engine.shipsList1[2].shipLocationTop * drawScale + 20);
            p1Ship3.Size = new System.Drawing.Size(Engine.shipsList1[2].shipWidth, Engine.shipsList1[2].shipHeight);
            p1Ship3.SizeMode = PictureBoxSizeMode.StretchImage;
            


            if (Engine.shipsList1[3].orientation)
            {
                p1Ship4.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship4.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship4.BackColor = Color.Red;
            p1Ship4.Location = new System.Drawing.Point(Engine.shipsList1[3].shipLocationLeft * drawScale, Engine.shipsList1[3].shipLocationTop * drawScale + 20);
            p1Ship4.Size = new System.Drawing.Size(Engine.shipsList1[3].shipWidth, Engine.shipsList1[3].shipHeight);
            p1Ship4.SizeMode = PictureBoxSizeMode.StretchImage;
            


            if (Engine.shipsList1[4].orientation)
            {
                p1Ship5.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship5.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship5.BackColor = Color.Red;
            p1Ship5.Location = new System.Drawing.Point(Engine.shipsList1[4].shipLocationLeft * drawScale, Engine.shipsList1[4].shipLocationTop * drawScale + 20);
            p1Ship5.Size = new System.Drawing.Size(Engine.shipsList1[4].shipWidth, Engine.shipsList1[4].shipHeight);
            p1Ship5.SizeMode = PictureBoxSizeMode.StretchImage;
           


            if (Engine.shipsList1[5].orientation)
            {
                p1Ship6.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship6.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship6.BackColor = Color.Red;
            p1Ship6.Location = new System.Drawing.Point(Engine.shipsList1[5].shipLocationLeft * drawScale, Engine.shipsList1[5].shipLocationTop * drawScale + 20);
            p1Ship6.Size = new System.Drawing.Size(Engine.shipsList1[5].shipWidth, Engine.shipsList1[5].shipHeight);
            p1Ship6.SizeMode = PictureBoxSizeMode.StretchImage;
            


            if (Engine.shipsList1[6].orientation)
            {
                p1Ship7.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship7.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship7.BackColor = Color.Red;
            p1Ship7.Location = new System.Drawing.Point(Engine.shipsList1[6].shipLocationLeft * drawScale, Engine.shipsList1[6].shipLocationTop * drawScale + 20);
            p1Ship7.Size = new System.Drawing.Size(Engine.shipsList1[6].shipWidth, Engine.shipsList1[6].shipHeight);
            p1Ship7.SizeMode = PictureBoxSizeMode.StretchImage;
            


            if (Engine.shipsList1[7].orientation)
            {
                p1Ship8.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship8.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship8.BackColor = Color.Red;
            p1Ship8.Location = new System.Drawing.Point(Engine.shipsList1[7].shipLocationLeft * drawScale, Engine.shipsList1[7].shipLocationTop * drawScale + 20);
            p1Ship8.Size = new System.Drawing.Size(Engine.shipsList1[7].shipWidth, Engine.shipsList1[7].shipHeight);
            p1Ship8.SizeMode = PictureBoxSizeMode.StretchImage;
            


            if (Engine.shipsList1[8].orientation)
            {
                p1Ship9.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship9.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship9.BackColor = Color.Red;
            p1Ship9.Location = new System.Drawing.Point(Engine.shipsList1[8].shipLocationLeft * drawScale, Engine.shipsList1[8].shipLocationTop * drawScale + 20);
            p1Ship9.Size = new System.Drawing.Size(Engine.shipsList1[8].shipWidth, Engine.shipsList1[8].shipHeight);
            p1Ship9.SizeMode = PictureBoxSizeMode.StretchImage;
          

            if (Engine.shipsList1[9].orientation)
            {
                p1Ship10.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            }
            else
            {
                p1Ship10.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");

            }
            p1Ship10.BackColor = Color.Red;
            p1Ship10.Location = new System.Drawing.Point(Engine.shipsList1[9].shipLocationLeft * drawScale, Engine.shipsList1[9].shipLocationTop * drawScale + 20);
            p1Ship10.Size = new System.Drawing.Size(Engine.shipsList1[9].shipWidth, Engine.shipsList1[9].shipHeight);
            p1Ship10.SizeMode = PictureBoxSizeMode.StretchImage;
           




            if (Engine.shipsList2[0].orientation)
            {
                p2Ship1.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship1.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship1.BackColor = Color.Blue;
            p2Ship1.Location = new System.Drawing.Point(Engine.shipsList2[0].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[0].shipLocationTop * drawScale + 20);
            p2Ship1.Size = new System.Drawing.Size(Engine.shipsList2[0].shipWidth, Engine.shipsList2[0].shipHeight);
            p2Ship1.SizeMode = PictureBoxSizeMode.StretchImage;




            if (Engine.shipsList2[1].orientation)
            {
                p2Ship2.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship2.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship2.BackColor = Color.Blue;
            p2Ship2.Location = new System.Drawing.Point(Engine.shipsList2[1].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[1].shipLocationTop * drawScale + 20);
            p2Ship2.Size = new System.Drawing.Size(Engine.shipsList2[1].shipWidth, Engine.shipsList2[1].shipHeight);
            p2Ship2.SizeMode = PictureBoxSizeMode.StretchImage;

            if (Engine.shipsList2[2].orientation)
            {
                p2Ship3.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship3.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}"); 

            }
            p2Ship3.BackColor = Color.Blue;
            p2Ship3.Location = new System.Drawing.Point(Engine.shipsList2[2].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[2].shipLocationTop * drawScale + 20);
            p2Ship3.Size = new System.Drawing.Size(Engine.shipsList2[2].shipWidth, Engine.shipsList2[2].shipHeight);
            p2Ship3.SizeMode = PictureBoxSizeMode.StretchImage;

            if (Engine.shipsList2[3].orientation)
            {
                p2Ship4.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship4.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship4.BackColor = Color.Blue;
            p2Ship4.Location = new System.Drawing.Point(Engine.shipsList2[3].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[3].shipLocationTop * drawScale + 20);
            p2Ship4.Size = new System.Drawing.Size(Engine.shipsList2[3].shipWidth, Engine.shipsList2[3].shipHeight);
            p2Ship4.SizeMode = PictureBoxSizeMode.StretchImage;


            if (Engine.shipsList2[4].orientation)
            {
                p2Ship5.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship5.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship5.BackColor = Color.Blue;
            p2Ship5.Location = new System.Drawing.Point(Engine.shipsList2[4].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[4].shipLocationTop * drawScale + 20);
            p2Ship5.Size = new System.Drawing.Size(Engine.shipsList2[4].shipWidth, Engine.shipsList2[4].shipHeight);
            p2Ship5.SizeMode = PictureBoxSizeMode.StretchImage;


            if (Engine.shipsList2[5].orientation)
            {
                p2Ship6.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship6.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship6.BackColor = Color.Blue;
            p2Ship6.Location = new System.Drawing.Point(Engine.shipsList2[5].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[5].shipLocationTop * drawScale + 20);
            p2Ship6.Size = new System.Drawing.Size(Engine.shipsList2[5].shipWidth, Engine.shipsList2[5].shipHeight);
            p2Ship6.SizeMode = PictureBoxSizeMode.StretchImage;


            if (Engine.shipsList2[6].orientation)
            {
                p2Ship7.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship7.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship7.BackColor = Color.Blue;
            p2Ship7.Location = new System.Drawing.Point(Engine.shipsList2[6].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[6].shipLocationTop * drawScale + 20);
            p2Ship7.Size = new System.Drawing.Size(Engine.shipsList2[6].shipWidth, Engine.shipsList2[6].shipHeight);
            p2Ship7.SizeMode = PictureBoxSizeMode.StretchImage;


            if (Engine.shipsList2[7].orientation)
            {
                p2Ship8.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship8.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship8.BackColor = Color.Blue;
            p2Ship8.Location = new System.Drawing.Point(Engine.shipsList2[7].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[7].shipLocationTop * drawScale + 20);
            p2Ship8.Size = new System.Drawing.Size(Engine.shipsList2[7].shipWidth, Engine.shipsList2[7].shipHeight);
            p2Ship8.SizeMode = PictureBoxSizeMode.StretchImage;



            if (Engine.shipsList2[8].orientation)
            {
                p2Ship9.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship9.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship9.BackColor = Color.Blue;
            p2Ship9.Location = new System.Drawing.Point(Engine.shipsList2[8].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[8].shipLocationTop * drawScale + 20);
            p2Ship9.Size = new System.Drawing.Size(Engine.shipsList2[8].shipWidth, Engine.shipsList2[8].shipHeight);
            p2Ship9.SizeMode = PictureBoxSizeMode.StretchImage;

            if (Engine.shipsList2[9].orientation)
            {
                p2Ship10.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRed.png"}");
            }
            else
            {
                p2Ship10.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipRRed.png"}");

            }
            p2Ship10.BackColor = Color.Blue;
            p2Ship10.Location = new System.Drawing.Point(Engine.shipsList2[9].shipLocationLeft * drawScale + (Engine.width * drawScale), Engine.shipsList2[9].shipLocationTop * drawScale + 20);
            p2Ship10.Size = new System.Drawing.Size(Engine.shipsList2[9].shipWidth, Engine.shipsList2[9].shipHeight);
            p2Ship10.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        public void StyleButtons()
        {
            startGame.BackColor = Color.Black;
            startGame.ForeColor = Color.White;
            startGame.Text = "New Game";
            startGame.Font = new Font(startGame.Font.FontFamily, 14);
            startGame.Location = new Point(20, 525);
            startGame.Height = 30;
            startGame.Width = 200;
            startGame.Click += new EventHandler(newGame);

            scoreboard.BackColor = Color.Black;
            scoreboard.ForeColor = Color.White;
            scoreboard.Text = "Scores";
            scoreboard.Font = new Font(startGame.Font.FontFamily, 14);
            scoreboard.Location = new Point(780, 525);
            scoreboard.Height = 30;
            scoreboard.Width = 200;
            scoreboard.Click += new EventHandler(showScores);

            Controls.Add(startGame);
            Controls.Add(scoreboard);


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            graphics.Clear(Color.FromArgb(0, 0, 0));

            for (int i = 0; i < Engine.width * drawScale; i += (rectWidth * drawScale))
            {
                graphics.DrawLine(whitePen, i, 40, i, Engine.height * drawScale + 20);
            }
            for (int i = Engine.width * drawScale; i < Engine.width * drawScale * 2; i += (rectWidth * drawScale))
            {
                graphics.DrawLine(whitePen, i, 40, i, Engine.height * drawScale + 20);
            }


            for (int i = 0; i <= Engine.width * drawScale + 20; i += (rectWidth * drawScale))
            {
                graphics.DrawLine(whitePen, 20, i, Engine.width * drawScale - 20, i);
            }



            for (int i = 0; i <= Engine.width * drawScale + 20; i += (rectWidth * drawScale))
            {
                graphics.DrawLine(whitePen, Engine.width * drawScale + 20, i, Engine.width * drawScale * 2 - 20, i);
            }


            graphics.DrawLine(blackPen, 0, 30, 0, Engine.height * drawScale + 20);
            graphics.DrawLine(blackPen, Engine.width * drawScale, 30, Engine.width * drawScale, Engine.height * drawScale + 20);





            for (int x = 0; x < Engine.width; x++)
            {
                for (int y = 1; y <= Engine.height; y++)
                {
                    if (Engine.board1[x, y - 1] == (int)Engine.Status.Ship)
                    {
                        graphics.DrawRectangle(bluePen, new Rectangle(x * drawScale, y * drawScale, rectWidth * drawScale, rectHeight * drawScale));
                    }
                    else if (Engine.board1[x, y - 1] == (int)Engine.Status.Hit)
                    {
                        graphics.FillRectangle(blueBrush, new Rectangle(x * drawScale, y * drawScale, rectWidth * drawScale, rectHeight * drawScale));
                    }
                    else if (Engine.board1[x, y - 1] == (int)Engine.Status.Miss)
                    {
                        graphics.FillRectangle(redBrush, new Rectangle(x * drawScale, y * drawScale, rectWidth * drawScale, rectHeight * drawScale));
                    }

                }
            }

            for (int x = 0; x < Engine.width; x++)
            {
                for (int y = 1; y <= Engine.height; y++)
                {

                    if (Engine.board2[x, y - 1] == (int)Engine.Status.Hit)
                    {
                        graphics.FillRectangle(redBrush, new Rectangle(x * drawScale + (Engine.width * drawScale), y * drawScale, rectWidth * drawScale, rectHeight * drawScale));
                    }
                    else if (Engine.board2[x, y - 1] == (int)Engine.Status.Ship)
                    {
                        graphics.FillRectangle(whiteBrush, new Rectangle(x * drawScale + (Engine.width * drawScale), y * drawScale, rectWidth * drawScale, rectHeight * drawScale));
                    }

                    else if (Engine.board2[x, y - 1] == (int)Engine.Status.Miss)
                    {
                        graphics.FillRectangle(blueBrush, new Rectangle(x * drawScale + (Engine.width * drawScale), y * drawScale, rectWidth * drawScale, rectHeight * drawScale));
                    }
                }
            }



        }

        void newGame(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you would like to start a new game?", "New Game?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        void showScores(object sender, EventArgs e)
        {
            var scoreWindow = new Scores();
            scoreWindow.ShowDialog();
        }

        void updateSink() {

            checkForSink(2, p2Ship10, 9, Engine.board2, Engine.shipsList2);
            checkForSink(2, p2Ship9, 8, Engine.board2, Engine.shipsList2);
            checkForSink(2, p2Ship8, 7, Engine.board2, Engine.shipsList2);
            checkForSink(2, p2Ship7, 6, Engine.board2, Engine.shipsList2);
            checkForSink(3, p2Ship6, 5, Engine.board2, Engine.shipsList2);
            checkForSink(3, p2Ship5, 4, Engine.board2, Engine.shipsList2);
            checkForSink(3, p2Ship4, 3, Engine.board2, Engine.shipsList2);
            checkForSink(4, p2Ship3, 2, Engine.board2, Engine.shipsList2);
            checkForSink(4, p2Ship2, 1, Engine.board2, Engine.shipsList2);
            checkForSink(5, p2Ship1, 0, Engine.board2, Engine.shipsList2);
            checkForSink(2, p1Ship10, 9, Engine.board1, Engine.shipsList1);
            checkForSink(2, p1Ship9, 8, Engine.board1, Engine.shipsList1);
            checkForSink(2, p1Ship8, 7, Engine.board1, Engine.shipsList1);
            checkForSink(2, p1Ship7, 6, Engine.board1, Engine.shipsList1);
            checkForSink(3, p1Ship6, 5, Engine.board1, Engine.shipsList1);
            checkForSink(3, p1Ship5, 4, Engine.board1, Engine.shipsList1);
            checkForSink(3, p1Ship4, 3, Engine.board1, Engine.shipsList1);
            checkForSink(4, p1Ship3, 2, Engine.board1, Engine.shipsList1);
            checkForSink(4, p1Ship2, 1, Engine.board1, Engine.shipsList1);
            checkForSink(5, p1Ship1, 0, Engine.board1, Engine.shipsList1);


        }
        void checkForSink(int shipSize, PictureBox ship, int shipNum, int[,]board, Ship[] shipsList)
        {
            if (board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit)
            {
                if (shipsList[shipNum].orientation)
                {
                    switch (shipSize)
                    {
                        case 2:
                            if (board[shipsList[shipNum].shipLocationLeft + 1, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;
                        case 3:
                            if (board[shipsList[shipNum].shipLocationLeft + 1, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft + 2, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;
                        case 4:
                            if (board[shipsList[shipNum].shipLocationLeft + 1, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft + 2, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft + 3, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;
                        case 5:
                            if (board[shipsList[shipNum].shipLocationLeft + 1, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft + 2, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft + 3, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft + 4, shipsList[shipNum].shipLocationTop] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;

                        default:
                            break;
                    }
                }

                else
                {
                    switch (shipSize)
                    {
                        case 2:
                            if (board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 1] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;
                        case 3:
                            if (board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 1] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 2] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;
                        case 4:
                            if (board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 1] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 2] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 3] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;
                        case 5:
                            if (board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 1] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 2] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 3] == (int)Engine.Status.Hit &&
                                board[shipsList[shipNum].shipLocationLeft, shipsList[shipNum].shipLocationTop + 4] == (int)Engine.Status.Hit)
                            {
                                Controls.Add(ship);
                            }
                            break;

                        default:
                            break;
                    }
                
            }
            }
        }
        void mouseClick(object sender, MouseEventArgs e)

        {
            if (!endGame)
            {
                if ((!(((e.X / drawScale) - 1) < Engine.width)) && ((!(((e.X / drawScale) + 1) >= (2 * Engine.width)))) && ((e.Y / drawScale) < 26) && ((e.Y / drawScale) > 1))
                {

                    if (Engine.board2[(e.X - (Engine.width * drawScale)) / drawScale, e.Y / drawScale - 1] == (int)Engine.Status.Ship)
                    {
                        Engine.board2[(e.X - (Engine.width * drawScale)) / drawScale, e.Y / drawScale - 1] = (int)Engine.Status.Hit;
                        Engine.ComputerTurn = true;
                        Engine.P2LiveShips--;
                        Engine.P1Tries++;

                        checkForSink(2, p2Ship10, 9, Engine.board2, Engine.shipsList2);
                        checkForSink(2, p2Ship9, 8, Engine.board2, Engine.shipsList2);
                        checkForSink(2, p2Ship8, 7, Engine.board2, Engine.shipsList2);
                        checkForSink(2, p2Ship7, 6, Engine.board2, Engine.shipsList2);
                        checkForSink(3, p2Ship6, 5, Engine.board2, Engine.shipsList2);
                        checkForSink(3, p2Ship5, 4, Engine.board2, Engine.shipsList2);
                        checkForSink(3, p2Ship4, 3, Engine.board2, Engine.shipsList2);
                        checkForSink(4, p2Ship3, 2, Engine.board2, Engine.shipsList2);
                        checkForSink(4, p2Ship2, 1, Engine.board2, Engine.shipsList2);
                        checkForSink(5, p2Ship1, 0, Engine.board2, Engine.shipsList2);

                        if (engine.checkForWin(Engine.board2))
                        {
                            endTime = DateTime.Now;

                            Engine.win = true;
                            Controls.Remove(p2Ship1);
                            Controls.Remove(p2Ship2);
                            Controls.Remove(p2Ship3);
                            Controls.Remove(p2Ship4);
                            Controls.Remove(p2Ship5);
                            Controls.Remove(p2Ship6);
                            Controls.Remove(p2Ship7);
                            Controls.Remove(p2Ship8);
                            Controls.Remove(p2Ship9);
                            Controls.Remove(p2Ship10);
                            Controls.Remove(p1Ship1);
                            Controls.Remove(p1Ship2);
                            Controls.Remove(p1Ship3);
                            Controls.Remove(p1Ship4);
                            Controls.Remove(p1Ship5);
                            Controls.Remove(p1Ship6);
                            Controls.Remove(p1Ship7);
                            Controls.Remove(p1Ship8);
                            Controls.Remove(p1Ship9);
                            Controls.Remove(p1Ship10);



                            Engine.board1 = engine.winMessage(Engine.board1);
                            Engine.board2 = engine.loseMessage(Engine.board2);
                            engine.sendData("name", Engine.P1Tries);
                            endGame = true;
                            MessageBox.Show("YOU WIN!!!");
                        }

                    }
                    else if (Engine.board2[(e.X - (Engine.width * drawScale)) / drawScale, e.Y / drawScale - 1] == (int)Engine.Status.Hit)
                    {
                        Engine.board2[(e.X - (Engine.width * drawScale)) / drawScale, e.Y / drawScale - 1] = (int)Engine.Status.Hit;
                    }
                    else if (Engine.board2[(e.X - (Engine.width * drawScale)) / drawScale, e.Y / drawScale - 1] == (int)Engine.Status.Miss)
                    {
                        Engine.board2[(e.X - (Engine.width * drawScale)) / drawScale, (e.Y / drawScale) - 1] = (int)Engine.Status.Miss;
                    }
                    else
                    {
                        Engine.board2[(e.X - (Engine.width * drawScale)) / drawScale, (e.Y / drawScale) - 1] = (int)Engine.Status.Miss;
                        Engine.P1Tries++;
                        Engine.ComputerTurn = true;
                    }
                }
                else
                {
                    MessageBox.Show("Take your guess on Player 2's board");
                    return;

                }

                while (Engine.ComputerTurn && (!endGame))
                {
                    engine.ComputerPlays();

                    while ((Engine.board1[Engine.ComputerGuessX, Engine.ComputerGuessY] == (int)Engine.Status.Hit) || (Engine.board1[Engine.ComputerGuessX, Engine.ComputerGuessY] == (int)Engine.Status.Miss))
                    {
                        engine.ComputerPlays();
                    }

                    if (Engine.ComputerGuessX > 0 && Engine.ComputerGuessX < 24 && Engine.ComputerGuessY > 0 && Engine.ComputerGuessY < 25)
                    {

                        if (Engine.board1[Engine.ComputerGuessX, Engine.ComputerGuessY] == (int)Engine.Status.Ship)
                        {
                            Engine.board1[Engine.ComputerGuessX, Engine.ComputerGuessY] = (int)Engine.Status.Hit;
                            Engine.P1LiveShips--;
                            Engine.P2Tries++;
                            engine.GenerateGuess(Engine.ComputerGuessX, Engine.ComputerGuessY);
                            checkForSink(2, p1Ship10, 9, Engine.board1, Engine.shipsList1);
                            checkForSink(2, p1Ship9, 8, Engine.board1, Engine.shipsList1);
                            checkForSink(2, p1Ship8, 7, Engine.board1, Engine.shipsList1);
                            checkForSink(2, p1Ship7, 6, Engine.board1, Engine.shipsList1);
                            checkForSink(3, p1Ship6, 5, Engine.board1, Engine.shipsList1);
                            checkForSink(3, p1Ship5, 4, Engine.board1, Engine.shipsList1);
                            checkForSink(3, p1Ship4, 3, Engine.board1, Engine.shipsList1);
                            checkForSink(4, p1Ship3, 2, Engine.board1, Engine.shipsList1);
                            checkForSink(4, p1Ship2, 1, Engine.board1, Engine.shipsList1);
                            checkForSink(5, p1Ship1, 0, Engine.board1, Engine.shipsList1);


                            if (engine.checkForWin(Engine.board1))
                            {
                                endTime = DateTime.Now;
                                Engine.win = false;
                                Controls.Remove(p2Ship1);
                                Controls.Remove(p2Ship2);
                                Controls.Remove(p2Ship3);
                                Controls.Remove(p2Ship4);
                                Controls.Remove(p2Ship5);
                                Controls.Remove(p2Ship6);
                                Controls.Remove(p2Ship7);
                                Controls.Remove(p2Ship8);
                                Controls.Remove(p2Ship9);
                                Controls.Remove(p2Ship10);
                                Controls.Remove(p1Ship1);
                                Controls.Remove(p1Ship2);
                                Controls.Remove(p1Ship3);
                                Controls.Remove(p1Ship4);
                                Controls.Remove(p1Ship5);
                                Controls.Remove(p1Ship6);
                                Controls.Remove(p1Ship7);
                                Controls.Remove(p1Ship8);
                                Controls.Remove(p1Ship9);
                                Controls.Remove(p1Ship10);
                                Engine.board2 = engine.winMessage(Engine.board2);
                                Engine.board1 = engine.loseMessage(Engine.board1);
                                endGame = true;
                                MessageBox.Show("YOU LOSE!!!");



                            }


                            Engine.ComputerTurn = false;


                        }

                        else
                        {
                            Engine.board1[Engine.ComputerGuessX, Engine.ComputerGuessY] = (int)Engine.Status.Miss;
                            Engine.P2Tries++;
                            Engine.ComputerTurn = false;
                        }

                    }
                }
            }
            Player1.Text = Engine.playerName + ":     Tries: " + Engine.P1Tries + "      Targets Remaining: " + Engine.P1LiveShips;

            Player2.Text = "Player 2:     Tries: " + Engine.P2Tries + "      Targets Remaining: " + Engine.P2LiveShips;



            engine.Update();

            this.Refresh();
            return;

        }

        private void ClosingGame(object sender, FormClosingEventArgs e)
        {
            endTime = DateTime.Now;
            if (!endGame)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to save your game before closing?", "Save Game?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    Engine.gameData.updateTimer();
                    Engine.gameData.updateBoards();
                    Engine.gameData.updateTries();
                    Engine.gameData.updateUsername();

                    Engine.save = true;
                    Engine.board1String = engine.getboardString(Engine.board1);
                    Engine.board2String = engine.getboardString(Engine.board2);
                    engine.getListString();
                    engine.getGuessString();


                }
                else if (dialogResult == DialogResult.No)
                {
                    Console.WriteLine("Not Saved");
                }
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
    }

}
