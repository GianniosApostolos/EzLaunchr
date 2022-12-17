namespace EzLaunchr
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OpenAllButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.createPanelButton = new System.Windows.Forms.Button();
            this.saveloadPanel = new System.Windows.Forms.Panel();
            this.saveXmlButton = new System.Windows.Forms.Button();
            this.loadXmlButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel.SuspendLayout();
            this.saveloadPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenAllButton
            // 
            this.OpenAllButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.OpenAllButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenAllButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OpenAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenAllButton.ForeColor = System.Drawing.Color.White;
            this.OpenAllButton.Location = new System.Drawing.Point(0, 0);
            this.OpenAllButton.MinimumSize = new System.Drawing.Size(80, 55);
            this.OpenAllButton.Name = "OpenAllButton";
            this.OpenAllButton.Size = new System.Drawing.Size(700, 100);
            this.OpenAllButton.TabIndex = 8;
            this.OpenAllButton.Text = "Open all links";
            this.OpenAllButton.UseVisualStyleBackColor = false;
            this.OpenAllButton.Click += new System.EventHandler(this.OpenAllButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flowLayoutPanel.Controls.Add(this.createPanelButton);
            this.flowLayoutPanel.Controls.Add(this.saveloadPanel);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(700, 285);
            this.flowLayoutPanel.TabIndex = 9;
            // 
            // createPanelButton
            // 
            this.createPanelButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.createPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPanelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPanelButton.ForeColor = System.Drawing.Color.White;
            this.createPanelButton.Location = new System.Drawing.Point(3, 3);
            this.createPanelButton.MinimumSize = new System.Drawing.Size(80, 55);
            this.createPanelButton.Name = "createPanelButton";
            this.createPanelButton.Size = new System.Drawing.Size(115, 120);
            this.createPanelButton.TabIndex = 17;
            this.createPanelButton.Text = "Add link";
            this.createPanelButton.UseVisualStyleBackColor = true;
            this.createPanelButton.Click += new System.EventHandler(this.createPanelButton_Click);
            // 
            // saveloadPanel
            // 
            this.saveloadPanel.Controls.Add(this.saveXmlButton);
            this.saveloadPanel.Controls.Add(this.loadXmlButton);
            this.saveloadPanel.Location = new System.Drawing.Point(3, 129);
            this.saveloadPanel.Name = "saveloadPanel";
            this.saveloadPanel.Size = new System.Drawing.Size(115, 120);
            this.saveloadPanel.TabIndex = 20;
            // 
            // saveXmlButton
            // 
            this.saveXmlButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.saveXmlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveXmlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveXmlButton.ForeColor = System.Drawing.Color.White;
            this.saveXmlButton.Location = new System.Drawing.Point(0, 0);
            this.saveXmlButton.MinimumSize = new System.Drawing.Size(80, 30);
            this.saveXmlButton.Name = "saveXmlButton";
            this.saveXmlButton.Size = new System.Drawing.Size(115, 57);
            this.saveXmlButton.TabIndex = 18;
            this.saveXmlButton.Text = "Save File";
            this.saveXmlButton.UseVisualStyleBackColor = true;
            this.saveXmlButton.Click += new System.EventHandler(this.saveXmlButton_Click);
            // 
            // loadXmlButton
            // 
            this.loadXmlButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.loadXmlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadXmlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadXmlButton.ForeColor = System.Drawing.Color.White;
            this.loadXmlButton.Location = new System.Drawing.Point(0, 63);
            this.loadXmlButton.MinimumSize = new System.Drawing.Size(80, 30);
            this.loadXmlButton.Name = "loadXmlButton";
            this.loadXmlButton.Size = new System.Drawing.Size(115, 57);
            this.loadXmlButton.TabIndex = 19;
            this.loadXmlButton.Text = "Load File";
            this.loadXmlButton.UseVisualStyleBackColor = true;
            this.loadXmlButton.Click += new System.EventHandler(this.loadXmlButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.topPanel.Controls.Add(this.flowLayoutPanel);
            this.topPanel.Location = new System.Drawing.Point(12, 12);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(700, 285);
            this.topPanel.TabIndex = 10;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bottomPanel.Controls.Add(this.OpenAllButton);
            this.bottomPanel.Location = new System.Drawing.Point(13, 317);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(700, 100);
            this.bottomPanel.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(724, 431);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(80, 180);
            this.Name = "Form1";
            this.Text = "EzLaunchr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.flowLayoutPanel.ResumeLayout(false);
            this.saveloadPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OpenAllButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button createPanelButton;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        public System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button saveXmlButton;
        private System.Windows.Forms.Button loadXmlButton;
        private System.Windows.Forms.Panel saveloadPanel;
    }
}

