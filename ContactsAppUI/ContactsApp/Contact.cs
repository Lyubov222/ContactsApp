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
        public PhoneNumber PhoneNumber { get; set; }

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
                CheckingLength(Surname, 50);
                Surname = Surname.ToUpper()[0] + Surname.Substring(1);
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
                CheckingLength(Name, 50);
                Name = Name.ToUpper()[0] + Name.Substring(1);
            }
        }

        /// <summary>
        /// Свойства email контакта с проверкой на длину
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { CheckingLength(Email, 50); }

        }

        /// <summary>
        /// Свойства ID вконтакте вместе с проверкой на длину
        /// </summary>
        public string IDVk
        {
            get { return _IDvk; }
            
            set
            {
                CheckingLength(IDVk, 15);
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
                if (Birthday.Year < 1900 || Birthday.Date > today || Birthday == null)
                {
                    throw new ArgumentException(" Исправьте дату рождения");
                }
            }
        }

        /// <summary>
        /// Проверка длины передаваемой строки на допустимый размер
        /// </summary>
        /// <param name="str">Принимаемая строка</param>
        /// <param name="availableLength"">Допустимая длина строки</param>
        void CheckingLength (string str, int availableLength)
        {
            if (str.Length>availableLength)
            {
                throw new ArgumentException("Длина не должна превышать " + availableLength + "символов");
            }
        }

        /// <summary>
        /// Конструктор контакта
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="email">Email</param>
        /// <param name="IdVk">ID вконтакте</param>
        /// <param name="birthday">День рождения</param>
        public Contact(PhoneNumber phoneNumber, string surname, string name, string email, string IdVk, DateTime birthday)
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
