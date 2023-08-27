using Moq;
using SortingApp;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class FileReaderTests
    {
        private readonly Mock<IFileSystem> fileSystem;
        
        public FileReaderTests()
        {
            fileSystem = new Mock<IFileSystem>();
        }

        [Fact]
        public void ReadFile_ReturnsList()
        {
            // Arrange
            string mockPath = "test.txt";
            List<string> expected = new() 
            { 
                "Adonis Julius Archer",
                "Vaughn Lewis",
                "Janet Parsons" 
            };
            fileSystem.Setup(x => x.File.ReadAllLines(It.IsAny<string>()))
                .Returns(expected.ToArray());

            // Act
            FileReader reader = new(fileSystem.Object);
            List<string> actual = reader.ReadFile(mockPath);

            // Assert
            Assert.Equal(expected, actual);
        }

    }
}
