using System;
using System.Globalization;
using System.IO;

using Logger;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_CreatesLogFile_ChecksIfExists()
        {
            // Arrange
            string testFilePath = "testlog.txt";
            FileLogger logger = new FileLogger
            {
                FilePath = testFilePath,
            };

            // Act
            logger.Log(LogLevel.Error, "Test log entry");

            // Assert
            Assert.IsTrue(File.Exists(testFilePath)); // Check if file exists
        }


        // This test method
        [TestMethod]
        public void FileLogger_WritesCorrectMessageToFile()
        {
            // Arrange
            string testFilePath = "test.txt";
            FileLogger logger = new FileLogger
            {
                FilePath = testFilePath,
            };

            string message = "Test";

            // Act
            logger.Log(LogLevel.Error, message);

            // Assert
            string logContent = File.ReadAllText(testFilePath); // Read the file content
            Assert.IsTrue(logContent.Contains(message)); // Check if the message is in the file
            Assert.IsTrue(logContent.Contains("Error")); // Check if the log level is in the file
        }


// name of member testing _ conditions _ success
// CTRL + . to build class
//    [TestMethod]
//    [ExpectedException(typeof(ArgumentException),
//"A userId of null was inappropriately allowed.")]
//    public void Name_PersonConstructor_ThrowsNullOnInstantion()
//    {
//        Person nt = new Person(null!);
//    }

[TestMethod]
public void Name_Inigo_Success()
{
    Person inigo = new("Inigo");
    inigo.Name = "Inigo";

    Assert.AreEqual("Inigo", inigo.Name);
}

[TestMethod]
public void Name_Initialized_NotNull()
{
    Person person = new("Inigo");
    Assert.IsNotNull(person.Name);
}

[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void Name_Initialized_Null()
{
    Person person = new(null!);
    //Assert.ThrowsException<ArgumentNullException>(() => person.Name = null!);
}

[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void Name_SetNullOutside_ArgumentNullException()
{

    Person person = new("Inigo");
    person.Name = null!;

}

[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void Name_SetEmpty_ArgumentNullException()
{
    Person person = new("Dogs");
    person.Name = "";
}
    }
}


public class Person
{
    private string? _name;
    public string Name
    {
        get
        {
            return _name!;
        }
        set
        {
            //if (value == null)
            //{
            //    throw new ArgumentNullException("name null");
            //}
            //ArgumentNullException.ThrowIfNull(value);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
            _name = value;
        }

    }

    public Person(string name)
    {
        //if (name == null)
        //{
        //    throw new ArgumentNullException("name");
        //}
        Name = name;
    }

}