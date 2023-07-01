using LibraryApp.Entities;
using LibraryApp.Repositories;
using LibraryApp.Repositories.Extensions;
using Newtonsoft.Json;
using Serilog;
using System.Linq;
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
        public void IfFilesExistSeedFromMemory()
        {
            string filePathReaders = "SavedInFile\\Readers.json";
            string filePathBooks = "SavedInFile\\Books.json";
            if (!File.Exists(filePathReaders) || !File.Exists(filePathBooks))
            {
                SeedData();
            }
        }

        public void Seed()
        {
            IfFilesExistSeedFromMemory();
            SeedReadersFromFiles();
            SeedBooksFromFiles();
            SeedEvents();
            Console.Clear();
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

            var books = new[]
            {
                new Book { Author = "J. K. Rowling", Title = "Harry Potter and the Philosopher's Stone" },
                new Book { Author = "Frank Herbert", Title = "Diuna" },
                new Book { Author = "Agatha Christie", Title = "And Then There Were None" },
                new Book { Author = "Cao Xueqin", Title = "Dream of the Red Chamber" },
                new Book { Author = "J. R. R. Tolkien", Title = "The Hobbit" },
                new Book { Author = "C. S. Lewis", Title = "The Lion, the Witch and the Wardrobe"},
                new Book { Author = "H. Rider Haggard", Title = "She: A History of Adventure"},
                new Book { Author = "J. K. Rowling", Title = "Harry Potter and the Chamber of Secrets"},
                new Book { Author = "J. K. Rowling", Title = "Harry Potter and the Chamber of Secrets"},
                new Book { Author = "J. K. Rowling", Title = "Harry Potter and the Prisoner of Azkaban"}
            };

            _bookRepository.AddBatch(books);
            _readerRepository.AddBatch(readers);

            _readerRepository.Save();
            _bookRepository.Save();
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

        private void SeedBooksFromFiles()
        {
            string filePath = "SavedInFile\\Books.json";

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                var data = JsonConvert.DeserializeObject<List<Book>>(jsonContent);
                foreach (var book in data)
                {
                    _bookRepository.Add(book);
                }
            }
            else
            {
                Console.WriteLine("File not exist.");
            }
            _bookRepository.Save();
        }
        private void SeedReadersFromFiles()
        {
            string filePath = "SavedInFile\\Readers.json";

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

                var data = JsonConvert.DeserializeObject<List<Reader>>(jsonContent);
                foreach (var reader in data)
                {
                    _readerRepository.Add(reader);
                }
            }
            else
            {
                Console.WriteLine("File not exist.");
            }
            _readerRepository.Save();
        } 
    }
}
