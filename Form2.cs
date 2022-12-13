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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Opacity = (double)Settings.Default["FormOpacity"];
            opacitySlider.Value = (int)Settings.Default["OpacitySliderPosition"];
        }


        private void addEntryButton_Click(object sender, EventArgs e)
        {
            LinkButton buttonToAdd = new LinkButton(linkTextBox.Text, descriptionTextBox.Text);
            Form1.form1.flowLayoutPanel.Controls.Add(buttonToAdd);
        }

        private void opacitySlider_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (opacitySlider.Value / 10f);

            Settings.Default["FormOpacity"] = this.Opacity;
            Settings.Default["OpacitySliderPosition"] = opacitySlider.Value;
        }
    }
}
