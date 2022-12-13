using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using EzLaunchr.Scripts;

namespace EzLaunchr
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        XMLHandler xmlHandler = new XMLHandler();


        public Form1()
        {
            form1 = this;
            InitializeComponent();
            this.flowLayoutPanel.AllowDrop = true;

        }

        private void createPanelButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }

        private void OpenAllButton_Click(object sender, EventArgs e)
        {
            foreach (LinkButton lb in flowLayoutPanel.Controls.OfType<LinkButton>())
              lb.OpenLink();
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlHandler.HandleXMLSave(flowLayoutPanel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xmlHandler.HandleXMLLoad(flowLayoutPanel);
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

