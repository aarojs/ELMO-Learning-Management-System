namespace ELearning;

public class Exam : Task
{
    private int _examDurationMins;
    private bool _isOpenBook;
    private bool _isOnline;
    private string _examLocation;

    public int ExamDurationMins
    {
        get { return _examDurationMins; }
        set { _examDurationMins = value; }
    }
    public bool IsOpenBook
    {
        get { return _isOpenBook; }
        set { _isOpenBook = value; }
    }
    public bool IsOnline
    {
        get { return _isOnline; }
        set { _isOnline = value; }
    }
    public string ExamLocation
    {
        get { return _examLocation; }
        set { _examLocation = value; }
    }

    public Exam(string taskId, string taskName, DateTime dueDate, int totalMark, int examDuration, string examLocation) : base(taskId, taskName, dueDate, totalMark)
    {
        _examLocation = examLocation;
        _examDurationMins = examDuration;
    }

    public override void DisplayTaskInfo()
    {
        Console.WriteLine($"Exam: {TaskName}, Date: {DueDate} Duration: {ExamDurationMins} mins, Open Book: {IsOpenBook}");
    }

    
}