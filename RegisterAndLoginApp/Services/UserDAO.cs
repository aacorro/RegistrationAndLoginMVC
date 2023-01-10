using static System.Net.Mime.MediaTypeNames;
using System;
using RegisterAndLoginApp.Models;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;
//using AspNetCore;
using System.Linq.Expressions;

namespace RegisterAndLoginApp.Services
{
	public class UserDAO
	{
		string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

	

		public bool FindUserByNameAndPassword(UserModel user)
		{
			bool success = false;

			string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username and password = @password";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(sqlStatement, connection);

				command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 50).Value = user.UserName;
				command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();

					if (reader.HasRows)
						success= true;
					 
				}
				catch(Exception eX)
				{
					Console.WriteLine(eX.Message);
				}
			}
			return success;
		}
	}
}
