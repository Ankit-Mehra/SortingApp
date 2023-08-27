using System.IO.Abstractions;

namespace SortingApp
{
    /// <summary>
    /// Provides methods for reading files.
    /// </summary>
    public class FileUtilites
    {
        readonly IFileSystem fileSystem;

        // <summary>Create FileReader with the given fileSystem implementation</summary>
        public FileUtilites(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        /// <summary>
        /// Reads the contents of a file and returns them as a list of strings.
        /// </summary>
        /// <param name="path">The path to the file to read.</param>
        /// <returns>A list of strings containing the contents of the file.</returns>
        public List<string> ReadFile(string path)
        {
            List <string> lines =  new();
            try
            {
                lines = fileSystem.File.ReadAllLines(path).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            return lines;
        }
        
        /// <summary>
        /// Writes the contents of a list of strings to a file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="lines"></param>
        public void WriteFile(string path, List<string> lines)
        {
            try
            {
                fileSystem.File.WriteAllLines(path, lines);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}