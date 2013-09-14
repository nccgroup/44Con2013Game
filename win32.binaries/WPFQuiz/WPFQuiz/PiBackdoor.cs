/*
A trivia game framework for Microsoft Windows

Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

https://github.com/nccgroup/44Con2013Game

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFQuiz
{
    class PiBackdoor
    {

        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private Game myGame = null;
        private MainWindow myWindow = null;
        private Random rngPRNG = new Random(System.DateTime.Now.Millisecond);

        public PiBackdoor(Game theGame, MainWindow mainWindow)
        {
            this.myGame = theGame;
            this.myWindow = mainWindow;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Interval = new TimeSpan(0, 0, 15);
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (myGame.FoneAFriend == true) return;
            else if (myGame.GameRunning == false) return;
            else
            {
                int randValue = Convert.ToInt32(rngPRNG.NextDouble() * (1 - 0) + 0);

                if (randValue == 1 && myWindow.image2.Visibility == System.Windows.Visibility.Hidden)
                {
                    myWindow.image2.Visibility = System.Windows.Visibility.Visible;
                }
                else if (randValue == 0 && myWindow.image2.Visibility == System.Windows.Visibility.Visible)
                {
                    myWindow.image2.Visibility = System.Windows.Visibility.Hidden;
                }

            }
        }

    }
}
