using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{ 
    /// <summary>
    /// Тестирование класса сериализации и десериализации
    /// </summary>
    [TestFixture]
    class ProjectManagerTest
    {
        /// <summary>
        /// путь к файлу 
        /// </summary>
        public string Location
        {
            get
            {
                var location = Assembly.GetExecutingAssembly().Location;
                location = Path.GetDirectoryName(location);
                location += "\\TestData\\";
                return location;
            }
        }

        /// <summary>
        /// Создание корректного проекта
        /// </summary>
        /// <returns></returns>
        private Project GetCorrectProject()
        {
            var project = new Project();
            PhoneNumber expectedphone = new PhoneNumber { Number = 79617444824 };
            var contact = new Contact(
                "Lyubov",
                "Pan",
                "lyubov.pan2000@mail.ru",
                "lisiza3322",
                new DateTime(2000, 3, 19),
                expectedphone);
            project.Contacts.Add(contact);

            expectedphone = new PhoneNumber { Number = 79138825183 };
            contact = new Contact(
                "Mariya",
                "Stepanova",
                "stepashka@mail.ru",
                "Id45632",
                new DateTime(2000, 6, 20),
                expectedphone);
            project.Contacts.Add(contact);
            return project;
        }

        [Test(Description = "Тест метода LoadFromFile")]
        public void ProjectManager_LoadCorrectData_FileLoadCorrected()
        {
            //SetUp
            var expectedProject = GetCorrectProject();

            //Act
            var actualProject = ProjectManager.LoadFromFile(Location, "correctproject.json");
            
            //Assert
            Assert.Multiple(() =>
            {

                for (int i = 0; i < expectedProject.Contacts.Count; i++)
                {
                    var expected = expectedProject.Contacts[i];
                    var actual = actualProject.Contacts[i];
                    Assert.AreEqual(expected, actual);
                }
            });
        }
         
        [TestCase(Description = "Негативный тест загрузки", TestName = "Загрузка некорректного файла")]
        public void ProjectManager_LoadIncorrectData_FileLoadIncorrectly()
        {
            //SetUp
            var expectedCount = 0;

            //Act
            var actualProject = ProjectManager.LoadFromFile(Location, "incorrectproject.json");

            //Assert
            Assert.IsNotNull(actualProject);            
            Assert.AreEqual(expectedCount, actualProject.Contacts.Count);
        }

        [TestCase(Description = "Негативный тест загрузки", TestName = "Загрузка пустого файла")]
        public void ProjectManager_LoadNullData_FileLoadIncorrectly()
        {
            //SetUp
            var expectedCount = 0;

            //Act
            var actualProject = ProjectManager.LoadFromFile("\\Lolol", "\\Lololo.json\\");

            //Assert
            Assert.IsNotNull(actualProject);
            Assert.AreEqual(expectedCount, actualProject.Contacts.Count);
        }

        [TestCase(Description = "", TestName = "Позитивный тест сохранения")]
        public void ProjectManager_SaveCorrectData_FileSaveCorrectly()
        {
            //SetUp
            var savingProject = GetCorrectProject();
            ProjectManager.SaveToFile(savingProject, Location, "SavedProjectFile.json");
            var expected = File.ReadAllText(Location + "correctproject.json");

            //Act
            var actual = File.ReadAllText(Location + "SavedProjectFile.json");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
