using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace SYMMDotNetCore.ConsoleApp
{
    internal class AdoDotNetEExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()// can only read cannot change
        {
            DataSource = "LAPTOP-5TMQTJGN", //Server Name
            InitialCatalog = "SYMMDotNetCore",// Database Name
            UserID = "sa", //since they are properties must use , in the end
            Password = "su$2003",

        };
        

        public void Read()
        {
 
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
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
                Console.WriteLine("BlogID " + dr["Blog_Id"]);
                Console.WriteLine("BlogTile " + dr["Blog_Title"]);
                Console.WriteLine("BlogAuthor " + dr["Blog_Author"]);
                Console.WriteLine("BlogContent " + dr["Blog_Content"]);
                Console.WriteLine("--------------------------------- ");
            }
        }

        public void AfterUpdate(int id)// similar like read but only show for only one row
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            
            connection.Open();
            Console.WriteLine("The Connection is successfully opened");

            string query = "select * from Blog_TBL WHERE Blog_ID=@Blog_ID";
            SqlCommand cmd = new SqlCommand(query, connection);//connection include the data from stringbuilder object 
            cmd.Parameters.AddWithValue("@Blog_Id", id);// To accept parameter
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);// to create query
            DataTable dt = new DataTable();//Table
            sqlDataAdapter.Fill(dt);// fill in the table

            connection.Close();
            Console.WriteLine("The Connection is successfully closed");

            if (dt.Rows.Count == 0)//to handle unexisting id
            {
                Console.WriteLine("No data is found");
                return;
            }

            DataRow dr = dt.Rows[0];// since id is unique, data will be only in 0 index
            {
                Console.WriteLine("BlogID " + dr["Blog_Id"]);
                Console.WriteLine("BlogTile " + dr["Blog_Title"]);
                Console.WriteLine("BlogAuthor " + dr["Blog_Author"]);
                Console.WriteLine("BlogContent " + dr["Blog_Content"]);
                Console.WriteLine("--------------------------------- ");
            }

        }

        public void Create(string title,string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string insertquery = @"INSERT INTO [dbo].[Blog_TBL]
           ([Blog_Title]
           ,[Blog_Author]
           ,[Blog_Content])
     VALUES
           (@Blog_Title
           ,@Blog_Author
           ,@Blog_Content)";
            //To insert with parameter
            
            SqlCommand cmd = new SqlCommand(insertquery, connection);
            cmd.Parameters.AddWithValue("@Blog_Title", title);// Parameter , variable
            cmd.Parameters.AddWithValue("@Blog_Author", author);
            cmd.Parameters.AddWithValue("@Blog_Content", content);
            int result =cmd.ExecuteNonQuery();// To execute the insertquery code which will return the no of row effected in int type

            connection.Close();

            string message = result > 0 ? "Saving success" : "Saving failed";
            Console.WriteLine(message);
        }
        public void Update(int id,string title, string author, string content)
        //existance of id is important to make sure which row will be updated
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string insertquery = @"UPDATE [dbo].[Blog_TBL]
   SET [Blog_Title] = @Blog_Title
      ,[Blog_Author] = @Blog_Author
      ,[Blog_Content] = @Blog_Content
 WHERE Blog_ID= @Blog_Id";
            //To insert with parameter

            SqlCommand cmd = new SqlCommand(insertquery, connection);
            cmd.Parameters.AddWithValue("@Blog_Id", id);
            cmd.Parameters.AddWithValue("@Blog_Title", title);// Parameter , variable
            cmd.Parameters.AddWithValue("@Blog_Author", author);
            cmd.Parameters.AddWithValue("@Blog_Content", content);
            int result = cmd.ExecuteNonQuery();// To execute the insertquery code which will return the no of row effected in int type

            connection.Close();

            string message = result > 0 ? "The updating is successful" : "The updating is failed";
            Console.WriteLine(message);

        }
        public void Delete(int id) // can delete by choosing Id number
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string insertquery = @"DELETE FROM [dbo].[Blog_TBL]
      WHERE Blog_ID=@Blog_ID";
            //To insert with parameter

            SqlCommand cmd = new SqlCommand(insertquery, connection);
            cmd.Parameters.AddWithValue("@Blog_Id", id);
            int result = cmd.ExecuteNonQuery();// To execute the insertquery code which will return the no of row effected in int type

            connection.Close();

            string message = result > 0 ? "The deleting process is successful" : "The deleting process is failed";
            Console.WriteLine(message);

        }
    }
}
