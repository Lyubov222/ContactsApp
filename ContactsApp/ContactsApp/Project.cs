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
            Contacts = Contacts.OrderBy(t => t.Surname).ToList();
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

        /// <summary>
        /// Осуществляет поиск контактов
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Контакты содержащие подстроку</returns>
        public List<Contact> GetByNameOrSurname(string text)
        {
            text = text.ToLower();
            return Contacts.FindAll(First => First.Surname.ToLower().Contains(text) ||
                                             First.Name.ToLower().Contains(text));
        }

        public bool Equals(Project other)
        {
            return other != null && this.Contacts.Equals(other.Contacts);
        }
    }
}
