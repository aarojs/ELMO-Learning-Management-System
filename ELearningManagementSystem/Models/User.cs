namespace ELearning;

public abstract class User
{
    private string _userId;
    private string _password;
    private string _firstName;
    private string _lastName;
    private string _email;
    private bool _isLoggedIn;

    public string UserId
    {
        get { return _userId; }
        set { _userId = value; } //readonly?
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; } //readonly?
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public bool IsLoggedIn
    {
        get { return _isLoggedIn; }
        set { _isLoggedIn = value; }
    }

    public User(string id, string password, string firstName, string lastName, string email)
    {
        _userId = id;
        _password = password;
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
    }

    public virtual void GetUserInfo()
    {
        Console.WriteLine($"ID: {UserId}");
        Console.WriteLine($"Name: {FirstName} {LastName}");
        Console.WriteLine($"Email: {Email}");
    }

    public virtual string GetName()
    {
        return $"{FirstName} {LastName}";
    }

    //Student and teacher will have their own custom Main menu implementations 
    public abstract void MainMenu();

    //Default method to change default user password set by admin
    public virtual void ChangePassword()
    {
        Console.Write("Enter current password: ");
        string currentPassword = Console.ReadLine();

        if (currentPassword != _password)
        {
            Console.WriteLine("Incorrect password. Please try again");
            return;
        }
        else
        {
            Console.WriteLine("Enter new password: ");
            string newPassword = Console.ReadLine();

            _password = newPassword;
            Console.WriteLine("Password updated successfully");
        }
    }

    public void Logout()
    {
        _isLoggedIn = false;
    }

}