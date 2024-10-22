using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    namespace EnglishFrenchDictionary
    {
        public class DictionaryApp
        {
            private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            public void AddWord(string englishWord, List<string> frenchTranslations)
            {

                if (!dictionary.TryGetValue(englishWord, out List<string>? existingTranslations))
                {
                    dictionary[englishWord] = new List<string>(frenchTranslations);
                }
                else
                {
                    existingTranslations.AddRange(frenchTranslations.Where(t => !existingTranslations.Contains(t)));
                }

                Console.WriteLine("Слово і варіанти перекладу додано");
            }


            public void RemoveWord(string englishWord)
            {
                if (dictionary.Remove(englishWord))
                {
                    Console.WriteLine("Слово видалено");
                }
                else
                {
                    Console.WriteLine("Слово не знайдено");
                }
            }

            public void RemoveTranslation(string englishWord, string translationToRemove)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    List<string> translations = dictionary[englishWord];
                    if (translations.Remove(translationToRemove))
                    {
                        Console.WriteLine("Варіант перекладу видалено");
                    }
                    else
                    {
                        Console.WriteLine("Варіант перекладу не знайдено");
                    }
                }
                else
                {
                    Console.WriteLine("Слово не знайдено");
                }
            }

            public void ChangeWord(string oldWord, string newWord)
            {
                if (dictionary.ContainsKey(oldWord))
                {
                    var translations = dictionary[oldWord];
                    dictionary.Remove(oldWord);
                    dictionary[newWord] = translations;

                    Console.WriteLine("Слово змінено");
                }
                else
                {
                    Console.WriteLine("Слово не знайдено");
                }
            }

            public void ChangeTranslation(string englishWord, string oldTranslation, string newTranslation)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    List<string> translations = dictionary[englishWord];
                    int index = translations.IndexOf(oldTranslation);
                    if (index != -1)
                    {
                        translations[index] = newTranslation;
                        Console.WriteLine("Варіант перекладу змінено");
                    }
                    else
                    {
                        Console.WriteLine("Старий варіант перекладу не знайдено");
                    }
                }
                else
                {
                    Console.WriteLine("Слово не знайдено");
                }
            }

            public void SearchTranslation(string englishWord)
            {
                if (dictionary.ContainsKey(englishWord))
                {
                    List<string> translations = dictionary[englishWord];
                    Console.WriteLine($"Варіанти перекладу для {englishWord}: {string.Join(", ", translations)}");
                }
                else
                {
                    Console.WriteLine("Слово не знайдено");
                }
            }

            public void DisplayDictionary()
            {
                if (dictionary.Count == 0)
                {
                    Console.WriteLine("Словник порожній.");
                    return;
                }

                Console.WriteLine("Словник:");
                foreach (var entry in dictionary)
                {
                    string englishWord = entry.Key;
                    List<string> translations = entry.Value;
                    Console.WriteLine($"- {englishWord}: {string.Join(", ", translations)}");
                }
            }
        }
    }
}
