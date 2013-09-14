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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace WPFQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuestionCollection qCollection = null;
        Random masterPRNG = null;

        Game gameMain = null;
        /// <summary>
        /// Init the main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            try
            {

               masterPRNG = new Random(Convert.ToInt32(System.DateTime.Now));
            }
            catch
            {
                masterPRNG = new Random();
            }

            qCollection = new QuestionCollection(masterPRNG);
            richTextBox1.AppendText("Loading questions..." + Environment.NewLine);
            if(qCollection.LoadQuestions(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCQuestions", richTextBox1) == false){
                MessageBox.Show("Having to exit due to not being able to find the questions directory!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            richTextBox1.AppendText("Loaded questions." + Environment.NewLine);

            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = true;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
        }



        /// <summary>
        /// Captures the escape key press and prompts for a password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Window winPassword = new Password();
                winPassword.Show();
            }
        }

        private void StartNewGame()
        {
            // Start
            gameMain = new Game(qCollection, this, masterPRNG);
            gameMain.PlayGame();
        }

        /// <summary>
        /// Answer A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (gameMain != null)
            {
                gameMain.QuestionAnswered("A", button3);
            }
        }

        /// <summary>
        /// Answer B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (gameMain != null)
            {
                gameMain.QuestionAnswered("B", button2);
            }
        }


        /// <summary>
        /// Answer C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (gameMain != null)
            {
                gameMain.QuestionAnswered("C", button3);
            }
        }

        /// <summary>
        /// Answer D
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (gameMain != null)
            {
                gameMain.QuestionAnswered("D", button4);
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (gameMain != null)
            {
                button6.IsEnabled = false;
                gameMain.FiftyFifty = true;
                
                foreach (string charBlock in gameMain.Get5050())
                {
                    if (charBlock == "A") button1.IsEnabled = false;
                    else if (charBlock == "B") button2.IsEnabled = false;
                    else if (charBlock == "C") button3.IsEnabled = false;
                    else if (charBlock == "D") button4.IsEnabled = false;
                }
            }
        }

        private void DoPiButton()
        {
            if (gameMain != null)
            {
                try
                {
                    string strFile = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\NCCSounds\\TheNet.wav";
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@strFile);
                    player.Play();
                }
                catch (Exception)
                {

                }

                gameMain.FoneAFriend = true;

                if (gameMain.GetAnswer() == "A")
                {
                    button1.IsEnabled = true;
                    button2.IsEnabled = false;
                    button3.IsEnabled = false;
                    button4.IsEnabled = false;
                }
                else if (gameMain.GetAnswer() == "B")
                {
                    button1.IsEnabled = false;
                    button2.IsEnabled = true;
                    button3.IsEnabled = false;
                    button4.IsEnabled = false;
                }
                else if (gameMain.GetAnswer() == "C")
                {
                    button1.IsEnabled = false;
                    button2.IsEnabled = false;
                    button3.IsEnabled = true;
                    button4.IsEnabled = false;
                }
                else if (gameMain.GetAnswer() == "D")
                {
                    button1.IsEnabled = false;
                    button2.IsEnabled = false;
                    button3.IsEnabled = false;
                    button4.IsEnabled = true;
                }
             
            }
        }

        private void image2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            image2.Visibility = System.Windows.Visibility.Hidden;
            DoPiButton();
        }
        
        private void image2_TouchUp(object sender, TouchEventArgs e)
        {
            image2.Visibility = System.Windows.Visibility.Hidden;
            DoPiButton();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (gameMain != null)
            {
                button7.IsEnabled = false;
                gameMain.MoreTime = true;
                gameMain.GiveMoreTime();
            }
        }

        [ValueConversion(typeof(double), typeof(Brushes))]
        public class DoubleToColor : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double i = System.Convert.ToDouble(value);
                if (i > 50d) return Brushes.Green;
                if (i <= 50d && i > 20d) return Brushes.Yellow;
                if (i <= 20d) return Brushes.Red;
                return Brushes.Black;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
        }
    }
}
