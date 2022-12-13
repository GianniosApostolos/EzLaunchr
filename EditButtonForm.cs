using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EzLaunchr.Properties;

namespace EzLaunchr
{
    internal partial class EditButtonForm : Form
    {
        private LinkButton lb;

        public EditButtonForm(LinkButton linkButton)
        {
            InitializeComponent();
            lb = linkButton;
            editLinkTextBox.Text = linkButton.link;
            editDescriptionTextBox.Text = linkButton.displayName.Text;

        }

        private void applyEditButton_Click(object sender, EventArgs e)
        {
            lb.link = editLinkTextBox.Text;
            lb.displayName.Text = editDescriptionTextBox.Text;

        }

        private void EditButtonForm_Load(object sender, EventArgs e)
        {
            this.Opacity=(double)Settings.Default["FormOpacity"];
        }
    }
}
