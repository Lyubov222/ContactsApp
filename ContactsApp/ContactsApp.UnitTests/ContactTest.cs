using NUnit.Framework;
using ContactsApp;
using System;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {

        [Test(Description = "Позитивный тест геттера Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            // SetUp
            var _testContact = new Contact();
            var expected = "Степанов";
            _testContact.Surname = expected;

            //Act
            var actual = _testContact.Surname;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }

        [Test(Description = "Позитивный тест сеттера Surname")]
        public void TestSurnameSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Surname = "Петров";

            //Act
            var actual = _testContact.Surname;

            //Assert
            Assert.AreEqual(actual, _testContact.Surname, "Сеттер неправильно заполнил фамилию");
        }

        [TestCase("", "Должно возникать исключение, если фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве фамилии")]
        [TestCase("Степанов-Степанов-Степанов-Степанов-Степанов-Степанов-Степанов-Степанов-Степанов-Степанов",
            "Должно возникать исключение, если фамилия длиннее 50 символов",
            TestName = "Присвоение неправильной фамилии больше 50 символов")]

        [Test(Description = "Негативный тест геттера Surname")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            //SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testContact.Surname = wrongSurname; },
                message);
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void TestNameGet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            var expected = "Степан";
            _testContact.Name = expected;

            //Act
            var actual = _testContact.Name;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }

        [Test(Description = "Позитивный тест сеттера Name")]
        public void TestNameSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Name = "Степан";

            //Act
            var actual = _testContact.Name;

            //Assert
            Assert.AreEqual(actual, _testContact.Name, "Сеттер неправильно заполнил имя");
        }

        [TestCase("", "Должно возникать исключение, если имя - пустая строка",
                   TestName = "Присвоение пустой строки в качестве имени")]
        [TestCase("Степан-Степан-Степан-Степан-Степан-Степан-Степан-Степан-Степан-Степан",
                   "Должно возникать исключение, если имя длиннее 50 символов",
                   TestName = "Присвоение неправильного имени больше 50 символов")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            //SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
            () => { _testContact.Name = wrongName; },
            message);
        }

        [Test(Description = "Позитивный тест геттера Email")]
        public void TestMailGet_CorrectValue()
        {
            //SetUP
            var _testContact = new Contact();
            var expected = "lyubov.pan2000@mail.ru";
            _testContact.Email = expected;

            //Act
            var actual = _testContact.Email;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер Email возвращает неправильную почту");
        }

        [Test(Description = "Позитивный тест сеттера Email")]
        public void TestMailSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Email = "lyubov.pan2000@mail.ru";

            //Act
            var actual = _testContact.Email;

            //Assert
            Assert.AreEqual(actual, _testContact.Email, "Сеттер неправильно заполнил почту");
        }

        [TestCase("",
         "Должно возникать исключение, если Email - пустая строка",
         TestName = "Присвоение пустой строки в качестве почты")]
        [TestCase("12345678901234567890123456789012345689012345678901234567890@mail.ru",
         "Должно возникать исключение, если почта больше 50 символов",
         TestName = "Присвоение неправильной почты больше 50 символов")]
        public void TestMailSet_ArgumentException(string wrongEmail, string message)
        {
            //?SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testContact.Email = wrongEmail; },
                message);
        }

        [Test(Description = "Позитивный тест геттера IDVk")]
        public void TestIdVkGet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            var expected = "id777777";
            _testContact.IDVk = expected;

            //Act
            var actual = _testContact.IDVk;

            //Assert
            Assert.AreEqual(expected, actual, "Геттер IDVk возвращает неправильный  idvk");
        }

        [Test(Description = "Позитивный тест сеттера IDVk")]
        public void TestIdVkSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.IDVk = "abracadab.id";

            //Act
            var actual = _testContact.IDVk;

            //Assert
            Assert.AreEqual(actual, _testContact.IDVk, "Сеттер неправильно заполнил idVk");
        }

        [TestCase("",
           "Должно возникать исключение, если IDVk - пустая строка",
           TestName = "Присвоение пустой строки в качестве IDVk")]
        [TestCase("id12345678901234567890",
           "Должно возникать исключение, если IDVk > 15 символов",
           TestName = "Присвоение неправильной даты больше текущей")]
        public void TestIdVKSet_ArgumentException(string wrongIdVk, string message)
        {
            //SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testContact.IDVk = wrongIdVk; },
                message);
        }

        [Test(Description = "Позитивный тест геттера BirthDay")]
        public void TestDateGet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            DateTime expected = new DateTime(2000, 8, 30);
            _testContact.Birthday = expected;

            //Act
            var actual = _testContact.Birthday;

            //Assert
            Assert.AreEqual(expected.Year, actual.Year, "Геттер BirthDay возвращает неправильную дату");
        }

        [Test(Description = "Позитивный тест сеттера BirthDay")]
        public void TestDateSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Birthday = new DateTime(2000, 5, 20);

            //Act
            var actual = _testContact.Birthday;

            //Assert
            Assert.AreEqual(actual, _testContact.Birthday, "Сеттер неправильно заполнил дату");
        }

        [TestCase("1899, 1, 5",
            "Должно возникать исключение, если год меньше 1900",
            TestName = "Присвоение неправильной даты меньше 1900")]
        [TestCase(null, "Должно возникать исключение, если дата - пустая строка",
            TestName = "Присвоение путой строки")]
        [TestCase("2028, 1, 5",
            "Должно возникать исключение, если год больше текущего",
            TestName = "Присвоение неправильной даты больше текущей")]
        public void TestDateSet_ArgumentException(DateTime wrongDate, string message)
        {
            //SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testContact.Birthday = wrongDate; },
                message);
        }
    }
}