using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Services
{
	public class SecurityService
	{
		UserDAO usersDAO = new UserDAO();

		public bool IsValid(UserModel user)
		{
			return usersDAO.FindUserByNameAndPassword(user);
		
		}
	}
}
