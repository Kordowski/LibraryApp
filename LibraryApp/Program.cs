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
var terminal = serviceProvider.GetService<Terminal>()!;
terminal.Start();
Log.CloseAndFlush();
