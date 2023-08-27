using Moq;
using SortingApp;
using System.IO.Abstractions;


namespace UnitTests
{
    public class FileUtilitesTests
    {
        private readonly Mock<IFileSystem> fileSystem;
        
        public FileUtilitesTests()
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
            FileUtilites reader = new(fileSystem.Object);
            List<string> actual = reader.ReadFile(mockPath);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WriteFile_WritesFile()
        {
            // Arrange
            string mockPath = "test.txt";
            List<string> mockLines = new()
            {
                "Adonis Julius Archer",
                "Vaughn Lewis",
                "Janet Parsons" 
            };
            fileSystem.Setup(x => x.File.WriteAllLines(It.IsAny<string>(), It.IsAny<List<string>>()))
                .Verifiable();

            // Act
            FileUtilites writer = new(fileSystem.Object);
            writer.WriteFile(mockPath, mockLines);

            // Assert
            fileSystem.Verify(
                x => 
                x.File.WriteAllLines(
                    It.IsAny<string>(),
                    It.IsAny<List<string>>()),
                Times.Once);
        }   

    }
}
