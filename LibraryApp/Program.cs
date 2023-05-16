using System.Threading.Channels;
using LibraryApp.Data;
using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Repositories.Extensions;

var itemAdded = new ItemAdded(ReaderAdded);
var readerRepository = new SqlRepository<Reader>(new LibraryAppDbContext(), itemAdded);
var bookRepository = new SqlRepository<Book>(new LibraryAppDbContext());

static void ReaderAdded(object item)
{
    var reader = (Reader)item;
    Console.WriteLine($"{reader.FirstName} added");
}
static void GetReaderById(IRepository<IEntity> readersRepository)
{
    var reader = readersRepository.GetById(2);
    Console.WriteLine(reader.ToString());
}
var books = new[]
{
    new Book { Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer’s Stone" },
    new Book { Author = "Miguel de Cervantes", Title = "Don Quixote" },
    new Book { Author = "Charles Dickens", Title = "A Tale of Two Cities" },
    new Book { Author = "J.R.R. Tolkien", Title = "The Lord of the Rings" }
};
var readers = new[]
{
    new Reader { FirstName = "Rafal", LastName = "Kordowski" },
    new Reader { FirstName = "Weronika", LastName = "Plichtowicz"},
    new Reader { FirstName = "Kuba", LastName = "Wodzynski"},
    new Worker { FirstName = "Pawel", LastName = "Gawarecki"},
    new Worker { FirstName = "Mohamed", LastName = "Ali"}
};
readerRepository.AddBatch(readers);
bookRepository.AddBatch(books);
WriteAllToConsole(readerRepository);
Console.WriteLine();
WriteAllToConsole(bookRepository);
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    Console.WriteLine($"Items in class:");
    var items = repository.GetAll();
    foreach (var entity in items)
    {
        Console.WriteLine(entity.ToString());
    }
}
