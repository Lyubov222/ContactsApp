using NUnit.Framework;
using ContactsApp;
using System;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {

        [Test(Description = "���������� ���� ������� Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            // SetUp
            var _testContact = new Contact();
            var expected = "��������";
            _testContact.Surname = expected;

            //Act
            var actual = _testContact.Surname;

            //Assert
            Assert.AreEqual(expected, actual, "������ Surname ���������� ������������ �������");
        }

        [Test(Description = "���������� ���� ������� Surname")]
        public void TestSurnameSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Surname = "������";

            //Act
            var actual = _testContact.Surname;

            //Assert
            Assert.AreEqual(actual, _testContact.Surname, "������ ����������� �������� �������");
        }

        [TestCase("", "������ ��������� ����������, ���� ������� - ������ ������",
            TestName = "���������� ������ ������ � �������� �������")]
        [TestCase("��������-��������-��������-��������-��������-��������-��������-��������-��������-��������",
            "������ ��������� ����������, ���� ������� ������� 50 ��������",
            TestName = "���������� ������������ ������� ������ 50 ��������")]

        [Test(Description = "���������� ���� ������� Surname")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            //SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testContact.Surname = wrongSurname; },
                message);
        }

        [Test(Description = "���������� ���� ������� Name")]
        public void TestNameGet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            var expected = "������";
            _testContact.Name = expected;

            //Act
            var actual = _testContact.Name;

            //Assert
            Assert.AreEqual(expected, actual, "������ Name ���������� ������������ ���");
        }

        [Test(Description = "���������� ���� ������� Name")]
        public void TestNameSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Name = "������";

            //Act
            var actual = _testContact.Name;

            //Assert
            Assert.AreEqual(actual, _testContact.Name, "������ ����������� �������� ���");
        }

        [TestCase("", "������ ��������� ����������, ���� ��� - ������ ������",
                   TestName = "���������� ������ ������ � �������� �����")]
        [TestCase("������-������-������-������-������-������-������-������-������-������",
                   "������ ��������� ����������, ���� ��� ������� 50 ��������",
                   TestName = "���������� ������������� ����� ������ 50 ��������")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            //SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
            () => { _testContact.Name = wrongName; },
            message);
        }

        [Test(Description = "���������� ���� ������� Email")]
        public void TestMailGet_CorrectValue()
        {
            //SetUP
            var _testContact = new Contact();
            var expected = "lyubov.pan2000@mail.ru";
            _testContact.Email = expected;

            //Act
            var actual = _testContact.Email;

            //Assert
            Assert.AreEqual(expected, actual, "������ Email ���������� ������������ �����");
        }

        [Test(Description = "���������� ���� ������� Email")]
        public void TestMailSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Email = "lyubov.pan2000@mail.ru";

            //Act
            var actual = _testContact.Email;

            //Assert
            Assert.AreEqual(actual, _testContact.Email, "������ ����������� �������� �����");
        }

        [TestCase("",
         "������ ��������� ����������, ���� Email - ������ ������",
         TestName = "���������� ������ ������ � �������� �����")]
        [TestCase("12345678901234567890123456789012345689012345678901234567890@mail.ru",
         "������ ��������� ����������, ���� ����� ������ 50 ��������",
         TestName = "���������� ������������ ����� ������ 50 ��������")]
        public void TestMailSet_ArgumentException(string wrongEmail, string message)
        {
            //?SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testContact.Email = wrongEmail; },
                message);
        }

        [Test(Description = "���������� ���� ������� IDVk")]
        public void TestIdVkGet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            var expected = "id777777";
            _testContact.IDVk = expected;

            //Act
            var actual = _testContact.IDVk;

            //Assert
            Assert.AreEqual(expected, actual, "������ IDVk ���������� ������������  idvk");
        }

        [Test(Description = "���������� ���� ������� IDVk")]
        public void TestIdVkSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.IDVk = "abracadab.id";

            //Act
            var actual = _testContact.IDVk;

            //Assert
            Assert.AreEqual(actual, _testContact.IDVk, "������ ����������� �������� idVk");
        }

        [TestCase("",
           "������ ��������� ����������, ���� IDVk - ������ ������",
           TestName = "���������� ������ ������ � �������� IDVk")]
        [TestCase("id12345678901234567890",
           "������ ��������� ����������, ���� IDVk > 15 ��������",
           TestName = "���������� ������������ ���� ������ �������")]
        public void TestIdVKSet_ArgumentException(string wrongIdVk, string message)
        {
            //SetUp
            var _testContact = new Contact();

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _testContact.IDVk = wrongIdVk; },
                message);
        }

        [Test(Description = "���������� ���� ������� BirthDay")]
        public void TestDateGet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            DateTime expected = new DateTime(2000, 8, 30);
            _testContact.Birthday = expected;

            //Act
            var actual = _testContact.Birthday;

            //Assert
            Assert.AreEqual(expected.Year, actual.Year, "������ BirthDay ���������� ������������ ����");
        }

        [Test(Description = "���������� ���� ������� BirthDay")]
        public void TestDateSet_CorrectValue()
        {
            //SetUp
            var _testContact = new Contact();
            _testContact.Birthday = new DateTime(2000, 5, 20);

            //Act
            var actual = _testContact.Birthday;

            //Assert
            Assert.AreEqual(actual, _testContact.Birthday, "������ ����������� �������� ����");
        }

        [TestCase("1899, 1, 5",
            "������ ��������� ����������, ���� ��� ������ 1900",
            TestName = "���������� ������������ ���� ������ 1900")]
        [TestCase(null, "������ ��������� ����������, ���� ���� - ������ ������",
            TestName = "���������� ����� ������")]
        [TestCase("2028, 1, 5",
            "������ ��������� ����������, ���� ��� ������ ��������",
            TestName = "���������� ������������ ���� ������ �������")]
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