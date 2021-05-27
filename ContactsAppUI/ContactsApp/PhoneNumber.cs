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
        private int _number;

        ///<summary>
        ///Требования к номеру телефона
        ///<summary>
       public int Numbers
        {
            get { return _number; }
            set
            {
                if (!Numbers.ToString().StartsWith("7"))
                {
                    throw new ArgumentException("Номер должен начинаться с 7!");
                }

                if (Numbers.ToString().Length != 11)
                {
                    throw new ArgumentException("Номер должен состоять из 11 цифр!");
                }
            }
           
        }
    }
}
