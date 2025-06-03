namespace ELearning;

public abstract class Task
{
    private string _taskId;
    private string _taskName;
    private DateTime _dueDate;
    private int _totalMark;

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
    public int TotalMark
    {
        get { return _totalMark; }
        set { _totalMark = value; }
    }

    public Task(string taskId, string taskName, DateTime dueDate, int totalMark)
    {
        _taskId = taskId;
        _taskName = taskName;
        _dueDate = dueDate;
        _totalMark = totalMark;
    }

    public abstract void DisplayTaskInfo();

    //For Task information display and debugging 
    public override string ToString()
    {
        return $"{TaskName} (ID: {TaskId}) - Due {DueDate.ToShortDateString()} - Worth {TotalMark} marks";
    }
}