
namespace ContactsAppUI
{
    partial class AboutForm
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
            this.ContactsAppLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AuthorAboutLabel = new System.Windows.Forms.Label();
            this.EmailAoutLabel = new System.Windows.Forms.Label();
            this.EmailLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GitHubLabel = new System.Windows.Forms.Label();
            this.GitHubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.AuthorAbout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContactsAppLabel
            // 
            this.ContactsAppLabel.AutoSize = true;
            this.ContactsAppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.ContactsAppLabel.Location = new System.Drawing.Point(26, 33);
            this.ContactsAppLabel.Name = "ContactsAppLabel";
            this.ContactsAppLabel.Size = new System.Drawing.Size(146, 25);
            this.ContactsAppLabel.TabIndex = 0;
            this.ContactsAppLabel.Text = "ContactsApp";
            this.ContactsAppLabel.Click += new System.EventHandler(this.ContactsAppLabel_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(28, 67);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(43, 13);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "v. 1.0.0";
            this.VersionLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // AuthorAboutLabel
            // 
            this.AuthorAboutLabel.AutoSize = true;
            this.AuthorAboutLabel.Location = new System.Drawing.Point(28, 130);
            this.AuthorAboutLabel.Name = "AuthorAboutLabel";
            this.AuthorAboutLabel.Size = new System.Drawing.Size(101, 13);
            this.AuthorAboutLabel.TabIndex = 2;
            this.AuthorAboutLabel.Text = "Author: Lyubov Pan";
            // 
            // EmailAoutLabel
            // 
            this.EmailAoutLabel.AutoSize = true;
            this.EmailAoutLabel.Location = new System.Drawing.Point(28, 180);
            this.EmailAoutLabel.Name = "EmailAoutLabel";
            this.EmailAoutLabel.Size = new System.Drawing.Size(100, 13);
            this.EmailAoutLabel.TabIndex = 3;
            this.EmailAoutLabel.Text = "e-mail for feedback:";
            // 
            // EmailLinkLabel
            // 
            this.EmailLinkLabel.AutoSize = true;
            this.EmailLinkLabel.Location = new System.Drawing.Point(134, 180);
            this.EmailLinkLabel.Name = "EmailLinkLabel";
            this.EmailLinkLabel.Size = new System.Drawing.Size(124, 13);
            this.EmailLinkLabel.TabIndex = 4;
            this.EmailLinkLabel.TabStop = true;
            this.EmailLinkLabel.Text = "lyubov.pan2000@mail.ru";
            // 
            // GitHubLabel
            // 
            this.GitHubLabel.AutoSize = true;
            this.GitHubLabel.Location = new System.Drawing.Point(28, 210);
            this.GitHubLabel.Name = "GitHubLabel";
            this.GitHubLabel.Size = new System.Drawing.Size(46, 13);
            this.GitHubLabel.TabIndex = 5;
            this.GitHubLabel.Text = "Git Hub:";
            // 
            // GitHubLinkLabel
            // 
            this.GitHubLinkLabel.AutoSize = true;
            this.GitHubLinkLabel.Location = new System.Drawing.Point(80, 210);
            this.GitHubLinkLabel.Name = "GitHubLinkLabel";
            this.GitHubLinkLabel.Size = new System.Drawing.Size(219, 13);
            this.GitHubLinkLabel.TabIndex = 6;
            this.GitHubLinkLabel.TabStop = true;
            this.GitHubLinkLabel.Text = "https://github.com/Lyubov222/ContactsApp";
            this.GitHubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkLabel_LinkClicked);
            // 
            // AuthorAbout
            // 
            this.AuthorAbout.AutoSize = true;
            this.AuthorAbout.Location = new System.Drawing.Point(12, 320);
            this.AuthorAbout.Name = "AuthorAbout";
            this.AuthorAbout.Size = new System.Drawing.Size(103, 13);
            this.AuthorAbout.TabIndex = 7;
            this.AuthorAbout.Text = "2021 Lyubov Pan ©";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 341);
            this.Controls.Add(this.AuthorAbout);
            this.Controls.Add(this.GitHubLinkLabel);
            this.Controls.Add(this.GitHubLabel);
            this.Controls.Add(this.EmailLinkLabel);
            this.Controls.Add(this.EmailAoutLabel);
            this.Controls.Add(this.AuthorAboutLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ContactsAppLabel);
            this.MaximumSize = new System.Drawing.Size(410, 380);
            this.MinimumSize = new System.Drawing.Size(410, 380);
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ContactsAppLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AuthorAboutLabel;
        private System.Windows.Forms.Label EmailAoutLabel;
        private System.Windows.Forms.LinkLabel EmailLinkLabel;
        private System.Windows.Forms.Label GitHubLabel;
        private System.Windows.Forms.LinkLabel GitHubLinkLabel;
        private System.Windows.Forms.Label AuthorAbout;
    }
}