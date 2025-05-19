namespace ELearning;
public abstract class User
{
    private string _userId;
    private string _firstName;
    private string _lastName;
    private string _email;

    public string UserId 
    {
        get {return _userId;}
        set {_userId = value;} //readonly?
    }

    public string FirstName
    {
        get {return _firstName;}
        set {_firstName = value;} //readonly?
    }

    public string LastName
    {
        get {return _lastName;}
        set {_lastName = value;}
    }

    public string Email 
    {
        get {return _email;}
        set {_email = value;}
    }

    public User(string id, string firstName, string lastName, string email)
    {
        _userId = id;
        _firstName = firstName;
        _lastName = lastName;
        _email = email;
    }

    public abstract void MainMenu();

}