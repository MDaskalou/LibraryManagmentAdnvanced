namespace LibraryManagmentAdnvanced
{
    public class UserMenu(string filePath)
    {
        private readonly LibraryManager _libraryManager = new(filePath); //skapar en instans av LibraryManager och skickar med sökvägen till jsonfilen

        public void ShowMenu()
        {
            bool showMenu = true;

            while (showMenu)
            { 
               Console.WriteLine("Choose one of the following options: ");
               Console.WriteLine("1. Add book");
               Console.WriteLine("2. Add author");
               Console.WriteLine("3. Update book details");
               Console.WriteLine("4. Update author details");
               Console.WriteLine("5. Remove book");
               Console.WriteLine("6. Remove author");
               Console.WriteLine("7. Show all books and authors");
               Console.WriteLine("8. Search for book");
               Console.WriteLine("9. Save and exit");



                string? choice = Console.ReadLine()?
                    .ToLower();

                     switch (choice)
                     {
                      case "1":
                        _libraryManager.AddBook();
                        Console.ReadKey();
                        Console.Clear();

                        break;

                      case "2":
                      _libraryManager.AddAuthor();
                      Console.ReadKey();
                      Console.Clear();

                      break;
                        case "3":
                        _libraryManager.UpdateBook();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                        case "4":
                        _libraryManager.UppdateAuthor();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                        case "5":
                        _libraryManager.RemoveBook();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                        case "6":
                        _libraryManager.RemoveAuthor();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "7":
                        _libraryManager.ShowAllBooksAndAuthors();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "8":
                        _libraryManager.SearchBook();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "9":
                        _libraryManager.SaveAndExit();
                        showMenu = false;
                        break;
                }

            }
    
        }
    }
}
