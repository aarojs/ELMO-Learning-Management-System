namespace ELearning;

public class Teacher : User
{
    private TeacherRole _role;
    private List<Unit> _teachingUnits;

    //Teacher has access to instance of Managers
    private TaskManager _taskManager;
    private UnitManager _unitManager;
    private UserManager _userManager;


    public TeacherRole Role
    {
        get { return _role; }
        set { _role = value; }
    }

    public List<Unit> TeachingUnits
    {
        get { return _teachingUnits; }
    }
    public TaskManager TaskManager
    {
        get { return _taskManager; }
    }
    public UnitManager UnitManager
    {
        get { return _unitManager; }
    }
    public UserManager UserManager
    {
        get { return _userManager; }
    }

    public Teacher(string id, string password, string firstName, string lastName, string email) : base(id, password, firstName, lastName, email)
    {
        _teachingUnits = new List<Unit>();
    }

    //Teacher Menu logic moved to Menu handler class. 
    //Encapsulates menu functionality
    public override void MainMenu()
    {
        TeacherMenu menu = new TeacherMenu(this);
        menu.ShowMenu();
    }

    public override void GetUserInfo()
    {
        base.GetUserInfo();
        Console.WriteLine($"Role: {Role}\n");
    }

    //Assign passed in manager instance
    public void SetManagers(TaskManager taskManager, UnitManager unitManager, UserManager userManager)
    {
        _taskManager = taskManager;
        _unitManager = unitManager;
        _userManager = userManager;
    }

    public void AddUnit(Unit unit)
    {
        if (!_teachingUnits.Contains(unit))
        {
            _teachingUnits.Add(unit);
        }
    }

    public void RemoveUnit(Unit unit)
    {
        if (_teachingUnits.Contains(unit))
        {
            _teachingUnits.Remove(unit);
        }
    }

    
    
}