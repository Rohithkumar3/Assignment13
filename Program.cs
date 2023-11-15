using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            DisplayWordCount(wordCount);

            ValidateEmailAddresses(inputText);

            ExtractMobileNumbers(inputText);

            Console.WriteLine("Enter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            CustomRegexSearch(inputText, customRegexPattern);
            Console.ReadKey();
        }

        static int CountWords(string text)
        {
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static void DisplayWordCount(int wordCount)
        {
            Console.WriteLine($"Word Count: {wordCount}");
        }

        static void ValidateEmailAddresses(string text)
        {
            MatchCollection emailMatches = Regex.Matches(text, @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
            DisplayMatches("Email Addresses:", emailMatches);
        }

        static void ExtractMobileNumbers(string text)
        {
            MatchCollection mobileNumberMatches = Regex.Matches(text, @"\b\d{10}\b");
            DisplayMatches("Mobile Numbers:", mobileNumberMatches);
        }

        static void CustomRegexSearch(string text, string pattern)
        {
            MatchCollection customMatches = Regex.Matches(text, pattern);
            DisplayMatches("Custom Regex Search Results:", customMatches);
        }

        static void DisplayMatches(string header, MatchCollection matches)
        {
            Console.WriteLine(header);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }

}
