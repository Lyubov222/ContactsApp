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
        /// <summary>
        /// Поле хранящее список контактов
        /// </summary>
        private Project _project;

        /// <summary>
        /// Обновленный список контактов, удовлетворяющих условиям поиска
        /// </summary>
        private List<Contact> _findedContacts = new List<Contact>();

        /// <summary>
        /// Переменная, хранящая путь
        /// </summary>
        private string _defaultFileName = ProjectManager.DefaultFilename;

        /// <summary>
        /// Инициализирует все компоненты, загружает информацию по контактам
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFromFile(_defaultFileName);
            _project.SortList();
            CheckBirthdayToday();
            /* PhoneNumber phone = new PhoneNumber
             {
                 Number = 79617444824
             };
             Contact contact1 = new Contact(phone, "Pan", "Luba", "PPPP", "id2343", new DateTime(2000, 3, 19));
             Project project = new Project();
             project.Contacts.Add(contact1);
             string path = System.IO.Path.Combine(ProjectManager.DevelopPath + ProjectManager.FileName);
             ProjectManager.SaveToFile(project, path);
             project = ProjectManager.LoadFromFile(path);*/

        }

        /// <summary>
        /// Формирует список именинников
        /// </summary>
        private void CheckBirthdayToday()
        {
            var listBirthday = _project.GetListBirthday();
            if (listBirthday != "")
            {
                BirthdayPanel.Visible = true;
                BirthDateLabel.Text = "Сегодня день рождения: ";
                var birthdayLabelText = listBirthday;
                BirthDateLabel.Text += birthdayLabelText;
            }
            else
            {
                BirthdayPanel.Visible = false;
            }
        }

        /// <summary>
        /// Отображает информацию о контактах в полях формы
        /// </summary>
        private void IsCorrectContent()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                var contact = FindTextBox.Text == String.Empty
                    ? _project.Contacts[selectedIndex]
                    : _findedContacts[selectedIndex];

                NameTextBox.Text = contact.Name;
                SurnameTextBox.Text = contact.Surname;
                DateBirthDay.Value = contact.Birthday;
                EmailTextBox.Text = contact.Email;
                VKTextBox.Text = contact.IDVk;
                PhoneTextBox.Text = contact.PhoneNumber.Number.ToString();
            }
            else
            {
                NameTextBox.Text = "";
                SurnameTextBox.Text = "";
                DateBirthDay.Value = DateTime.Today;
                EmailTextBox.Text = "";
                VKTextBox.Text = "";
                PhoneTextBox.Text = "";
            }
        }

        /// <summary>
        /// Корректирует данные в ListBox и полях формы
        /// </summary>
        private void UpdateData()
        {
            _project.SortList();
            ClearData();
            foreach (var t in _project.Contacts)
            {
                ContactsListBox.Items.Add(t.Surname);
                _findedContacts.Add(t);
            }
            IsCorrectContent();
            CheckBirthdayToday();
            SaveToFile();
        }

        /// <summary>
        /// Удаляет все элементы из ListBox и списка контактов, удовлетворяющих условиям поиска
        /// </summary>
        private void ClearData()
        {
            ContactsListBox.Items.Clear();
            _findedContacts.Clear();
        }

        /// <summary>
        /// Сохраняет данные в файл
        /// </summary>
        private void SaveToFile()
        {
            ProjectManager.SaveToFile(_project, _defaultFileName);
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        private void DeleteContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            var updatedIndex = _findedContacts[selectedIndex];
            if (selectedIndex < 0)
            {
                return;
            }
            var result = MessageBox.Show("Are you sure you want to delete " +
                                         updatedIndex.Surname +
                                         " from your contact list?", "Delete contact",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result != DialogResult.OK)
            {
                return;
            }
            _project.Contacts.RemoveAt(_project.Contacts.IndexOf(updatedIndex));
            ContactsListBox.Items.RemoveAt(selectedIndex);
            IsCorrectContent();
            CheckBirthdayToday();
            SaveToFile();
        }

        /// <summary>
        /// Метод добавления контакта 
        /// </summary>
        private void AddContact()
        {
            if (FindTextBox.Text.Length != 0)
            {
                return;
            }
            var form = new ContactForm();
            form.ShowDialog();
            if (form.Contact == null)
            {
                return;
            }
            _project.Contacts.Add(form.Contact);
            UpdateData();
            _project.SortList();
        }

        /// <summary>
        /// Метод редактирования контакта 
        /// </summary>
        private void EditContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }
            var form = new ContactForm
            {
                Contact = _findedContacts[selectedIndex]
            };
            form.ShowDialog();
            if (form.Contact == null)
            {
                return;
            }
            _project.Contacts[_project.Contacts.
                IndexOf(_findedContacts[selectedIndex])] = form.Contact;
            _findedContacts[selectedIndex] = form.Contact;
            UpdateData();
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

        /// <summary>
        /// Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Добарление контакта через ToolStripMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }


        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }
}
