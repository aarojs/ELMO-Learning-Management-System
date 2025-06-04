namespace ELearning;

public class LoginManager
{
    private UserManager _userManager;

    public LoginManager(UserManager userManager)
    {
        _userManager = userManager;
    }

    //Log in and return User 
    public User Login()
    {
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
    }




}