namespace EzLaunchr
{
    partial class EditButtonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditButtonForm));
            this.applyEditButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.editLinkTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editImageTextBox = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // applyEditButton
            // 
            this.applyEditButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.applyEditButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.applyEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyEditButton.ForeColor = System.Drawing.Color.White;
            this.applyEditButton.Location = new System.Drawing.Point(67, 200);
            this.applyEditButton.Name = "applyEditButton";
            this.applyEditButton.Size = new System.Drawing.Size(80, 30);
            this.applyEditButton.TabIndex = 9;
            this.applyEditButton.Text = "Apply";
            this.applyEditButton.UseVisualStyleBackColor = false;
            this.applyEditButton.Click += new System.EventHandler(this.applyEditButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Link or full file path";
            // 
            // editDescriptionTextBox
            // 
            this.editDescriptionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.editDescriptionTextBox.ForeColor = System.Drawing.Color.White;
            this.editDescriptionTextBox.Location = new System.Drawing.Point(24, 103);
            this.editDescriptionTextBox.Multiline = true;
            this.editDescriptionTextBox.Name = "editDescriptionTextBox";
            this.editDescriptionTextBox.Size = new System.Drawing.Size(170, 30);
            this.editDescriptionTextBox.TabIndex = 6;
            this.editDescriptionTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.editDescriptionTextBox_MouseDoubleClick);
            // 
            // editLinkTextBox
            // 
            this.editLinkTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.editLinkTextBox.ForeColor = System.Drawing.Color.White;
            this.editLinkTextBox.Location = new System.Drawing.Point(24, 45);
            this.editLinkTextBox.Multiline = true;
            this.editLinkTextBox.Name = "editLinkTextBox";
            this.editLinkTextBox.Size = new System.Drawing.Size(170, 30);
            this.editLinkTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Image path";
            // 
            // editImageTextBox
            // 
            this.editImageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.editImageTextBox.ForeColor = System.Drawing.Color.White;
            this.editImageTextBox.Location = new System.Drawing.Point(24, 161);
            this.editImageTextBox.Multiline = true;
            this.editImageTextBox.Name = "editImageTextBox";
            this.editImageTextBox.Size = new System.Drawing.Size(170, 30);
            this.editImageTextBox.TabIndex = 10;
            // 
            // EditButtonForm
            // 
            this.AcceptButton = this.applyEditButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(214, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.editImageTextBox);
            this.Controls.Add(this.applyEditButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editDescriptionTextBox);
            this.Controls.Add(this.editLinkTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(230, 300);
            this.MinimumSize = new System.Drawing.Size(230, 300);
            this.Name = "EditButtonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Button";
            this.Load += new System.EventHandler(this.EditButtonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyEditButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editDescriptionTextBox;
        private System.Windows.Forms.TextBox editLinkTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox editImageTextBox;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}