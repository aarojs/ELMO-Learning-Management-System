namespace ELearning;

public abstract class Task : IGradable
{
    private string _taskId;
    private string _taskName;
    private DateTime _dueDate;
    private double _totalMark;
    private double _achievedMark;
    private bool _graded;
    private Unit _parentUnit;

    public string TaskId
    {
        get { return _taskId; }
        set { _taskId = value; }
    }
    public string TaskName
    {
        get { return _taskName; }
        set { _taskName = value; }
    }
    public DateTime DueDate
    {
        get { return _dueDate; }
        set { _dueDate = value; }
    }
    public double TotalMark
    {
        get { return _totalMark; }
        set { _totalMark = value; }
    }
    public double AchievedMark
    {
        get { return _achievedMark; }
        set { _achievedMark = value; }
    }
    public bool Graded
    {
        get { return _graded; }
        set { _graded = value; }
    }
    public Unit ParentUnit
    {
        get { return _parentUnit; }
        set { _parentUnit = value; }
    }

    public Task(string taskId, string taskName, DateTime dueDate, double totalMark, Unit parentUnit)
    {
        _taskId = taskId;
        _taskName = taskName;
        _dueDate = dueDate;
        _totalMark = totalMark;
        _parentUnit = parentUnit;
    }

    public virtual void DisplayTaskInfo()
    {
        Console.WriteLine($"Task ID: {TaskId}");
        Console.WriteLine($"Task name: {TaskName}");
        Console.WriteLine($"Due: {DueDate.ToShortDateString()}");
    }


    public bool GradeTask(double mark)
    {
        if (mark >= 0 && mark <= _totalMark)
        {
            _achievedMark = mark;
            _graded = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public double GetGrade()
    {
        if (_graded)
        {
            return _achievedMark;
        }
        else
        {
            return 0;
        }
    }

    public bool IsGraded()
    {
        return _graded;
    }
}