using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryApp;

public class Terminal
{
    private readonly TerminalService _terminalService;

    public Terminal(TerminalService terminalService)
    {
        _terminalService = terminalService;
    }

    public void Start()
    {
        Hello();
        MainMenu();
    }

    private void Hello()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("      Welcome to LibraryApp");
        Console.WriteLine("=====================================");

        ClickAnyButton();
    }

    private void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1.Reader");
            Console.WriteLine("2.Book");
            Console.WriteLine("3.Borrow Book");
            Console.WriteLine("Press 'x' to close App");

            switch (ReadKey())
            {
                case "1":
                    ReaderMenu();
                    break;
                case "2":
                    BookMenu();
                    break;
                case "3":
                    BorrowMenu();
                    break;
                case "X":
                    ByeMessage();
                    return;
            };
        }
    }

    //Może warto by było to podzielić na mniejsze klasy, do zostanowienia. Ale na razie pokazuję bajer "region". Zauważ, że możesz to przyjemnie zwijać.
    #region ReaderMenu

    private void ReaderMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Reader:");
            Console.WriteLine("1.Add new Reader");
            Console.WriteLine("2.Remove Reader");
            Console.WriteLine("3.Find Reader by ID");
            Console.WriteLine("4.Show All Readers");
            Console.WriteLine("Press 'x' to back to main menu");

            switch (ReadKey())
            {
                case "1":
                    AddNewReader();
                    ClickAnyButton();
                    break;
                case "2":
                case "3":
                    GetReaderById();
                    ClickAnyButton();
                    break;
                case "4":
                    _terminalService.WriteAllReadersToConsole();
                    ClickAnyButton();
                    break;
                    
                case "X":
                    return;
            };
        }
    }

    private void AddNewReader()
    {
        Console.WriteLine("Add new Reader");
        Console.WriteLine("");

        Console.Write("First name: ");
        var firstName = Console.ReadLine();

        Console.Write("Last name: ");
        var lastName = Console.ReadLine();

        _terminalService.AddReader(firstName, lastName, out var message);
        Console.WriteLine(message);
    }

    // private void GetBookById()
    //{
    //    WriteAllToConsole(_terminalService);
    //    var isValid = false;
    //    int number;
    //    do
    //    {
    //        Console.WriteLine($"Input Book ID: ");
    //        string input = Console.ReadLine();
    //        isValid = int.TryParse(input, out number);
    //        if (!isValid)
    //        {
    //            Console.WriteLine("Wrong value. Try again.");
    //        }
    //    } while (!isValid);

    //    var book = bookRepository.GetById(number);
    //    Console.WriteLine(book?.ToString());
    //    Console.WriteLine($"Do you want to delete this book?");
    //    Console.WriteLine($"Press 'Y' for Delete reader, anything else for leave");
    //    var UserInput = Console.ReadLine().ToUpper();
    //    if (UserInput == "Y")
    //    {
    //     //   _terminalService.RemoveBook(book, out var message);
    //    }
    //}
    private void GetReaderById()
    {
        _terminalService.GetReaderById();
    }

    #endregion

    #region BookMenu

    private void BookMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Book:");
            Console.WriteLine("1.Add new Book");
            Console.WriteLine("2.Get Reader by Id");
            Console.WriteLine("3.Remove Book");
            Console.WriteLine("4.Show All Books");
            Console.WriteLine("Press 'x' to back to main menu");

            switch (ReadKey())
            {
                case "1":
                    AddNewBook();
                    ClickAnyButton();
                    break;
                case "2":
                case "3":
                    _terminalService.WriteAllBooksToConsole();
                    ClickAnyButton();
                    break;
                case "4":
                    _terminalService.WriteAllBooksToConsole();
                    ClickAnyButton();
                    break;
                case "X":
                    return;
            };
        }
    }

    private void AddNewBook()
    {
        Console.WriteLine("Add new Book");
        Console.WriteLine("");

        Console.Write("Title: ");
        var title = Console.ReadLine();

        Console.Write("Author: ");
        var author = Console.ReadLine();

        _terminalService.AddBook(title, author, out var message);
        Console.WriteLine(message);
    }
    #endregion

    #region BorrowMenu

    private void BorrowMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Borrow:");
            Console.WriteLine("1.Borrow Book");
            Console.WriteLine("2.Return Book");
            Console.WriteLine("3.Show All Borrows");
            Console.WriteLine("Press 'x' to back to main menu");

            switch (ReadKey())
            {
                case "1":
                    Console.WriteLine("Choose an option for Borrow");
                    break;
                case "X":
                    return;
            };
        }
    }

    #endregion

    #region Common


    private void ClickAnyButton()
    {
        Console.WriteLine();
        Console.WriteLine("Kliknij dowolny przycisk, aby przejść dalej...");
        Console.ReadKey();
        Console.Clear();
    }

    private string ReadKey()
    {
        var input = Console.ReadKey().KeyChar.ToString().ToUpper();

        Console.Clear();

        return input;
    }

    private void ByeMessage()
    {
        Console.WriteLine($"Bye Bye!");
    }

    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        Console.WriteLine($"Items from SQL:");
        var items = repository.GetAll();
        foreach (var entity in items)
        {
            Console.WriteLine(entity.ToString());
        }
    }
    #endregion

}
