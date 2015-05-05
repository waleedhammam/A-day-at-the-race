using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_the_races
{
    public partial class Form1 : Form
    {
        // making array of objects of grey hound and guy
        Greyhound[] greyhound = new Greyhound[4];
        Guy[] guy = new Guy[3];
        public Form1()
        {
            InitializeComponent();
            // initializing greyhounds objects
            greyhound[0] = new Greyhound(dog1.Location.X, pictureBox1.Width, dog1);
            greyhound[1] = new Greyhound(dog2.Location.X, pictureBox1.Width, dog2);
            greyhound[2] = new Greyhound(dog3.Location.X, pictureBox1.Width, dog3);
            greyhound[3] = new Greyhound(dog4.Location.X, pictureBox1.Width, dog4);

            // instance of random
            Random randomizer = new Random();
            // passing the randomizer to greyhound
            for (int i = 0; i < 4; i++)
            {
                greyhound[i].randomizer = randomizer;
            }
            // initializing guy objects
            guy[0] = new Guy("joe", null, 50, radioButton1, textBox1);
            guy[1] = new Guy("Bob", null, 75, radioButton2, textBox2);
            guy[2] = new Guy("Al", null, 45, radioButton3, textBox3);
            // updating labels
            for (int i = 0; i < 3; i++)
            {
                guy[i].UpdateLables();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // the race go on if win == true
            bool win = true;
            // the winner dog
            int dog = 0;
            // Initiating the race
            while(win)
            {
                // moving the 4 dogs
                for(int i = 0; i < 4; i++)
                {
                   if(greyhound[i].Run())
                   {
                       // the winner dog
                       dog = i + 1;
                       // the race done if win == false
                       win = false;
                       // showing the winner dog
                       MessageBox.Show("winner is: " + dog);
                       // reseting the dogs
                       for (int j = 0; j < 4; j++)
                       {
                           greyhound[j].reset();
                       }
                       // calculating bets
                       for (int k = 0; k < 3; k++)
                       {
                           // if guy didn't enter bet
                           if (guy[k].MyBet != null)
                           {
                               guy[k].Collect(dog);
                               guy[k].MyBet = null;
                               guy[k].UpdateLables();
                           }
                       }
                   }
                    // refreshing the racetrack
                   pictureBox1.Refresh();
                }
            }
            // if guy's money out, then he's out
            for (int m = 0; m < 3; m++)
            {
                // if guy cash < 5
                if (guy[m].cash < 5)
                {
                    // this person can't bet anymore
                    guy[m].MyRadioButton.Enabled = false;
                    guy[m].UpdateLables();
                }
            }
        }

        private void dog1_Click(object sender, EventArgs e)
        {
        }
        // updating guy's 1 label
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "joe";
        }
        // updating guy's 2 label
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "bob";
        }
        // updating guy's 1 label
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Al";
        }
        // bet button
        private void button2_Click(object sender, EventArgs e)
        {
            // taking the money bet to int from numerical up down
            int money = (int) numericUpDown1.Value;
            // taking the dog guy's bet on
            int dog = (int)numericUpDown2.Value;
            // the first guy want to bet
            if (radioButton1.Checked)
            {
                guy[0].PlaceBet(money, dog);
                guy[0].UpdateLables();
            }
            // the second guy want to bet
            if (radioButton2.Checked)
            {
                guy[1].PlaceBet(money, dog);
                guy[1].UpdateLables();
            }
            // the third guy want to bet
            if (radioButton3.Checked)
            {
                guy[2].PlaceBet(money, dog);
                guy[2].UpdateLables();
            }

        }
        // contact us
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" We are group 21\n Thank you for using our program :D");
        }
    }
}
