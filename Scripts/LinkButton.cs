/*
 * This class is responsible for creating the Buttons containing the links
 */

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace EzLaunchr
{
    class LinkButton : Panel
    {

        public string link { get; set; }
        public string imagePath { get; set; }
        public Label displayName { get; set; }
        private Button removeButton;
        private Button editButton;
        private Panel topPanel;
        private Panel topPanelBottomSideColor;


        public LinkButton() { }


        public LinkButton(string link, string labelDescription)
        {
            this.link = link;


            //Creating the background panel
            this.Size = new Size(115, 120); //Width , Height
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.Click += LinkButton_Click;

            // Creating the X button at the top right of the panel
            removeButton = new Button();
            removeButton.Size = new Size(23, 23);
            removeButton.BackColor = Color.FromArgb(50, 50, 50);
            removeButton.ForeColor = Color.White;
            removeButton.Top = this.Top;
            removeButton.Left = this.Right-23;
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


            //Creating the panel that sits on below of the top buttons
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
            displayName.BackColor = Color.Transparent;
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

        //Will be called when we want to dispose a button
        public void UnsbscribeFromAllEvents() 
        {

            displayName.Click -= displayName_Click;
            removeButton.Click -= removeButton_Click;
            editButton.Click -= editButton_Click;
            this.Click -= LinkButton_Click;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            //Removing all event handlers before disposing the button
            UnsbscribeFromAllEvents();

            this.Parent.Controls.Remove(this); //removing LinkButton from the FlowLayoutPanel and then Disposing it
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


        public void ChangeBackgroundImage(string imagePath)
        {
            this.imagePath = imagePath;

            if (String.IsNullOrWhiteSpace(imagePath))
                return;

            try
            {
                //Disposing the old background image if exists.
                if (this.BackgroundImage != null)
                    this.BackgroundImage.Dispose();



                //Changing the background image
                this.BackgroundImage = ResizedImageFromPath(imagePath, new Size(this.Width,this.Height)); //main panel extends behind some controls so users need to follow the template. Otherwise the image won't be displayed correctly
                this.BackgroundImageLayout = ImageLayout.Zoom;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine("Exception: " + e.Message + " when trying to find iamge link");
                Console.WriteLine("Path for image: " + imagePath +" might not exist");

                string messageBoxMessage = "Could not find specified image path. Please ensure that there is an image at location: " +imagePath +"\n"
                    +"This error can be fixed by leaving the image path field empty.";

                MessageBox.Show(messageBoxMessage, "Incorrect image path", MessageBoxButtons.OK);
            }
        }

        //Resizing the image specified by a path to a given size.
        public static Image ResizedImageFromPath(string imagePath, Size size)
        {
            Image myOrignialImage = new Bitmap(imagePath);
            return (Image)(new Bitmap(myOrignialImage,size));
        }


        // Opens link in default browser or launches the desired application
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
                        "\nPlease edit or delete and recreate the problematic button.";
                    MessageBox.Show(messageBoxMessage, "Link is missing", MessageBoxButtons.OK);
                    return;
                }

                throw;
            }
        }
    }
}
