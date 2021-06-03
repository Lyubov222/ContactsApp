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
        /// Переменная хранящая путь к сохранению файла сериализации
        /// </summary>
        public static string DefaultFilename
        {
            get
            {
                var appDataFolder =
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var defaultFileName = appDataFolder + $@"\Lyubov222\ContactsApp\project.json";
                return defaultFileName;
            }
        }
        /// <summary>
        /// Сохранение данных  в JSON-файл
        /// </summary>
        /// <param name="project">сериализуемый объект(список контактов)</param>
        /// <param name="fileName">Имя сохраняемого файла</param>
        public static void SaveToFile(Project project, string path, string fileName)
        {
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (var sw = new StreamWriter(path + fileName))
            using (var writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }
        /// <summary>
        /// Считывание данных контактов из файла
        /// Файл берется из папки "Мои документы"
        /// </summary>
        /// <param name="fileName">Имя JSON-файла с данными</param>
        public static Project LoadFromFile(string path, string fileName)
        {
            if (!File.Exists(path + fileName))
            {
                return new Project();
            }

            var serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            try
            {
                using (var sr = new StreamReader(path + fileName))
                using (var reader = new JsonTextReader(sr))
                {
                    var project = serializer.Deserialize<Project>(reader);
                    return project ?? new Project(); // ?? возвращает значение своего операнда слева, если его значение не равно null
                }
            }
            catch
            {
                return new Project();
            }
        }

    }
}
