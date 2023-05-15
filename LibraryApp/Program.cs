using LibraryApp.Repositories;
using LibraryApp.Entities;

var readersRepository = new GenericRepository<Readers>();

readersRepository.Add(new Readers {FirstName = "Rafal" });
readersRepository.Add(new Readers {FirstName = "Weronika"});
readersRepository.Add(new Readers { FirstName = "Kuba" });
readersRepository.Save();
