using System;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using EzLaunchr.Scripts;

namespace EzLaunchr
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        XMLHandler xmlHandler = new XMLHandler();


            PrivateFontCollection myfontCollection = new PrivateFontCollection();
        public Form1()
        {
            form1 = this;
            InitializeComponent();
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
            //Can perform checks to figure out of the user leaves without saving changes
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xmlHandler.HandleXMLLoad(flowLayoutPanel,false);
        }

        private void saveXmlButton_Click(object sender, EventArgs e)
        {
            xmlHandler.HandleXMLSave(flowLayoutPanel);
        }


        //Hiding the panel that holds the Save XML and Load XML buttons to reduce visual clutter
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (flowLayoutPanel.Controls.OfType<LinkButton>().Count() >0 ) //This check is used in order to determine if there are more 1 LinkButtons in the flowlayoutpanel. If there are NOT we do not hide the save nad load buttons. This means that the user didn't add anything yet
            {
                if (this.Width <= 280)
                    saveloadPanel.Visible = false;
                else
                    saveloadPanel.Visible = true;
            }
            else
                saveloadPanel.Visible = true;

        }

        private void loadXmlButton_Click(object sender, EventArgs e)
        {
            xmlHandler.HandleXMLLoad(flowLayoutPanel,true); //It loads another xml file
        }

        private void overwriteSave_Click(object sender, EventArgs e)
        {
            xmlHandler.HandleXMLOverwrite(flowLayoutPanel);
        }
    }
}

