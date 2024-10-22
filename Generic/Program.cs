using Generic.EnglishFrenchDictionary;

namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task1");
            Bookkeeping bookkeeping = new Bookkeeping();

            Book book1 = new Book("Твір1", "Автор1", "Роман", 1000);
            Book book2 = new Book("Твір2", "Автор2", "Антиутопія", 2000);
            Book book3 = new Book("Твір3", "Автор3", "Роман", 1500);
            Book book4 = new Book("Твір4", "Автор4", "Фентезі", 2024);
            Book book5 = new Book("Твір5", "Автор5", "Фентезі", 1900);

            bookkeeping.AddBook(book1);
            bookkeeping.AddBook(book2);
            bookkeeping.AddBook(book3);

            Console.WriteLine("Книги в обліку:");
            bookkeeping.InfoBooks();

            Book newBook2 = new Book("Твір2(новий)", "Автор2(новий)", "Антиутопія", 2000);
            bookkeeping.UpdateBook(book2, newBook2);
            Console.WriteLine("\nКниги після оновлення:");
            bookkeeping.InfoBooks();


            bookkeeping.AddBegin(book4);
            Console.WriteLine("\nКниги після додавання на початок:");
            bookkeeping.InfoBooks();


            bookkeeping.AddEnd(book5);
            Console.WriteLine("\nКниги після додавання в кінець:");
            bookkeeping.InfoBooks();


            bookkeeping.AddPosition(new Book("Твір6", "Автор6", "Наукова фантастика", 2023), 2);
            Console.WriteLine("\nКниги після додавання в позицію 2:");
            bookkeeping.InfoBooks();


            bookkeeping.RemoveBook(book3); 
            Console.WriteLine("\nКниги після видалення Твір3:");
            bookkeeping.InfoBooks();

            bookkeeping.RemovePosition(1);
            Console.WriteLine("\nКниги після видалення з позиції 1:");
            bookkeeping.InfoBooks();


            bookkeeping.RemoveFromBegin();
            Console.WriteLine("\nКниги після видалення з початку:");
            bookkeeping.InfoBooks();


            bookkeeping.RemoveFromEnd();
            Console.WriteLine("\nКниги після видалення з кінця:");
            bookkeeping.InfoBooks();


            var foundBooks = bookkeeping.SearchBooks("Твір2(новий)", null, null, null);
            Console.WriteLine("\nРезультати пошуку книг за заголовком Твір2(новий):");
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book);
            }




            Console.WriteLine("Task2");
            DictionaryApp dictionaryApp = new DictionaryApp();
            dictionaryApp.AddWord("cat", new List<string> { "chat", "feline" });
            dictionaryApp.AddWord("dog", new List<string> { "chien", "canin" });
            dictionaryApp.AddWord("bird", new List<string> { "oiseau" });


            Console.WriteLine();
            dictionaryApp.DisplayDictionary();


            Console.WriteLine();
            dictionaryApp.SearchTranslation("cat");

            Console.WriteLine();
            dictionaryApp.ChangeWord("dog", "puppy");
            dictionaryApp.DisplayDictionary();

            Console.WriteLine();
            dictionaryApp.ChangeTranslation("cat", "feline", "félin");
            dictionaryApp.DisplayDictionary();

            Console.WriteLine();
            dictionaryApp.RemoveTranslation("cat", "chat");
            dictionaryApp.DisplayDictionary();


            Console.WriteLine();
            dictionaryApp.RemoveWord("bird");
            dictionaryApp.DisplayDictionary();


            Clinic clinic = new Clinic();
            clinic.Run();
        }
    }
}
