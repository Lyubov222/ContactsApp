using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{

    /// <summary>
    /// Класс номер телефона 
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private long _number;

        ///<summary>
        ///Требования к номеру телефона   
        ///<summary>
       public long Number
        {
            get { return _number; }
            set
            {
                if (!value.ToString().StartsWith("7"))
                {
                    throw new ArgumentException("Номер должен начинаться с 7!");
                }

                if (value.ToString().Length != 11)
                {
                    throw new ArgumentException("Номер должен состоять из 11 цифр!");
                }
                _number = value;
            }
           
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PhoneNumber() { }
    }
}
