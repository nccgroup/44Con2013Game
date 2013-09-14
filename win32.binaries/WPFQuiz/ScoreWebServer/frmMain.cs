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
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace ScoreWebServer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var server = new LocalHttpListener();
            var task = Task.Factory.StartNew(() => server.Start());
            button1.Enabled = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
