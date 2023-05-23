using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;


namespace LibraryApp.Repositories;

public class Terminal
{
    public static void Hello()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("      Welcome to LibraryApp");
        Console.WriteLine("=====================================");
    }
    public static void MainMenu()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1.Reader");
        Console.WriteLine("2.Book");
        Console.WriteLine("3.Borrow Book");
        Console.WriteLine("Press 'x' to close App");

    }

    public static void ReaderMenu()
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
    }

    public static void BookMenu()
    {
        Console.WriteLine("Choose an option for Book:");
        Console.WriteLine("1.Add Book");
        Console.WriteLine("2.Remove Book");
        Console.WriteLine("3.Show All Books");
        Console.WriteLine("Press 'x' to back to main menu");
    }


    public static void BorrowMenu()
    {
        Console.WriteLine("Choose an option for Borrow:");
        Console.WriteLine("1.Borrow Book");
        Console.WriteLine("2.Return Book");
        Console.WriteLine("3.Show All Borrows");
        Console.WriteLine("Press 'x' to back to main menu");
    }
}
