using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using ContactsApp;

namespace ContactsAppUI
{
    /// <summary>
    /// Класс редактирования и добавления контактов
    /// </summary>
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Для некорректного значения TextBox
        /// </summary>
        public static readonly Color IncorrectValue = Color.DarkSalmon;

        /// <summary>
        /// Для корректного значения TextBox
        /// </summary>
        public static readonly Color CorrectValue = Color.White;

        /// <summary>
        /// Поле, хранящее контакт
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Загрузка формы
        /// </summary>
        public Contact Contact
        {
            get => _contact; 
            set
            {
                _contact = value;
                if (_contact == null) 
                {
                    return;
                }
                NameTextBox.Text = _contact.Name;
                SurnameTextBox.Text = _contact.Surname;
                DateBirthDay.Value = _contact.Birthday;
                PhoneTextBox.Text = _contact.PhoneNumber.Number.ToString();
                EmailTextBox.Text = _contact.Email;
                VKTextBox.Text = _contact.IDVk;
            }
        }

        /// <summary>
        /// Инициализирует все компоненты
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Проверка на ввод фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurnameTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = CorrectValue;
            }
           catch (Exception exception)
            {
                Console.WriteLine(exception);
                SurnameTextBox.BackColor = IncorrectValue;
            }
        }

        /// <summary>
        /// Реакция нажатие кнопки OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            string inputError = "Error list:\n";

            if ((SurnameTextBox.BackColor == IncorrectValue) || (SurnameTextBox.Text == ""))
            {
                inputError = inputError + "incorrect surname.\n";
            }

            if ((NameTextBox.BackColor == IncorrectValue) || (NameTextBox.Text == ""))
            {
                inputError = inputError + "incorrect name.\n";
            }

            if (DateBirthDay.BackColor == IncorrectValue)
            {
                inputError = inputError + "incorrect date.\n";
            }

            if ((PhoneTextBox.BackColor == IncorrectValue) || (PhoneTextBox.Text == ""))
            {
                inputError = inputError + "incorrect phone.\n";
            }

            if ((EmailTextBox.BackColor == IncorrectValue) || (EmailTextBox.Text == ""))
            {
                inputError = inputError + "incorrect e-mail.\n";
            }

            if ((VKTextBox.BackColor == IncorrectValue) || (VKTextBox.Text == ""))
            {
                inputError = inputError + "incorrect vk.com.";
            }

            if (inputError != "Error list:\n")
            {
                MessageBox.Show(inputError, @"Error");
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Реакция на нажатие кнопки Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _contact = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Проверка ввода имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextBox.Text;
                NameTextBox.BackColor = CorrectValue;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                NameTextBox.BackColor = IncorrectValue;
            }
        }

        /// <summary>
        /// Проверка ввода даты рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateBirthDay_Leave(object sender, EventArgs e)
        {
            DateBirthDay.BackColor = CorrectValue;
            try
            {
                _contact.Birthday = DateBirthDay.Value;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                DateBirthDay.BackColor = IncorrectValue;
                DateBirthDay.Invalidate();
            }
        }

        /// <summary>
        /// Проверка на ввод номера телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = CorrectValue;

            if ((PhoneTextBox.Text.All(char.IsDigit)) && (PhoneTextBox.Text != ""))
            {
                try
                {
                    PhoneNumber value = new PhoneNumber();
                    value.Number = long.Parse(PhoneTextBox.Text);
                    _contact.PhoneNumber = value;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception);
                    PhoneTextBox.BackColor = IncorrectValue;
                }
            }
            else
            {
                PhoneTextBox.BackColor = IncorrectValue;
            }
        }

        /// <summary>
        ///  Проверка на ввод почты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = CorrectValue;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                EmailTextBox.BackColor = IncorrectValue;
            }
        }

        private void VKTextBox_Leave(object sender, EventArgs e)
        {
            VKTextBox.BackColor = CorrectValue;
            try
            {
                _contact.IDVk = VKTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception);
                VKTextBox.BackColor = IncorrectValue;
            }
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            _contact.Birthday = DateBirthDay.Value;
        }
    }
}
