using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace A_Day_at_the_races
{
    class Greyhound
    {
        // the place where the dog start
        public int StartPos;
        // the length of the track
        public int RaceTrackLen;
        // declaring the picture box
        public PictureBox Picturebox;
        // the dog location on the track
        public int location = 0;
        // instance(object) of random
        public Random randomizer;

        // Constructor initializing values
        public Greyhound(int StartPos, int RaceTrackLen, PictureBox Picturebox)
        {
            this.StartPos = StartPos;
            this.RaceTrackLen = RaceTrackLen;
            this.Picturebox = Picturebox;
        }
        // Moving the dog on the track
        // return true when dog reaches the end
        public bool Run()
        {
            // Getting the dog current location
            Point p = Picturebox.Location;
            // moving the dog at random 1, 2, 3, 4 spaces
            p.X += randomizer.Next(1, 4);
            // update the dog's location
            Picturebox.Location = p;
            // save location to variable
            location = p.X;
            // return true, then the race finished
            if (location > (RaceTrackLen - 2.5 * StartPos))
            {
                return true;
            }
            return false;
        }

        // rest the dog to start when race finish
        public void reset()
        {
            Point p = Picturebox.Location;
            p.X = StartPos;
            Picturebox.Location = p;
        }
    }
}
