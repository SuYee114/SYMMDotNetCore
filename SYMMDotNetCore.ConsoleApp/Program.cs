using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "LAPTOP-5TMQTJGN"; //Server Name
stringBuilder.InitialCatalog = "SYMMDotNetCore";// Database Name
stringBuilder.UserID = "sa";
stringBuilder.Password = "su$2003";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
// Server connection through stringBuilder obj indirectly (need to install Nuget Package to use SqlConnection
//The direct way :
//SqlConnection connection = new SqlConnection(DataSource = "LAPTOP-5TMQTJGN;InitialCatalog = "SYMMDotNetCore;UserID = "sa";Password = "su$2003");

connection.Open();
Console.WriteLine("The Connection is successfully opened");

string query = "select * from Blog_TBL";
SqlCommand cmd = new SqlCommand(query, connection);//connection include the data from stringbuilder object 
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);// to create query
DataTable dt = new DataTable();//Table
sqlDataAdapter.Fill(dt);// fill in the table

connection.Close();
Console.WriteLine("The Connection is successfully closed");

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("BlogID "+dr["Blog_Id"]);
    Console.WriteLine("BlogTile " + dr["Blog_Title"]);
    Console.WriteLine("BlogAuthor " + dr["Blog_Author"]);
    Console.WriteLine("BlogContent " + dr["Blog_Content"]);
    Console.WriteLine("--------------------------------- ");
}

Console.ReadKey();