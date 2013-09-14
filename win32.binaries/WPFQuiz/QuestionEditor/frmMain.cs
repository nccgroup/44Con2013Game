/*
A trivia game framework for Microsoft Windows

Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

https://github.com/nccgroup/44Con2013Game

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace QuestionEditor
{
    public partial class frmMain : Form
    {
        bool bChanged = false;
        bool bFromDisk = false;
        string strFilename = "";
        
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        /// <summary>
        /// Form constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Init the file list
        /// </summary>
        private void initFiles()
        {
            
            try
            {
                listQuestions.Clear();
            }
            catch (Exception)
            {

            }

            foreach (string strFile in Directory.EnumerateFiles("C:\\NCCQuestions\\", "*.xml"))
            {
                
                this.Invoke((MethodInvoker)delegate {listQuestions.Items.Add(strFile);});

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            //Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            initFiles();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            //Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            //initFiles();
        }

        /// <summary>
        /// Init lists
        /// </summary>
        private void initLists()
        {
            int intCount = 0;

            this.cmbLevel.DisplayMember = "Text";
            this.cmbLevel.ValueMember = "Value";

            cmbLevel.Items.Clear();
            cmbTime.Items.Clear();

            for (intCount = 0; intCount < 12; intCount++)
            {

                StringBuilder strText = new StringBuilder();
                StringBuilder strTimeText = new StringBuilder();

                // Level object
                strText.Append(intCount.ToString());
                if (intCount == 0)
                {
                    strText.Append(" (easiest)");
                }
                if (intCount == 11)
                {
                    strText.Append(" (hardest)");
                }
                ComboboxItem cmbItem = new ComboboxItem();
                cmbItem.Text = strText.ToString();
                cmbItem.Value = intCount.ToString();
                cmbLevel.Items.Add(cmbItem);

                // Time object

                ComboboxItem cmbItemTime = new ComboboxItem();


                try
                {
                    if (intCount > 0)
                    {
                        int intTemp = 120 / intCount;
                        cmbItemTime.Value = intTemp;
                    }
                    else
                    {
                        cmbItemTime.Value = 120;
                    }

                    strTimeText.Append(cmbItemTime.Value.ToString());
                    strTimeText.Append(" seconds");
                }
                catch (Exception)
                {
                    cmbItemTime.Value = 65535;
                }


                cmbItemTime.Text = strTimeText.ToString();
                cmbTime.Items.Add(cmbItemTime);

                cmbAnswer.Items.Clear();
                ComboboxItem cmbAA = new ComboboxItem();
                cmbAA.Text = "A";
                cmbAA.Value = "A";
                ComboboxItem cmbAB = new ComboboxItem();
                cmbAB.Text = "B";
                cmbAB.Value = "B";
                ComboboxItem cmbAC = new ComboboxItem();
                cmbAC.Text = "C";
                cmbAC.Value = "C";
                ComboboxItem cmbAD = new ComboboxItem();
                cmbAD.Text = "D";
                cmbAD.Value = "D";
                cmbAnswer.Items.Add(cmbAA);
                cmbAnswer.Items.Add(cmbAB);
                cmbAnswer.Items.Add(cmbAC);
                cmbAnswer.Items.Add(cmbAD);
                

            }

        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("C:\\NCCQuestions\\") == false)
            {
                if (MessageBox.Show("C:\\NCCQuestions\\ does not exist. Shall I create it for you?\nIf not then I will exit.", "Directory does not exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory("C:\\NCCQuestions\\");
                    }
                    catch (Exception expError)
                    {
                        MessageBox.Show("Failed to create C:\\NCCQuestions\\ : " + expError.Message);
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            initLists();
            initFiles();

            /*
            FileSystemWatcher fsWatcher = new FileSystemWatcher();
            fsWatcher.Path = "C:\\NCCQuestions\\";
            fsWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            fsWatcher.Filter = "*.xml";
            fsWatcher.Created += new FileSystemEventHandler(OnChanged);
            fsWatcher.Deleted += new FileSystemEventHandler(OnChanged);
            fsWatcher.Renamed += new RenamedEventHandler(OnRenamed);
            fsWatcher.EnableRaisingEvents = true;
             */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void cmbLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmbTime_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            if (bChanged == true)
            {
                if (MessageBox.Show("Changes pending are you sure you wan't to continue?", "Data will be lost", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            initLists();
            txtDesc.Text = "";
            richQuestion.Text = "";
            richAnswerA.Text = "";
            richAnswerB.Text = "";
            richAnswerC.Text = "";
            richAnswerD.Text = "";
            cmbLevel.SelectedItem = null;
            cmbLevel.Text = "";
            cmbTime.SelectedItem = null;
            cmbTime.Text = "";
            cmbAnswer.SelectedItem = null;
            cmbAnswer.Text = "";
            bChanged = false;
            bFromDisk = false;
            strFilename = "";
            lblAction.Text = "New";
        }

        private void richQuestion_TextChanged(object sender, EventArgs e)
        {
            bChanged = true;
            lblAction.Text = "Changes pending";
        }

        private void richAnswerA_TextChanged(object sender, EventArgs e)
        {
            bChanged = true;
            lblAction.Text = "Changes pending";
        }

        private void richAnswerB_TextChanged(object sender, EventArgs e)
        {
            bChanged = true;
            lblAction.Text = "Changes pending";
        }

        private void richAnswerC_TextChanged(object sender, EventArgs e)
        {
            bChanged = true;
            lblAction.Text = "Changes pending";
        }

        private void richAnswerD_TextChanged(object sender, EventArgs e)
        {
            bChanged = true;
            lblAction.Text = "Changes pending";
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            bChanged = true;
            lblAction.Text = "Changes pending";
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            if (txtDesc.TextLength > 4 && richQuestion.TextLength > 10 && richAnswerA.TextLength > 0 && richAnswerB.TextLength > 0 &&
                richAnswerC.TextLength > 0 && richAnswerD.TextLength > 0 && cmbLevel.SelectedItem != null && cmbTime.SelectedItem != null &&
                cmbAnswer.SelectedItem != null)
            {
                if (txtDesc.TextLength > 4 == false) lblAction.Text = "Description too short";
                else if (richQuestion.TextLength > 10 == false) lblAction.Text = "Quesiton too too short";
                else if (richAnswerA.TextLength > 0 == false) lblAction.Text = "Needs an answer A";
                else if (richAnswerB.TextLength > 0 == false) lblAction.Text = "Needs an answer B";
                else if (richAnswerC.TextLength > 0 == false) lblAction.Text = "Needs an answer C";
                else if (richAnswerD.TextLength > 0 == false) lblAction.Text = "Needs an answer D";
                else if (cmbLevel.SelectedItem != null == false) lblAction.Text = "Needs a level";
                else if (cmbTime.SelectedItem != null == false) lblAction.Text = "Needs a time limit";
                else if (cmbAnswer.SelectedItem != null == false) lblAction.Text = "Needs an answer";
                else lblAction.Text = "Unknown problem";
            }
            else
            {
                MessageBox.Show("Can't save incomplete questions", "Can't save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initFiles();
                return;
            }

            if (bFromDisk == true)
            {
                if (MessageBox.Show("I will be saving to the existing file '" + strFilename + "'. Continue?", "Data will be overwritten", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    if (MessageBox.Show("Do you want me to save to a new file?", "Create new file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bFromDisk = false;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            XmlDocument newDoc = new XmlDocument();
            XmlElement newRoot = newDoc.CreateElement("Question");
            XmlNode xmlE = newDoc.AppendChild(newRoot);

            XmlElement QuestionDesc = newDoc.CreateElement("QuestionDesc");
            QuestionDesc.InnerText = txtDesc.Text;
            xmlE.AppendChild(QuestionDesc);

            XmlElement QuestionText = newDoc.CreateElement("QuestionText"); 
            XmlNode QuestionTextRich = newDoc.CreateCDataSection("QuestionText");
            QuestionTextRich.InnerText = richQuestion.Text;
            QuestionText.AppendChild(QuestionTextRich);
            xmlE.AppendChild(QuestionText);

            XmlElement Time = newDoc.CreateElement("Time");
            try
            {
                ComboboxItem cmbItemTime = cmbTime.SelectedItem as ComboboxItem;
                Time.InnerText = cmbItemTime.Value.ToString();
            }
            catch (Exception)
            {
                Time.InnerText = "0";
            }
            xmlE.AppendChild(Time);

            XmlElement Level = newDoc.CreateElement("Level");
            try
            {
                ComboboxItem cmbItemLevel = cmbLevel.SelectedItem as ComboboxItem;
                Level.InnerText = cmbItemLevel.Value.ToString();
            }
            catch (Exception)
            {
                Level.InnerText = "0";
            }
            xmlE.AppendChild(Level);

            XmlElement Bonus =newDoc.CreateElement("Bonus");
            Bonus.InnerText = "false";
            xmlE.AppendChild(Bonus);

            XmlElement AnswerA = newDoc.CreateElement("AnswerA");
            AnswerA.InnerText = richAnswerA.Text;
            xmlE.AppendChild(AnswerA);

            XmlElement AnswerB = newDoc.CreateElement("AnswerB");
            AnswerB.InnerText = richAnswerB.Text;
            xmlE.AppendChild(AnswerB);

            XmlElement AnswerC = newDoc.CreateElement("AnswerC");
            AnswerC.InnerText = richAnswerC.Text;
            xmlE.AppendChild(AnswerC);

            XmlElement AnswerD = newDoc.CreateElement("AnswerD");
            AnswerD.InnerText = richAnswerD.Text;
            xmlE.AppendChild(AnswerD);

            ComboboxItem cmbItemAnswer = cmbAnswer.SelectedItem as ComboboxItem;
            XmlElement Correct = newDoc.CreateElement("Correct");
            Correct.InnerText = cmbItemAnswer.Value.ToString();
            xmlE.AppendChild(Correct);

            if (bFromDisk == true)
            {
                string strFile = "C:\\NCCQuestions\\"+ strFilename;
                newDoc.Save(@strFile);
                lblAction.Text = "Saved " + strFilename;
                bChanged = false;
                initFiles();
                cmdNew_Click(null, null);
            }
            else
            {
                string strFile = "C:\\NCCQuestions\\"+ txtDesc.Text + ".xml";
                try
                {
                    newDoc.Save(@strFile);
                    lblAction.Text = "Saved " + txtDesc.Text + ".xml";
                    initFiles();
                }
                catch (Exception expError)
                {
                    MessageBox.Show("Couldn't save: " + expError.Message + "\n Please check description and try again", "Couldn't save",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void listQuestions_DoubleClick(object sender, EventArgs e)
        {
            initLists();
            richQuestion.Text = "";
            richAnswerA.Text = "";
            richAnswerB.Text = "";
            richAnswerC.Text = "";
            richAnswerD.Text = "";
            bChanged = false;
            bFromDisk = false;

            

            if (listQuestions.SelectedItems.Count == 1)
            {
                foreach(ListViewItem lstLVI in listQuestions.SelectedItems){
                    strFilename = Path.GetFileName(lstLVI.Text);
                    string xmlText = File.ReadAllText(lstLVI.Text);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlText);
                    
                    try{
                        XmlNode xmlQD = xmlDoc.GetElementsByTagName("QuestionDesc")[0];
                        XmlNode xmlQ = xmlDoc.GetElementsByTagName("QuestionText")[0];
                        XmlCDataSection xmlCData = xmlQ.FirstChild as XmlCDataSection;
                        XmlNode xmlAA = xmlDoc.GetElementsByTagName("AnswerA")[0];
                        XmlNode xmlAB = xmlDoc.GetElementsByTagName("AnswerB")[0];
                        XmlNode xmlAC = xmlDoc.GetElementsByTagName("AnswerC")[0];
                        XmlNode xmlAD = xmlDoc.GetElementsByTagName("AnswerD")[0];
                        XmlNode xmlT = xmlDoc.GetElementsByTagName("Time")[0];
                        XmlNode xmlL = xmlDoc.GetElementsByTagName("Level")[0];
                        XmlNode xmlA = null;
                        int intCount = 0;
                        try
                        {
                            xmlA = xmlDoc.GetElementsByTagName("Correct")[0];
                            intCount = 0;
                            foreach (ComboboxItem cmbItem in cmbAnswer.Items)
                            {
                                if (cmbItem.Value.ToString().Equals(xmlA.InnerText)) cmbAnswer.SelectedItem = cmbItem;
                                intCount++;
                            }
                        }
                        catch (Exception)
                        {
                            cmbAnswer.SelectedItem = null;
                        }

                        txtDesc.Text = xmlQD.InnerText.ToString();
                        richQuestion.Text = xmlCData.InnerText;
                        richAnswerA.Text = xmlAA.InnerText;
                        richAnswerB.Text = xmlAB.InnerText;
                        richAnswerC.Text = xmlAC.InnerText;
                        richAnswerD.Text = xmlAD.InnerText;
                        intCount =0;
                        foreach (ComboboxItem cmbItem in cmbTime.Items)
                        {
                            if (cmbItem.Value.ToString().Equals(xmlT.InnerText)) cmbTime.SelectedItem = cmbItem;
                            intCount++;
                        }
                        intCount = 0;
                        foreach (ComboboxItem cmbItem in cmbLevel.Items)
                        {
                            if (cmbItem.Value.ToString().Equals(xmlL.InnerText)) cmbLevel.SelectedItem = cmbItem;
                            intCount++;
                        }
                        bFromDisk = true;
                    } catch (Exception expError){
                        MessageBox.Show("Problem with question file format: " + expError.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        bFromDisk = false;
                    }

                    bChanged = false;
                    lblAction.Text = "Loaded " + Path.GetFileName(lstLVI.Text);
                }
            }

            initFiles();
        }

        private void listQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        
    }
}
