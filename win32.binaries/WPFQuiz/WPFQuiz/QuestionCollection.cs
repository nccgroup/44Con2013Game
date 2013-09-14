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
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WPFQuiz
{
    /// <summary>
    /// Collection of question objects
    /// </summary>
    public class QuestionCollection
    {

        List<Question> lstQuestions = new List<Question>();
        Random rngPRNG = null;

        public QuestionCollection(Random myPRNG)
        {
            rngPRNG = myPRNG;
        }

        public int Count { get; set; }


        // Loads the XML questions from this directory
        public bool LoadQuestions(string strDirectory, RichTextBox richMain)
        {
            
            if (Directory.Exists(strDirectory) == false)
            {
                System.Windows.MessageBox.Show("Couldn't find the directory containing questions: " + strDirectory, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }


            int intCount = 0;
            foreach(string strFile in Directory.EnumerateFiles(strDirectory,"*.xml")){

                XDocument thisXML = XDocument.Load(strFile);
                Question thisQuestion = new Question(strFile,richMain);
                lstQuestions.Add(thisQuestion);
                intCount++;
            }

            richMain.AppendText("Loaded a total of " + lstQuestions.Count() + " files" + Environment.NewLine);
            Count = lstQuestions.Count();

            return true;
        }

        public Question GetRandomQuestionAtLevel(int intLevel)
        {
            List<Question> lstQuestionPool = new List<Question>();

            foreach (Question questionCurrent in lstQuestions)
            {
                if (questionCurrent.Level == intLevel)
                {
                    lstQuestionPool.Add(questionCurrent);
                }
            }

            if (lstQuestionPool.Count == 0) {
                //MessageBox.Show("No Questions at level " + intLevel);
                Console.WriteLine("No question at that level");
                //return null;
                return GetRandomQuestionAtLevel(intLevel - 1);
            }


            
            int randValue = Convert.ToInt32(rngPRNG.NextDouble() * (lstQuestionPool.Count - 0) + 0);

            Question qSelected = null;

            try
            {
                qSelected = lstQuestionPool[randValue];
            }
            catch (ArgumentOutOfRangeException)
            {
                qSelected = lstQuestionPool[randValue-1];
            }

            return qSelected;
        }

    }
}
