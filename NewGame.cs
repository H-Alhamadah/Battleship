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
    public partial class NewGame : Form
    {
        static System.Windows.Forms.Label nameLabel = new System.Windows.Forms.Label();
        static System.Windows.Forms.Label placeShips = new System.Windows.Forms.Label();
        static System.Windows.Forms.TextBox NameBox = new System.Windows.Forms.TextBox();
        Button start = new Button();
        Button ship1 = new Button();
        Button ship2 = new Button();
        Button ship3 = new Button();
        Button ship4 = new Button();
        Button ship5 = new Button();
        Button ship6 = new Button();
        Button ship7 = new Button();
        Button ship8 = new Button();
        Button ship9 = new Button(); 
        Button ship10 = new Button();


        private bool isDragging = false;
        private bool dontRotate = false;
        public static bool startGame = false;
        private int oldX, oldY;
        public static int[] locationsX = new int[30];
        public static int[] locationsY = new int[30];
        BufferedGraphics buffer;

        public NewGame()
        {
            InitializeComponent();
            StyleForm();
            StyleShips();
            this.FormClosing += ClosingGame;
            var currentContext = BufferedGraphicsManager.Current;
            buffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }


        public void StyleShips()
        {

            ship1.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship1.BackgroundImageLayout = ImageLayout.Stretch;
            ship1.BackColor = Color.Black;
            ship1.Location = new System.Drawing.Point(560, 160);
            ship1.Size = new System.Drawing.Size(100, 20);
            ship1.FlatStyle = FlatStyle.Flat;
   

            ship2.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship2.BackgroundImageLayout = ImageLayout.Stretch;
            ship2.BackColor = Color.Black;
            ship2.Location = new System.Drawing.Point(560, 200);
            ship2.Size = new System.Drawing.Size(80, 20);
            ship2.FlatStyle = FlatStyle.Flat;


            ship3.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship3.BackgroundImageLayout = ImageLayout.Stretch;
            ship3.BackColor = Color.Black;
            ship3.Location = new System.Drawing.Point(560, 240);
            ship3.Size = new System.Drawing.Size(80, 20);
            ship3.FlatStyle = FlatStyle.Flat;



            ship4.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship4.BackgroundImageLayout = ImageLayout.Stretch;
            ship4.BackColor = Color.Black;
            ship4.Location = new System.Drawing.Point(560, 280);
            ship4.Size = new System.Drawing.Size(60, 20);
            ship4.FlatStyle = FlatStyle.Flat;



            ship5.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship5.BackgroundImageLayout = ImageLayout.Stretch;
            ship5.BackColor = Color.Black;
            ship5.Location = new System.Drawing.Point(560, 320);
            ship5.Size = new System.Drawing.Size(60, 20);
            ship5.FlatStyle = FlatStyle.Flat;



            ship6.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship6.BackgroundImageLayout = ImageLayout.Stretch;
            ship6.BackColor = Color.Black;
            ship6.Location = new System.Drawing.Point(560, 360);
            ship6.Size = new System.Drawing.Size(60, 20);
            ship6.FlatStyle = FlatStyle.Flat;


            ship7.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship7.BackgroundImageLayout = ImageLayout.Stretch;
            ship7.BackColor = Color.Black;
            ship7.Location = new System.Drawing.Point(560, 400);
            ship7.Size = new System.Drawing.Size(40, 20);
            ship7.FlatStyle = FlatStyle.Flat;


            ship8.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship8.BackgroundImageLayout = ImageLayout.Stretch;
            ship8.BackColor = Color.Black;
            ship8.Location = new System.Drawing.Point(560, 440);
            ship8.Size = new System.Drawing.Size(40, 20); 
            ship8.FlatStyle = FlatStyle.Flat;


            ship9.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship9.BackgroundImageLayout = ImageLayout.Stretch;
            ship9.BackColor = Color.Black;
            ship9.Location = new System.Drawing.Point(560, 480);
            ship9.Size = new System.Drawing.Size(40, 20);
            ship9.FlatStyle = FlatStyle.Flat;


            ship10.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");
            ship10.BackgroundImageLayout = ImageLayout.Stretch;
            ship10.BackColor = Color.Black;
            ship10.Location = new System.Drawing.Point(560, 520);
            ship10.Size = new System.Drawing.Size(40, 20);
            ship10.FlatStyle = FlatStyle.Flat;

            ship1.Click += new System.EventHandler(this.Rotate);
            ship2.Click += new System.EventHandler(this.Rotate);
            ship3.Click += new System.EventHandler(this.Rotate);
            ship4.Click += new System.EventHandler(this.Rotate);
            ship5.Click += new System.EventHandler(this.Rotate);
            ship6.Click += new System.EventHandler(this.Rotate);
            ship7.Click += new System.EventHandler(this.Rotate);
            ship8.Click += new System.EventHandler(this.Rotate);
            ship9.Click += new System.EventHandler(this.Rotate);
            ship10.Click += new System.EventHandler(this.Rotate);

            ship1.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship1.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship1.MouseUp += new MouseEventHandler(this.onMouseUp);

            ship2.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship2.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship2.MouseUp += new MouseEventHandler(this.onMouseUp);

            ship3.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship3.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship3.MouseUp += new MouseEventHandler(this.onMouseUp);
            
            ship4.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship4.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship4.MouseUp += new MouseEventHandler(this.onMouseUp);
            
            ship5.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship5.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship5.MouseUp += new MouseEventHandler(this.onMouseUp);
            
            ship6.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship6.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship6.MouseUp += new MouseEventHandler(this.onMouseUp);
            
            ship7.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship7.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship7.MouseUp += new MouseEventHandler(this.onMouseUp);
            
            ship8.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship8.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship8.MouseUp += new MouseEventHandler(this.onMouseUp);
            
            ship9.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship9.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship9.MouseUp += new MouseEventHandler(this.onMouseUp);

            ship10.MouseDown += new MouseEventHandler(this.onMouseDown);
            ship10.MouseMove += new MouseEventHandler(this.onMouseMove);
            ship10.MouseUp += new MouseEventHandler(this.onMouseUp);


            Controls.Add(ship1);
            Controls.Add(ship2);
            Controls.Add(ship3);
            Controls.Add(ship4);
            Controls.Add(ship5);
            Controls.Add(ship6);
            Controls.Add(ship7);
            Controls.Add(ship8);
            Controls.Add(ship9);
            Controls.Add(ship10);

        }
        public void StyleForm()
        {
            
            start.Text = "Start";
            start.Font = new Font(nameLabel.Font.FontFamily, 10);
            start.Location = new System.Drawing.Point(250, 650);
            start.Size = new System.Drawing.Size(100, 25);
            nameLabel.Size= new System.Drawing.Size(400, 30);
            nameLabel.Text = "Please enter your name";
            nameLabel.Font = new Font(nameLabel.Font.FontFamily, 14);
            nameLabel.ForeColor = Color.White;
            nameLabel.BackColor = Color.Black;
            nameLabel.Location = new Point(190, 40);
            placeShips.Size = new System.Drawing.Size(300, 30);
            placeShips.Text = "Place your ships";
            placeShips.Font = new Font(nameLabel.Font.FontFamily, 14);
            placeShips.ForeColor = Color.White;
            placeShips.BackColor = Color.Black;
            placeShips.Location = new Point(190, 120);
            NameBox.Location = new System.Drawing.Point(100, 80);
            NameBox.Size = new System.Drawing.Size(400, 50);
            NameBox.TabIndex = 0;
            start.Click += new System.EventHandler(this.StartGame);

            Controls.Add(nameLabel);
            Controls.Add(placeShips);
            Controls.Add(NameBox);
            Controls.Add(start);
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            buffer.Graphics.Clear(Color.FromArgb(0, 0, 0));

            for (int i = 60; i < Engine.width * Form1.drawScale+40; i += (Form1.rectWidth * Form1.drawScale))
            {
                buffer.Graphics.DrawLine(Form1.whitePen, i, 160, i, Engine.height * Form1.drawScale + 140);
            }



            for (int i = 160; i <= Engine.width * Form1.drawScale + 140; i += (Form1.rectWidth * Form1.drawScale))
            {
                buffer.Graphics.DrawLine(Form1.whitePen, 60, i, Engine.width * Form1.drawScale +20, i);
            }

            buffer.Render();


        }

        private  void StartGame(object sender, EventArgs e)
        {
            getShipLocations();

            if (NameBox.Text.Length > 16)
            {
                MessageBox.Show("Name must be less than 16 characters long");
            }
            else
            {
                if (!verifyShipLocations())
                {
                    MessageBox.Show("Place your ships on the grid");
                }
                else
                {
                    if (overlap())
                    {
                        MessageBox.Show("Ships can not overlap");
                    }
                    else {
                        if (!(String.IsNullOrWhiteSpace(NameBox.Text)))
                        {
                            Engine.playerName = NameBox.Text;
                        }
                        Engine.custLocationsX = locationsX;
                        Engine.custLocationsY = locationsY;
                        Engine.customShips = true;
                        buffer.Dispose();
                        this.Close();
                    }
                } 
            }

        }

        bool overlap()
        {
            for (int i = 0; i < locationsX.Length; i++)
            {
                for (int j = i+1; j < locationsX.Length; j++)
                {
                    if (locationsX[i] == locationsX[j])
                    {
                        if(locationsY[i] == locationsY[j])
                        {
                            return true;
                        }
                    }
                }        
            }
            return false;
        }
        bool verifyShipLocations()
        {
            for(int i=0; i<locationsX.Length; i++)
            {
                if (locationsX[i] > Engine.width-1 || locationsY[i] > Engine.width)
                {
                    return false;
                }
            }
            return true;
        }

        private void Rotate(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            int temp = 0;
            if (!dontRotate)
            {
                if (button.Size.Width == 20)
                {
                    temp = button.Size.Height;
                    button.Size = new System.Drawing.Size(temp, 20);
                    button.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\Ship.png"}");

                }
                else
                {
                    temp = button.Size.Width;
                    button.Size = new System.Drawing.Size(20, temp);
                    button.BackgroundImage = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\ShipR.png"}");




                }
            }
 
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            Button button = (sender as Button);
            isDragging = true;
            oldX = e.X;
            oldY = e.Y;
        }
        private void onMouseMove(object sender, MouseEventArgs e)
        {
            Button button = (sender as Button);

            if (isDragging)
            {
                dontRotate = true;
                button.Top = button.Top + (e.Y - oldY);
                button.Left = button.Left + (e.X - oldX);
            }
            
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            Button button = (sender as Button);

            button.FlatAppearance.BorderColor = Color.White;


            if (button.Location.X % 20 != 0)
            {
                if(button.Location.X % 20 <= 10)
                {
                    button.Location= new System.Drawing.Point((button.Location.X -button.Location.X%20), button.Location.Y);
                }
                else
                {
                    button.Location = new System.Drawing.Point((button.Location.X + (20-button.Location.X % 20)), button.Location.Y);
                }
            }


            if (button.Location.Y % 20 != 0)
            {
                if (button.Location.Y % 20 <= 10)
                {
                    button.Location = new System.Drawing.Point( button.Location.X, (button.Location.Y - button.Location.Y % 20));
                }
                else
                {
                    button.Location = new System.Drawing.Point( button.Location.X, (button.Location.Y + (20 - button.Location.Y % 20)));
                }
            }
            if (button.Left < 60)
            {
                button.Location = new System.Drawing.Point(60, button.Location.Y);
            }
            if (button.Top < 160)
            {
                button.Location = new System.Drawing.Point(button.Location.X, 160);
            }
            if (button.Right > 520)
            {
                button.Location = new System.Drawing.Point(520-button.Width, button.Location.Y);
            }
            if (button.Bottom > 640)
            {
                button.Location = new System.Drawing.Point(button.Location.X, 640-button.Height);
            }

            Console.WriteLine("The X Cord is: " + button.Location.X + " The Y Cord is: " +
                button.Location.Y + " The Top is: " + button.Top + " The Left is: " + button.Left +
                " The bottom is: " + button.Bottom + " the right is: " + button.Right);
            isDragging = false;
            dontRotate = false;

        }

        public void getShipLocations()
        {
          
            if (ship1.Width == 20)
            {
                locationsX[0] = (ship1.Location.X / 20) - 2;
                locationsX[1] = (ship1.Location.X / 20) - 2;
                locationsX[2] = (ship1.Location.X / 20) - 2;
                locationsX[3] = (ship1.Location.X / 20) - 2;
                locationsX[4] = (ship1.Location.X / 20) - 2;

                locationsY[0] = (ship1.Location.Y / 20) - 7;
                locationsY[1] = (ship1.Location.Y / 20) - 6;
                locationsY[2] = (ship1.Location.Y / 20) - 5;
                locationsY[3] = (ship1.Location.Y / 20) - 4;
                locationsY[4] = (ship1.Location.Y / 20) - 3;
                Engine.shipsList1[0] = new Ship(locationsX[0], locationsY[0], 20, 100, false);

            }
            else
            {
                locationsX[0] = (ship1.Location.X / 20) - 2;
                locationsX[1] = (ship1.Location.X / 20) - 1;
                locationsX[2] = (ship1.Location.X / 20);
                locationsX[3] = (ship1.Location.X / 20) + 1;
                locationsX[4] = (ship1.Location.X / 20) + 2;

                locationsY[0] = (ship1.Location.Y / 20) - 7;
                locationsY[1] = (ship1.Location.Y / 20) - 7;
                locationsY[2] = (ship1.Location.Y / 20) - 7;
                locationsY[3] = (ship1.Location.Y / 20) - 7;
                locationsY[4] = (ship1.Location.Y / 20) - 7;
                Engine.shipsList1[0] = new Ship(locationsX[0], locationsY[0], 100, 20, true);

            }

            if (ship2.Width == 20)
            {
                locationsX[5] = (ship2.Location.X / 20) - 2;
                locationsX[6] = (ship2.Location.X / 20) - 2;
                locationsX[7] = (ship2.Location.X / 20) - 2;
                locationsX[8] = (ship2.Location.X / 20) - 2;

                locationsY[5] = (ship2.Location.Y / 20) - 7;
                locationsY[6] = (ship2.Location.Y / 20) - 6;
                locationsY[7] = (ship2.Location.Y / 20) - 5;
                locationsY[8] = (ship2.Location.Y / 20) - 4;
                Engine.shipsList1[1] = new Ship(locationsX[5], locationsY[5], 20, 80,false);

            }
            else
            {
                
                locationsX[5] = (ship2.Location.X / 20) - 2;
                locationsX[6] = (ship2.Location.X / 20) - 1;
                locationsX[7] = (ship2.Location.X / 20);
                locationsX[8] = (ship2.Location.X / 20) + 1;

                locationsY[5] = (ship2.Location.Y / 20) - 7;
                locationsY[6] = (ship2.Location.Y / 20) - 7;
                locationsY[7] = (ship2.Location.Y / 20) - 7;
                locationsY[8] = (ship2.Location.Y / 20) - 7;
                Engine.shipsList1[1] = new Ship(locationsX[5], locationsY[5], 80, 20,true);

            }
            if (ship3.Width == 20)
            {
                
                locationsX[9] = (ship3.Location.X / 20) - 2;
                locationsX[10] = (ship3.Location.X / 20) - 2;
                locationsX[11] = (ship3.Location.X / 20) - 2;
                locationsX[12] = (ship3.Location.X / 20) - 2;

                locationsY[9] = (ship3.Location.Y / 20) - 7;
                locationsY[10] = (ship3.Location.Y / 20) - 6;
                locationsY[11] = (ship3.Location.Y / 20) - 5;
                locationsY[12] = (ship3.Location.Y / 20) - 4;
                Engine.shipsList1[2] = new Ship(locationsX[9], locationsY[9], 20, 80, false);

            }
            else
            {
                locationsX[9] = (ship3.Location.X / 20) - 2;
                locationsX[10] = (ship3.Location.X / 20) - 1;
                locationsX[11] = (ship3.Location.X / 20);
                locationsX[12] = (ship3.Location.X / 20) + 1;

                locationsY[9] = (ship3.Location.Y / 20) - 7;
                locationsY[10] = (ship3.Location.Y / 20) - 7;
                locationsY[11] = (ship3.Location.Y / 20) - 7;
                locationsY[12] = (ship3.Location.Y / 20) - 7;
                Engine.shipsList1[2] = new Ship(locationsX[9], locationsY[9], 80, 20, true);

            }


            if (ship4.Width == 20)
            {
               
                locationsX[13] = (ship4.Location.X / 20) - 2;
                locationsX[14] = (ship4.Location.X / 20) - 2;
                locationsX[15] = (ship4.Location.X / 20) - 2;
           

                locationsY[13] = (ship4.Location.Y / 20) - 7;
                locationsY[14] = (ship4.Location.Y / 20) - 6;
                locationsY[15] = (ship4.Location.Y / 20) - 5;
                Engine.shipsList1[3] = new Ship(locationsX[13], locationsY[13], 20, 60, false);


            }
            else
            {
                locationsX[13] = (ship4.Location.X / 20) - 2;
                locationsX[14] = (ship4.Location.X / 20) - 1;
                locationsX[15] = (ship4.Location.X / 20);

                locationsY[13] = (ship4.Location.Y / 20) - 7;
                locationsY[14] = (ship4.Location.Y / 20) - 7;
                locationsY[15] = (ship4.Location.Y / 20) - 7;
                Engine.shipsList1[3] = new Ship(locationsX[13], locationsY[13], 60, 20, true);

            }

            if (ship5.Width == 20)
            {
                locationsX[16] = (ship5.Location.X / 20) - 2;
                locationsX[17] = (ship5.Location.X / 20) - 2;
                locationsX[18] = (ship5.Location.X / 20) - 2;


                locationsY[16] = (ship5.Location.Y / 20) - 7;
                locationsY[17] = (ship5.Location.Y / 20) - 6;
                locationsY[18] = (ship5.Location.Y / 20) - 5;
                Engine.shipsList1[4] = new Ship(locationsX[16], locationsY[16], 20, 60, false);


            }
            else
            {
                locationsX[16] = (ship5.Location.X / 20) - 2;
                locationsX[17] = (ship5.Location.X / 20) - 1;
                locationsX[18] = (ship5.Location.X / 20);

                locationsY[16] = (ship5.Location.Y / 20) - 7;
                locationsY[17] = (ship5.Location.Y / 20) - 7;
                locationsY[18] = (ship5.Location.Y / 20) - 7;
                Engine.shipsList1[4] = new Ship(locationsX[16], locationsY[16], 60, 20, true);

            }

            if (ship6.Width == 20)
            {
                locationsX[19] = (ship6.Location.X / 20) - 2;
                locationsX[20] = (ship6.Location.X / 20) - 2;
                locationsX[21] = (ship6.Location.X / 20) - 2;


                locationsY[19] = (ship6.Location.Y / 20) - 7;
                locationsY[20] = (ship6.Location.Y / 20) - 6;
                locationsY[21] = (ship6.Location.Y / 20) - 5;
                Engine.shipsList1[5] = new Ship(locationsX[19], locationsY[19], 20, 60, false);


            }
            else
            {
                locationsX[19] = (ship6.Location.X / 20) - 2;
                locationsX[20] = (ship6.Location.X / 20) - 1;
                locationsX[21] = (ship6.Location.X / 20);

                locationsY[19] = (ship6.Location.Y / 20) - 7;
                locationsY[20] = (ship6.Location.Y / 20) - 7;
                locationsY[21] = (ship6.Location.Y / 20) - 7;
                Engine.shipsList1[5] = new Ship(locationsX[19], locationsY[19], 60, 20, true);

            }


            if (ship7.Width == 20)
            {
                locationsX[22] = (ship7.Location.X / 20) - 2;
                locationsX[23] = (ship7.Location.X / 20) - 2;

                locationsY[22] = (ship7.Location.Y / 20) - 7;
                locationsY[23] = (ship7.Location.Y / 20) - 6;
                Engine.shipsList1[6] = new Ship(locationsX[22], locationsY[22], 20, 40, false);


            }
            else
            {
                locationsX[22] = (ship7.Location.X / 20) - 2;
                locationsX[23] = (ship7.Location.X / 20) - 1;
             

                locationsY[22] = (ship7.Location.Y / 20) - 7;
                locationsY[23] = (ship7.Location.Y / 20) - 7;
                Engine.shipsList1[6] = new Ship(locationsX[22], locationsY[22], 40, 20, true);

            }

            if (ship8.Width == 20)
            {
                locationsX[24] = (ship8.Location.X / 20) - 2;
                locationsX[25] = (ship8.Location.X / 20) - 2;

                locationsY[24] = (ship8.Location.Y / 20) - 7;
                locationsY[25] = (ship8.Location.Y / 20) - 6;
                Engine.shipsList1[7] = new Ship(locationsX[24], locationsY[24], 20, 40, false);


            }
            else
            {
                locationsX[24] = (ship8.Location.X / 20) - 2;
                locationsX[25] = (ship8.Location.X / 20) - 1;


                locationsY[24] = (ship8.Location.Y / 20) - 7;
                locationsY[25] = (ship8.Location.Y / 20) - 7;
                Engine.shipsList1[7] = new Ship(locationsX[24], locationsY[24], 40, 20, true);

            }

            if (ship9.Width == 20)
            {
                locationsX[26] = (ship9.Location.X / 20) - 2;
                locationsX[27] = (ship9.Location.X / 20) - 2;

                locationsY[26] = (ship9.Location.Y / 20) - 7;
                locationsY[27] = (ship9.Location.Y / 20) - 6;
                Engine.shipsList1[8] = new Ship(locationsX[26], locationsY[26], 20, 40, false);


            }
            else
            {
                locationsX[26] = (ship9.Location.X / 20) - 2;
                locationsX[27] = (ship9.Location.X / 20) - 1;


                locationsY[26] = (ship9.Location.Y / 20) - 7;
                locationsY[27] = (ship9.Location.Y / 20) - 7;
                Engine.shipsList1[8] = new Ship(locationsX[26], locationsY[26], 40, 20, true);

            }

            if (ship10.Width == 20)
            {
                locationsX[28] = (ship10.Location.X / 20) - 2;
                locationsX[29] = (ship10.Location.X / 20) - 2;

                locationsY[28] = (ship10.Location.Y / 20) - 7;
                locationsY[29] = (ship10.Location.Y / 20) - 6;
                Engine.shipsList1[9] = new Ship(locationsX[28], locationsY[28], 20, 40, false);


            }
            else
            {
                locationsX[28] = (ship10.Location.X / 20) - 2;
                locationsX[29] = (ship10.Location.X / 20) - 1;


                locationsY[28] = (ship10.Location.Y / 20) - 7;
                locationsY[29] = (ship10.Location.Y / 20) - 7;
                Engine.shipsList1[9] = new Ship(locationsX[28], locationsY[28], 40, 20, true);

            }
        }
        private void ClosingGame(object sender, FormClosingEventArgs e)
        {
            Engine.forceClosed = true;
        }

    }
}
