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
using System.Timers;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Xml;
using System.Reflection;
using System.IO;

namespace WPFQuiz
{
    public class Game
    {
        private QuestionCollection qCollection = null;
        private MainWindow MyMain = null;
        private Question WhatIAmAsking = null;
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private PiBackdoor thisBackdoor = null;
        Random rngPRNG = null;

        /// <summary>
        /// Parent object of the game
        /// </summary>
        public Game(QuestionCollection qCollectionIn, MainWindow myMain, Random myPRNG)
        {
            this.PlayerName = "";
            this.PlayerEMail = "";
            this.PlayerStarted = false;
            this.FoneAFriend = false;
            this.AskTheAudiance = false;
            this.FiftyFifty = false;
            this.MoreTime = false;
            this.Level = 0;
            this.Seconds = 0;
            this.qCollection = qCollectionIn;
            this.MyMain = myMain;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.rngPRNG = myPRNG;
        }

        /// <summary>
        /// Player's name
        /// </summary>
        public string PlayerName{get;set;}


        /// <summary>
        /// Player's e-mail address
        /// </summary>
        public string PlayerEMail{get;set;}

        /// <summary>
        /// Player started game
        /// </summary>
        public bool PlayerStarted{ get; set; }

        /// <summary>
        /// Level the user is on
        /// </summary>
        public int Level{get;set;}

        /// <summary>
        /// Do they have the phone a friend life line?
        /// </summary>
        public bool FoneAFriend{get;set;}

        /// <summary>
        /// Do they have the ask audiance life line?
        /// </summary>
        public bool AskTheAudiance{get;set;}

        /// <summary>
        /// Do they have the 50/50 life line?
        /// </summary>
        public bool FiftyFifty{get;set;}

        /// <summary>
        /// Do they have the more time life line?
        /// </summary>
        public bool MoreTime{get;set;}

        /// <summary>
        /// Number of seconds this game as been running
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// Is the game running
        /// </summary>
        public bool GameRunning { get; set; }

        /// <summary>
        /// Get the next question
        /// </summary>
        /// <returns>Returns a question object</returns>
        public Question nextQuestion()
        {
            return qCollection.GetRandomQuestionAtLevel(Level);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            MyMain.progressBar1.Value = MyMain.progressBar1.Value - 1;
            Seconds++;

            if (MyMain.progressBar1.Value == 0)
            {
                StopTheClock();
                GameOver();
            }
            else if (MyMain.progressBar1.Value > 20)
            {
                GreenProgressBar();
            }
            else if (MyMain.progressBar1.Value <= 20 && MyMain.progressBar1.Value > 7)
            {
                YellowProgressBar();
            }
            else if (MyMain.progressBar1.Value <= 7)
            {
                RedProgressBar();
            }
        }

        public void StopTheClock()
        {
            timer.Stop();
        }

        public string GetAnswer()
        {
            if (WhatIAmAsking == null)
            {
                return "Z";
            }
            else
            {
                return WhatIAmAsking.Correct;
            }
        }

        public void GiveMoreTime(){
            MyMain.progressBar1.Value += 15;
            try
            {
                string strFile = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\Dangerous.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                player.Play();
            }
            catch (Exception)
            {

            }
        }

        public string[] Get5050()
        {
            try
            {
                string strFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\Secure.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                player.Play();
            }
            catch (Exception)
            {

            }
            string[] charLetters = {"A","B","C","D"};
            string[] chrRet = new string[2];

            int intCount = 0;

            
            while(intCount < 2){
           
                // First char
                if (intCount == 0)
                {
                    while (true)
                    {
                        int randValue = Convert.ToInt32(rngPRNG.NextDouble() * (3 - 0) + 0);
                        if (this.GetAnswer().Equals(charLetters[randValue]) == false)
                        {
                            Console.WriteLine(this.GetAnswer() + " - " + charLetters[randValue]);
                            chrRet[0] = charLetters[randValue];
                            intCount++;
                            break;
                        }
                    }
                }

                // Second char
                if(intCount == 1){
                    while (true)
                    {
                        int randValue = Convert.ToInt32(rngPRNG.NextDouble() * (3 - 0) + 0);
                        if (this.GetAnswer().Equals(charLetters[randValue]) == false && chrRet[0] != charLetters[randValue])
                        {

                            chrRet[1] = charLetters[randValue];
                            intCount++;
                            break;
                        }
                    }

                }
            }



            return chrRet;
        }

