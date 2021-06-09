using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс контактов 
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия
        /// </summary> 
        private string _surname;

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        ///<summary>
        /// Номер телефона
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

        ///<summary>
        /// Дата рождения
        /// </summary>
        private DateTime _birthday;

        ///<summary>
        /// e-mail 
        /// </summary>
        private string _email;

        ///<summary>
        /// ID Вконтакте
        /// </summary>
        private string _IDvk;

        /// <summary>
        /// Свойства фамилии контакта с проверкой на длину 
        /// и заглавную букву в начале
        /// </summary>
        public string Surname
        {
            get { return _surname; }

            set
            {
                AssetLength(value, 50);
                _surname = value.ToUpper()[0] + value.Substring(1);
            }
        }

        /// <summary>
        /// Свойства имени контакта с проверкой на длину 
        /// и заглавную букву в начале
        /// </summary>
        public string Name
        {
            get { return _name; }

            set
            {
                AssetLength(value, 50);
                _name = value.ToUpper()[0] + value.Substring(1);
            }
        }

        /// <summary>
        /// Свойства email контакта с проверкой на длину
        /// </summary>
        public string Email
        {
            get { return _email; }

            set 
            { 
                AssetLength(value, 50);
                if(!value.Contains("@"))
                {
                    throw new ArgumentException("E-mail must contains @.");
                }
                _email = value;
            }

        }

        /// <summary>
        /// Свойства ID вконтакте вместе с проверкой на длину
        /// </summary>
        public string IDVk
        {
            get { return _IDvk; }
            
            set
            {
                AssetLength(value, 15);
                _IDvk = value;
            }
        }

        /// <summary>
        /// Свойства день рождения с проверкой даты
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }

            set
            {
                DateTime today = DateTime.Now;

                if (value.Year < 1900 || value.Date > today || value == null)
                {
                    throw new ArgumentException(" Исправьте дату рождения ");
                }
                _birthday = value;
            }
        }

        /// <summary>
        /// Проверка длины передаваемой строки на допустимый размер
        /// </summary>
        /// <param name="str">Принимаемая строка</param>
        /// <param name="length"">длина строки</param>
        void AssetLength (string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Ошибка. Пустая строка");
            }
            if (str.Length > length)
            {
                throw new ArgumentException("Длина не должна превышать " + length + "символов");
            }

        }

        /// <summary>
        /// конструктор класса по умолчанию
        /// </summary>
        public Contact() { }

        /// <summary>
        /// Конструктор контакта
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="email">Email</param>
        /// <param name="IdVk">ID вконтакте</param>
        /// <param name="birthday">День рождения</param>
        public Contact(PhoneNumber phoneNumber, string surname, string name, string email, 
                       string IdVk, DateTime birthday)
        {
            PhoneNumber = phoneNumber;
            Surname = surname;
            Name = name;
            Email = email;
            IDVk= IdVk;
            Birthday = birthday;
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }      
}
