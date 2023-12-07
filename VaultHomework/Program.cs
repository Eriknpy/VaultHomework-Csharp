using System.Runtime.CompilerServices;
using System.Text;

// Makes internal classes and members visible to the specified assembly, in this case, the test project
[assembly: InternalsVisibleTo("VaultHomework.Test")]
namespace VaultHomework
{
    internal class Program
    {
        /// <summary>
        /// // Entry point of the program
        /// </summary>
        /// <param name="args"> Set default file path.</param>
        internal static void Main(string[] args)
        {
            // Set default file path and update if an argument is provided
            string filePath = args.Length > 0 ? args[0] : "input.txt";
            try
            {
                // Variable to hold the count of valid passphrases
                int generalCounter = 0;
                int csHarpCounter = 0;
                const Int32 BufferSize = 128;
                // Open the file for reading
                using (var fileStream = File.OpenRead(filePath))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    string? line;
                    // Read the file line by line
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        IValidation validation = new GeneralValidator();
                        if (line != "" && validation.CheckValidPassphrases(line))
                        {
                            generalCounter++;
                        }
                        validation = new CsHarpValidtor();
                        if (line != "" && validation.CheckValidPassphrases(line))
                        {
                            csHarpCounter++;
                        }
                    }
                }

                // Print the results for each validation method
                Console.WriteLine($"General");
                Console.WriteLine($"Correct passphrases in total:  {generalCounter}");
                Console.WriteLine($"\nCsHarp");
                Console.WriteLine($"Correct passphrases in total:  {csHarpCounter}\n");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An IO error occurred: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Passphrases checking finished.");
            }
        }
    }
}
