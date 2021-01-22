using System;
using System.Linq;


namespace CombineStrings
{
    public class Combiner
    {

        /// <summary>
        /// Combines/joins the supplied <paramref name="fragments"/> and ensures
        /// only one instance of <paramref name="separator"/> between them.
        /// </summary>
        public static string GetCombination(char separator, params string[] fragments)
        {
            string combo = "";
            foreach (string part in fragments)
            {
                combo += part + separator;
            }
            string final = combo.Remove(combo.Length - 1); // Remove divider at end from last loop iteration
            return final;
        }

        /// <summary>
        /// Combines/joins the supplied <paramref name="fragments"/> and ensures
        /// only one instance of <paramref name="separator"/> between them.
        /// Essentially a <see cref="System.IO.Path.Combine(string[])"/> that
        /// accepts an argument for the separator.
        /// </summary>
        public static string Combine(char separator, params string[] fragments)
        {
            if (string.IsNullOrEmpty(separator.ToString())
                || separator == '\0')
            {
                throw new ArgumentNullException("separator");
            }
            else if (fragments == null || fragments.Contains(""))
            {
                throw new ArgumentNullException("fragments");
            }
            var fullstring = "";
            try
            {
                fullstring = GetCombination(separator, fragments);
            }
            catch (Exception)
            {
                throw;
            }
            return fullstring;
        }
    }
}