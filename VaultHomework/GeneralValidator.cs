namespace VaultHomework
{
    internal sealed class GeneralValidator : ValidatorBase
    {
        /// <summary>
        /// Checks if the last character of a line is a valid punctuation mark.
        /// This method uses a loop to check if the last character matches any of the valid characters.
        /// Time Complexity: O(1)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="line">The line to be checked.</param>
        /// <returns>True if the last character is a valid punctuation mark. Otherwise false.</returns>
        protected internal override bool IsLastCharValid(string line)
        {
            char lastChar = line[^1];
            char[] validChars = { '!', '?', '.' };
            int index = 0;
            do
            {
                if (lastChar == validChars[index])
                {
                    return true;
                }
                index++;
            }
            while (index < validChars.Length);

            return false;
        }

        /// <summary>
        /// Checks if all characters in a line, except the last character, are lowercase letters or whitespace.
        /// This method ensures that the line, up to the second-to-last character, adheres to the criteria.
        /// Time Complexity: O(n)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="line">The line to be validated.</param>
        /// <returns>True if all characters, excluding the last punctuation mark, are lowercase or whitespace. Otherwise false.</returns>
        protected internal override bool IsAllValid(string line)
        {
            int index = 0;
            /* 
               The '-2' in the loop condition is because:
               - The last character of the line is a punctuation mark, which is not being checked here.
               - Arrays are zero-indexed, so 'line.Length - 1' is the last character, and 'line.Length - 2' is the second-to-last character.
               This ensures the loop checks all characters up to (but not including) the final punctuation mark. 
            */
            while (index < line.Length - 2 &&
                (char.IsWhiteSpace(line[index]) || char.IsLower(line[index])))
            {
                index++;
            }
            return index == line.Length - 2;
        }

        /// <summary>
        /// Determines if all words in a given array are unique.
        /// This method compares each word against every other word in the array to check for duplicates.
        /// Time Complexity: O(n^2)
        /// Space Complexity: O(1)
        /// </summary>
        /// <param name="words">The array of words to be checked.</param>
        /// <returns>True if there are no duplicate words in the array. Otherwise false.</returns>
        protected internal override bool CheckOccurrences(string[] words)
        {
            // Comparing each word with every other word to check for duplicates.
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int k = i + 1; k < words.Length; k++)
                {
                    if (words[i] == words[k])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
