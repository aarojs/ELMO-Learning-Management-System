namespace ELearning;

public class Assignment : Task
{
    private string _description;
    private int _minWords;
    private int _maxWords;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public int MinWords
    {
        get { return _minWords; }
        set { _minWords = value; }
    }
    public int MaxWords
    {
        get { return _maxWords; }
        set { _maxWords = value; }
    }

    public Assignment(string taskId, string taskName, DateTime dueDate, int totalMark, string description, int minWords, int maxWords) : base(taskId, taskName, dueDate, totalMark)
    {
        _description = description;
        _minWords = minWords;
        _maxWords = maxWords;
    }

    public override void DisplayTaskInfo()
    {
        Console.WriteLine($"Assignment: {TaskName}, Due: {DueDate.ToShortDateString()}, Min Words: {MinWords} Max Words: {MaxWords}");
    }
    
}