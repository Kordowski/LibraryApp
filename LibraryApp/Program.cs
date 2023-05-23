using LibraryApp;
using Microsoft.Extensions.DependencyInjection;

var startup = new Startup();

var serviceProvider = startup.BuildServiceProvider();

var terminal = serviceProvider.GetService<Terminal>();

terminal.Start();


//var closeApp = false;
//while (!closeApp)
//{
//    Terminal.MainMenu();
//    var userInput = Console.ReadLine();
//    switch (userInput)
//    {
//        case "1":
//            {
//                ReaderUI();
//                break;
//            }
//        case "2":
//            {

//                break;
//            }
//        case "3":
//            {
//                break;
//            }
//        case "x":
//        case "X":
//            {
//                CloseApp = true;
//                break;
//            }
//    }
//}


//List<AuditEntry> auditEntries = new List<AuditEntry>();

////void AuditMessage(AuditEntry auditEntry)


//auditEntries.Add(new AuditEntry { Action = "Logowanie", UserFullName = "JohnDoe", Timestamp = DateTime.Now });
//auditEntries.Add(new AuditEntry { Action = "Wylogowanie", UserFullName = "JaneSmith", Timestamp = DateTime.Now });

//AuditLog auditLog = new AuditLog
//{
//    Entries = auditEntries
//};

//string json = JsonConvert.SerializeObject(auditLog, (Newtonsoft.Json.Formatting)Formatting.Indented);
//File.WriteAllText("Audit.json", json);



////var books = new[]
////{
////    new Book { Author = "J.K. Rowling", Title = "Harry Potter and the Sorcerer’s Stone" },
////    new Book { Author = "Miguel de Cervantes", Title = "Don Quixote" },
////    new Book { Author = "Charles Dickens", Title = "A Tale of Two Cities" },
////    new Book { Author = "J.R.R. Tolkien", Title = "The Lord of the Rings" }
////};

////bookRepository.AddBatch(books);

//Console.WriteLine();
//WriteAllToConsole(bookRepository);
//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    Console.WriteLine($"Items from SQL:");
//    var items = repository.GetAll();
//    foreach (var entity in items)
//    {
//        Console.WriteLine(entity.ToString());
//    }
//}

//void ReaderUI()
//{
//    string userInput;
//    Terminal.ReaderMenu();
//    userInput = Console.ReadLine();
//    switch (userInput)
//    {
//        case "1":
//        case "6":
//            {
//                do
//                {
//                    Console.WriteLine($"If you want to quit adding press 'X'");
//                    string firstName;
//                    string lastName;
//                    Console.WriteLine($"Input first name for Reader:");
//                    firstName = Console.ReadLine();
//                    if (firstName == "x" || firstName == "X")
//                    {
//                        Console.Clear();
//                        break;
//                    }
//                    Console.WriteLine($"Input last name for Reader:");
//                    lastName = Console.ReadLine();
//                    readerRepository.Add(new Reader { FirstName = firstName, LastName = lastName });
//                } while (userInput != "1");
//                readerRepository.Save();
//                break;
//            }
//        case "2":
//            {
//                WriteAllToConsole(readerRepository);
//                GetReaderById(readerRepository);
//                readerRepository.Save();
//                break;
//            }
//        case "3":
//            {
//                break;
//            }
//        case "4":
//            {
//                WriteAllToConsole(readerRepository);
//                GetReaderById(readerRepository);
//                readerRepository.Save();
//                break;
//            }
//        case "5":
//            {
//                break;
//            }
//        case "7":
//            WriteAllToConsole(readerRepository);
//            break;
//    }
//}
//void GetReaderById(IRepository<Reader> readersRepository)
//{
//    Console.WriteLine($"Input Reader ID: ");
//    var input = int.Parse(Console.ReadLine());
//    var reader = readersRepository.GetById(input);
//    Console.WriteLine(reader?.ToString());
//    Console.WriteLine($"Do you want to delete this reader?");
//    Console.WriteLine($"Press 'Y' for Delete reader, anything else for leave");
//    var UserInput = Console.ReadLine();
//    if (UserInput == "Y" || UserInput == "y")
//    {
//        readerRepository.Remove(reader);
//    }
//}


