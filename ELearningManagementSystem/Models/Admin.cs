namespace ELearning;

public sealed class Admin : User
{
    //Access to manager instances 
    private UserManager _userManager;
    private DegreeManager _degreeManager;
    private UnitManager _unitManager;
    private TaskManager _taskManager;

    //Creating a single instance for the Singleton pattern
    private static Admin _instance = null;

    //Private admin constructor to prevent outside initialisation
    private Admin(string userId, string password, string firstName, string lastName, string email) : base(userId, password, firstName, lastName, email)
    {

    }


    //Creates Admin instance on access of Instance Property.
    public static Admin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Admin("admin", "admin", "System", "Admin", "admin@learning.com");
            }
            return _instance;
        }
    }

    //Properties to send through to Menu class - maintaining the same instance of managers
    public UserManager UserManager
    {
        get { return _userManager; }
    }
    public DegreeManager DegreeManager
    {
        get { return _degreeManager; }
    }
    public UnitManager UnitManager
    {
        get { return _unitManager; }
    }
    public TaskManager TaskManager
    {
        get { return _taskManager; }
    }

    //MainMenu grew too big to keep in the Admin Class
    //Moved all menus out into their own Menu classes
    //Encapsulates Menu functionality. 
    public override void MainMenu()
    {
        //Passing singeton reference to Menu class
        AdminMenu menu = new AdminMenu(Admin.Instance);
        menu.ShowMenu();
    }

   
    //Assigns passed in manager instances 
    public void SetManagers(UserManager userManager, DegreeManager degreeManager, UnitManager unitManager, TaskManager taskManager)
    {
        _userManager = userManager;
        _degreeManager = degreeManager;
        _unitManager = unitManager;
        _taskManager = taskManager;
    }



}