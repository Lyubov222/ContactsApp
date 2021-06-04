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
        private Contact _contact;

        /// <summary>
        /// Переменная для проверки корректного ввода всех TextBox
        /// </summary>
        private bool _isCorrectContact;

        /// <summary>
        /// Переменная, хранящая недопустимые для ввода всех TextBox
        /// </summary>
        string _inCorrectSymbols = @"123456789!@#$%^&*()_+|-+=\.,<>";

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
                PhoneTextBox.Text = _contact.PhoneNumber.ToString();
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
       /// Проверяет наличие некорректных данных ввода
       /// </summary>
       /// <returns> true - если есть некорректные данные, иначе false</returns>
        private bool IsContactValidated()
        {
            return SurnameTextBox.BackColor == IncorrectValue ||
                   NameTextBox.BackColor == IncorrectValue ||
                   BirthdayLabel.Text == String.Empty ||
                   PhoneTextBox.BackColor == IncorrectValue ||
                   VKTextBox.Text == "Error";
        }

        /// <summary>
        /// Проверяет все TextBox на наличие символов и корректность
        /// </summary>
        ///<returns> true - если проверка прошла успешно, иначе false </returns>
        private bool CheckTextBox()
        {
            return NameTextBox.Text != null &&
                   SurnameTextBox.Text != null && 
                   _isCorrectContact == false && 
                   PhoneTextBox.Text.Length == 11 && 
                   NameTextBox.Text != string.Empty && 
                   SurnameTextBox.Text != string.Empty;
        }

        /// <summary>
        /// Проверка на ввод фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurnameTextBox_Leave(object sender, EventArgs e)
        {
            var check = SurnameTextBox.Text.Length >= 50;
            for (var i=0; i< SurnameTextBox.TextLength; i++)
            {
                foreach (var t in _inCorrectSymbols.Where(t =>SurnameTextBox.Text[i]==t))
                {
                    check = true;
                }
            }
            SurnameTextBox.BackColor = check ? IncorrectValue : CorrectValue;
        }

        /// <summary>
        /// Реакция нажатие кнопки OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            _isCorrectContact = IsContactValidated();
            if (CheckTextBox())
            {
                _contact = new Contact
                {
                    PhoneNumber = new PhoneNumber(),
                    Surname = SurnameTextBox.Text,
                    Name = NameTextBox.Text,
                    Email = EmailTextBox.Text
                };
                _contact.PhoneNumber.Number = Convert.ToInt64(PhoneTextBox.Text);
                _contact.IDVk = VKTextBox.Text;
                _contact.Birthday = DateBirthDay.Value;
                Close();
            }
            else
            {
                MessageBox.Show("Check the values are correct and try again",
                    "", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Реакция на нажатие кнопки Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _contact = null;
            Close();
        }

        /// <summary>
        /// Проверка ввода имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            var check = NameTextBox.Text.Length >= 50;
            for (var i=0; i<NameTextBox.TextLength; i++)
            {
                foreach (var t in _inCorrectSymbols.Where(t => NameTextBox.Text[i] == t))
                {
                    check = true;
                }
            }
            NameTextBox.BackColor = check ? IncorrectValue : CorrectValue;
        }

        /// <summary>
        /// Проверка ввода даты рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateBirthDay_ValueChanged(object sender, EventArgs e)
        {
            if (DateBirthDay.Value.Year >= 1900 && DateBirthDay.Value <= DateTime.Now)
            {
                BirthdayLabel.Text = "Birthday";
                BirthdayLabel.ForeColor = Color.Black;
            }
            else
            {
                BirthdayLabel.Text = "Error";
                BirthdayLabel.ForeColor = IncorrectValue;
            }
        }

        /// <summary>
        /// Проверка на ввод номера телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_Leave(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = PhoneTextBox.Text.Length != 11 ? IncorrectValue : CorrectValue;
            if (PhoneTextBox.Text.StartsWith("7"))
            {
                return;
            }
            PhoneTextBox.BackColor = IncorrectValue;
        }

        /// <summary>
        ///  Проверка на ввод почты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            EmailTextBox.BackColor = EmailTextBox.Text.Contains("@") ? CorrectValue : IncorrectValue;
        }
    }
}
