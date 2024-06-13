using SYMMDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetEExample adoDotNetExample = new AdoDotNetEExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(5, "Java & C#", "Pu Pu", "Basic to Advanced");//in update Id increment number can be change
//adoDotNetExample.Delete(1);
adoDotNetExample.AfterUpdate(1);
adoDotNetExample.AfterUpdate(5);

Console.ReadKey();