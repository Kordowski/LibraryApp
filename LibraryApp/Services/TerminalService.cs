using System.Text.Json.Nodes;
using LibraryApp.Entities;
using LibraryApp.Repositories;
using Newtonsoft.Json;
using Serilog;

namespace LibraryApp.Services
{
    public class TerminalService
    {
        private readonly SqlRepository<Reader> _readerRepository;
        private readonly SqlRepository<Book> _bookRepository;

        public TerminalService(SqlRepository<Reader> readerRepository, SqlRepository<Book> bookRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
        }

        public void AddReader(string firstName, string lastName, out string message)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                message = "Wrong first name.";
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                message = "Wrong last name.";
                return;
            }

            var reader = new Reader
            {
                FirstName = firstName,
                LastName = lastName
            };

            _readerRepository.Add(reader);

            _readerRepository.Save();
            message = "";
        }



        public void AddBook(string title, string author, out string message)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                message = "Wrong first name.";
                return;
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                message = "Wrong last name.";
                return;
            }

            var book = new Book()
            {
                Title = title,
                Author = author
            };

            _bookRepository.Add(book);

            _bookRepository.Save();
            message = "";
        }

        public void GetReaderById()
        {
            WriteAllToConsole(_readerRepository);
            Console.WriteLine($"Input Reader ID: ");
            var input = int.Parse(Console.ReadLine());
            var reader = _readerRepository.GetById(input);
            Console.WriteLine(reader?.ToString());
            Console.WriteLine($"Do you want to delete this reader?");
            Console.WriteLine($"Press 'Y' for Delete reader, anything else for leave");
            var UserInput = Console.ReadLine().ToUpper();
            if (UserInput == "Y")
            {
                _readerRepository.Remove(reader);
                _readerRepository.Save();
            }
        }
        public void GetBookById()
        {
            WriteAllToConsole(_bookRepository);
            Console.WriteLine($"Input Book ID: ");
            var input = int.Parse(Console.ReadLine());
            var book = _bookRepository.GetById(input);
            Console.WriteLine(book?.ToString());
            Console.WriteLine($"Do you want to delete this book?");
            Console.WriteLine($"Press 'Y' for Delete reader, anything else for leave");
            var UserInput = Console.ReadLine().ToUpper();
            if (UserInput == "Y")
            {
                _bookRepository.Remove(book);
                _bookRepository.Save();
            }
        }
        public void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            Console.WriteLine($"Items from SQL:");
            var items = repository.GetAll();
            foreach (var entity in items)
            {
                Console.WriteLine(entity.ToString());
            }
        }
        public void WriteAllReadersToConsole()
        {
            var items = _readerRepository.GetAll();
            Console.WriteLine($"Items from SQL:");
            foreach (var entity in items)
            {
                Console.WriteLine(entity.ToString());
            }
        }
        public void WriteAllBooksToConsole()
        {
            var items = _bookRepository.GetAll();
            Console.WriteLine($"Items from SQL:");
            foreach (var entity in items)
            {
                Console.WriteLine(entity.ToString());
            }
        }
        

        public void SaveAllReadersToFile()
        {
            string json = JsonConvert.SerializeObject(_readerRepository.GetAll());
            string filePath = "SavedInFile\\Readers.json";
            File.WriteAllText(filePath, json);
            Log.Information("Readers saved in file.");
        }
        public void SaveAllBooksToFile()
        {
            string json = JsonConvert.SerializeObject(_bookRepository.GetAll());
            string filePath = "SavedInFile\\Books.json";
            File.WriteAllText(filePath, json);
            Log.Information("Books saved in file.");
        }
    }
}
