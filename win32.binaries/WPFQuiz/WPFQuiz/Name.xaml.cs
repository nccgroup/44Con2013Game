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
using System.Windows.Shapes;
using WpfKb;
using System.Text.RegularExpressions;

namespace WPFQuiz
{
    /// <summary>
    /// Interaction logic for Name.xaml
    /// </summary>
    public partial class Name : Window
    {

        private Game _myGame = null;
        /// <summary>
        /// 
        /// </summary>
        public Name(Game myGame)
        {
            _myGame = myGame;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length < 5)
            {
                txtName.Foreground = new SolidColorBrush(Colors.Red);
                txtName.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }
            else
            {
                txtName.Foreground = new SolidColorBrush(Colors.Black);
            }

            if (txtEmail.Text.Length < 5 || (txtEmail.Text.Contains("@") == false || txtEmail.Text.Contains(".") == false))
            {
                txtEmail.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }
            else txtEmail.Foreground = new SolidColorBrush(Colors.Black);

            Match match = Regex.Match(txtName.Text, @"^[\w ]+$");
            if (match.Success == false)
            {
                txtName.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }

            if ((txtName.Text.Length < 5) || (txtEmail.Text.Length < 5 || (txtEmail.Text.Contains("@") == false || txtEmail.Text.Contains(".") == false)))
            {
                return;
            }
            else
            {
                _myGame.PlayerName = txtName.Text;
                _myGame.PlayerEMail = txtEmail.Text;
                _myGame.PlayerStarted = true;
                this.Close();
            }

        }

        private void TestWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
