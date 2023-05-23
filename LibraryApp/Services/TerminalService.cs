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

            message = "Reader added.";
        }
    }
}
