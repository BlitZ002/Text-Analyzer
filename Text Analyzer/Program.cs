namespace Text_Analyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a text");
            string input = Console.ReadLine().ToLower();

            int wordCount = CountWords(input);
            int vowelCount = CountVowels(input);
            int constantCount = CountConsonants(input);
            var letterFrequency = CountLetterFrequency(input);

            Console.WriteLine($"Number of words: {wordCount}");
            Console.WriteLine($"Number of vowels: {vowelCount}");
            Console.WriteLine($"Number of constants: {constantCount}");
            Console.WriteLine("Letter frequencies");

            foreach(var item in letterFrequency)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            static int CountWords(string text) 
            {
                var words = text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                return words.Length;
            }

            static int CountVowels(string text)
            {
                int count = 0;
                var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                foreach (char c in text) 
                {
                    if (Char.IsLetter(c) && vowels.Contains(c)) count++;
                }
                return count;
            }

            static int CountConsonants(string text)
            {
                int count = 0;
                var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                foreach (char c in text)
                {
                    if (Char.IsLetter(c) && !vowels.Contains(c)) count++;
                }
                return count;
            }

            static Dictionary<char, int> CountLetterFrequency(string text)
            {
                var frequency = new Dictionary<char, int>();
                foreach(char c in text)
                {
                    if (Char.IsLetter(c))
                    {
                        if(frequency.ContainsKey(c))
                            frequency[c]++;
                        else
                            frequency[c] = 1;
                    }
                }
                return frequency;
            }
        }
    }
}
