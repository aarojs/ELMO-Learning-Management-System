namespace ELearning;

public class LoginManager
{
    private List<User> _users;

    public LoginManager()
    {
        _users = new List<User>();
    }

    //Log in and return User 
    public User Login()
    {
        Console.WriteLine("User ID: ");
        string userID = Console.ReadLine();

        Console.WriteLine("Password: ");
        string password = Console.ReadLine();

        //Admin login 
        if (userID == "admin" && password == "admin")
        {
            return Admin.Instance;
        }

        //Regular user Login 
        foreach (User user in _users)
        {
            if (user.UserId == userID && user.Password == password)
            {
                return user;
            }
        }

        //If user or Admin is not returned, print error message
        Console.WriteLine("Login failed. Invalid login credentials");
        return null;
    }




}