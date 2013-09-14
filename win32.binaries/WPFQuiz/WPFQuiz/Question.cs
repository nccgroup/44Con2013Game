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
using System.Xml;
using System.IO;
using System.Windows.Controls;

namespace WPFQuiz
{

    public class Question
    {

        public Question(string myFilename, RichTextBox richMain)
        {
            Filename = Path.GetFileName(myFilename);
            string xmlText = File.ReadAllText(myFilename);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlText);

            try
            {
                XmlNode xmlQD = xmlDoc.GetElementsByTagName("QuestionDesc")[0];
                XmlNode xmlQ = xmlDoc.GetElementsByTagName("QuestionText")[0];
                XmlCDataSection xmlCData = xmlQ.FirstChild as XmlCDataSection;
                XmlNode xmlAA = xmlDoc.GetElementsByTagName("AnswerA")[0];
                XmlNode xmlAB = xmlDoc.GetElementsByTagName("AnswerB")[0];
                XmlNode xmlAC = xmlDoc.GetElementsByTagName("AnswerC")[0];
                XmlNode xmlAD = xmlDoc.GetElementsByTagName("AnswerD")[0];
                XmlNode xmlT = xmlDoc.GetElementsByTagName("Time")[0];
                XmlNode xmlL = xmlDoc.GetElementsByTagName("Level")[0];
                XmlNode xmlA = xmlDoc.GetElementsByTagName("Correct")[0];

                QuestionDescripion = xmlQD.InnerText.ToString();
                QuestionText = xmlCData.InnerText;
                AnswerA = xmlAA.InnerText;
                AnswerB = xmlAB.InnerText;
                AnswerC = xmlAC.InnerText;
                AnswerD = xmlAD.InnerText;
                Correct = xmlA.InnerText;
                Time = Convert.ToInt32(xmlT.InnerText);
                Level = Convert.ToInt32(xmlL.InnerText);
            }
            catch (Exception expError)
            {
                richMain.AppendText("Problem with question file format: " + expError.Message + Environment.NewLine);
            }

        }

        /// <summary>
        /// Filename the question is stored in
        /// </summary>
        public string Filename{ get;set; }

        /// <summary>
        /// Description of question
        /// </summary>
        public string QuestionDescripion { get; set; }

        /// <summary>
        /// Text of the question
        /// </summary>
        public string QuestionText{ get; set; }

        /// <summary>
        /// Time the person has to answer the question
        /// </summary>
        public Int32 Time { get; set; }

        /// <summary>
        /// Level this question represents
        /// </summary>
        public Int32 Level { get; set; }

        /// <summary>
        /// Is this a bonus question?
        /// </summary>
        public bool Bonus { get; set; }

        /// <summary>
        /// Answer A
        /// </summary>
        public string AnswerA { get;set; }

        /// <summary>
        /// Answer B
        /// </summary>
        public string AnswerB { get;set; }

        /// <summary>
        /// Answer C
        /// </summary>
        public string AnswerC { get;set; }

        /// <summary>
        /// Answer D
        /// </summary>
        public string AnswerD { get; set; }

        /// <summary>
        /// Correct Answer
        /// </summary>
        public string Correct { get; set; }

        /// <summary>
        /// Is the question running
        /// </summary>
        public bool QuestionRunning { get; set; }
        
    }
}
