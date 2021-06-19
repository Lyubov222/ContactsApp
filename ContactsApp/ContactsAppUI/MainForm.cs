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
            _project = ProjectManager.LoadFromFile(_defaultFileName, "project.json");
            _project.SortList();
            FormListBirthday();
        }

        /// <summary>
        /// Формирует список именинников
        /// </summary>
        private void FormListBirthday()
        {
            var listBirthday = _project.GetListBirthday();
            if (listBirthday != "")
            {
                BirthdayPanel.Visible = true;
                BirthdayDayLabel.Text = "Сегодня день рождения: ";
                var birthdayLabelText = listBirthday;
                BirthdayDayLabel.Text += birthdayLabelText;
            }
            else
            {
                BirthdayPanel.Visible = false;
            }
        }

        /// <summary>
        /// Отображает информацию о контактах в полях формы
        /// </summary>
        private void DisplayInfortstion()
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
                ClearInfomationContact();
            }
        }

        /// <summary>
        /// Корректирует данные в ListBox и полях формы
        /// </summary>
        private void UpdateContactListBox() 
        {
            _project.SortList();
            ClearListBox();
            foreach (var t in _project.Contacts)
            {
                ContactsListBox.Items.Add(t.Surname);
                _findedContacts.Add(t);
            }
            DisplayInfortstion();
            FormListBirthday(); 
            SaveProject();
        }

        /// <summary>
        /// Удаляет все элементы из ListBox и списка контактов, удовлетворяющих условиям поиска
        /// </summary>
        private void ClearListBox() 
        {
            ContactsListBox.Items.Clear();
            _findedContacts.Clear();
        }

        /// <summary>
        /// Сохраняет данные в файл
        /// </summary>
        private void SaveProject()
        {
            ProjectManager.SaveToFile(_project, _defaultFileName, "project.json");
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
            DisplayInfortstion();
            FormListBirthday();
            SaveProject();
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
            var dialogResulte = form.ShowDialog();

            if (dialogResulte == DialogResult.OK)
            {
                _project.Contacts.Add(form.Contact);
                UpdateContactListBox();
                if(ContactsListBox.Items == null)
                {
                    return;
                }
                var index = 0;
                index = _findedContacts.IndexOf(form.Contact);
                if (_findedContacts.Count > index)
                {
                    ContactsListBox.SelectedIndex = index;
                    DisplayInfortstion();
                }
                else
                {
                    ClearInfomationContact();
                }
            }
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
            var selectedContact = _findedContacts[selectedIndex];
            var originalIndex = _project.Contacts.IndexOf(selectedContact);
            _project.Contacts[originalIndex] = form.Contact; 
            _findedContacts[selectedIndex] = form.Contact;
            UpdateContactListBox();
            var index = 0;
            index = _findedContacts.IndexOf(form.Contact);
            if (_findedContacts.Count > index)
            {
                ContactsListBox.SelectedIndex = index;
                DisplayInfortstion();
            }
            else
            {
                ClearInfomationContact();
       
            }
            FindTextBox.Text = "";
        }

        /// <summary>
        /// Отчищает информацию контакта
        /// </summary>
        private void ClearInfomationContact()
        {
            NameTextBox.Text = "";
            SurnameTextBox.Text = "";
            EmailTextBox.Text = "";
            VKTextBox.Text = "";
            PhoneTextBox.Text = "";
            DateBirthDay.Value = DateTime.Today;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateContactListBox();
            if(_findedContacts.Count > 0)
            {
                ContactsListBox.SelectedIndex = 0;
            }
            FormListBirthday();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
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
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearListBox();
            foreach (var t in _project.GetByNameOrSurname(FindTextBox.Text))
            {
                _findedContacts.Add(t);
                ContactsListBox.Items.Add(t.Surname);

            }
            DisplayInfortstion();
        }
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayInfortstion();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            DeleteContact();
        }
        private void DateBirthDay_ValueChanged(object sender, EventArgs e)
        {
            if(ContactsListBox.SelectedIndex == -1)
            {
                return;
            }
            DateBirthDay.Value = _findedContacts[ContactsListBox.SelectedIndex].Birthday;
        }

    }
}
