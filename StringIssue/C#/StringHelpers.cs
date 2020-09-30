using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StringIssue
{
    public static class StringHelpers
    {
        /// <summary>
        /// Method that does not perform well.
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string MergeStrings(IEnumerable<string> strs)
        {
            var toReturn = "";

            foreach (var str in strs)
            {
                toReturn += str;
            }

            return toReturn;
        }


        public static string MergeStringsOptimized(IEnumerable<string> strs)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var str in strs)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }


    }
}

/* Explain why your solution is faster below this line

The original mergeStrings method requires the OS to allocate memory when using toReturn ="";  because system.string is immutable, so whenever the content is modified this takes up memory
This can affect performance in a high degree when you use string concatenation on a very large dataset

MergeStringsOptimized() uses the built in Stringbuilder method which doesn't create a new object in memory, but expands memory to accomodate the modified string
It should be noted for single concatenation, the one approach that increases readability should be used, as the performance is trivial, in small datasets. 
 */
