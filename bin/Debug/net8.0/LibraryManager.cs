
using System.Text.Json;


namespace LibraryManagmentAdnvanced
{
    public class LibraryManager (string filePath)
    {
        private readonly string _filePath = filePath; //väg till jsonfilen


        public void AddBook()
        {
            try
            {
                string jsonData = File.ReadAllText(_filePath);
                MyLittleDb myLittleDb = JsonSerializer.Deserialize<MyLittleDb>(jsonData) ?? new MyLittleDb();


                // Lägga till en ny bok
                string title;
                do // Loopa tills användaren har angett en giltig titel
                {
                    Console.WriteLine("Enter book title: ");
                    title = Console.ReadLine() ??"";

                    if (string.IsNullOrEmpty(title)) // Om titeln är tom
                    {
                        Console.WriteLine("Title can't be empty. Please try again.");
                    }
                } while (string.IsNullOrEmpty(title));

                string author;
                do
                {
                    Console.WriteLine("Enter book author: ");
                    author = Console.ReadLine() ??"";

                    if (string.IsNullOrEmpty(author))
                    {
                        Console.WriteLine("Author can't be empty. Please try again.");
                    }
                } while (string.IsNullOrEmpty(author));

                string genre;
                do
                {
                    Console.WriteLine("Enter book genre: ");
                    genre = Console.ReadLine() ??"";

                    if (string.IsNullOrEmpty(genre))
                    {
                        Console.WriteLine("Genre can't be empty. Please try again.");
                    }
                } while (string.IsNullOrEmpty(genre));

                int publishYear;
                while (true)
                {
                    Console.WriteLine("Enter publish year: ");
                    string yearInput = Console.ReadLine() ??"";
                    if (int.TryParse(yearInput, out publishYear) && publishYear > 0)
                    {
                        break; // Giltigt år, bryt ur loopen
                    }
                    else
                    {
                        Console.WriteLine("Publish year must be a positive number. Please try again.");
                    }
                }

                int isbn;
                while (true)
                {
                    Console.WriteLine("Enter ISBN: ");
                    string isbnInput = Console.ReadLine() ??"";
                    if (int.TryParse(isbnInput, out isbn) && isbn > 0)
                    {
                        break; // Giltigt ISBN, bryt ur loopen
                    }
                    else
                    {
                        Console.WriteLine("ISBN must be a positive number. Please try again.");
                    }
                }


                Book newBook = new Book(title, author, genre, publishYear, isbn);
                myLittleDb.Books.Add(newBook);

                MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);


                Console.WriteLine("The book has been added to the list.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }


        }

        public void AddAuthor()
        {
            try
            {
                MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath);

                string name;
                do
                {
                    Console.WriteLine("Enter author name: ");
                    name = Console.ReadLine() ??"";

                    if (string.IsNullOrEmpty(name)) // Om namnet är tomt
                    {
                        Console.WriteLine("Name can't be empty. Please try again.");
                    }


                } while (string.IsNullOrEmpty(name));
                string country;
                do
                {
                    Console.WriteLine("Enter author country: ");
                    country = Console.ReadLine() ??"";

                    if (string.IsNullOrEmpty(country))
                    {
                        Console.WriteLine("Country can't be empty. Please try again.");
                    }

                } while (string.IsNullOrEmpty(country));

                Author newAuthor = new Author(name, country);
                myLittleDb.Authors.Add(newAuthor);

                MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);

                Console.WriteLine("The author has been added to the list.");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }

        }
        public void UpdateBook()
        {
            try
            {
                MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath); // Laddar data direkt via MyLittleDb-klassen


                if (myLittleDb.Books.Count > 0)
                {
                    Console.WriteLine("Enter the title of the book you want to update: ");
                    string title = Console.ReadLine() ??"";

                    Book? bookToUpdate = myLittleDb.Books.FirstOrDefault(book => book.Title.ToLower() == title.ToLower());

                    if (bookToUpdate != null)
                    {
                        Console.WriteLine("Enter new title: ");
                        string newTitle = Console.ReadLine() ??"";
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            bookToUpdate.Title = newTitle;
                        }

                        Console.WriteLine("Enter new author: ");
                        string newAuthor = Console.ReadLine() ??"";
                        if (!string.IsNullOrEmpty(newAuthor))
                        {
                            bookToUpdate.Author = newAuthor;
                        }

                        Console.WriteLine("Enter new genre: ");
                        string newGenre = Console.ReadLine() ??"";
                        if (!string.IsNullOrEmpty(newGenre))
                        {
                            bookToUpdate.Genre = newGenre;
                        }

                        while (true)
                        {
                            Console.WriteLine("Enter new publish year: ");
                            string yearInput = Console.ReadLine() ??"";
                            if (int.TryParse(yearInput, out var newPublishYear) && newPublishYear > 0)
                            {
                                bookToUpdate.PublishYear = newPublishYear;
                                break; // Giltigt år, bryt ur loopen
                            }
                            else
                            {
                                Console.WriteLine("Publish year must be a positive number. Please try again.");
                            }
                        }

                        while (true)
                        {
                            Console.WriteLine("Enter new ISBN: ");
                            string isbnInput = Console.ReadLine() ??"";
                            if (int.TryParse(isbnInput, out var newIsbn) && newIsbn > 0)
                            {
                                bookToUpdate.Isbn = newIsbn;
                                break; // Giltigt ISBN, bryt ur loopen
                            }
                            else
                            {
                                Console.WriteLine("ISBN must be a positive number. Please try again.");
                            }
                        }

                        Console.WriteLine("The book has been updated.");

                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else
                {
                    Console.WriteLine("No books found.");
                }

                // Serialize to JSON and write to file
                MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }



        }

