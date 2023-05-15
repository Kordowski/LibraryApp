using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entities;

namespace LibraryApp.Repositories
{
    internal class ReadersRepository
    {
        private readonly List<Readers> _readers = new();

        public void Add(Readers readers)
        {
            readers.Id = _readers.Count + 1;
            _readers.Add(readers);
        }

        public void Save()
        {
            foreach (var reader in _readers)
            {
                Console.WriteLine(reader);
            }
        }

        public Readers GetById(int id)
        {
            return _readers.Single(item => item.Id == id);
        }
    }
}