        public void GreenProgressBar()
        {
            // "#FF01D328";
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
            MyMain.progressBar1.Foreground = myBrush;
            
        }

        public void RedProgressBar()
        {
            
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Red);
            MyMain.progressBar1.Foreground = myBrush;
        }

        public void YellowProgressBar()
        {

            SolidColorBrush myBrush = new SolidColorBrush(Colors.Yellow);
            MyMain.progressBar1.Foreground = myBrush;
        }

        public void AskQuestion()
        {
            WhatIAmAsking = qCollection.GetRandomQuestionAtLevel(Level);
            if (WhatIAmAsking != null)
            {
                GreenProgressBar();
                MyMain.label1.Content = Level.ToString() + " of 11";
                MyMain.richTextBox1.Document.Blocks.Clear();
                MyMain.richTextBox1.Document.Blocks.Add(new Paragraph(new Run(WhatIAmAsking.QuestionText)));
                MyMain.button1.IsEnabled = true;
                MyMain.button2.IsEnabled = true;
                MyMain.button3.IsEnabled = true;
                MyMain.button4.IsEnabled = true;
                MyMain.button5.IsEnabled = false;
                if (this.FiftyFifty == false) MyMain.button6.IsEnabled = true;
                else MyMain.button6.IsEnabled = false;
                if (this.MoreTime== false) MyMain.button7.IsEnabled = true;
                else MyMain.button7.IsEnabled = false;
                MyMain.button1.Content = WhatIAmAsking.AnswerA;
                MyMain.button2.Content = WhatIAmAsking.AnswerB;
                MyMain.button3.Content = WhatIAmAsking.AnswerC;
                MyMain.button4.Content = WhatIAmAsking.AnswerD;
                MyMain.progressBar1.Value = WhatIAmAsking.Time;
                timer.Start();
            }
            else
            {
                GameOver();
            }
        }


        
        
