namespace VaultHomework
{
    internal sealed class CsHarpValidtor : ValidatorBase
    {
        /// <summary>
        /// Determines if all words in a given array are unique.
        /// This method uses LINQ to group words and check if any word appears more than once.
        /// Time Complexity: O(n)
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="words">The array of words to be checked.</param>
        /// <returns>True if there are no duplicate words in the array. Otherwise false.</returns>
        protected internal override bool CheckOccurrences(string[] words)
        {
            return words.GroupBy(word => word).All(x => x.Count() == 1);
        }

        /// <summary>
        /// Checks if all characters in a line, except the last, are lowercase letters or whitespace.
        /// This method ensures that the line, up to the second-to-last character, adheres to the criteria for lowercase letters or whitespace.
        /// Using LINQ to check each character, excluding the last punctuation mark.
        /// Time Complexity: O(n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="line">The line to be validated.</param>
        /// <returns>True if all characters, excluding the last punctuation mark, are lowercase or whitespace. Otherwise false.</returns>
        protected internal override bool IsAllValid(string line)
        {
            if (string.IsNullOrEmpty(line) || line.Length == 1)
            {
                return false;
            }
            return line[..^1].All(ch => char.IsLower(ch) || char.IsWhiteSpace(ch));
        }

        /// <summary>
        /// Checks if the last character of a line is one of the specified valid punctuation marks.
        /// This method uses LINQ to determine if the last character matches the valid characters.
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="line">The line to be checked.</param>
        /// <returns>True if the last character is a valid punctuation mark. Otherwise false.</returns>
        protected internal override bool IsLastCharValid(string line)
        {
            return new[] { '!', '?', '.' }.Any(x => x == line[^1]);
        }
    }
}
