using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Services;

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
            Console.WriteLine("3.Return Book");
            Console.WriteLine("4.Find Reader by ID");
            Console.WriteLine("5.Check Reader Borrows");
            Console.WriteLine("6.Serial Addition Readers");
            Console.WriteLine("7.Show All Readers");
            Console.WriteLine("Press 'x' to back to main menu");

            switch (ReadKey())
            {
                case "1":
                    AddNewReader();
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

    #endregion

    #region BookMenu

    private void BookMenu()
    {
        while (true)
        {
            Console.WriteLine("Choose an option for Book:");
            Console.WriteLine("1.Add new Book");
            Console.WriteLine("2.Remove Book");
            Console.WriteLine("3.Show All Books");
            Console.WriteLine("Press 'x' to back to main menu");

            switch (ReadKey())
            {
                case "1":
                    Console.WriteLine("Add new Book");
                    break;
                case "X":
                    return;
            };
        }
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

    #endregion
}
