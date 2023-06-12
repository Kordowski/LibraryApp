using LibraryApp;
using Microsoft.Extensions.DependencyInjection;
using Serilog;




var startup = new Startup();

startup.CreateDir();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("SavedInFile//Audit.txt")
    .CreateLogger();

var serviceProvider = startup.BuildServiceProvider();

var terminal = serviceProvider.GetService<Terminal>();

terminal.Start();

Log.CloseAndFlush();







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


//void ReaderUI()
//{
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



