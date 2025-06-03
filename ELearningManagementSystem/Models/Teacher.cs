namespace ELearning;

public class Teacher : User
{

    public enum TeacherRole
    {
        UnitConvenor,
        Lecturer,
        Tutor
    }

    private TeacherRole _role;
    private List<Unit> _teachingUnits;

    //Teacher has access to instance of TaskManager 
    private TaskManager _taskManager;


    public TeacherRole Role
    {
        get { return _role; }
        set { _role = value; }
    }

    public List<Unit> TeachingUnits
    {
        get { return _teachingUnits; } //fix
    }

    public Teacher(string id, string password, string firstName, string lastName, string email) : base(id, password, firstName, lastName, email)
    {
        _teachingUnits = new List<Unit>();
    }

    public override void MainMenu()
    {


        bool finished = false;

        //Main Menu loop
        while (!finished)
        {
            Console.WriteLine("Teacher Menu:");
            Console.WriteLine("1. Create Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Change Password");
            Console.WriteLine("4. Logout");
            String input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _taskManager.CreateTask();
                    break;
                case "2":
                    _taskManager.ViewTasks();
                    break;
                case "3":
                    ChangePassword();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }


    }
    public void SetTaskManager(TaskManager taskManager)
    {
        _taskManager = taskManager;
    }


    
    
}