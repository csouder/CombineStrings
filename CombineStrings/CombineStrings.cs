using System;
using System.Linq;


namespace CombineStrings
{
    public class Combiner
    {
        private string[] fragments;
        private char divider;

        public Combiner()
        {
            this.divider = '-';
            this.fragments = new string[] {"This","is","default"};
        }
        public Combiner(char divider, string[] fragments)
        {
            this.divider = divider;
            this.fragments = fragments;
        }

        //Returns the combination of string fragments with the dividers in place
        public string GetCombination()
        {
            string combo = "";
            foreach (string part in this.fragments)
            {
                combo += part + this.divider;
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
            var tester = new Combiner(separator, fragments);
            string fullstring = "";
            try
            {
                fullstring = tester.GetCombination();
            }
            catch (Exception)
            {
                throw;
            }
            return fullstring;
        }
    }
}