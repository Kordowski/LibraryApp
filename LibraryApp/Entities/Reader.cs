using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Repositories;

namespace LibraryApp.Entities;

public class Reader : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public override string ToString() => $"Id: {Id}, First name: {FirstName}, Last name: {LastName}";

    public void AddReader()
    {
        Console.WriteLine($"Input first name for Reader:");
        this.FirstName = Console.ReadLine();
        Console.WriteLine($"Input last name for Reader:");
        this.LastName = Console.ReadLine();
        new Reader { FirstName = this.FirstName, LastName = this.LastName };
    }
}

