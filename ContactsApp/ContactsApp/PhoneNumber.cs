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
                    throw new ArgumentException("The number must start with 7!");
                }

                if (value.ToString().Length != 11)
                {
                    throw new ArgumentException("The number must be 11 digits!");
                }
                _number = value;
            }
           
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PhoneNumber() { }


        public bool Equals(PhoneNumber other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _number == other._number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((PhoneNumber)obj);
        }

        public override int GetHashCode()
        {
            return _number.GetHashCode();
        }
    }
}
