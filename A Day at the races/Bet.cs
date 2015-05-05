using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Day_at_the_races
{
    class Bet
    {
        // bet amount
        public int amount;
        // dog which bettor bets on
        public int dog;
        // instance of guy
        public Guy Bettor;

        // Constructor to initialize values
        public Bet(int Amount, int Dog, Guy Bettor)
        {
            this.amount = Amount;
            this.dog = Dog;
            this.Bettor = Bettor;
        }

        // get bet description
        public string GetDescription()
        {
            if (amount ==0)
            {
                return Bettor.name + " hasn't place ant bet";
            }
            else
            {
                return Bettor.name + " has placed " + amount + " on " + dog;
            }
        }

        // takes the winner and returns the bet amount 
        // according to loss or winning
        public int PayOut(int winner)
        {
            if (dog == winner)
            {
                return amount;
            }
            else
            {
                return -amount;
            }
        }
    }
}
