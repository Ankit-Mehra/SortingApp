using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SortingApp
{
    /// <summary>
    /// Provides methods for sorting lists of names.
    /// </summary>
    public class Sorter
    {
        /// <summary>
        /// Given a set of names, order that set first by last name, then by any given names the person may have.
        /// A name must have at least 1 given name and may have up to 3 given names.
        /// </summary>
        /// <param name="lines">The list of names to sort.</param>
        /// <returns>The sorted list of names.</returns>
        public static List<string> SortNamesByLastNameThenGivenName(List<string> lines)
        {
            // x.Split(' ') splits the string x into an array of words based on spaces.
            // Last() returns the last element of the array of words, which is the last word of the string.
            // CompareTo compares the last words of x and y and returns an integer that indicates their relative order.
            // If the last word of x comes before the last word of y, CompareTo returns a negative number.
            // If the last word of x comes after the last word of y, CompareTo returns a positive number.
            // If the last words are the same, CompareTo returns zero.
            static int sortLast(string x, string y) => x.Split(' ').Last().CompareTo(y.Split(' ').Last());
            //Get the last name from the line
            lines.Sort((x, y) => sortLast(x, y));
            return lines;
        }
    }
}
