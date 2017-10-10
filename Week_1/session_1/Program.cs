using System;
using System.Collections.Generic;

namespace fun_with_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX_SIZE = 10;
            List<string> favorite_words = new List<string>{
                "apple",
                "moon",
                "Pizza",
                "LOL"
            };

            List<string> words = new List<string>();
            

            while(words.Count < MAX_SIZE)
            {
                System.Console.WriteLine("Enter a word");
                string newWord = Console.ReadLine();
                words.Add(newWord);
                ReadWordList(words, favorite_words);
            }
        }
        static void ReadWordList(List<string> overall, List<string> favorites)
        {
            System.Console.WriteLine("");
            foreach(string word in overall)
            {
                if(IsFavoriteWord(word, favorites))
                {
                    System.Console.WriteLine($"{word} (I LIKE THIS ONE!)");
                }
                else
                    System.Console.WriteLine(word);
            }
        }
        static bool IsFavoriteWord(string testWord, List<string> favorites)
        {
            return favorites.Contains(testWord);
        }
    }
}
