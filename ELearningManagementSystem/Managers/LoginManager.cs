namespace ELearning;

//Controls and manages logic for the user
public class LoginManager
{
    //LoginManager uses UserManager instance to find and validate users
    private UserManager _userManager;

    public LoginManager(UserManager userManager)
    {
        _userManager = userManager;
    }

    //Log in and return User 
    public User Login()
    {
        bool finished = false;
        while (!finished)
        {
            Console.WriteLine("Welcome to ELMO. An E-Learning Management Operator");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Close system");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter your login details.");
                    Console.WriteLine("User ID: ");
                    string userId = Console.ReadLine();

                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();

                    //Admin login 
                    if (userId == "admin" && password == "admin")
                    {
                        return Admin.Instance;
                    }

                    //Regular user Login 
                    User user = _userManager.FindUser(userId);
                    if (user != null && user.Password == password)
                    {
                        return user;
                    }

                    //If user or Admin is not returned, print error message
                    Console.WriteLine("Login failed. Invalid login credentials");
                    return null;
                case "2":
                    finished = true;
                    break;
            }
        }
        return null;
    }




}