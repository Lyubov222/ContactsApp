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
                AssertLength(value, 50);
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
                AssertLength(value, 50);
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
                AssertLength(value, 50);
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
                AssertLength(value, 15);
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
                    throw new ArgumentException(" Correct your date of birth ");
                }
                _birthday = value;
            }
        }

        /// <summary>
        /// Проверка длины передаваемой строки на допустимый размер
        /// </summary>
        /// <param name="str">Принимаемая строка</param>
        /// <param name="length"">длина строки</param>
        void AssertLength (string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Error. Empty line");
            }
            if (str.Length > length)
            {
                throw new ArgumentException("Length should not exceed " + length + "characters");
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
        public Contact(string name, string surname, string email, string IdVk,
            DateTime birthday, PhoneNumber phoneNumber)
        {
            this.Birthday = birthday;
            this.Email = email;
            this.IDVk = IdVk;
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
        }

        public bool Equals(Contact other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _surname == other._surname
                   && _name == other._name
                   && _email == other._email
                   && _birthday.Equals(other._birthday)
                   && _IDvk == other._IDvk
                   && Equals(PhoneNumber, other.PhoneNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Contact)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_surname != null ? _surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_email != null ? _email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _birthday.GetHashCode();
                hashCode = (hashCode * 397) ^ (_IDvk != null ? _IDvk.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        /// Метод для реализации интерфейса IComporable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Contact other)
        {
            return other == null ? 1 : String.Compare(_surname, other._surname, StringComparison.Ordinal);
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
