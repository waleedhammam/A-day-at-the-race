using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace A_Day_at_the_races
{
    class Guy
    {
        // bettor name
        public string name;
        // instance of bet
        public Bet MyBet;
        // money bettor has
        public int cash;
        // bettor radio button
        public RadioButton MyRadioButton;
        // bettor text box
        public TextBox MyTextBox;

        // Constructor to initialize values
        public Guy(string name, Bet MyBet, int Cash, RadioButton MyRadioButton, TextBox MyTextBox)
        {
            this.name = name;
            this.MyBet = MyBet;
            this.cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyTextBox = MyTextBox;
        }
        // refresh labels
        public void UpdateLables()
        {
            // if user hasn't put a bet
            if (MyBet == null)
            {
                MyTextBox.Text = name + " hasn't bet yet ";
            }
            else
            {
                MyTextBox.Text = MyBet.GetDescription();
            }
            MyRadioButton.Text = name + " has " + cash + " Bucks ";
        }

        // clear bet " i don't know what it does
        public void ClearBet()
        {
            MyBet.amount = 0;
        }
        // place bet if bettor has enough cash
        public bool PlaceBet(int amount, int dog)
        {
            if (amount <= cash)
            {
                MyBet = new Bet(amount, dog, this);
                return true;
            }
            return false;
        }
        // takes winer and returns it's cash
        public int Collect(int winner)
        {
             cash += MyBet.PayOut(winner);
             return cash;
        }
    }
}