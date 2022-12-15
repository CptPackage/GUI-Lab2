using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{

	public class User
	{
        public String Username { get; set; }
        public String Password { get; set; }
	}

	public class UsersRepository: JsonRepository<User> {
        private static readonly String USERS_FILE_PATH = "users.json";
        private static UsersRepository? instance;

        protected UsersRepository()
        {
            base.default_path = USERS_FILE_PATH;
        }

        protected UsersRepository(String newFilePath) : base(newFilePath) {}

        public override bool exists(User target)
        {
            User? found = base.find(findUserByUsername(target.Username));
            return found == null;
        }

        public static UsersRepository getInstance()
        {
            if (instance == null) {
                instance = new UsersRepository();
            }
            return instance;
        }

        private Predicate<User> findUserByUsername(String username)
        {
            return delegate (User user)
            {
                if (user.Username == username)
                {
                    return true;
                }
                return false;
            };
        }
    }
}
