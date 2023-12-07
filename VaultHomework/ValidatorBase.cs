namespace VaultHomework
{
    public abstract class ValidatorBase : IValidation
    {
        /// <summary>
        /// Validates a passphrase by checking various conditions: the validity of the last character,
        /// the number of words, character validity within the passphrase, and the uniqueness of each word. 
        /// The method splits the passphrase into words, excluding the last punctuation mark. 
        /// Time Complexity: O(n) + O(n) + O(n^2) = O(n^2). The O(n^2) complexity is due to the CheckOccurrences method 
        /// which checks for duplicate words in the passphrase.
        /// Space Complexity: O(n) for the 'words' array, which stores the split words from the input line.
        /// </summary>
        /// <param name="input">The passphrase string to validate.</param>
        /// <returns>True if the passphrase meets all validation criteria, otherwise false.</returns>
        public bool CheckValidPassphrases(string input)
        {
            var words = input.Remove(input.Length - 1).Split(' ');
            return IsLastCharValid(input) && words.Length > 1 && IsAllValid(input) && CheckOccurrences(words);
        }

        protected internal abstract bool CheckOccurrences(string[] words);

        protected internal abstract bool IsAllValid(string line);

        protected internal abstract bool IsLastCharValid(string line);
    }
}
