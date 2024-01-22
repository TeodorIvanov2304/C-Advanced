using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            ReadWordsToFind(wordsFilePath, words);

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                ReadTextAndMatch(words, reader);

                var sortedWords = words.OrderByDescending(x => x.Value);
                WriteWordsInFile(outputFilePath, sortedWords);

            }
        }

        private static void WriteWordsInFile(string outputFilePath, IOrderedEnumerable<KeyValuePair<string, int>> sortedWords)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (KeyValuePair<string, int> word in sortedWords)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        private static void ReadTextAndMatch(Dictionary<string, int> words, StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                string pattern = @"\w{1,}";
                string text = reader.ReadLine().ToLower();
                MatchCollection matches = Regex.Matches(text, pattern);
                MatchWordsAndAddToDictionary(words, matches);
            }
        }

        private static void MatchWordsAndAddToDictionary(Dictionary<string, int> words, MatchCollection matches)
        {
            foreach (Match item in matches)
            {

                if (words.ContainsKey(item.ToString()))
                {
                    words[item.ToString()]++;
                }
            }
        }

        private static void ReadWordsToFind(string wordsFilePath, Dictionary<string, int> words)
        {
            using (StreamReader reader = new StreamReader(wordsFilePath))
            {

                while (!reader.EndOfStream)
                {
                    string[] word = reader.ReadLine().Split();

                    foreach (var item in word)
                    {
                        words.Add(item, 0);
                    }
                }
            }
        }
    }
}
