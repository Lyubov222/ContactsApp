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
    }
}
