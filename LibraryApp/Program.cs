using LibraryApp.Data;
using LibraryApp.Repositories;
using LibraryApp.Entities;

var readerRepository = new SqlRepository<Reader>(new LibraryAppDbContext());
var bookRepository = new SqlRepository<Book>(new LibraryAppDbContext());

//sqlRepository.Add(new Reader { FirstName = "Rafal", LastName = "Kordowski"});
//sqlRepository.Add(new Reader { FirstName = "Weronika",LastName = "Plichtowicz"});
//sqlRepository.Add(new Reader { FirstName = "Kuba", LastName = "Wodzynski"});
//sqlRepository.Save();
//var emp = sqlRepository.GetById(1);
//Console.WriteLine(emp.ToString());
//GetReaderById(sqlRepository);

AddReader(readerRepository);
AddWorker(readerRepository);
AddBook(bookRepository);
WriteAllToConsole(readerRepository);
Console.WriteLine();
WriteAllToConsole(bookRepository);




static void GetReaderById(IRepository<IEntity> readersRepository)
{
    var reader = readersRepository.GetById(2);
    Console.WriteLine(reader.ToString());
}

static void AddReader(IRepository<Reader> readerRepository)
{
    readerRepository.Add(new Reader { FirstName = "Rafal", LastName = "Kordowski" });
    readerRepository.Add(new Reader { FirstName = "Weronika", LastName = "Plichtowicz" });
    readerRepository.Add(new Reader { FirstName = "Kuba", LastName = "Wodzynski" });
    readerRepository.Save();
}

static void AddWorker(IWriteRepository<Worker> managerRepository)
{
    managerRepository.Add(new Worker { FirstName = "Pawel", LastName = "Gawarecki" });
    managerRepository.Add(new Worker { FirstName = "Mohamed", LastName = "Ali" });
    managerRepository.Save();
}

static void AddBook(IWriteRepository<Book> bookRepository)
{

    bookRepository.Add(new Book { Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer’s Stone" });
    bookRepository.Add(new Book { Author = "Miguel de Cervantes", Title = "Don Quixote" });
    bookRepository.Add(new Book { Author = "Charles Dickens", Title = "A Tale of Two Cities" });
    bookRepository.Add(new Book { Author = "J.R.R. Tolkien", Title = "The Lord of the Rings" });
    bookRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    Console.WriteLine($"Items in");
    var items = repository.GetAll();
    foreach (var entity in items)
    {
        Console.WriteLine(entity.ToString());
    }
}
