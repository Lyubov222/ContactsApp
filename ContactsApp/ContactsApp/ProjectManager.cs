using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ContactsApp
{
    /// <summary>
    /// Класс сериализации
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Serializer
        /// </summary>
        private static readonly JsonSerializer _serializ = new JsonSerializer();

        /// <summary>
        /// Путь до папки "AppData" пользователя
        /// </summary>
        public static readonly string DevelopPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                                             @"\Lyubov222\ContactsApp\";
        public static readonly string FileName = @"project.json";

        /// <summary>
        /// Сохранение данных  в JSON-файл
        /// </summary>
        /// <param name="project">сериализуемый объект(список контактов)</param>
        /// <param name="fileName">Имя сохраняемого файла</param>
        public static void SaveToFile(Project project, string fileName)
        {
            DirectoryInfo path = new DirectoryInfo (System.IO.Path.GetDirectoryName(fileName));

            if (!path.Exists)
            {
                path.Create();
            }

            using (StreamWriter sw = new StreamWriter(fileName)) //класс запись файлов
            using (JsonWriter writer = new JsonTextWriter(sw)) 
            {
                _serializ.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Считывание данных контактов из файла
        /// Файл берется из папки "Мои документы"
        /// </summary>
        /// <param name="fileName">Имя JSON-файла с данными</param>
        public static Project LoadFromFile(string fileName)
        {
            DirectoryInfo path = new DirectoryInfo(System.IO.Path.GetDirectoryName(fileName));

            if (!path.Exists)
            {
                return new Project();
            }

            if (!File.Exists(fileName))
            {
                return new Project();
            }

            Project project = null;
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    project = (Project)_serializ.Deserialize<Project>(reader);
                }

                if (project == null)
                {
                    return new Project();
                }
            }
            catch (Exception e)
            {
                return new Project();
            }

            return project;
        }

    }
}
