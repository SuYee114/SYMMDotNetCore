using SYMMDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetEExample adoDotNetExample = new AdoDotNetEExample();
//adoDotNetExample.Read();
adoDotNetExample.Create("title", "author", "content");


Console.ReadKey();