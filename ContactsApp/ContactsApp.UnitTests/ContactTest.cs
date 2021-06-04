using NUnit.Framework;
using ContactsApp;
using System;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        [Test(Description = "Οξηθςθβνϋι ςερς γεςςεπΰ Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            var expected = "Ρμθπνξβ";
            var contact = new Contact();
            contact.Surname = expected;
            var actual = contact.Surname;
            Assert.AreEqual(expected, actual, "Γεςςεπ Surname βξηβπΰωΰες νεοπΰβθλόνσώ τΰμθλθώ");
        }

        [Test(Description = "Νεγΰςθβνϋι ςερς γεςςεπΰ Surname")]
        public void TestSurnameGet_InCorrectValue()
        {
            var wrongSurname = "ττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττττ";
            var contact = new Contact(); 

            Assert.Throws<ArgumentException>(
                () => { contact.Surname = wrongSurname; },
                "Δξλζνξ βξηνθκΰςό θρκλώχενθε, ερλθ τΰμθλθÿ - οσρςΰÿ ρςπξκΰ");
        }
    }
}