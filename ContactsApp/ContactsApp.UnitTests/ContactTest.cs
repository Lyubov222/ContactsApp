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
            var expected = "�������";
            var contact = new Contact();
            contact.Surname = expected;
            var actual = contact.Surname;
            Assert.AreEqual(expected, actual, "������ Surname ���������� ������������ �������");
        }

        [Test(Description = "���������� ���� ������� Surname")]
        public void TestSurnameGet_InCorrectValue()
        {
            var wrongSurname = "������������������������������������������������������������������������������������������";
            var contact = new Contact(); 

            Assert.Throws<ArgumentException>(
                () => { contact.Surname = wrongSurname; },
                "������ ��������� ����������, ���� ������� - ������ ������");
        }
    }
}