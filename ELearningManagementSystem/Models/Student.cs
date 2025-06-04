namespace ELearning;

public class Student : User
{
    private Degree _degree;
    private List<Unit> _enrolledUnits;
    private List<Task> _pendingTasks;
    private List<Task> _submittedTasks;
    private TaskManager _taskManager;
    private UnitManager _unitManager;
    public Degree Degree { get { return _degree; } set { _degree = value; } }
    public List<Unit> EnrolledUnits
    {
        get { return _enrolledUnits; }
    }
    public List<Task> PendingTasks
    {
        get { return _pendingTasks; }
    }
    public List<Task> SubmittedTasks
    {
        get { return _submittedTasks; }
    }
    public TaskManager TaskManager
    {
        get { return _taskManager; }
    }
    public UnitManager UnitManager
    {
        get { return _unitManager; }
    }

    //Will prompt for degree later, should a student need a degree to be created?
    public Student(string id, string password, string firstName, string lastName, string email) : base(id, password, firstName, lastName, email)
    {
        _enrolledUnits = new List<Unit>();
        _pendingTasks = new List<Task>();
        _submittedTasks = new List<Task>();
    }

    public void SetManagers(TaskManager taskManager, UnitManager unitManager)
    {
        _taskManager = taskManager;
        _unitManager = unitManager;
    }
    public override void MainMenu()
    {
        StudentMenu menu = new StudentMenu(this);
        menu.ShowMenu();
    }

    public void SubmitTask(Task task)
    {
        if (_pendingTasks.Contains(task) && task is ISubmittable submittableTask)
        {
            if (!submittableTask.IsSubmitted())
            {
                submittableTask.Submit();
                _pendingTasks.Remove(task);
                _submittedTasks.Add(task);
                Console.WriteLine($"Task {task.TaskName} successfully submitted");
            }
            else
            {
                Console.WriteLine($"Task {task.TaskName} is already submitted");
            }
        }
        else
        {
            Console.WriteLine("Task cannot be submitted.");
        }
    }

    public void ViewSubmittedTasks()
    {
        foreach (Task task in _submittedTasks)
        {
            Console.WriteLine($"{task.ParentUnit.UnitTitle} - {task.TaskName}");
            Console.WriteLine($"Due date: {task.DueDate}");
            Console.WriteLine($"Total marks: {task.TotalMark}");
        }
    }

    public void ViewPendingTasks()
    {
        foreach (Task task in _pendingTasks)
        {
            Console.WriteLine($"{task.ParentUnit.UnitTitle} - {task.TaskName}");
            Console.WriteLine($"Due date: {task.DueDate}");
            Console.WriteLine($"Total marks: {task.TotalMark}");
        }
    }

    public void AddUnit(Unit unit)
    {
        if (!_enrolledUnits.Contains(unit))
        {
            _enrolledUnits.Add(unit);
        }
    }

    public void AddPendingTask(Task task)
    {
        if (!_pendingTasks.Contains(task))
        {
            _pendingTasks.Add(task);
        }
    }

    public void AddSubmittedTask(Task task)
    {
        if (!_submittedTasks.Contains(task))
        {
            _submittedTasks.Add(task);
        }
    }

    public void RemoveUnit(Unit unit)
    {
        if (_enrolledUnits.Contains(unit))
        {
            _enrolledUnits.Remove(unit);
        }
    }

    public void RemovePendingTask(Task task)
    {
        if (_pendingTasks.Contains(task))
        {
            _pendingTasks.Remove(task);
        }
    }

    public void RemoveSubmittedTask(Task task)
    {
        if (_submittedTasks.Contains(task))
        {
            _submittedTasks.Remove(task);
        }
    }


    

}