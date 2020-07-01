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
    public partial class Title : Form
    {
        Timer timer = new Timer();
        int time = 0;
        bool firstTime = true;
        public static DialogResult dialogResult;

        public Title()
        {
            
            InitializeComponent();
            StyleTitle();
            this.FormBorderStyle = FormBorderStyle.None;
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);

        }

        public void timer_Tick(object sender, EventArgs e)
        {           
            if (time > 2&&firstTime) {
                firstTime = false;
                userChoice();
            }
            time++;
        }
        public void userChoice()
        { 
            dialogResult = MessageBox.Show("Would you like to resume a previous game?", "Resume Game?", MessageBoxButtons.YesNo);
            this.Close();
        }

        public void StyleTitle()
        {
            PictureBox picture= new PictureBox();
            picture.Image = Image.FromFile($"{Environment.CurrentDirectory}{@"\Images\waterwars.jpg"}");
            //picture.Image = Image.FromFile(@"C:\Users\HadeelAlhamadah\source\repos\GridGame\GridGame\waterwars.jpg");
            picture.Location = new Point(0, 0);
            picture.Size = this.Size;
            this.Controls.Add(picture);
        }
        
    }
}
