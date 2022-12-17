using System;
using System.Drawing;
using System.Windows.Forms;
using EzLaunchr.Properties;

namespace EzLaunchr
{
    internal partial class EditButtonForm : Form
    {
        private LinkButton lb;
        private Color labelForeColor;

        public EditButtonForm(LinkButton linkButton)
        {
            InitializeComponent();
            lb = linkButton;
            editLinkTextBox.Text = linkButton.link;
            editDescriptionTextBox.Text = linkButton.displayName.Text;
            editImageTextBox.Text = linkButton.imagePath;

            labelForeColor = linkButton.displayName.ForeColor; //get the ForeColor of the description label
        }

        private void EditButtonForm_Load(object sender, EventArgs e)
        {
            this.Opacity=(double)Settings.Default["FormOpacity"];
        }

        private void applyEditButton_Click(object sender, EventArgs e)
        {
            lb.link = editLinkTextBox.Text;
            lb.displayName.Text = editDescriptionTextBox.Text;
            lb.ChangeBackgroundImage(editImageTextBox.Text);

            lb.displayName.ForeColor = labelForeColor;
            this.Close();
        }

        private void editDescriptionTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ColorDialog myColorDialog = new ColorDialog();
            
            // Allows the user to use custom colors
            myColorDialog.AllowFullOpen = true;

            // Sets the initial color select to the selected LinkButton's description label forecolor.
            myColorDialog.Color = labelForeColor;

            if (myColorDialog.ShowDialog() == DialogResult.OK)
                labelForeColor = myColorDialog.Color;


        }
    }
}
