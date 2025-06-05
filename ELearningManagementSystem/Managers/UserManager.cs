namespace ELearning;

//Controls and manages logic for users
public class UserManager
{
    private List<User> _users = new List<User>();

    //Create a new user
    public void CreateUser()
    {
        Console.WriteLine("Choose user type: 1. Student, 2. Teacher");
        string choice = Console.ReadLine();
        Role role;

        switch (choice)
        {
            case "1":
                role = Role.Student;
                break;
            case "2":
                role = Role.Teacher;
                break;
            default:
                Console.WriteLine("Invalid user choice");
                return;
        }

        Console.WriteLine("First Name: ");
        string firstName = Console.ReadLine();

        Console.WriteLine("Last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Default password: ");
        string password = Console.ReadLine();

        //Generate UserID using method 
        string userId = GenerateUserId(role, firstName, lastName);

        //Generate Email Using firstname and lastname 
        string email = GenerateUserEmail(userId);

        User newUser;

        switch (role)
        {
            case Role.Student:
                newUser = new Student(userId, password, firstName, lastName, email);
                break;
            case Role.Teacher:
                newUser = new Teacher(userId, password, firstName, lastName, email);
                break;
            default:
                Console.WriteLine("Are you an Admin?");
                return;
        }

        AddUser(newUser);
        Console.WriteLine($"User created successfully. ID: {newUser.UserId}");
    }

    //Add user to user manager's list of users
    public void AddUser(User user)
    {
        if (user == null)
        {
            Console.WriteLine("User does not exist");
            return;
        }

        bool userExists = false;
        foreach (User u in _users)
        {
            if (u.UserId == user.UserId)
            {
                userExists = true;
                break;
            }
        }

        if (userExists)
        {
            Console.WriteLine($"A user with the ID {user.UserId} already exists. Cannot create user");
            return;
        }
        _users.Add(user);
    }


    //Uses user Role, First Name and Last Name to generate a unique id
    public string GenerateUserId(Role role, string firstName, string lastName)
    {
        string initials = $"{firstName[0]}{lastName[0]}".ToUpper();

        //Generate unique ID with 4digits
        Random random = new Random();
        String digits = random.Next(0, 9999).ToString("D4");

        //User id is first 3 letters of their role, their initials and the 4 digit number
        return $"{role.ToString().Substring(0, 3).ToUpper()}_{initials}{digits}";
    }

    //Unique User ID to create email address
    public string GenerateUserEmail(string userId)
    {
        return $"{userId}@learning.com";
    }


    //Print all users
    public void ViewAllUsers()
    {
        foreach (User u in _users)
        {
            u.GetUserInfo();
        }
    }

    //Find a user given a valid user ID
    public User FindUser(string id)
    {
        foreach (User u in _users)
        {
            if (u.UserId.Equals(id, StringComparison.OrdinalIgnoreCase))
            {
                return u;
            }
        }
        return null;
    }
}