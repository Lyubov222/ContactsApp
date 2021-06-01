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
            return SurnameTextBox.Text != null &&
                   NameTextBox.Text != null &&
                   _isCorrectContact != false &&
                   PhoneTextBox.Text.Length == 11 &&
                   NameTextBox.Text != string.Empty &&
                   SurnameTextBox.Text != string.Empty;
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {

        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SurnameLabel_Click(object sender, EventArgs e)
        {
            var check = SurnameTextBox.Text.Length >= 50;
            for (var i=0; i<SurnameTextBox.TextLength; i++)
            {
                
            }
        }

        /// <summary>
        /// Реакция нажатия книпки OK
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

    }
}
