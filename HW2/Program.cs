using System;
using System.IO;
using System.Collections.Generic;

//є заданий текст вивести кількість слів, в тексті кількість входження кожного символу, речень, кількість абзаців 

namespace NavchalnaTEXT2
{
    class Program
    {
        public static string ReadFromfile(string address)
        {
            String text = File.ReadAllText(address);
            return text;
        }

        public static int ParagraphCounter(string text)
        {
            String[] paragraphs = text.Split("\n");
            return paragraphs.Length;
        }

        public static Dictionary<char, int> CountingChars(string text)
        {
            Dictionary<char, int> CountingCharsDict = new Dictionary<char, int> { };
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ' || text[i] == '-' || text[i] == '"' || text[i] == '\t' || text[i] == '\r' || text[i] == '\n')
                {
                    continue;
                }
                else
                {
                    if (CountingCharsDict.ContainsKey(text[i]))
                    {
                        CountingCharsDict[text[i]]++;
                    }
                    else
                    {
                        CountingCharsDict.Add(text[i], 1);
                    }
                }
            }
            return CountingCharsDict;
        }

        public static void CleanText(string text)
        {
            string[] badSymbols = new string[] { "\n\n", "  ", ".." };
            string[] correctSymbols = new string[] { "\n", " ", " " };

            for (int i = 0; i < badSymbols.Length; i++)
            {
                while (text.Contains(badSymbols[i]))
                {
                    text.Replace(badSymbols[i], correctSymbols[i]);
                }
            }
        }

        public static int TextWords(string text)
        {
            char[] charSeparators = new char[] { ' ' };
            string[] stringSeparators = new string[] { "\n", "!", "?", "!?", ",", ".", "...", "!!!" };
            string[] result;
            result = text.Split(charSeparators, StringSplitOptions.None);
            return result.Length;
        }

        public static int TextSentenses(string text)
        {
            char[] symbols = new char[] { '.', '?', '!', '\n', ';' };
            int result = text.Split(symbols, StringSplitOptions.RemoveEmptyEntries).Length;
            return result;
        }

        public static void Print(Dictionary<char, int> dict)
        {
            foreach (KeyValuePair<char, int> item in dict)
            {
                Console.WriteLine("{0}  -------->  {1}", item.Key, item.Value);
            }
        }

        static void Main(string[] args)
        {
            string text = ReadFromfile(@"..\..\..\read.txt");
            CleanText(text);
            Dictionary<char, int> forChars = CountingChars(text);
            Print(forChars);
            int forParagraphs = ParagraphCounter(text);
            int forWords = TextWords(text);
            int forSentenses = TextSentenses(text);
            Console.Write($"\nCount of paragraphs: {forParagraphs}\nCount of Sentences: {forSentenses}\n" +
                $"Count of words: {forWords}");
            Console.ReadLine();
        }
    }
}
