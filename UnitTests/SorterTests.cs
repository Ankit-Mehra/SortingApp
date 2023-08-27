using System.Globalization;
using SortingApp;

namespace UnitTests
{
    public class SorterTests
    {
        [Fact]
        public void SortNamesByLastNameThenGivenName_SortsList()
        {
            // Arrange
            List<string> names = new() 
            { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer" 
            };
            List<string> expected = new() 
            {
                "Adonis Julius Archer", "Vaughn Lewis", "Janet Parsons" 
            };

            // Act
            List<string> actual = Sorter.SortNamesByLastNameThenGivenName(names);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}