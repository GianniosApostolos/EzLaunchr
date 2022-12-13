using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace EzLaunchr
{
    class LinkButton : Panel
    {

        public string link { get; set; }
        public Label displayName { get; set; }
        private Button removeButton;
        private Button editButton;
        private Panel topPanel;
        private Panel topPanelBottomSideColor;


        public LinkButton() { }


        public LinkButton(string link, string labelDescription)
        {
            this.link = link;

            this.Size = new Size(115, 120);
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.Click += LinkButton_Click;

            // Creating the X button at the top right of the panel
            removeButton = new Button();
            removeButton.Size = new Size(23, 23);
            removeButton.BackColor = Color.FromArgb(50, 50, 50);
            removeButton.ForeColor = Color.White;
            removeButton.Top = this.Top;
            removeButton.Left = this.Right-25;
            removeButton.Text = "🗙";
            removeButton.TextAlign = ContentAlignment.MiddleCenter;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.FlatAppearance.BorderSize = 0;
            //Clicking on the button deletes the whole panel
            removeButton.Click += new EventHandler(removeButton_Click);


            // Creating the edit button that allows the user to edit an entry
            editButton = new Button();
            editButton.Size = new Size(23, 23);
            editButton.BackColor = Color.FromArgb(50, 50, 50);
            editButton.ForeColor = Color.White;
            editButton.Top = this.Top;
            editButton.Left = this.Right - 50;
            editButton.Text = "✐";
            editButton.TextAlign = ContentAlignment.MiddleCenter;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.FlatAppearance.BorderSize = 0;
            //Clicking on the button deletes the whole panel
            editButton.Click += new EventHandler(editButton_Click);


            //Creating the panel that sits on top of the button
            topPanel = new Panel();
            topPanel.BackColor = Color.FromArgb(50, 50, 50);
            topPanel.Size = new Size(this.Width, 25);
            topPanel.Top = this.Top;
            topPanel.Left = this.Left;
            
            //topPanelBottomSideColor is the small darker line that serves as a visual seperator on the top part of the LinkButton
            topPanelBottomSideColor = new Panel();
            topPanelBottomSideColor.Parent = topPanel;
            topPanelBottomSideColor.BackColor = Color.FromArgb(30, 30, 30);
            topPanelBottomSideColor.Size = new Size(this.Width, 2);
            topPanelBottomSideColor.Dock = DockStyle.Bottom;

            // Creating the label that sits on top of the panel
            displayName = new Label();
            displayName.BackColor = Color.FromArgb(60, 60, 60);
            displayName.ForeColor = Color.White;
            displayName.AutoSize = false;
            displayName.Top = this.Top + removeButton.Height + topPanelBottomSideColor.Height + 5;
            displayName.Left = this.Left;
            displayName.Width = this.Width;
            displayName.Height = this.Height;
            displayName.Text = labelDescription;
            displayName.TextAlign = ContentAlignment.TopCenter;
            // Clicking on the label is the same as clicking on the panel
            displayName.Click += new EventHandler(displayName_Click);




            //Adding all the controls on top of the panel
            this.Controls.Add(removeButton);
            this.Controls.Add(editButton);
            this.Controls.Add(displayName);
            this.Controls.Add(topPanel);
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            //Removing all event handlers before disposing the button

            displayName.Click -= displayName_Click;
            removeButton.Click -= removeButton_Click;
            this.Click -= LinkButton_Click;

            this.Dispose();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditButtonForm editForm = new EditButtonForm(this);
            editForm.ShowDialog();
        }


        private void displayName_Click(object sender, EventArgs e)
        {
            LinkButton_Click(sender,e);
        }

        private void LinkButton_Click(object sender, EventArgs e)
        {
            OpenLink();
        }
        

        // Opens link in default browser
        public void OpenLink()
        {
            Console.WriteLine("Redirecting to: " + link);
            try
            {
                System.Diagnostics.Process.Start(link);
            }
            catch (Exception e)
            {
                if (e is Win32Exception w)
                {
                    Console.WriteLine(w.Message);
                    Console.WriteLine(w.ErrorCode.ToString());
                    Console.WriteLine(w.NativeErrorCode.ToString());
                    Console.WriteLine(w.StackTrace);
                    Console.WriteLine(w.Source);
                    Exception ex = w.GetBaseException();
                    Console.WriteLine(e.Message);

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    return;
                }
                if (e is InvalidOperationException i)
                {
                    Console.WriteLine("Exception: " + i.Message + " when trying to find link to follow");
                    string messageBoxMessage = "There was a problem following the link when pressing the button." +
                        "\nThis usually occurs when there was no link attached to the button." +
                        "\nPlease delete and recreate the problematic button.";
                    MessageBox.Show(messageBoxMessage, "Link is missing", MessageBoxButtons.OK);
                    return;
                }

                throw;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
