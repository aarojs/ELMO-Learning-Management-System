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

    //A lot of these you have access to through the methods. Best approach?
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

    public abstract void DisplayTaskInfo(); // have not even used this once. !!!

    //For Task information display and debugging. Use this?
    public override string ToString()
    {
        return $"{TaskName} (ID: {TaskId}) - Due {DueDate.ToShortDateString()} - Worth {TotalMark} marks";
    }

    public void GradeTask(double mark)
    {
        if (mark >= 0)
        {
            _achievedMark = mark;
        }
        Console.WriteLine("Mark cannot be negative");
    }

    public double GetGrade()
    {
        if (_achievedMark >= 0)
        {
            return _achievedMark;
        }
        Console.WriteLine("Task has not been graded.");
        return 0;
    }

    public bool IsGraded()
    {
        return _achievedMark >= 0;
    }
}