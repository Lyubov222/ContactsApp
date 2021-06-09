using NUnit.Framework;
using ContactsApp;
using System;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        private Contact _testContact;

        public void SetUp()
        {
            _testContact = new Contact();
        }

        [Test(Description = "���������� ���� ������� Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            SetUp();
            var expected = "��������";
            _testContact.Surname = expected;
            var actual = _testContact.Surname;
            Assert.AreEqual(expected, actual, "������ Surname ���������� ������������ �������");
        }

        [Test(Description = "���������� ���� ������� Surname")]
        public void TestSurnameSet_CorrectValue()
        {
            SetUp();
            _testContact.Surname = "������";
            var actual = _testContact.Surname;
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
            SetUp();
            SetUp();
            Assert.Throws<ArgumentException>(
                () => { _testContact.Surname = wrongSurname; },
                message);
        }

        [Test(Description = "���������� ���� ������� Name")]
        public void TestNameGet_CorrectValue()
        {
            SetUp();
            var expected = "������";

            _testContact.Name = expected;
            var actual = _testContact.Name;
            Assert.AreEqual(expected, actual, "������ Name ���������� ������������ ���");
        }

        [TestCase("", "������ ��������� ����������, ���� ��� - ������ ������",
                   TestName = "���������� ������ ������ � �������� �����")]
        [TestCase("������-������-������-������-������-������-������-������-������-������",
                   "������ ��������� ����������, ���� ��� ������� 50 ��������",
                   TestName = "���������� ������������� ����� ������ 50 ��������")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            SetUp();
            Assert.Throws<ArgumentException>(
            () => { _testContact.Name = wrongName; },
            message);
        }

        [Test(Description = "���������� ���� ������� Email")]
        public void TestMailGet_CorrectValue()
        {
            SetUp();
            var expected = "lyubov.pan2000@mail.ru";

            _testContact.Email = expected;
            var actual = _testContact.Email;
            Assert.AreEqual(expected, actual, "������ Email ���������� ������������ �����");
        }

        [Test(Description = "���������� ���� ������� Email")]
        public void TestMailSet_CorrectValue()
        {
            SetUp();
            _testContact.Email = "lyubov.pan2000@mail.ru";
            var actual = _testContact.Email;
            Assert.AreEqual(actual, _testContact.Email, "������ ����������� �������� �����");
        }

        [TestCase("",
         "������ ��������� ����������, ���� Email - ������ ������",
         TestName = "���������� ������ ������ � �������� �����")]
        [TestCase("������������������������������������������������������������@mail.ru",
         "������ ��������� ����������, ���� ����� ������ 50 ��������",
         TestName = "���������� ������������ ����� ������ 50 ��������")]
        public void TestMailSet_ArgumentException(string wrongEmail, string message)
        {
            SetUp();
            Assert.Throws<ArgumentException>(
                () => { _testContact.Email = wrongEmail; },
                message);
        }

        [Test(Description = "���������� ���� ������� IDVk")]
        public void TestIdVkGet_CorrectValue()
        {
            SetUp();
            var expected = "id777777";

            _testContact.IDVk = expected;
            var actual = _testContact.IDVk;
            Assert.AreEqual(expected, actual, "������ IDVk ���������� ������������  idvk");
        }

        [Test(Description = "���������� ���� ������� IDVk")]
        public void TestIdVkSet_CorrectValue()
        {
            SetUp();
            _testContact.IDVk = "abracadab.id";
            var actual = _testContact.IDVk;
            Assert.AreEqual(actual, _testContact.IDVk, "������ ����������� �������� idVk");
        }

        [TestCase("",
           "������ ��������� ����������, ���� IDVk - ������ ������",
           TestName = "���������� ������ ������ � �������� IDVk")]
        [TestCase("id230934i1-e0wtjf-9erugj-wer0iugj4rfrf3rf3rfr3f",
           "������ ��������� ����������, ���� IDVk > 15 ��������",
           TestName = "���������� ������������ ���� ������ �������")]
        public void TestIdVKSet_ArgumentException(string wrongIdVk, string message)
        {
            SetUp();
            Assert.Throws<ArgumentException>(
                () => { _testContact.IDVk = wrongIdVk; },
                message);
        }

        [Test(Description = "���������� ���� ������� BirthDay")]
        public void TestDateGet_CorrectValue()
        {
            SetUp();
            DateTime expected = new DateTime(2000, 8, 30);

            _testContact.Birthday = expected;
            var actual = _testContact.Birthday;
            Assert.AreEqual(expected.Year, actual.Year, "������ BirthDay ���������� ������������ ����");
        }

        [Test(Description = "���������� ���� ������� BirthDay")]
        public void TestDateSet_CorrectValue()
        {
            SetUp();
            _testContact.Birthday = new DateTime(2000, 5, 20);
            var actual = _testContact.Birthday;
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
            SetUp();
            Assert.Throws<ArgumentException>(
                () => { _testContact.Birthday = wrongDate; },
                message);
        }
    }
}