namespace ELearning;

public class Exam : Task
{
    private int _examDurationMins;
    private bool _isOpenBook;
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
    public string ExamLocation
    {
        get { return _examLocation; }
        set { _examLocation = value; }
    }

    public Exam(string taskId, string taskName, DateTime dueDate, double totalMark, Unit unit, int examDuration, string examLocation, bool isOpenBook) : base(taskId, taskName, dueDate, totalMark, unit)
    {
        _examLocation = examLocation;
        _examDurationMins = examDuration;
        _isOpenBook = isOpenBook;
        
    }

    public override void DisplayTaskInfo()
    {
        base.DisplayTaskInfo();
        Console.WriteLine($"Duration (mins): {ExamDurationMins}");
        Console.WriteLine($"Location: {ExamLocation}");
        Console.WriteLine($"Open book: {IsOpenBook}\n");
    }





}