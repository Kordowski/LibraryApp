using LibraryApp.Entities;
using LibraryApp.Repositories;

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

        //public void RemoveBook(IRepository<Book> bookRepository, out string message)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        message = "Wrong first name.";
        //        return;
        //    }

        //    if (int.TryParse(id, out int number))
        //    {
        //        message = "Wrong last name.";
        //        return;
        //    }

        //    var list = _bookRepository.GetAll();
        //    foreach (var item in list)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    message = "";
        //}
       

        public void GetReaderById()
        {
            var items = _readerRepository.GetAll();
            items.Count();

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
    }
}
