using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form 
    {
        public MainForm()
        {
            InitializeComponent();
            PhoneNumber phone = new PhoneNumber
            {
                Number = 79617444824
            };
            Contact contact1 = new Contact(phone, "Pan", "Luba", "PPPP", "id2343", new DateTime(2000, 3, 19));
            Project project = new Project();
            project.Contacts.Add(contact1);
            string path = System.IO.Path.Combine(ProjectManager.DevelopPath + ProjectManager.FileName);
            ProjectManager.SaveToFile(project, path);
            project = ProjectManager.LoadFromFile(path);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BirthdayLabel_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void AddContact()
        {
            if (FindTextBox.Text.Length != 0)
            {
                return;
            }
            var form = new ContactForm();

        }
            
    }
}
