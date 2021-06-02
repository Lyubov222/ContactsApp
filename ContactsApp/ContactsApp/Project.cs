using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Список всех контактов 
    /// </summary>
    public class Project
    {
        ///<summary>
        /// Список контактов 
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Сортирует список контактов
        /// </summary>
        public void SortList()
        {
            Contacts.Sort();
        }

        /// <summary>
        /// Формирует список именинников
        /// </summary>
        /// <returns>Строка, состоящая из фамилий именинников через запятую</returns>
        public string GetListBirthday()
        {
            var listContacts = Contacts.Where(First => First.Birthday.Day == DateTime.Now.Day &&
                                                       First.Birthday.Month == DateTime.Now.Month);
            return string.Join(",", listContacts.Select(contact => contact.Surname).ToList());
        }

    }
}