        /// <summary>
        /// Event interface for when buttons are pushed
        /// </summary>
        /// <param name="strButton"></param>
        /// <param name="btnPushed"></param>
        public void QuestionAnswered(string strButton, Button btnPushed)
        {
            Console.WriteLine("Answer: " + this.GetAnswer());
            Console.WriteLine("Supplied: " + strButton);

            
            if (this.GetAnswer().Equals(strButton)) // Winrar
            {
                StopTheClock();
                btnPushed.Content = "Correct";
                Level++;

                if (Level == 8)
                {
                    try
                    {
                        string strFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\ConfidencePlay.wav";
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                        player.Play();
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    try
                    {
                        string strFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\ExcellentPlay.wav";
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                        player.Play();
                    }
                    catch (Exception)
                    {

                    }
                }

                if (Level >= 12)
                {
                    Winrar();
                }
                else
                {
                    AskQuestion();
                }
            }
            else // Game over
            {
                StopTheClock();
                btnPushed.Content = "Wrong";
                GameOver();
            }
        }

        /// <summary>
        /// How we start asking questions
        /// </summary>
        public void PlayGame()
        {
            try
            {
                string strFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\ShallPlay.wav";
                Console.WriteLine(strFile);
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                player.Play();
            }
            catch (Exception)
            {

            }
            Window winName = new Name(this);
            winName.ShowDialog();

            if (this.PlayerStarted == false) return;

            //PlayerEMail
            MyMain.button1.IsEnabled = true;
            MyMain.button2.IsEnabled = true;
            MyMain.button3.IsEnabled = true;
            MyMain.button4.IsEnabled = true;
            MyMain.button5.IsEnabled = false;
            thisBackdoor = new PiBackdoor(this, MyMain);
            AskQuestion();
        }


        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public void SaveGame()
        {
            if (Directory.Exists("C:\\NCCPlayers\\") == false)
            {
                try
                {
                    Directory.CreateDirectory("C:\\NCCPlayers\\");
                }
                catch (Exception)
                {
                    MessageBox.Show("Couldn't create the required directory C:\\NCCPlayer\\. Games wont be saved!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            XmlDocument newDoc = new XmlDocument();
            XmlElement newRoot = newDoc.CreateElement("Game");
            XmlNode xmlE = newDoc.AppendChild(newRoot);

            XmlElement XPlayerName = newDoc.CreateElement("PlayerName");
            XPlayerName.InnerText = PlayerName;
            xmlE.AppendChild(XPlayerName);
            XmlElement XEMail = newDoc.CreateElement("PlayerEMail");
            XEMail.InnerText = PlayerEMail;
            xmlE.AppendChild(XEMail);
            XmlElement XLevel = newDoc.CreateElement("Level");
            XLevel.InnerText = Level.ToString();
            xmlE.AppendChild(XLevel);
            XmlElement XSeconds = newDoc.CreateElement("Seconds");
            XSeconds.InnerText = Seconds.ToString();
            xmlE.AppendChild(XSeconds);

            XmlElement X5050 = newDoc.CreateElement("FiftyFifty");
            X5050.InnerText = FiftyFifty.ToString();
            xmlE.AppendChild(X5050);
            XmlElement XBackdoor = newDoc.CreateElement("Backdoor");
            XBackdoor.InnerText = FoneAFriend.ToString();
            xmlE.AppendChild(XBackdoor);
            XmlElement XMoreTime = newDoc.CreateElement("MoreTime");
            XMoreTime.InnerText = XMoreTime.ToString();
            xmlE.AppendChild(XMoreTime);


            string strFile = "C:\\NCCPlayers\\" + GetTimestamp(DateTime.Now) + ".xml";
            newDoc.Save(@strFile);
        }
        public void Winrar()
        {
            SaveGame();
            try
            {
                string strFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\Win.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                player.Play();
            }
            catch (Exception)
            {

            }
            MyMain.progressBar1.Value = 120;
            GreenProgressBar();
            MyMain.label1.Content = "Challenge completed!";
            MyMain.richTextBox1.Document.Blocks.Clear();
            MyMain.richTextBox1.Document.Blocks.Add(new Paragraph(new Run(PlayerName + " completed all levels!")));
            MyMain.button1.IsEnabled = false;
            MyMain.button2.IsEnabled = false;
            MyMain.button3.IsEnabled = false;
            MyMain.button4.IsEnabled = false;
            MyMain.button5.IsEnabled = true;
            MyMain.button6.IsEnabled = false;
            MyMain.button7.IsEnabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void GameOver()
        {
            thisBackdoor.Stop();
            SaveGame();
            try
            {
                string strFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\GameOver.wav";
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                player.Play();
            }
            catch (Exception)
            {

            }
            MyMain.progressBar1.Value = 120;
            RedProgressBar();
            MyMain.label1.Content = "Game Over";
            MyMain.richTextBox1.Document.Blocks.Clear();
            MyMain.richTextBox1.Document.Blocks.Add(new Paragraph(new Run(PlayerName + " got to level " + Level)));
            MyMain.button1.IsEnabled = false;
            MyMain.button2.IsEnabled = false;
            MyMain.button3.IsEnabled = false;
            MyMain.button4.IsEnabled = false;
            MyMain.button5.IsEnabled = true;
            MyMain.button6.IsEnabled = false;
            MyMain.button7.IsEnabled = false;
        }
    }
}
