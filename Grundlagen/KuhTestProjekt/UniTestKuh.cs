using System;
using System.IO;
using FirstOOP;
using NUnit.Framework;

namespace KuhTestProjekt
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Kuh myKuh = new Kuh("Berta", "Braun");
            Assert.That(myKuh.Name, Is.EqualTo("Berta"));
            Assert.That(myKuh.Colour, Is.EqualTo("Braun"));
        }

        [Test]
        public void Constructor_WithNullOrEmptyName_ThrowsInvalidDataException()
        {
            // Prüfen, ob bei einem leeren Namen eine InvalidDataException geworfen wird
            Assert.Throws<InvalidDataException>(() => new Kuh("", "Braun"));

            // Prüfen, ob auch bei null eine Exception geworfen wird
            Assert.Throws<InvalidDataException>(() => new Kuh(null, "Schwarz"));
        }
    }
}