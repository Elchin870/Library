using EFCore_library.Data;
using EFCore_library.Models;

namespace EFCore_library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new LibraryContext();
            bool isLogin = false;
            while (isLogin == false)
            {
                try
                {
                    Console.Write("Enter LibId: ");
                    var libId = Console.ReadLine();
                    bool isFind = false;

                    foreach (var item in context.Libs)
                    {
                        if (item.Id == Convert.ToInt32(libId))
                        {
                            Console.Clear();
                            Console.WriteLine($"Hello {item.FirstName} {item.LastName}");
                            isFind = true;
                            isLogin = true;
                            break;
                        }
                    }
                    if (isFind == false)
                    {
                        Console.WriteLine("Wrong input!!!");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Empty input!!!");
                }

            }
            bool inMenu = true;
            while (inMenu == true)
            {
                Console.WriteLine("1)Show All Books");
                Console.WriteLine("2)Add New Book");
                Console.WriteLine("3)Update Book");
                Console.WriteLine("4)Delete Book");
                Console.WriteLine("5)Exit");
                Console.Write("Secim edin: ");
                var secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        var books = context.Books.ToList();
                        Console.Clear();
                        foreach (var book in books)
                        {
                            Console.WriteLine($"{book.Id} {book.Name} {book.Pages} {book.YearPress} {book.Quantity}");
                        }
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter book Id: ");
                        var newBookId = Console.ReadLine();
                        Console.Write("Enter book Name: ");
                        var newBookName = Console.ReadLine();
                        Console.Write("Enter book Pages: ");
                        var newBookPages = Console.ReadLine();
                        Console.Write("Enter book Year: ");
                        var newBookYear = Console.ReadLine();
                        Console.Write("Enter book Quantity: ");
                        var newBookQuantity = Console.ReadLine();
                        try
                        {
                            var newBook = new Book { Id = Convert.ToInt32(newBookId), Name = newBookName, Pages = Convert.ToInt32(newBookPages), YearPress = Convert.ToInt32(newBookYear), Quantity = Convert.ToInt32(newBookQuantity), IdAuthor = 1, IdCategory = 1, IdPress = 1, IdThemes = 1 };
                            context.Books.Add(newBook);
                            context.SaveChanges();
                            Console.WriteLine("Book added succesfully");
                            Thread.Sleep(2000);
                            Console.Clear();

                        }
                        catch (Exception)
                        {

                            Console.WriteLine("This Id Already exist or empty input!");
                            Thread.Sleep(2000);
                            Console.Clear();

                        }
                        break;
                    case "3":
                        Console.Clear();
                        try
                        {
                            Console.Write("Enter book id for update: ");
                            var bookIdForUpdate = Console.ReadLine();
                            var FindId = context.Books.FirstOrDefault(i => i.Id == Convert.ToInt32(bookIdForUpdate));
                            if (FindId != null)
                            {
                                Console.WriteLine("1)Name");
                                Console.WriteLine("2)Year");
                                Console.WriteLine("3)Quantity");
                                Console.Write("Secim edin: ");
                                var secimUpdate = Console.ReadLine();
                                switch (secimUpdate)
                                {
                                    case "1":
                                        Console.Write("Enter new name: ");
                                        var newName = Console.ReadLine();
                                        FindId.Name = newName;
                                        context.SaveChanges();
                                        Console.WriteLine("Name changed");
                                        Thread.Sleep(1500);
                                        Console.Clear();
                                        break;
                                    case "2":
                                        Console.Write("Enter new year: ");
                                        var newYear = Console.ReadLine();
                                        FindId.YearPress = Convert.ToInt32(newYear);
                                        context.SaveChanges();
                                        Console.WriteLine("Year changed");
                                        Thread.Sleep(1500);
                                        Console.Clear();
                                        break;
                                    case "3":
                                        Console.Write("Enter new quantity: ");
                                        var newQuantity = Console.ReadLine();
                                        FindId.YearPress = Convert.ToInt32(newQuantity);
                                        context.SaveChanges();
                                        Console.WriteLine("Quantity changed");
                                        Thread.Sleep(1500);
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.WriteLine("Wrong input!!!");
                                        Thread.Sleep(1500);
                                        Console.Clear();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("This Id couldn't find!");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Empty input!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }

                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Enter id for delete: ");
                        var idForDelete = Console.ReadLine();
                        var Finded = context.Books.FirstOrDefault(i => i.Id == Convert.ToInt32(idForDelete));
                        if (Finded != null)
                        {
                            context.Books.Remove(Finded);
                            context.SaveChanges();
                            Console.WriteLine("Book deleted");
                            Thread.Sleep(1500);
                            Console.Clear();

                        }
                        else
                        {
                            Console.WriteLine("This Id couldn't find!");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;
                    case "5":
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input!!!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
