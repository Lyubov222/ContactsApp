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
        public static readonly string _myPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                                                            "/Lyubov222/ContactsAppUI/ContactsApp";

        public static DirectoryInfo directoryInfo = new DirectoryInfo(_myPath);

        /// <summary>
        /// Сохранение данных  в JSON-файл
        /// </summary>
        /// <param name="project">сериализуемый объект(список контактов)</param>
        /// <param name="NameOfFile">Имя сохраняемого файла</param>
        public static void SaveToFile(Project project, string NameOfFile)
        {
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            using (StreamWriter sw = new StreamWriter(_myPath + @NameOfFile))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                _serializ.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Считывание данных контактов из файла
        /// Файл берется из папки "Мои документы"
        /// </summary>
        /// <param name="NameOfFile">Имя JSON-файла с данными</param>
        /// <returns></returns>
        public static Project LoadFromFile(string path, string NameOfFile)
        {
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                return new Project();
            }

            if (!File.Exists(path + NameOfFile))
            {
                return new Project();
            }

            Project project = null;
            try
            {
                using (StreamReader sr = new StreamReader(_myPath + @NameOfFile))
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