        public void UppdateAuthor()
        {
            try
            {
                MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath); // Laddar data direkt via MyLittleDb-klassen


                if (myLittleDb.Authors is [_, ..] list)
                {
                    Console.WriteLine("Enter the name of the author you want to update: ");
                    string name = Console.ReadLine() ??"";

                    Author? authorToUpdate = list.FirstOrDefault(author => author?.Name.ToLower() == name.ToLower());

                    if (authorToUpdate != null)
                    {
                        Console.WriteLine("Enter new name: ");
                        string newName = Console.ReadLine() ??"";
                        if (!string.IsNullOrEmpty(newName))
                        {
                            authorToUpdate.Name = newName;
                        }

                        Console.WriteLine("Enter new country: ");
                        string newCountry = Console.ReadLine() ??"";
                        if (!string.IsNullOrEmpty(newCountry))
                        {
                            authorToUpdate.Country = newCountry;
                        }

                        Console.WriteLine("The author has been updated.");


                    }
                    else
                    {
                        Console.WriteLine("Author not found.");


                    }
                    MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        public void RemoveBook()
        {
            try
            {
                MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath); // Laddar data direkt via MyLittleDb-klassen


                if (myLittleDb.Books.Count > 0)
                {
                    Console.WriteLine("Enter the title of the book you want to remove: ");
                    _ = Console.ReadLine() ??"";

                    string updatejson = JsonSerializer.Serialize(myLittleDb, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(_filePath, updatejson);


                }
                else
                {
                    Console.WriteLine("No books found.");
                }
                MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        public void RemoveAuthor()
        {
            try
            {
                MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath); // Laddar data direkt via MyLittleDb-klassen

                if (myLittleDb.Authors.Count > 0)
                {
                    Console.WriteLine("Enter the name of the author you want to remove: ");
                    _ = Console.ReadLine() ??"";

                    string updatejson = JsonSerializer.Serialize(myLittleDb, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(_filePath, updatejson);

                }
                else
                {
                    Console.WriteLine("No authors found.");
                }
                MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        public void SearchBook()
        {
            try
            {
                MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath); // Laddar data direkt via MyLittleDb-klassen


                if (myLittleDb.Books.Count > 0)
                {


                    Console.WriteLine("Enter the Title or Author of the book you want to search for:");

                    string searchQuery = Console.ReadLine() ??"".ToLower().Trim();
                    Console.WriteLine($"Searching for: {searchQuery}");

                    //var matchingBook = myLittleDb.Books
                        //.Where(book => (book.Title.ToLower().Contains(searchQuery)) || book.Author.ToLower().Contains(searchQuery))
                        //.ToList();

                    var matchingBook = myLittleDb.Books
                        .Where(book => (book.Title?.ToLower().Contains(searchQuery) ?? false) ||
                                       (book.Author?.ToLower().Contains(searchQuery) ?? false))
                        .ToList();



                    if (matchingBook.Count > 0)
                    {
                        Console.WriteLine("Book(s) found: ");
                        foreach (var book in matchingBook)
                        {
                            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Publish year: {book.PublishYear}, ISBN: {book.Isbn}, Review: {book.Review}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No books found.");

                    }
                }

                MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

        public void ShowAllBooksAndAuthors()
            {
                try
                {
                    MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath); // Laddar data direkt via MyLittleDb-klassen


                    if (myLittleDb.Books.Count > 0)
                    {

                        Console.WriteLine("Books: ");
                        foreach (var book in myLittleDb.Books)
                        {
                            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Publish year: {book.PublishYear}, ISBN: {book.Isbn}, Review: {book.Review}");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No books found.");
                    }

                    if (myLittleDb.Authors.Count > 0)
                    {
                        Console.WriteLine("Authors: ");
                        foreach (var author in myLittleDb.Authors)
                        {
                            Console.WriteLine($"Name: {author?.Name}, Country: {author?.Country}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No authors found.");
                    }
                    MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong: " + ex.Message);
                }

            }

        public void SaveAndExit()
        {
            try
            {
                MyLittleDb myLittleDb = MyLittleDb.LoadData(_filePath); // Laddar data direkt via MyLittleDb-klassen


                MyLittleDb.SaveDataIfNotNull(myLittleDb, _filePath);

                Console.WriteLine("Data has been saved and the program will now exit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }

    }
}


