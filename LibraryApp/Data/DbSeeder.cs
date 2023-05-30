using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Repositories.Extensions;
using Serilog;
using Serilog.Events;

namespace LibraryApp.Data
{
    public class DbSeeder
    {

        private readonly SqlRepository<Reader> _readerRepository;
        private readonly SqlRepository<Book> _bookRepository;

        public DbSeeder(SqlRepository<Reader> readerRepository, SqlRepository<Book> bookRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
        }

        public void Seed()
        {
            SeedData();
            SeedEvents();
        }

        private void SeedData()
        {
            var readers = new[]
            {
                new Reader { FirstName = "Rafal", LastName = "Kordowski" },
                new Reader { FirstName = "Weronika", LastName = "Plichtowicz" },
                new Reader { FirstName = "Kuba", LastName = "Wodzynski" },
                new Worker { FirstName = "Pawel", LastName = "Gawarecki" },
                new Worker { FirstName = "Mohamed", LastName = "Ali" }
            };

            _readerRepository.AddBatch(readers);

            _readerRepository.Save();
        }

        private void SeedEvents()
        {
            _readerRepository.ItemAdded += ReaderRepositoryOnItemAdded;
            _bookRepository.ItemAdded += BookRepositoryOnItemAdded;
            _bookRepository.ItemRemoved += BookRepositoryOnItemRemoved;
            _readerRepository.ItemRemoved += ReaderRepositoryOnItemRemoved;
        }

        private void BookRepositoryOnItemAdded(object? sender, Book e)
        {
            Console.WriteLine($"Book added => {e.Title}");
            Log.Information($"Book {e.Title} {e.Author} Added!");
        }

        private void ReaderRepositoryOnItemAdded(object? sender, Reader e)
        {
            Console.WriteLine($"Reader added => {e.FirstName}");
            Log.Information($"Reader {e.FirstName} {e.LastName} Added!");
        }
                

        private void BookRepositoryOnItemRemoved(object? sender, Book e)
        {
            Console.WriteLine($"Book removed => {e.Title}");
            Log.Information($"Book {e.Title} {e.Author} Removed!");
        }

        private void ReaderRepositoryOnItemRemoved(object? sender, Reader e)
        {
            Console.WriteLine($"Reader removed => {e.FirstName}");
            Log.Information($"Book {e.FirstName} {e.LastName} Removed!");
        }
    }
}
